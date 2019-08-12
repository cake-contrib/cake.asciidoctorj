using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;

namespace Cake.AsciiDoctorJ
{
    /// <summary>
    /// This is the runner. <see cref="Tool{TSettings}"/>
    /// </summary>
    internal class AsciiDoctorJRunner : Tool<AsciiDoctorJRunnerSettings>, IAsciiDoctorJRunner
    {
        private ICakeEnvironment environment;

        /// <summary>
        /// default ctor. <see cref="Tool{TSettings}(IFileSystem,ICakeEnvironment,IProcessRunner,IToolLocator)"/>
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        internal AsciiDoctorJRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.environment = environment;
        }

        /// <summary>
        /// AsciiDoctorJ
        /// </summary>
        /// <returns></returns>
        protected override string GetToolName() => "AsciiDoctorJ Runner";

        /// <summary>
        /// AsciiDoctorJ.exe
        /// </summary>
        /// <returns></returns>
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