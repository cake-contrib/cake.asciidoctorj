using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Cake.AsciiDoctorJ.Tests.Fixtures;
using Cake.Core.IO;

using FluentAssertions;

using Xunit;

namespace Cake.AsciiDoctorJ.Tests
{
    public class SettingsExtensionsTests
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void Should_convert_all_extensions_to_arguments(Action<AsciiDoctorJRunnerSettings> setFlag, string expectedParam)
        {
            var fixture = new AsciiDoctorJRunnerSettingsExtensionsFixture();
            var sut = new AsciiDoctorJRunnerSettings();

            setFlag(sut);

            var actual = fixture.EvaluateArgs(sut);
            actual.Should().Contain(expectedParam);
        }

        [Theory]
        [ClassData(typeof(ArgSetterTestData))]
        public void Should_convert_all_extensions_to_setArgs(
            Action<AsciiDoctorJRunnerSettings> setFlag,
            Func<AsciiDoctorJRunnerSettings, object> getFlag,
            object expected)
        {
            var sut = new AsciiDoctorJRunnerSettings();
            setFlag(sut);

            var actual = getFlag(sut);

            if (!(actual is string) && actual is IEnumerable enumerable)
            {
                enumerable.Should().BeEquivalentTo((IEnumerable)expected);
            }
            else
            {
                actual.Should().Be(expected);
            }
        }

        [Theory]
        [ClassData(typeof(RetValTestData))]
        public void Should_return_the_settings_for_fluent_re_use(Func<AsciiDoctorJRunnerSettings, AsciiDoctorJRunnerSettings> fluentMethod)
        {
            var sut = new AsciiDoctorJRunnerSettings();

            var actual = fluentMethod(sut);

            actual.Should().Be(sut);
        }

