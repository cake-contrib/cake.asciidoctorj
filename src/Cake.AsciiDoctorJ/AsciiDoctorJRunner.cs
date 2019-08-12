using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;

namespace Cake.AsciiDoctorJ
{
    public class AsciiDoctorJRunner : Tool<AsciiDoctorJRunnerSettings>, IAsciiDoctorJRunner
    {
        private ICakeEnvironment environment;

        public AsciiDoctorJRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.environment = environment;
        }

        protected override string GetToolName() => "AsciiDoctorJ Runner";

        protected override IEnumerable<string> GetToolExecutableNames() => new[] { "asciidoctorj.exe", "asciidoctorj" };

        internal AsciiDoctorJRunner Run(Action<AsciiDoctorJRunnerSettings> configure = null)
        {
            var settings = new AsciiDoctorJRunnerSettings();
            configure?.Invoke(settings);
            return Run(settings);
        }

        protected AsciiDoctorJRunner Run(AsciiDoctorJRunnerSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args, environment);
            Run(settings, args);
            return this;
        }
    }
}