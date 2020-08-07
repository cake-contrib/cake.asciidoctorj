using System;
using System.Linq;

using Cake.Testing.Fixtures;

namespace Cake.AsciiDoctorJ.Tests.Fixtures
{
    public class AsciiDoctorJRunnerFixture : ToolFixture<AsciiDoctorJRunnerSettings>
    {
        public AsciiDoctorJRunnerFixture()
            : base("asciidoctorj.exe")
        {
        }

        public void GivenSettingsIsNull()
        {
            Settings = null;
        }

        public ToolFixtureResult RunFluent(Action<AsciiDoctorJRunnerSettings> configure)
        {
            var tool = new AsciiDoctorJRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(configure, Settings);
            return ProcessRunner.Results.LastOrDefault();
        }

        protected override void RunTool()
        {
            var tool = new AsciiDoctorJRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
