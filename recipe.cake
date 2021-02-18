#load nuget:?package=Cake.Recipe&version=2.2.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.AsciiDoctorJ",
    masterBranchName: "main",
    repositoryOwner: "cake-contrib",
    repositoryName: "cake.asciidoctorj",
    appVeyorAccountName: "cakecontrib",
    shouldRunDotNetCorePack: true,
    shouldUseDeterministicBuilds: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
