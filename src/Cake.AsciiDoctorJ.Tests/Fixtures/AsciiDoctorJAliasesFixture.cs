using System;
using System.Linq;

using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
using Cake.Testing.Fixtures;

using Moq;

namespace Cake.AsciiDoctorJ.Tests.Fixtures
{
    internal class AsciiDoctorJAliasesFixture : AsciiDoctorJRunnerFixture
    {
        private ICakeContext context;

        public AsciiDoctorJAliasesFixture()
        {
            var argumentsMoq = new Mock<ICakeArguments>();
            var registryMoq = new Mock<IRegistry>();
            var dataService = new Mock<ICakeDataService>();
            context = new CakeContext(
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

        internal void GivenContextIsNull()
        {
            context = null;
        }

        internal new ToolFixtureResult RunFluent(Action<AsciiDoctorJRunnerSettings> configure)
        {
            context.AsciiDoctorJ(configure);
            return ProcessRunner.Results.LastOrDefault();
        }

        protected override void RunTool()
        {
            context.AsciiDoctorJ(Settings);
        }
    }
}
