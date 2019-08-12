using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cake.AsciiDoctorJ
{
    /*
       Options:
    -h, --help
       show this message
       Default: false

        --trace
       include backtrace information on errors (default: false)
       Default: false

     */

    /// <summary>
    /// The settings for AsciiDoctorJ
    /// </summary>
    public class AsciiDoctorJRunnerSettings : ToolSettings
    {
        /// <summary>
        /// Default
        /// </summary>
        public AsciiDoctorJRunnerSettings()
        {
            InputFiles = new List<FilePath>();
            LoadPath = new List<DirectoryPath>();
            ClassPath = new List<DirectoryPath>();
            Attributes = new Dictionary<string, string>();
        }

        /// <summary>
        /// -V, --version
        ///    display the version and runtime environment
        ///    Default: false
        /// </summary>
        public bool Version { get; set; }

        /// <summary>
        ///  -v, --verbose
        ///     enable verbose mode(default: false)
        ///     Default: false
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// -t, --timings
        ///   enable timings mode(default: false)
        ///   Default: false
        /// </summary>
        public bool TimingsMode { get; set; }

        /// <summary>
        ///     -E, --template-engine
        /// template engine to use for the custom render templates(loads gem on demand)
        /// </summary>
        public string TemplateEngine { get; set; }

        /// <summary>
        ///  -T, --template-dir
        ///     directory containing custom render templates the override the built-in set
        /// </summary>
        public DirectoryPath TemplateDir { get; set; }

        /// <summary>
        ///  -n, --section-numbers
        ///     auto-number section titles in the HTML backend; disabled by default
        ///     Default: false
        /// </summary>
        public bool SectionNumbers { get; set; }

        /// <summary>
        ///  -S, --safe-mode
        ///     set safe mode level explicitly: [unsafe, safe, server, secure] (default:
        ///     unsafe)
        ///     Default: UNSAFE
        /// </summary>
        public SafeMode? SafeMode { get; set; }

        /// <summary>
        ///  -r, --require
        ///     require the specified library before executing the processor(using
        ///     require)
        /// </summary>
        public bool Require { get; set; }

        /// <summary>
        ///  -q, --quiet
        ///     suppress warnings(default: false)
        ///     Default: false
        /// </summary>
        public bool Quiet { get; set; }

        /// <summary>
        ///  -o, --out-file
        ///     output file(default: based on input file path); use - to output to
        ///     STDOUT
        /// </summary>
        public FilePath Output { get; set; }

        /// <summary>
        ///     -s, --no-header-footer
        ///     suppress output of header and footer(default: false)
        ///     Default: false
        /// </summary>
        public bool SuppressHeaderAndFooter { get; set; }

        public IList<FilePath> InputFiles { get; private set; }

        /// <summary>
        ///     -I, --load-path
        ///     add a directory to the $LOAD_PATH may be specified more than once
        /// </summary>
        public IList<DirectoryPath> LoadPath { get; private set; }

        /// <summary>
        ///     -e, --eruby
        ///     specify eRuby implementation to render built-in templates: [erb, erubis]
        ///     (default: erb)
        ///     Default: erb
        /// </summary>
        public ERuby? ERuby { get; set; }

        /// <summary>
        ///     -d, --doctype
        ///     document type to use when rendering output: [article, book, inline]
        ///     (default: article)
        /// </summary>
        public DocType? DocType { get; set; }

        /// <summary>
        ///     -D, --destination-dir
        ///     destination output directory(default: directory of source file)
        /// </summary>
        public DirectoryPath DestinationDir { get; set; }

        /// <summary>
        ///     -C, --compact
        ///     compact the output by removing blank lines(default: false)
        ///     Default: false
        /// </summary>
        public bool Compact { get; set; }

        /// <summary>
        ///     -cp, -classpath, --classpath
        ///     add a directory to the classpath may be specified more than once
        /// </summary>
        public IList<DirectoryPath> ClassPath { get; private set; }

        /// <summary>
        ///     -B, --base-dir
        ///     base directory containing the document and resources(default: directory
        ///     of source file)
        /// </summary>
        public DirectoryPath BaseDir { get; set; }

        /// <summary>
        ///     -b, --backend
        ///     set output format backend(default: html5)
        ///     Default: html5
        /// </summary>
        public string Backend { get; set; }

        /// <summary>
        ///    -a, --attribute
        ///    a list of attributes, in the form key or key=value pair, to set on the
        ///    document
        ///    Default: []
        /// </summary>
        public IDictionary<string, string> Attributes { get; private set; }

        /// <summary>
        /// Processes the given settings and modifies the <see cref="ProcessArgumentBuilder"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="environment"></param>
        internal void Evaluate(ProcessArgumentBuilder args, ICakeEnvironment environment)
        {
            if (Version)
            { args.Append("--version"); }

            if (Verbose)
            { args.Append("--verbose"); }

            if (TimingsMode)
            { args.Append("--timings"); }

            if (!string.IsNullOrEmpty(TemplateEngine))
            {
                args.Append("--template-engine " + TemplateEngine);
            }

            if (TemplateDir != null)
            {
                args.Append("--template-dir " + TemplateDir.MakeAbsolute(environment).FullPath.Quote());
            }

            if (SectionNumbers)
            { args.Append("--section-numbers"); }

            if (SafeMode.HasValue)
            {
                args.Append("--safe-mode " + Enum.GetName(typeof(SafeMode), SafeMode.Value).ToLower(CultureInfo.InvariantCulture));
            }

            if (Require)
            { args.Append("--require"); }

            if (Quiet)
            { args.Append("--quiet"); }

            if (Output != null)
            {
                args.Append("--out-file " + Output.MakeAbsolute(environment).FullPath.Quote());
            }

            if (SuppressHeaderAndFooter)
            { args.Append("--no-header-footer"); }

            foreach (var p in LoadPath)
            { args.Append("--load-path " + p.MakeAbsolute(environment).FullPath.Quote()); }

            if (ERuby.HasValue)
            {
                { args.Append("--eruby " + Enum.GetName(typeof(ERuby), ERuby.Value).ToLower(CultureInfo.InvariantCulture)); }
            }

            if (DocType.HasValue)
            {
                { args.Append("--doctype " + Enum.GetName(typeof(DocType), DocType.Value).ToLower(CultureInfo.InvariantCulture)); }
            }

            if (DestinationDir != null)
            {
                args.Append("--destination-dir " + DestinationDir.MakeAbsolute(environment).FullPath.Quote());
            }

            if (Compact)
            { args.Append("--compact"); }

            foreach (var p in ClassPath)
            {
                args.Append("--classpath " + p.MakeAbsolute(environment).FullPath.Quote());
            }

            if (BaseDir != null)
            {
                args.Append("--base-dir " + BaseDir.MakeAbsolute(environment).FullPath.Quote());
            }

            if (!string.IsNullOrEmpty(Backend))
            { args.Append("--backend " + Backend); }

            foreach (var kvp in Attributes)
            {
                args.Append($"--attribute {kvp.Key}={kvp.Value}");
            }

            // input is last!
            foreach (var f in InputFiles)
            {
                args.Append(f.MakeAbsolute(environment).FullPath.Quote());
            }
        }
    }
}