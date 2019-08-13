using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cake.AsciiDoctorJ
{
    /// <summary>
    /// Extensions for fluent writing of <see cref="AsciiDoctorJRunnerSettings"/>
    /// </summary>
    public static class AsciiDoctorJRunnerSettingsExtensions
    {
        /// <summary>
        /// Add a list of files to <see cref="AsciiDoctorJRunnerSettings.InputFiles"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithInputFiles(this AsciiDoctorJRunnerSettings @this, IEnumerable<FilePath> files)
        {
            foreach (var f in files)
            {
                @this.InputFiles.Add(f);
            }
            return @this;
        }

        /// <summary>
        /// Add a single File to <see cref="AsciiDoctorJRunnerSettings.InputFiles"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithInputFile(this AsciiDoctorJRunnerSettings @this, FilePath file)
        {
            @this.InputFiles.Add(file);
            return @this;
        }

        /// <summary>
        /// Set <see cref="AsciiDoctorJRunnerSettings.Version"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithVersion(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Version = true;
            return @this;
        }

        /// <summary>
        /// set <see cref="AsciiDoctorJRunnerSettings.Verbose"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithVerbose(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Verbose = true;
            return @this;
        }

        /// <summary>
        /// set <see cref="AsciiDoctorJRunnerSettings.TimingsMode"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithTimingsMode(this AsciiDoctorJRunnerSettings @this)
        {
            @this.TimingsMode = true;
            return @this;
        }

        /// <summary>
        /// Set the <see cref="AsciiDoctorJRunnerSettings.TemplateEngine"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithTemplateEngine(this AsciiDoctorJRunnerSettings @this, string engine)
        {
            @this.TemplateEngine = engine;
            return @this;
        }

        /// <summary>
        /// Set the <see cref="AsciiDoctorJRunnerSettings.TemplateDir"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithTemplateDir(this AsciiDoctorJRunnerSettings @this, DirectoryPath dir)
        {
            @this.TemplateDir = dir;
            return @this;
        }

        /// <summary>
        /// Set <see cref="AsciiDoctorJRunnerSettings.SectionNumbers"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithSectionNumbers(this AsciiDoctorJRunnerSettings @this)
        {
            @this.SectionNumbers = true;
            return @this;
        }

        /// <summary>
        /// Set <see cref="AsciiDoctorJRunnerSettings.SafeMode"/>
        /// For possible values <seealso cref="SafeMode"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithSafeMode(this AsciiDoctorJRunnerSettings @this, SafeMode mode)
        {
            @this.SafeMode = mode;
            return @this;
        }

        /// <summary>
        /// Set <see cref="AsciiDoctorJRunnerSettings.Require"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithRequire(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Require = true;
            return @this;
        }

        /// <summary>
        /// Set <see cref="AsciiDoctorJRunnerSettings.Quiet"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithQuiet(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Quiet = true;
            return @this;
        }

        /// <summary>
        /// Set the <see cref="AsciiDoctorJRunnerSettings.Output"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithOutputFile(this AsciiDoctorJRunnerSettings @this, FilePath output)
        {
            @this.Output = output;
            return @this;
        }

        /// <summary>
        /// Set <see cref="AsciiDoctorJRunnerSettings.SuppressHeaderAndFooter"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithSuppressHeaderAndFooter(this AsciiDoctorJRunnerSettings @this)
        {
            @this.SuppressHeaderAndFooter = true;
            return @this;
        }

        /// <summary>
        /// Adds multiple paths to <see cref="AsciiDoctorJRunnerSettings.LoadPath"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithLoadPaths(this AsciiDoctorJRunnerSettings @this, IEnumerable<DirectoryPath> paths)
        {
            foreach (var p in paths)
            {
                @this.LoadPath.Add(p);
            }
            return @this;
        }

        /// <summary>
        /// Adds one path to <see cref="AsciiDoctorJRunnerSettings.LoadPath"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithLoadPath(this AsciiDoctorJRunnerSettings @this, DirectoryPath path)
        {
            @this.LoadPath.Add(path);
            return @this;
        }

        /// <summary>
        /// Sets <see cref="AsciiDoctorJRunnerSettings.ERuby"/>
        /// Possible values <seealso cref="ERuby"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="eRuby"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithERuby(this AsciiDoctorJRunnerSettings @this, ERuby eRuby)
        {
            @this.ERuby = eRuby;
            return @this;
        }

        /// <summary>
        /// Sets the <see cref="AsciiDoctorJRunnerSettings.DocType"/>
        /// Possible Values <seealso cref="DocType"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="docType"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithDocType(this AsciiDoctorJRunnerSettings @this, DocType docType)
        {
            @this.DocType = docType;
            return @this;
        }

        /// <summary>
        /// Sets the <see cref="AsciiDoctorJRunnerSettings.DestinationDir"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithDestinationDir(this AsciiDoctorJRunnerSettings @this, DirectoryPath dir)
        {
            @this.DestinationDir = dir;
            return @this;
        }

        /// <summary>
        /// Sets <see cref="AsciiDoctorJRunnerSettings.Compact"/> to true
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithCompact(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Compact = true;
            return @this;
        }

        /// <summary>
        /// Add multiple paths to <see cref="AsciiDoctorJRunnerSettings.ClassPath"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithClassPaths(this AsciiDoctorJRunnerSettings @this, IEnumerable<DirectoryPath> paths)
        {
            foreach (var p in paths)
            {
                @this.ClassPath.Add(p);
            }
            return @this;
        }

        /// <summary>
        /// Add one path to <see cref="AsciiDoctorJRunnerSettings.ClassPath"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithClassPath(this AsciiDoctorJRunnerSettings @this, DirectoryPath path)
        {
            @this.ClassPath.Add(path);
            return @this;
        }

        /// <summary>
        /// Sets the <see cref="AsciiDoctorJRunnerSettings.BaseDir"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithBaseDir(this AsciiDoctorJRunnerSettings @this, DirectoryPath dir)
        {
            @this.BaseDir = dir;
            return @this;
        }

        /// <summary>
        /// Set the <see cref="AsciiDoctorJRunnerSettings.Backend"/>
        /// Use this only if you need a non-builtin backend (e.g. "pdf")
        /// For builtin backends <seealso cref="WithBuiltinBackend(AsciiDoctorJRunnerSettings, BuiltinBackend)"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="backend"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithBackend(this AsciiDoctorJRunnerSettings @this, string backend)
        {
            @this.Backend = backend;
            return @this;
        }

        /// <summary>
        /// Set the <see cref="AsciiDoctorJRunnerSettings.Backend"/> to a builtin backend.
        /// Possible values <seealso cref="BuiltinBackend"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="backend"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithBuiltinBackend(this AsciiDoctorJRunnerSettings @this, BuiltinBackend backend)
        {
            @this.Backend = Enum.GetName(typeof(BuiltinBackend), backend).ToLower(CultureInfo.InvariantCulture);
            return @this;
        }

        /// <summary>
        /// Add multiple attributes to <see cref="AsciiDoctorJRunnerSettings.Attributes"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithAttribute(this AsciiDoctorJRunnerSettings @this, string key, string value)
        {
            @this.Attributes[key] = value;
            return @this;
        }

        /// <summary>
        /// Add one attribute to <see cref="AsciiDoctorJRunnerSettings.Attributes"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        public static AsciiDoctorJRunnerSettings WithAttributes(this AsciiDoctorJRunnerSettings @this, IEnumerable<KeyValuePair<string, string>> attrs)
        {
            foreach (var kvp in attrs)
            {
                @this.Attributes[kvp.Key] = kvp.Value;
            }
            return @this;
        }
    }
}