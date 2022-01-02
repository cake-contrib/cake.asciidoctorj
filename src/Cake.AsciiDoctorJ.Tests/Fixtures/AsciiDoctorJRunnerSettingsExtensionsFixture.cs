using Cake.Core.IO;
using Cake.Testing;

namespace Cake.AsciiDoctorJ.Tests.Fixtures;

public class AsciiDoctorJRunnerSettingsExtensionsFixture
{
    public string EvaluateArgs(AsciiDoctorJRunnerSettings settings)
    {
        var args = new ProcessArgumentBuilder();
        var environment = FakeEnvironment.CreateWindowsEnvironment();

        settings.Evaluate(args, environment);

        return args.Render();
    }
}
