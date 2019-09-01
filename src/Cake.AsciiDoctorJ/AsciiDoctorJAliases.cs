using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.AsciiDoctorJ
{
    /// <summary>
    /// Aliases for AsciiDoctorJ
    /// </summary>
    public static class AsciiDoctorJAliases
    {
        /// <summary>
        /// Runs AsciiDoctorJ
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        /// /// <example>
        /// <code>
        /// <![CDATA[
        /// Task("Convert")
        ///     .Does(() =>
        /// {
        ///     AsciiDoctorJ(s => s
	    ///         .WithVerbose()
	    ///         .WithDocType(DocType.Article)
	    ///         .WithBackend("pdf")
	    ///         .WithInputFile(file)
	    ///         .WithDestinationDir(distDir));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static IAsciiDoctorJRunner AsciiDoctorJ(
            this ICakeContext context,
            Action<AsciiDoctorJRunnerSettings> configure = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var runner = new AsciiDoctorJRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Run(configure);
        }

        /// <summary>
        /// Runs AsciiDoctorJ
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        /// /// <example>
        /// <code>
        /// <![CDATA[
        /// Task("Convert")
        ///     .Does(() =>
        /// {
        ///     AsciiDoctorJ(new AsciiDoctorJRunnerSettings {
        ///         Verbose = true,
        ///         DocType = DocType.Article,
        ///         Backend = "pdf",
        ///         InputFiles = new[]{ file },
        ///         DestinationDir = distDir
        ///     });
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static IAsciiDoctorJRunner AsciiDoctorJ(
            this ICakeContext context,
            AsciiDoctorJRunnerSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var runner = new AsciiDoctorJRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Run(settings);
        }
    }
}
