using Cake.Core;
using Cake.Core.IO;
using NUnit.Framework;
using AutoFixture;
using FluentAssertions;

namespace Cake.AsciiDoctorJ.Tests
{
    [TestFixture]
    public class SettingsTests : TestBase
    {
        [SetUp]
        public void Setup()
        {
            SetupFixture();
        }

        [TestCase("Version", "--version")]
        [TestCase("Verbose", "--verbose")]
        [TestCase("TimingsMode", "--timings")]
        [TestCase("SectionNumbers", "--section-numbers")]
        [TestCase("Require", "--require")]
        [TestCase("Quiet", "--quiet")]
        [TestCase("SuppressHeaderAndFooter", "--no-header-footer")]
        [TestCase("Compact", "--compact")]
        public void SimpleBoolProperties(string propertyName, string expectedParam)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings();

            var prop = typeof(AsciiDoctorJRunnerSettings).GetProperty(propertyName);
            prop.SetValue(sut, true);

            sut.Evaluate(args, Fixture.Create<ICakeEnvironment>());

            var actual = args.Render();
            actual.Should().Contain(expectedParam);
        }

        [TestCase(SafeMode.Safe, "--safe-mode safe")]
        [TestCase(SafeMode.Unsafe, "--safe-mode unsafe")]
        [TestCase(SafeMode.Secure, "--safe-mode secure")]
        [TestCase(SafeMode.Server, "--safe-mode server")]
        public void SafeModeValues(SafeMode mode, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings
            {
                SafeMode = mode
            };

            sut.Evaluate(args, Fixture.Create<ICakeEnvironment>());

            var actual = args.Render();
            actual.Should().Contain(expected);
        }

        [TestCase(ERuby.Erb, "--eruby erb")]
        [TestCase(ERuby.Erubis, "--eruby erubis")]
        public void ERubyValues(ERuby eruby, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings
            {
                ERuby = eruby
            };

            sut.Evaluate(args, Fixture.Create<ICakeEnvironment>());

            var actual = args.Render();
            actual.Should().Contain(expected);
        }

        [TestCase(DocType.Article, "--doctype article")]
        [TestCase(DocType.Book, "--doctype book")]
        [TestCase(DocType.Inline, "--doctype inline")]
        public void DocTypeValues(DocType type, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings
            {
                DocType = type
            };

            sut.Evaluate(args, Fixture.Create<ICakeEnvironment>());

            var actual = args.Render();
            actual.Should().Contain(expected);
        }
    }
}