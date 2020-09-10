using System;

using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.AsciiDoctorJ
{
    /// <summary>
    /// <para>Functions to call <see href="https://asciidoctor.org/">AsciiDoctorJ</see>.</para>
    /// <para>
    /// In order to use this add-in, add the following to your build.cake.
    /// <code><![CDATA[
    /// #addin "nuget:?package=Cake.AsciiDoctorJ"
    /// ]]></code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("asciidoctorj")]
    public static class AsciiDoctorJAliases
    {
        /// <summary>
        /// Runs the tool using an action to configure settings.
        /// </summary>
        /// <param name="context">The <see cref="ICakeContext"/>.</param>
        /// <param name="configure">An action to configure the <see cref="AsciiDoctorJRunnerSettings"/>.</param>
        /// <example>
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
        [CakeAliasCategory("AsciiDoctorJ")]
        public static void AsciiDoctorJ(
            this ICakeContext context,
            Action<AsciiDoctorJRunnerSettings> configure = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var runner = new AsciiDoctorJRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(configure);
        }

        /// <summary>
        /// Runs the tool using the given <see cref="AsciiDoctorJRunnerSettings"/>.
        /// </summary>
        /// <param name="context">The <see cref="ICakeContext"/>.</param>
        /// <param name="settings">The <see cref="AsciiDoctorJRunnerSettings"/>.</param>
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
        [CakeAliasCategory("AsciiDoctorJ")]
        public static void AsciiDoctorJ(
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
            runner.Run(settings);
        }
    }
}
