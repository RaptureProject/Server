[![GitHub license](https://img.shields.io/github/license/RaptureProject/Server?style=for-the-badge&color=00bb00)](https://github.com/RaptureProject/Server/blob/main/LICENSE.txt)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.0-4baaaa?style=for-the-badge)](CODE_OF_CONDUCT.md)
[![GitHub issues](https://img.shields.io/github/issues/RaptureProject/Server?style=for-the-badge)](https://github.com/RaptureProject/Server/issues)

# Rapture Server
This repository contains the Rapture server source code.

# Getting Started
In order to contribute to the server you will need to install a few dependencies, the steps outlined below should get you up and running with a basic development environment.

## Dependencies
Dependencies recommended are as follows:

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/), [Visual Studio Code](https://code.visualstudio.com/download), or [JetBrains Rider](https://www.jetbrains.com/rider/)

The code editor you use is really up to you in terms of what you prefer, just keep in mind that Visual Studio 2022 and JetBrains Rider will giive you the best development experience.
You can also choose to use any other code editor if you really want thats not in the list so long as you are willing to go through the extra configuration needed to do so (ex. Vim, NeoVim, Emacs, etc.).

## Run Rapture Server
Once you have all the dependencies listed above you can:

- Run `dotnet run` from the `src/AppHost` directory.
- Open the `Rapture.sln` file in either Visual Studio 2022, Visual Studio Code, or JetBrains Rider and run the `Rapture.AppHost` project.

After it is up and running you should be able to connect using the Rapture client.
