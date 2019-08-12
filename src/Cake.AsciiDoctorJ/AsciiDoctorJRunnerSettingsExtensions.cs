using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cake.AsciiDoctorJ
{
    public static class AsciiDoctorJRunnerSettingsExtensions
    {
        public static AsciiDoctorJRunnerSettings WithInputFiles(this AsciiDoctorJRunnerSettings @this, IEnumerable<FilePath> files)
        {
            foreach (var f in files)
            {
                @this.InputFiles.Add(f);
            }
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithInputFile(this AsciiDoctorJRunnerSettings @this, FilePath file)
        {
            @this.InputFiles.Add(file);
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithVersion(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Version = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithVerbose(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Verbose = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithTimingsMode(this AsciiDoctorJRunnerSettings @this)
        {
            @this.TimingsMode = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithTemplateEngine(this AsciiDoctorJRunnerSettings @this, string engine)
        {
            @this.TemplateEngine = engine;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithTemplateDir(this AsciiDoctorJRunnerSettings @this, DirectoryPath dir)
        {
            @this.TemplateDir = dir;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithSectionNumbers(this AsciiDoctorJRunnerSettings @this)
        {
            @this.SectionNumbers = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithSafeMode(this AsciiDoctorJRunnerSettings @this, SafeMode mode)
        {
            @this.SafeMode = mode;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithRequire(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Require = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithQuiet(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Quiet = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithOutputFile(this AsciiDoctorJRunnerSettings @this, FilePath output)
        {
            @this.Output = output;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithSuppressHeaderAndFooter(this AsciiDoctorJRunnerSettings @this)
        {
            @this.SuppressHeaderAndFooter = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithLoadPaths(this AsciiDoctorJRunnerSettings @this, IEnumerable<DirectoryPath> paths)
        {
            foreach (var p in paths)
            {
                @this.LoadPath.Add(p);
            }
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithLoadPath(this AsciiDoctorJRunnerSettings @this, DirectoryPath path)
        {
            @this.LoadPath.Add(path);
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithERuby(this AsciiDoctorJRunnerSettings @this, ERuby eRuby)
        {
            @this.ERuby = eRuby;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithDocType(this AsciiDoctorJRunnerSettings @this, DocType docType)
        {
            @this.DocType = docType;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithDestinationDir(this AsciiDoctorJRunnerSettings @this, DirectoryPath dir)
        {
            @this.DestinationDir = dir;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithCompact(this AsciiDoctorJRunnerSettings @this)
        {
            @this.Compact = true;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithClassPaths(this AsciiDoctorJRunnerSettings @this, IEnumerable<DirectoryPath> paths)
        {
            foreach (var p in paths)
            {
                @this.ClassPath.Add(p);
            }
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithClassPath(this AsciiDoctorJRunnerSettings @this, DirectoryPath path)
        {
            @this.ClassPath.Add(path);
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithBaseDir(this AsciiDoctorJRunnerSettings @this, DirectoryPath dir)
        {
            @this.BaseDir = dir;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithBackend(this AsciiDoctorJRunnerSettings @this, string backend)
        {
            @this.Backend = backend;
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithBuiltinBackend(this AsciiDoctorJRunnerSettings @this, BuiltinBackend backend)
        {
            @this.Backend = Enum.GetName(typeof(BuiltinBackend), backend).ToLower(CultureInfo.InvariantCulture);
            return @this;
        }

        public static AsciiDoctorJRunnerSettings WithAttribute(this AsciiDoctorJRunnerSettings @this, string key, string value)
        {
            @this.Attributes[key] = value;
            return @this;
        }

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