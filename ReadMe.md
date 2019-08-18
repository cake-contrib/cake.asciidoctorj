# cake.asciidoctorj

This addin makes [asciidoctorj](https://github.com/asciidoctor/asciidoctorj) available as a tool in [cake](https://cakebuild.net/)

[![License](http://img.shields.io/:license-mit-blue.svg)](http://cake-contrib.mit-license.org)

## usage

Install asciidoctorj - this addin has no dependency on asciidoctorj.

```cs
#addin "nuget:?package=Cake.AsciiDoctorJ"

AsciiDoctorJ(s => s
	.WithVerbose()
	.WithInputFile(file)
	.WithDestinationDir(distDir));
```

## Build Status

|Develop|Master|
|:--:|:--:|
|[![Build status](https://ci.appveyor.com/api/projects/status/lfnuyv5q5dbc9aoj/branch/develop?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-asciidoctorj/branch/develop)|[![Build status](https://ci.appveyor.com/api/projects/status/lfnuyv5q5dbc9aoj/branch/master?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-asciidoctorj/branch/master)|

## Code Coverage

[![Coverage Status](https://coveralls.io/repos/github/cake-contrib/cake.asciidoctorj/badge.svg?branch=develop)](https://coveralls.io/github/cake-contrib/cake.asciidoctorj?branch=develop)

## Packages

| Location | Link |
|:--:|:--:|
|NuGet|![Nuget](https://img.shields.io/nuget/v/cake.asciidoctorj)|


## Chat Room

Join in the conversation about Cake.AsciiDoctorJ on gitter

[![Join the chat at https://gitter.im/cake-contrib/Lobby](https://badges.gitter.im/cake-contrib/Lobby.svg)](https://gitter.im/cake-contrib/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