        private class TestData : IEnumerable<object[]>
        {
            private IEnumerable<(Action<AsciiDoctorJRunnerSettings>, string)> GetTestData()
            {
                // flags
                yield return (s => s.WithVersion(), "--version");
                yield return (s => s.WithVerbose(), "--verbose");
                yield return (s => s.WithTimingsMode(), "--timings");
                yield return (s => s.WithSectionNumbers(), "--section-numbers");
                yield return (s => s.WithRequire(), "--require");
                yield return (s => s.WithQuiet(), "--quiet");
                yield return (s => s.WithSuppressHeaderAndFooter(), "--no-header-footer");
                yield return (s => s.WithCompact(), "--compact");

                // safemode-arg
                yield return (s => s.WithSafeMode(SafeMode.Safe), "--safe-mode safe");
                yield return (s => s.WithSafeMode(SafeMode.Unsafe), "--safe-mode unsafe");
                yield return (s => s.WithSafeMode(SafeMode.Secure), "--safe-mode secure");
                yield return (s => s.WithSafeMode(SafeMode.Server), "--safe-mode server");

                // eruby-arg
                yield return (s => s.WithERuby(ERuby.Erb), "--eruby erb");
                yield return (s => s.WithERuby(ERuby.Erubis), "--eruby erubis");

                // doctype-arg
                yield return (s => s.WithDocType(DocType.Article), "--doctype article");
                yield return (s => s.WithDocType(DocType.Book), "--doctype book");
                yield return (s => s.WithDocType(DocType.Inline), "--doctype inline");

                // builtin backend - arg
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.DocBook), "--backend docbook");
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.DocBook5), "--backend docbook5");
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.Html), "--backend html");
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.Html5), "--backend html5");
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.Manpage), "--backend manpage");
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.Xhtml), "--backend xhtml");
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.Xhtml5), "--backend xhtml5");

                // misc args
                yield return (s => s.WithTemplateEngine("some-engine"), "--template-engine some-engine");
                yield return (s => s.WithTemplateDir(new DirectoryPath("/foo")), "--template-dir \"/foo\"");
                yield return (s => s.WithOutputFile(new FilePath("/foo.pdf")), "--out-file \"/foo.pdf\"");
                yield return (s => s.WithLoadPath(new DirectoryPath("/foo")), "--load-path \"/foo\"");
                yield return (s => s.WithLoadPaths(new[] { new DirectoryPath("/foo"), new DirectoryPath("/bar") }), "--load-path \"/foo\" --load-path \"/bar\"");
                yield return (s => s.WithDestinationDir(new DirectoryPath("/foo")), "--destination-dir \"/foo\"");
                yield return (s => s.WithClassPath(new DirectoryPath("/foo")), "--classpath \"/foo\"");
                yield return (s => s.WithClassPaths(new[] { new DirectoryPath("/foo"), new DirectoryPath("/bar") }), "--classpath \"/foo\" --classpath \"/bar\"");
                yield return (s => s.WithBaseDir(new DirectoryPath("/foo")), "--base-dir \"/foo\"");
                yield return (s => s.WithBackend("pdf"), "--backend pdf");
                yield return (s => s.WithAttribute("foo", "bar"), "--attribute foo=bar");
                yield return (s => s.WithAttributes(new Dictionary<string, string> { { "foo", "bar" }, { "bim", "bam" } }), "--attribute foo=bar --attribute bim=bam");
                yield return (s => s.WithInputFile(new FilePath("/foo.adoc")), "/foo.adoc");
                yield return (s => s.WithInputFiles(new[] { new FilePath("/foo.adoc"), new FilePath("/bar.adoc") }), "\"/foo.adoc\" \"/bar.adoc\"");
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                return GetTestData().Select(x => new[] { (object)x.Item1, x.Item2 }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class ArgSetterTestData : IEnumerable<object[]>
        {
            private IEnumerable<(Action<AsciiDoctorJRunnerSettings>,
                Func<AsciiDoctorJRunnerSettings, object>,
                object)> GetTestData()
            {
                // flags
                yield return (s => s.WithVersion(), s => s.Version, true);
                yield return (s => s.WithVerbose(), s => s.Verbose, true);
                yield return (s => s.WithTimingsMode(), s => s.TimingsMode, true);
                yield return (s => s.WithSectionNumbers(), s => s.SectionNumbers, true);
                yield return (s => s.WithRequire(), s => s.Require, true);
                yield return (s => s.WithQuiet(), s => s.Quiet, true);
                yield return (s => s.WithSuppressHeaderAndFooter(), s => s.SuppressHeaderAndFooter, true);
                yield return (s => s.WithCompact(), s => s.Compact, true);

                // safemode-arg
                yield return (s => s.WithSafeMode(SafeMode.Safe), s => s.SafeMode, SafeMode.Safe);
                yield return (s => s.WithSafeMode(SafeMode.Unsafe), s => s.SafeMode, SafeMode.Unsafe);
                yield return (s => s.WithSafeMode(SafeMode.Secure), s => s.SafeMode, SafeMode.Secure);
                yield return (s => s.WithSafeMode(SafeMode.Server), s => s.SafeMode, SafeMode.Server);

                // eruby-arg
                yield return (s => s.WithERuby(ERuby.Erb), s => s.ERuby, ERuby.Erb);
                yield return (s => s.WithERuby(ERuby.Erubis), s => s.ERuby, ERuby.Erubis);

                // doctype-arg
                yield return (s => s.WithDocType(DocType.Article), s => s.DocType, DocType.Article);
                yield return (s => s.WithDocType(DocType.Book), s => s.DocType, DocType.Book);
                yield return (s => s.WithDocType(DocType.Inline), s => s.DocType, DocType.Inline);

                // misc args
                var fooDir = new DirectoryPath("/foo");
                var barDir = new DirectoryPath("/bar");
                var fooPdf = new FilePath("foo.pdf");
                var fooAdoc = new FilePath("foo.adoc");
                var barAdoc = new FilePath("bar.adoc");
                var fooBar = new KeyValuePair<string, string>("foo", "bar");
                var bimBam = new KeyValuePair<string, string>("bim", "bam");
                yield return (s => s.WithTemplateEngine("some-engine"), s => s.TemplateEngine, "some-engine");
                yield return (s => s.WithTemplateDir(fooDir), s => s.TemplateDir, fooDir);
                yield return (s => s.WithOutputFile(fooPdf), s => s.Output, fooPdf);
                yield return (s => s.WithLoadPath(fooDir), s => s.LoadPath, new[] { fooDir });
                yield return (s => s.WithLoadPaths(new[] { fooDir, barDir }), s => s.LoadPath, new[] { fooDir, barDir });
                yield return (s => s.WithDestinationDir(fooDir), s => s.DestinationDir, fooDir);
                yield return (s => s.WithClassPath(fooDir), s => s.ClassPath, new[] { fooDir });
                yield return (s => s.WithClassPaths(new[] { fooDir, barDir }), s => s.ClassPath, new[] { fooDir, barDir });
                yield return (s => s.WithBaseDir(fooDir), s => s.BaseDir, fooDir);
                yield return (s => s.WithBackend("pdf"), s => s.Backend, "pdf");
                yield return (s => s.WithBuiltinBackend(BuiltinBackend.Html), s => s.Backend, "html");
                yield return (s => s.WithAttribute(fooBar.Key, fooBar.Value), s => s.Attributes, new[] { fooBar });
                yield return (s => s.WithAttributes(new[] { fooBar, bimBam }), s => s.Attributes, new[] { fooBar, bimBam });
                yield return (s => s.WithInputFile(fooAdoc), s => s.InputFiles, new[] { fooAdoc });
                yield return (s => s.WithInputFiles(new[] { fooAdoc, barAdoc }), s => s.InputFiles, new[] { fooAdoc, barAdoc });
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                return GetTestData().Select(x => new[] { (object)x.Item1, x.Item2, x.Item3 }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class RetValTestData : IEnumerable<object[]>
        {
            private IEnumerable<Func<AsciiDoctorJRunnerSettings, AsciiDoctorJRunnerSettings>> GetTestData()
            {
                // flags
                yield return s => s.WithVersion();
                yield return s => s.WithVerbose();
                yield return s => s.WithTimingsMode();
                yield return s => s.WithSectionNumbers();
                yield return s => s.WithRequire();
                yield return s => s.WithQuiet();
                yield return s => s.WithSuppressHeaderAndFooter();
                yield return s => s.WithCompact();

                // args
                yield return s => s.WithSafeMode(SafeMode.Safe);
                yield return s => s.WithERuby(ERuby.Erubis);
                yield return s => s.WithDocType(DocType.Inline);
                yield return s => s.WithTemplateEngine("some-engine");
                yield return s => s.WithTemplateDir(new DirectoryPath("/foo"));
                yield return s => s.WithOutputFile(new FilePath("/foo.pdf"));
                yield return s => s.WithLoadPath(new DirectoryPath("/foo"));
                yield return s => s.WithLoadPaths(new[] { new DirectoryPath("/foo"), new DirectoryPath("/bar") });
                yield return s => s.WithDestinationDir(new DirectoryPath("/foo"));
                yield return s => s.WithClassPath(new DirectoryPath("/foo"));
                yield return s => s.WithClassPaths(new[] { new DirectoryPath("/foo"), new DirectoryPath("/bar") });
                yield return s => s.WithBaseDir(new DirectoryPath("/foo"));
                yield return s => s.WithBuiltinBackend(BuiltinBackend.Html);
                yield return s => s.WithBackend("pdf");
                yield return s => s.WithAttribute("foo", "bar");
                yield return s => s.WithAttributes(new Dictionary<string, string> { { "foo", "bar" }, { "bim", "bam" } });
                yield return s => s.WithInputFile(new FilePath("/foo.adoc"));
                yield return s => s.WithInputFiles(new[] { new FilePath("/foo.adoc"), new FilePath("/bar.adoc") });
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                return GetTestData().Select(x => new[] { (object)x }).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
