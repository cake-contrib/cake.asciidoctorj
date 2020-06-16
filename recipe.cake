#load nuget:?package=Cake.Recipe&version=1.1.1

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.AsciiDoctorJ",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.AsciiDoctorJ",
    appVeyorAccountName: "cakecontrib",
    shouldRunGitVersion: true,
    shouldExecuteGitLink: false,
    shouldRunCodecov: true,
    shouldDeployGraphDocumentation: false,
    shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
