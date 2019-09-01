# Cake.AsciiDoctorJ

[![standard-readme compliant][]][standard-readme]
[![All Contributors](https://img.shields.io/badge/all_contributors-0-orange.svg?style=flat-square)](#contributors)
[![Appveyor build][appveyorimage]][appveyor]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

> makes [asciidoctorj](https://github.com/asciidoctor/asciidoctorj) available as a tool in [cake](https://cakebuild.net/)

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
  - [Contributors](#contributors)
- [License](#license)

## Install

```cs
#addin nuget:?package=Cake.AsciiDoctorJ
```

## Usage

```cs
#addin nuget:?package=Cake.AsciiDoctorJ

Task("MyTask").Does(() => {
  AsciiDoctorJ(s => s
	  .WithVerbose()
	  .WithInputFile(file)
	  .WithDestinationDir(distDir));
});
```

## Maintainer

[Nils Andresen @nils-a][maintainer]

## Contributing

Cake.AsciiDoctorJ follows the [Contributor Covenant][contrib-covenant] Code of Conduct.

We accept Pull Requests.
Please see [the contributing file][contributing] for how to contribute to Cake.AsciiDoctorJ.

Small note: If editing the Readme, please conform to the [standard-readme][] specification.

This project follows the [all-contributors][] specification. Contributions of any kind welcome!

### Contributors

Thanks goes to these wonderful people ([emoji key][emoji-key]):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

## License

[MIT License © Nils Andresen][license]

[all-contributors]: https://github.com/all-contributors/all-contributors
[appveyor]: https://ci.appveyor.com/project/cakecontrib/cake-asciidoctorj
[appveyorimage]: https://img.shields.io/appveyor/ci/cakecontrib/cake-asciidoctorj.svg?logo=appveyor&style=flat-square
[codecov]: https://codecov.io/gh/cake-contrib/Cake.AsciiDoctorJ
[codecovimage]: https://img.shields.io/codecov/c/github/cake-contrib/Cake.AsciiDoctorJ.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[contributing]: CONTRIBUTING.md
[emoji-key]: https://allcontributors.org/docs/en/emoji-key
[maintainer]: https://github.com/nils-a
[nuget]: https://nuget.org/packages/Cake.AsciiDoctorJ
[nugetimage]: https://img.shields.io/nuget/v/Cake.AsciiDoctorJ.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
