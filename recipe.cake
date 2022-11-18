#load nuget:?package=Cake.Recipe&version=3.0.1

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
    shouldUseDeterministicBuilds: true,
    shouldRunInspectCode: false, // we're shipping a custom version of it below
    preferredBuildProviderType: BuildProviderType.GitHubActions,
    preferredBuildAgentOperatingSystem: PlatformFamily.Linux);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
