#load nuget:?package=Cake.Recipe&version=2.2.1

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
    preferredBuildProviderType: BuildProviderType.GitHubActions,
    preferredBuildAgentOperatingSystem: PlatformFamily.Linux);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
