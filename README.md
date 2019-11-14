# BepInEx Documentation

This is the repo for storing documentation related to BepInEx.  

## [View the docs](https://bepinex.github.io/bepinex_docs/)

## Contributing

All contributions either via PRs or issues are welcome!

This project uses [DocFX](https://dotnet.github.io/docfx/) to render the API documentation and the articles.  
Please refer to DocFX documentation for information on using [DocFX-flavoured markdown](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html?tabs=tabid-1%2Ctabid-a).

### Setting up the repo locally

1. Clone this repo
2. Create a `src` folder and clone [BepInEx](https://github.com/BepInEx/BepInEx) repository **recursively pulling the submodules** into it.  
    For instance, you can use `git clone --recurse-submodules https://github.com/BepInEx/BepInEx.git .` inside the `src` folder.
3. Run `nuget restore` in the `src` folder to restore packages.
4. Install DocFX. Currently our CI uses [DocFX 2.47](https://github.com/dotnet/docfx/releases/download/v2.47/docfx.zip), so you should consider using the same version. However, **pick the version that works with your VS/MSBuild setup**. It's suggested to download and install [MSBuild 15](https://stackoverflow.com/questions/52729944/how-to-get-msbuild-15-without-a-full-install-of-visual-studio) separately if you use Visual Studio 2019 or older (or use).  
    **NOTE** Currently DocFX works best with MSBuild 15 (which ships with VS19) or mono. 
5. Run `docfx --serve` in this repository folder to build the documentation and automatically serve them on `localhost:8080`.
