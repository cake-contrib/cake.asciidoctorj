using Cake.Core;
using Cake.Core.IO;
using NUnit.Framework;
using FluentAssertions;
using Cake.Testing;

namespace Cake.AsciiDoctorJ.Tests
{
    [TestFixture]
    [TestOf(typeof(AsciiDoctorJRunnerSettings))]
    public class SettingsTests
    {
        private ICakeEnvironment environment;

        [SetUp]
        public void Setup()
        {
            environment = FakeEnvironment.CreateWindowsEnvironment();
        }

        [TestCase("Version", "--version")]
        [TestCase("Verbose", "--verbose")]
        [TestCase("TimingsMode", "--timings")]
        [TestCase("SectionNumbers", "--section-numbers")]
        [TestCase("Require", "--require")]
        [TestCase("Quiet", "--quiet")]
        [TestCase("SuppressHeaderAndFooter", "--no-header-footer")]
        [TestCase("Compact", "--compact")]
        public void Should_Convert_All_Flags_To_Arguments(string propertyName, string expectedParam)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings();

            var prop = typeof(AsciiDoctorJRunnerSettings).GetProperty(propertyName);
            prop.SetValue(sut, true);

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
            var sut = new AsciiDoctorJRunnerSettings
            {
                SafeMode = mode
            };

            sut.Evaluate(args, environment);

            var actual = args.Render();
            actual.Should().Contain(expected);
        }

        [TestCase(ERuby.Erb, "--eruby erb")]
        [TestCase(ERuby.Erubis, "--eruby erubis")]
        public void Should_Convert_Eruby_Settings_To_Arguments(ERuby eruby, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings
            {
                ERuby = eruby
            };

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
            var sut = new AsciiDoctorJRunnerSettings
            {
                DocType = type
            };

            sut.Evaluate(args, environment);

            var actual = args.Render();
            actual.Should().Contain(expected);
        }
    }
}
