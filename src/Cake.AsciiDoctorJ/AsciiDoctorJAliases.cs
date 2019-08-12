using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.AsciiDoctorJ
{
    public static class AsciiDoctorJAliases
    {
        [CakeMethodAlias]
        public static IAsciiDoctorJRunner AsciiDoctorJ(
            this ICakeContext context,
            Action<AsciiDoctorJRunnerSettings> configure)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            var runner = new AsciiDoctorJRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.Run(configure);
        }
    }
}