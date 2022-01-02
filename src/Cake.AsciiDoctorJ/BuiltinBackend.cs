namespace Cake.AsciiDoctorJ;

/// <summary>
/// The builtin backends. Use <see cref="AsciiDoctorJRunnerSettingsExtensions.WithBuiltinBackend(AsciiDoctorJRunnerSettings, BuiltinBackend)"/>
/// to use these values to modify <see cref="AsciiDoctorJRunnerSettings.Backend"/>.
/// </summary>
public enum BuiltinBackend
{
    /// <summary>
    /// html backend
    /// </summary>
    Html,

    /// <summary>
    /// html5 backend
    /// </summary>
    Html5,

    /// <summary>
    /// xhtml backend
    /// </summary>
    Xhtml,

    /// <summary>
    /// xhtml5 backend
    /// </summary>
    Xhtml5,

    /// <summary>
    /// docbook backend
    /// </summary>
    DocBook,

    /// <summary>
    /// docbook5 backend
    /// </summary>
    DocBook5,

    /// <summary>
    /// manpage backend
    /// </summary>
    Manpage,
}
