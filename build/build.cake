#tool "nuget:?package=NUnit.ConsoleRunner&version=3.10.0"
#tool "nuget:?package=OpenCover&version=4.7.922"
#tool "nuget:?package=coveralls.io&version=1.4.2"
#addin "nuget:?package=Cake.Coveralls&version=0.10.0"

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
		
	// test & coverage
	Information("Test and coverage...");
	var testAssemblies = GetFiles(srcDir + File($"**/bin/{configuration}/*.Tests.dll"));
	var testOutput = binDir + File("TestResult.xml");
	var coverOutput = binDir + File("CoverageResult.xml");
	OpenCover(c => 
	{
		c.NUnit3(testAssemblies, new NUnit3Settings 
		{
			Work = binDir,
			OutputFile = testOutput
		});
	},
	coverOutput,
	new OpenCoverSettings()
		.WithFilter("+[Cake.AsciiDoctorJ]*")
		.WithFilter("-[Cake.AsciiDoctorJ.Tests]*")
	);
	
	// on AppVeyor, publish testsettings..
	if(EnvironmentVariable("APPVEYOR_JOB_ID") != null)
	{
		Information("Running on AppVeyor. Publishing Test-Result.");
		BuildSystem.AppVeyor.UploadTestResults(testOutput, AppVeyorTestResultsType.NUnit3);

		var repoToken = EnvironmentVariable("COVERALLS_REPO_TOKEN");
		if(repoToken == null)
		{
			Warning("We're running on AppVeyor but there is no COVERALLS_REPO_TOKEN");
		} 
		else 
		{
			Information("Publishing Coverage-Result to coveralls.io");
			CoverallsIo(coverOutput, new CoverallsIoSettings()
			{
				RepoToken = repoToken
			});
		}
	}
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