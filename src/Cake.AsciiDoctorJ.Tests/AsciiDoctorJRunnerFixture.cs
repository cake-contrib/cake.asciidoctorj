namespace Cake.AsciiDoctorJ.Tests
{
    using Cake.Testing.Fixtures;

    public class AsciiDoctorJRunnerFixture : ToolFixture<AsciiDoctorJRunnerSettings>
    {
        public AsciiDoctorJRunnerFixture()
            : base("AsciiDoctorJ.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new AsciiDoctorJRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
