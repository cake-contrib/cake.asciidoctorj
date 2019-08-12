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
        /// run AsciiDoctorJ:
        ///
        /// Example:
        /// AsciiDoctorJ(s => s
        ///   .WithVerbose()
        ///   .WithInputFile(file)
        ///   .WithDestinationDir(distDir));
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IAsciiDoctorJRunner AsciiDoctorJ(
            this ICakeContext context,
            Action<AsciiDoctorJRunnerSettings> configure)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var runner = new AsciiDoctorJRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Run(configure);
        }
    }
}