# cake.asciidoctorj

makes [asciidoctorj](https://github.com/asciidoctor/asciidoctorj) available as a tool in [cake](https://cakebuild.net/)

## usage

Install asciidoctorj - this addin has no dependency on asciidoctorj.

```cs
#addin "nuget:?package=Cake.AsciiDoctorJ"

AsciiDoctorJ(s => s
	.WithVerbose()
	.WithInputFile(file)
	.WithDestinationDir(distDir));
```

## TODO

* Documentation !