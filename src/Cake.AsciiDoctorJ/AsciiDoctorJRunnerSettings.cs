using System;
using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.AsciiDoctorJ
{
    /// <summary>
    /// The settings to configure the run of <see href="https://asciidoctor.org/">AsciiDoctorJ</see>.
    /// </summary>
    public class AsciiDoctorJRunnerSettings : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsciiDoctorJRunnerSettings"/> class.
        /// </summary>
        public AsciiDoctorJRunnerSettings()
        {
            InputFiles = new List<FilePath>();
            LoadPath = new List<DirectoryPath>();
            ClassPath = new List<DirectoryPath>();
            Attributes = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// display the version and runtime environment.
        /// <para>Default: false.</para>
        /// <para>corresponds to: -V, --version.</para>
        /// </summary>
        public bool Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// enable verbose mode.
        /// <para>Default: false.</para>
        /// <para>corresponds to: -v, --verbose.</para>
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// enable timings mode.
        /// <para>Default: false.</para>
        /// <para>corresponds to: -t, --timings.</para>
        /// </summary>
        public bool TimingsMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the
        /// template engine to use for the custom render templates (loads gem on demand).
        /// <para>corresponds to: -E, --template-engine.</para>
        /// </summary>
        public string TemplateEngine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the
        /// directory containing custom render templates the override the built-in set.
        /// <para>corresponds to:  -T, --template-dir.</para>
        /// </summary>
        public DirectoryPath TemplateDir { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// auto-number section titles in the HTML backend.
        /// <para>Default: false.</para>
        /// <para>corresponds to:  -n, --section-numbers.</para>
        /// </summary>
        public bool SectionNumbers { get; set; }

        /// <summary>
        /// Gets or sets a value to
        /// set safe mode level explicitly: [unsafe, safe, server, secure].
        /// <para>Default: UNSAFE.</para>
        /// <para>corresponds to: -S, --safe-mode.</para>
        /// </summary>
        public SafeMode? SafeMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// require the specified library before executing the processor.
        /// <para>corresponds to: -r, --require.</para>
        /// </summary>
        public bool Require { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// suppress warnings.
        /// <para>Default: false.</para>
        /// <para>corresponds to:  -q, --quiet.</para>
        /// </summary>
        public bool Quiet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the
        /// output file(default: based on input file path); use - to output to STDOUT.
        /// <para>corresponds to:  -o, --out-file.</para>
        /// </summary>
        public FilePath Output { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// suppress output of header and footer.
        /// <para>Default: false.</para>
        /// <para>corresponds to: -s, --no-header-footer.</para>
        /// </summary>
        public bool SuppressHeaderAndFooter { get; set; }

        /// <summary>
        /// Gets the list of input files to be processed.
        /// </summary>
        public IList<FilePath> InputFiles { get; }

        /// <summary>
        /// Gets the list of directories to add to the $LOAD_PATH.
        /// <para>corresponds to: -I, --load-path.</para>
        /// </summary>
        public IList<DirectoryPath> LoadPath { get; }

        /// <summary>
        /// Gets or sets a value to
        /// specify eRuby implementation to render built-in templates: [erb, erubis].
        /// <para>Default: erb.</para>
        /// <para>corresponds to: -e, --eruby.</para>
        /// </summary>
        public ERuby? ERuby { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the
        /// document type to use when rendering output: [article, book, inline].
        /// <para>Default: article.</para>
        /// <para>corresponds to:    -d, --doctype.</para>
        /// </summary>
        public DocType? DocType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the
        /// destination output directory.
        /// <para>Default: Directory of source file.</para>
        /// <para>corresponds to:    -D, --destination-dir.</para>
        /// </summary>
        public DirectoryPath DestinationDir { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// compact the output by removing blank lines.
        /// <para>Default: false.</para>
        /// <para>corresponds to:     -C, --compact.</para>
        /// </summary>
        public bool Compact { get; set; }

        /// <summary>
        /// Gets the list of directories to add to the classpath.
        /// <para>corresponds to:     -cp, -classpath, --classpath.</para>
        /// </summary>
        public IList<DirectoryPath> ClassPath { get; }

        /// <summary>
        /// Gets or sets a value indicating the
        /// base directory containing the document and resources.
        /// <para>Default: directory of source file.</para>
        /// <para>corresponds to:     -B, --base-dir.</para>
        /// </summary>
        public DirectoryPath BaseDir { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to
        /// set output format backend.
        /// <para>Default: html5.</para>
        /// <para>corresponds to:     -b, --backend.</para>
        /// </summary>
        public string Backend { get; set; }

        /// <summary>
        /// Gets the list of attributes to set on the document.
        /// <para>Default: [].</para>
        /// <para>corresponds to:    -a, --attribute.</para>
        /// </summary>
        public IDictionary<string, string> Attributes { get; }

        /// <summary>
        /// Processes the given settings and modifies the <see cref="ProcessArgumentBuilder"/>.
        /// </summary>
        /// <param name="args">The <see cref="ProcessArgumentBuilder"/> to modify.</param>
        /// <param name="environment">The <see cref="ICakeEnvironment"/>.</param>
        internal void Evaluate(ProcessArgumentBuilder args, ICakeEnvironment environment)
        {
            if (Version)
            {
                args.Append("--version");
            }

            if (Verbose)
            {
                args.Append("--verbose");
            }

            if (TimingsMode)
            {
                args.Append("--timings");
            }

            if (!string.IsNullOrEmpty(TemplateEngine))
            {
                args.Append("--template-engine " + TemplateEngine);
            }

            if (TemplateDir != null)
            {
                args.Append("--template-dir " + TemplateDir.MakeAbsolute(environment).FullPath.Quote());
            }

            if (SectionNumbers)
            {
                args.Append("--section-numbers");
            }

            if (SafeMode.HasValue)
            {
                // ReSharper disable PossibleNullReferenceException
                args.Append("--safe-mode " + Enum.GetName(typeof(SafeMode), SafeMode.Value).ToLowerInvariant());

                // ReSharper enable PossibleNullReferenceException
            }

            if (Require)
            {
                args.Append("--require");
            }

            if (Quiet)
            {
                args.Append("--quiet");
            }

            if (Output != null)
            {
                args.Append("--out-file " + Output.MakeAbsolute(environment).FullPath.Quote());
            }

            if (SuppressHeaderAndFooter)
            {
                args.Append("--no-header-footer");
            }

            foreach (var p in LoadPath)
            {
                args.Append("--load-path " + p.MakeAbsolute(environment).FullPath.Quote());
            }

            if (ERuby.HasValue)
            {
                // ReSharper disable PossibleNullReferenceException
                args.Append("--eruby " + Enum.GetName(typeof(ERuby), ERuby.Value).ToLowerInvariant());

                // ReSharper enable PossibleNullReferenceException
            }

            if (DocType.HasValue)
            {
                args.Append("--doctype " + Enum.GetName(typeof(DocType), DocType.Value).ToLowerInvariant());
            }

            if (DestinationDir != null)
            {
                // ReSharper disable PossibleNullReferenceException
                args.Append("--destination-dir " + DestinationDir.MakeAbsolute(environment).FullPath.Quote());

                // ReSharper enable PossibleNullReferenceException
            }

            if (Compact)
            {
                args.Append("--compact");
            }

            foreach (var p in ClassPath)
            {
                args.Append("--classpath " + p.MakeAbsolute(environment).FullPath.Quote());
            }

            if (BaseDir != null)
            {
                args.Append("--base-dir " + BaseDir.MakeAbsolute(environment).FullPath.Quote());
            }

            if (!string.IsNullOrEmpty(Backend))
            {
                args.Append("--backend " + Backend);
            }

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
