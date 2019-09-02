namespace Cake.AsciiDoctorJ.Tests
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Testing;
    using Moq;

    public class AsciiDoctorJAliasesFixture : AsciiDoctorJRunnerFixture
    {
        internal ICakeContext _context;

        public AsciiDoctorJAliasesFixture()
        {
            var argumentsMoq = new Mock<ICakeArguments>();
            var registryMoq = new Mock<IRegistry>();
            var dataService = new Mock<ICakeDataService>();
            _context = new CakeContext(
                FileSystem,
                Environment,
                Globber,
                new FakeLog(),
                argumentsMoq.Object,
                ProcessRunner,
                registryMoq.Object,
                Tools, dataService.Object,
                Configuration);
        }

        protected override void RunTool()
        {
            if (Settings == null)
            {
                AsciiDoctorJAliases.AsciiDoctorJ(_context);
            }
            else
            {
                AsciiDoctorJAliases.AsciiDoctorJ(_context, Settings);
            }
        }
    }
}
