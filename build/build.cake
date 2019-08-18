#tool "nuget:?package=NUnit.ConsoleRunner&version=3.10.0"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var rootDir = Directory("./../");
var srcDir = rootDir + Directory ("src");
var binDir = rootDir + Directory("bin");
var distDir = rootDir + Directory("dist");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(binDir);
	CleanDirectory(distDir);
});

Task("Build")
	.Does(() => 
{
    var file = srcDir + File("Cake.AsciiDoctorJ.sln");
	NuGetRestore(file);
	MSBuild(file, settings => settings
		.SetVerbosity(Verbosity.Minimal)
		.SetConfiguration(configuration)
		.WithTarget("Build")
	); 
	
	var testAssemblies = GetFiles(srcDir + File($"**/bin/{configuration}/*.Tests.dll"));
	var workDir = testAssemblies.First().GetDirectory();
	NUnit3(testAssemblies);
});

Task("Dist")
	.IsDependentOn("Build")
	.Does(() => 
{
	NuGetPack(srcDir + File("Cake.AsciiDoctorJ.nuspec"), new NuGetPackSettings {
		BasePath                = binDir.ToString(),
	    OutputDirectory         = distDir.ToString()
	});
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Dist");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);