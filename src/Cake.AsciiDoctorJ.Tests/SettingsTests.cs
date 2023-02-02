using Shouldly;

using Xunit;

using System.Collections;
using System.Collections.Generic;
using System;

using Cake.AsciiDoctorJ.Tests.Fixtures;

using System.Linq;

using Cake.Core.IO;

namespace Cake.AsciiDoctorJ.Tests;

public class SettingsTests
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void Should_convert_all_setters_to_arguments(Action<AsciiDoctorJRunnerSettings> setFlag,
        string expectedParam)
    {
        var fixture = new AsciiDoctorJRunnerSettingsExtensionsFixture();
        var sut = new AsciiDoctorJRunnerSettings();

        setFlag(sut);

        var actual = fixture.EvaluateArgs(sut);
        actual.ShouldContain(expectedParam);
    }

    private class TestData : IEnumerable<object[]>
    {
        private IEnumerable<(Action<AsciiDoctorJRunnerSettings>, string)> GetTestData()
        {
            // flags
            yield return (s => s.Version = true, "--version");
            yield return (s => s.Verbose = true, "--verbose");
            yield return (s => s.TimingsMode = true, "--timings");
            yield return (s => s.SectionNumbers = true, "--section-numbers");
            yield return (s => s.Quiet = true, "--quiet");
            yield return (s => s.SuppressHeaderAndFooter = true, "--no-header-footer");
            yield return (s => s.Compact = true, "--compact");

            // safemode-arg
            yield return (s => s.SafeMode = SafeMode.Safe, "--safe-mode safe");
            yield return (s => s.SafeMode = SafeMode.Unsafe, "--safe-mode unsafe");
            yield return (s => s.SafeMode = SafeMode.Secure, "--safe-mode secure");
            yield return (s => s.SafeMode = SafeMode.Server, "--safe-mode server");

            // eruby-arg
            yield return (s => s.ERuby = ERuby.Erb, "--eruby erb");
            yield return (s => s.ERuby = ERuby.Erubis, "--eruby erubis");

            // doctype-arg
            yield return (s => s.DocType = DocType.Article, "--doctype article");
            yield return (s => s.DocType = DocType.Book, "--doctype book");
            yield return (s => s.DocType = DocType.Inline, "--doctype inline");

            // misc args
            yield return (s => s.TemplateEngine = "some-engine", "--template-engine some-engine");
            yield return (s => s.TemplateDir = new DirectoryPath("/foo"), "--template-dir \"/foo\"");
            yield return (s => s.Output = new FilePath("/foo.pdf"), "--out-file \"/foo.pdf\"");
            yield return (s => s.LoadPath.Add(new DirectoryPath("/foo")), "--load-path \"/foo\"");
            yield return (s => s.DestinationDir = new DirectoryPath("/foo"), "--destination-dir \"/foo\"");
            yield return (s => s.ClassPath.Add(new DirectoryPath("/foo")), "--classpath \"/foo\"");
            yield return (s => s.BaseDir = new DirectoryPath("/foo"), "--base-dir \"/foo\"");
            yield return (s => s.Backend = "pdf", "--backend pdf");
            yield return (s => s.Attributes.Add("foo", "bar"), "--attribute foo=bar");
            yield return (s => s.InputFiles.Add(new FilePath("/foo.adoc")), "\"/foo.adoc\"");
            yield return (s => s.Require.Add("asciidoctor-diagram"), "--require asciidoctor-diagram");
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return GetTestData().Select(x => new[] { (object)x.Item1, x.Item2 }).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
