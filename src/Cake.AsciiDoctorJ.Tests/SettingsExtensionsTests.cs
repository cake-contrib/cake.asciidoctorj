using Cake.Core;
using Cake.Core.IO;
using NUnit.Framework;
using AutoFixture;
using FluentAssertions;

namespace Cake.AsciiDoctorJ.Tests
{
    [TestFixture]
    public class SettingsExtensionsTests : TestBase
    {
        [SetUp]
        public void Setup()
        {
            SetupFixture();
        }

        [TestCase("WithVersion", "--version")]
        [TestCase("WithVerbose", "--verbose")]
        [TestCase("WithTimingsMode", "--timings")]
        [TestCase("WithSectionNumbers", "--section-numbers")]
        [TestCase("WithRequire", "--require")]
        [TestCase("WithQuiet", "--quiet")]
        [TestCase("WithSuppressHeaderAndFooter", "--no-header-footer")]
        [TestCase("WithCompact", "--compact")]
        public void SimpleBoolProperties(string extensionName, string expectedParam)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings();

            var ext = typeof(AsciiDoctorJRunnerSettingsExtensions).GetMethod(extensionName,
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            ext.Invoke(null, new object[] { sut });

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
            var sut = new AsciiDoctorJRunnerSettings().WithSafeMode(mode);

            sut.Evaluate(args, Fixture.Create<ICakeEnvironment>());

            var actual = args.Render();
            actual.Should().Contain(expected);
        }

        [TestCase(ERuby.Erb, "--eruby erb")]
        [TestCase(ERuby.Erubis, "--eruby erubis")]
        public void ERubyValues(ERuby eruby, string expected)
        {
            var args = new ProcessArgumentBuilder();
            var sut = new AsciiDoctorJRunnerSettings().WithERuby(eruby);

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
            var sut = new AsciiDoctorJRunnerSettings().WithDocType(type);

            sut.Evaluate(args, Fixture.Create<ICakeEnvironment>());

            var actual = args.Render();
            actual.Should().Contain(expected);
        }
    }
}