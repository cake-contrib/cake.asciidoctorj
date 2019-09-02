namespace Cake.AsciiDoctorJ
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

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
        /// Gets or sets a value indicating whether to:
        /// display the version and runtime environment
        /// Default: false
        /// corresponds to: -V, --version.
        /// </summary>
        public bool Version { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// enable verbose mode(default: false)
        /// Default: false
        /// corresponds to: -v, --verbose.
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// enable timings mode
        /// Default: false
        /// corresponds to: -t, --timings.
        /// </summary>
        public bool TimingsMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating:
        /// template engine to use for the custom render templates(loads gem on demand)
        /// corresponds to: -E, --template-engine.
        /// </summary>
        public string TemplateEngine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating:
        /// directory containing custom render templates the override the built-in set
        /// corresponds to:  -T, --template-dir.
        /// </summary>
        public DirectoryPath TemplateDir { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// auto-number section titles in the HTML backend; disabled by default
        /// Default: false
        /// corresponds to:  -n, --section-numbers.
        /// </summary>
        public bool SectionNumbers { get; set; }

        /// <summary>
        /// Gets or sets a value to:
        /// set safe mode level explicitly: [unsafe, safe, server, secure]
        /// Default: UNSAFE
        /// corresponds to: -S, --safe-mode.
        /// </summary>
        public SafeMode? SafeMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// require the specified library before executing the processor
        /// corresponds to: -r, --require.
        /// </summary>
        public bool Require { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// suppress warnings
        /// Default: false
        /// corresponds to:  -q, --quiet.
        /// </summary>
        public bool Quiet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating:
        /// output file(default: based on input file path); use - to output to STDOUT
        /// corresponds to:  -o, --out-file.
        /// </summary>
        public FilePath Output { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// suppress output of header and footer
        /// Default: false
        /// corresponds to: -s, --no-header-footer.
        /// </summary>
        public bool SuppressHeaderAndFooter { get; set; }

        /// <summary>
        /// Gets the list of input files to be processed.
        /// </summary>
        public IList<FilePath> InputFiles { get; private set; }

        /// <summary>
        /// Gets the list of directories to add to the $LOAD_PATH.
        /// corresponds to: -I, --load-path.
        /// </summary>
        public IList<DirectoryPath> LoadPath { get; private set; }

        /// <summary>
        /// Gets or sets a value to:
        /// specify eRuby implementation to render built-in templates: [erb, erubis]
        /// Default: erb
        /// corresponds to: -e, --eruby.
        /// </summary>
        public ERuby? ERuby { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the:
        /// document type to use when rendering output: [article, book, inline]
        /// Default: article
        /// corresponds to:    -d, --doctype.
        /// </summary>
        public DocType? DocType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating:
        /// destination output directory(default: directory of source file)
        /// corresponds to:    -D, --destination-dir.
        /// </summary>
        public DirectoryPath DestinationDir { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// compact the output by removing blank lines
        /// Default: false
        /// corresponds to:     -C, --compact.
        /// </summary>
        public bool Compact { get; set; }

        /// <summary>
        /// Gets the list of directories to add to the classpath.
        /// corresponds to:     -cp, -classpath, --classpath.
        /// </summary>
        public IList<DirectoryPath> ClassPath { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating:
        /// base directory containing the document and resources
        /// Default: directory of source file.
        /// corresponds to:     -B, --base-dir.
        /// </summary>
        public DirectoryPath BaseDir { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to:
        /// set output format backend.
        /// Default: html5
        /// corresponds to:     -b, --backend.
        /// </summary>
        public string Backend { get; set; }

        /// <summary>
        /// Gets the list of attributes to set on the document
        /// Default: []
        /// corresponds to:    -a, --attribute.
        /// </summary>
        public IDictionary<string, string> Attributes { get; private set; }

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
                args.Append("--safe-mode " + Enum.GetName(typeof(SafeMode), SafeMode.Value).ToLower(CultureInfo.InvariantCulture));
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
                args.Append("--eruby " + Enum.GetName(typeof(ERuby), ERuby.Value).ToLower(CultureInfo.InvariantCulture));
            }

            if (DocType.HasValue)
            {
                args.Append("--doctype " + Enum.GetName(typeof(DocType), DocType.Value).ToLower(CultureInfo.InvariantCulture));
            }

            if (DestinationDir != null)
            {
                args.Append("--destination-dir " + DestinationDir.MakeAbsolute(environment).FullPath.Quote());
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
