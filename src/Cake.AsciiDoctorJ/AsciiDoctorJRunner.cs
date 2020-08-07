using System;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Cake.AsciiDoctorJ.Tests")]

namespace Cake.AsciiDoctorJ
{
    /// <summary>
    /// This is the runner. <see cref="Tool{TSettings}"/>.
    /// </summary>
    internal class AsciiDoctorJRunner : Tool<AsciiDoctorJRunnerSettings>
    {
        private readonly ICakeEnvironment environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsciiDoctorJRunner"/> class.
        /// <see cref="Tool{TSettings}(IFileSystem,ICakeEnvironment,IProcessRunner,IToolLocator)"/>.
        /// </summary>
        /// <param name="fileSystem">The <see cref="IFileSystem"/>.</param>
        /// <param name="environment">The <see cref="ICakeEnvironment"/>.</param>
        /// <param name="processRunner">The <see cref="IProcessRunner"/>.</param>
        /// <param name="tools">The <see cref="IToolLocator"/>.</param>
        internal AsciiDoctorJRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Runs the tool using an action to configure settings.
        /// </summary>
        /// <param name="configure">The configuration action.</param>
        /// <param name="settings">The settings.</param>
        internal void Run(Action<AsciiDoctorJRunnerSettings> configure = null, AsciiDoctorJRunnerSettings settings = null)
        {
            if (settings == null)
            {
                settings = new AsciiDoctorJRunnerSettings();
            }

            configure?.Invoke(settings);
            Run(settings);
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        /// <param name="settings">The settings.</param>
        internal void Run(AsciiDoctorJRunnerSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args, environment);
            Run(settings, args);
        }

        /// <inheritdoc/>
        protected override string GetToolName() => "AsciiDoctorJ Runner";

        /// <inheritdoc/>
        protected override IEnumerable<string> GetToolExecutableNames() => new[] { "asciidoctorj.exe", "asciidoctorj" };
    }
}
