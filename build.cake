#addin nuget:?package=Cake.DocFx&version=0.13.1
#tool nuget:?package=docfx.console&version=2.47.0
#addin nuget:?package=Cake.DoInDirectory&version=3.3.0
#addin nuget:?package=Cake.Json&version=4.0.0
#addin nuget:?package=Newtonsoft.Json&version=11.0.2
#addin nuget:?package=Cake.FileHelpers&version=3.2.1

var target = Argument("target", "Build");
var urlPrefix = Argument("url_prefix", "/");
var currentBranch = Argument("branch_name", RunGit("rev-parse --abbrev-ref HEAD"));

Information($"Current branch: {currentBranch}");

string RunGit(string command, string separator = "") 
{
    using(var process = StartAndReturnProcess("git", new ProcessSettings { Arguments = command, RedirectStandardOutput = true })) 
    {
        process.WaitForExit();
        return string.Join(separator, process.GetStandardOutput());
    }
}

void CleanDir(DirectoryPath path) 
{
    if(DirectoryExists(path))
        DeleteDirectory(path, new DeleteDirectorySettings { Force = true, Recursive = true });
}

Task("Cleanup")
    .Does(() => 
{
    CleanDir("_site");
});

Task("CleanDeps")
    .Does(() =>
{
    CleanDir("src");
    CleanDir("common");
});

Task("PullDeps")
    .Does(() =>
{
    if(!DirectoryExists("src"))
    {
        Information("Pulling BepInEx");
        CreateDirectory("src");
        RunGit("clone https://github.com/BepInEx/BepInEx.git src");

        DoInDirectory("src", () => 
        {
            if(currentBranch != "master")
                RunGit($"checkout {currentBranch}");
            RunGit("submodule update --init --recursive");
            NuGetRestore("BepInEx.sln");
        });
    }

    if(!DirectoryExists("common"))
    {
        Information("Pulling common files");
        CleanDir("common");
        RunGit("clone https://github.com/BepInEx/bepinex_docs.git common");
        DoInDirectory("common", () => 
        {
            RunGit("checkout common");
        });
    }
});

Task("PullGHPages")
    .Does(() =>
{
    Information("Pulling latest pages");
    CleanDir("gh-pages");
    CreateDirectory("gh-pages");
    RunGit("clone https://github.com/BepInEx/bepinex_docs.git gh-pages");
    DoInDirectory("gh-pages", () => 
    {
        RunGit("checkout gh-pages");
    });
});

Task("GenDocs")
    .Does(() => 
{
    Information("Generating metadata");
    DocFxMetadata("./docfx.json");

    Information("Generating docs");
    DocFxBuild("./docfx.json", new DocFxBuildSettings {
        GlobalMetadata = {
            ["_urlPrefix"] = urlPrefix
        }
    });
});

Task("PublishGHPages")
    .IsDependentOn("Cleanup")
    .IsDependentOn("CleanDeps")
    .IsDependentOn("PullDeps")
    .IsDependentOn("PullGHPages")
    .IsDependentOn("GenDocs")
    .Does(() => 
{
    var ghPages = Directory("gh-pages");
    var buildDir = ghPages + Directory(currentBranch);

    Information($"Copying docs to {buildDir}");
    CleanDir(buildDir);
    CreateDirectory(buildDir);
    CopyDirectory("_site", buildDir);

    var allTags = GetDirectories("gh-pages/*", new GlobberSettings {
        Predicate = d => !d.Hidden
    });

    Information($"Generating versions file");
    FileWriteText(ghPages + File("versions.json"),
        SerializeJsonPretty(new Dictionary<string, object> {
            ["versions"] = allTags.Select(d => new Dictionary<string, object> {
                ["name"] = d.GetDirectoryName(),
                ["tag"] = d.GetDirectoryName()
            })
        }));
});

Task("Build")
    .IsDependentOn("Cleanup")
    .IsDependentOn("PullDeps")
    .IsDependentOn("GenDocs");

Task("Serve")
    .Does(() =>
{
    DocFxServe("./_site");
});

Task("BuildServe")
    .IsDependentOn("Build")
    .IsDependentOn("Serve");

RunTarget(target);