# Cake.AsciiDoctorJ

[![standard-readme compliant][]][standard-readme]
[![All Contributors][all-contributors-badge]](#contributors)
[![Contributor Covenant][contrib-covenantimg]][contrib-covenant]
[![Build][buildimage]][build]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

makes [asciidoctorj](https://github.com/asciidoctor/asciidoctorj) available as a tool in [cake](https://cakebuild.net/)

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Discussion](#discussion)
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
## Discussion

If you have questions, search for an existing one, or create a new discussion on the Cake GitHub repository, using the `extension-q-a` category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)

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
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="http://www.nils-andresen.de/"><img src="https://avatars3.githubusercontent.com/u/349188?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Nils Andresen</b></sub></a><br /><a href="https://github.com/cake-contrib/cake.asciidoctorj/commits?author=nils-a" title="Code">💻</a> <a href="https://github.com/cake-contrib/cake.asciidoctorj/commits?author=nils-a" title="Documentation">📖</a></td>
    <td align="center"><a href="https://twitter.com/hereispascal"><img src="https://avatars1.githubusercontent.com/u/2190718?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Pascal Berger</b></sub></a><br /><a href="https://github.com/cake-contrib/cake.asciidoctorj/issues?q=author%3Apascalberger" title="Bug reports">🐛</a> <a href="https://github.com/cake-contrib/cake.asciidoctorj/commits?author=pascalberger" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/DiDoHH"><img src="https://avatars.githubusercontent.com/u/45682415?v=4?s=100" width="100px;" alt=""/><br /><sub><b>DiDoHH</b></sub></a><br /><a href="https://github.com/cake-contrib/cake.asciidoctorj/commits?author=DiDoHH" title="Documentation">📖</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

## License

[MIT License © Nils Andresen][license]

[all-contributors]: https://github.com/all-contributors/all-contributors
[all-contributors-badge]: https://img.shields.io/github/all-contributors/cake-contrib/cake.AsciiDoctorJ/develop?&style=flat-square
[build]: https://github.com/cake-contrib/cake.asciidoctorj/actions/workflows/build.yml
[buildimage]: https://github.com/cake-contrib/cake.asciidoctorj/actions/workflows/build.yml/badge.svg
[codecov]: https://codecov.io/gh/cake-contrib/Cake.AsciiDoctorJ
[codecovimage]: https://img.shields.io/codecov/c/github/cake-contrib/Cake.AsciiDoctorJ.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/2/0/code_of_conduct/
[contrib-covenantimg]: https://img.shields.io/badge/Contributor%20Covenant-v2.0%20adopted-ff69b4.svg
[contributing]: CONTRIBUTING.md
[emoji-key]: https://allcontributors.org/docs/en/emoji-key
[maintainer]: https://github.com/nils-a
[nuget]: https://nuget.org/packages/Cake.AsciiDoctorJ
[nugetimage]: https://img.shields.io/nuget/v/Cake.AsciiDoctorJ.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
