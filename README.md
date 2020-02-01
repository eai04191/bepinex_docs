# BepInEx Documentation

This is the repo for storing documentation related to BepInEx.  

## [View the docs](https://bepinex.github.io/bepinex_docs/)

## Contributing

All contributions either via PRs or issues are welcome!

This project uses [DocFX](https://dotnet.github.io/docfx/) to render the API documentation and the articles.  
Please refer to DocFX documentation for information on using [DocFX-flavoured markdown](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html?tabs=tabid-1%2Ctabid-a).

### Writing docs locally

1. Clone this repo
2. Write documentation into `api` or `articles` folder. Refer to [docfx guide](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html) and [DFM syntax guide](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html) for info on writing the guides using DocFX
3. Run `build.ps1` (PowerShell) or `build.sh` (Unix) to build the docs
   * Optionally, specify `-Target=<target>` argument with one of the following commands:
       * `Build`: Build the docs
       * `Serve`: Serve the already built docs on `localhost:8080`
       * `BuildServe`: Build and serve the docs
       * `CleanDeps`: Remove BepInEx and common files folder in order to redownload them on the next build

