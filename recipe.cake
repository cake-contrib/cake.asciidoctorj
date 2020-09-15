#load nuget:https://pkgs.dev.azure.com/cake-contrib/Home/_packaging/addins%40Local/nuget/v3/index.json?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.AsciiDoctorJ",
    masterBranchName: "main",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.AsciiDoctorJ",
    appVeyorAccountName: "cakecontrib",
    shouldRunDotNetCorePack: true,
    shouldPublishMyGet: false, // currently broken
    shouldUseDeterministicBuilds: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
