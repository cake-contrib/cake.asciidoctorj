using Cake.Core;
using Cake.Core.IO;
using NUnit.Framework;
using FluentAssertions;
using Cake.Testing;

namespace Cake.AsciiDoctorJ.Tests
{
    [TestFixture]
    [TestOf(typeof(AsciiDoctorJRunnerSettingsExtensions))]
    public class SettingsExtensionsTests
    {
        // TODO: It would be better (i.e. more isolated) to test whether the extensions use the settings "correctly"...

        private ICakeEnvironment environment;

        [SetUp]
        public void Setup()
        {
            environment = FakeEnvironment.CreateWindowsEnvironment();
        }

        [TestCase("WithVersion", "--version")]
        [TestCase("WithVerbose", "--verbose")]
        [TestCase("WithTimingsMode", "--timings")]
        [TestCase("WithSectionNumbers", "--section-numbers")]
        [TestCase("WithRequire", "--require")]
        [TestCase("WithQuiet", "--quiet")]
        [TestCase("WithSuppressHeaderAndFooter", "--no-header-footer")]
        [TestCase("WithCompact", "--compact")]
        public void Should_Convert_All_Flags_To_Arguments(string extensionName, string expectedParam)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings();

            var ext = typeof(AsciiDoctorJRunnerSettingsExtensions).GetMethod(extensionName,
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            ext.Invoke(null, new object[] { sut });

            sut.Evaluate(args, environment);

            var actual = args.Render();
            actual.Should().Contain(expectedParam);
        }

        [TestCase(SafeMode.Safe, "--safe-mode safe")]
        [TestCase(SafeMode.Unsafe, "--safe-mode unsafe")]
        [TestCase(SafeMode.Secure, "--safe-mode secure")]
        [TestCase(SafeMode.Server, "--safe-mode server")]
        public void Should_Convert_SafeMode_Settings_To_Arguments(SafeMode mode, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings().WithSafeMode(mode);

            sut.Evaluate(args, environment);

            var actual = args.Render();
            actual.Should().Contain(expected);
        }

        [TestCase(ERuby.Erb, "--eruby erb")]
        [TestCase(ERuby.Erubis, "--eruby erubis")]
        public void Should_Convert_Eruby_Settings_To_Arguments(ERuby eruby, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings().WithERuby(eruby);

            sut.Evaluate(args, environment);

            var actual = args.Render();
            actual.Should().Contain(expected);
        }

        [TestCase(DocType.Article, "--doctype article")]
        [TestCase(DocType.Book, "--doctype book")]
        [TestCase(DocType.Inline, "--doctype inline")]
        public void Should_Convert_DocType_Settings_To_Arguments(DocType type, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings().WithDocType(type);

            sut.Evaluate(args, environment);

            var actual = args.Render();
            actual.Should().Contain(expected);
        }
    }
}
