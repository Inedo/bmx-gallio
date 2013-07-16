using System;
using System.IO;
using System.Linq;
using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Configurers.Extension;
using Inedo.BuildMaster.Web;
using Microsoft.Win32;

namespace Inedo.BuildMasterExtensions.Gallio
{
    /// <summary>
    /// Contains global configuration for the Gallio extension.
    /// </summary>
    [CustomEditor(typeof(GallioExtensionConfigurerEditor))]
    public sealed class GallioExtensionConfigurer : ExtensionConfigurerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GallioExtensionConfigurer" /> class.
        /// </summary>
        public GallioExtensionConfigurer()
        {
            using (var gallioKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Gallio.org\Gallio", false) ?? Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Gallio.org\Gallio", false))
            {
                if (gallioKey == null)
                    return;

                var subkeyNames = gallioKey
                    .GetSubKeyNames()
                    .OrderByDescending(TryParseVersion);

                foreach (var subKeyName in subkeyNames)
                {
                    using (var versionKey = gallioKey.OpenSubKey(subKeyName, false))
                    {
                        var gallioDirectory = versionKey.GetValue("InstallationFolder") as string;
                        if (string.IsNullOrEmpty(gallioDirectory))
                            continue;

                        this.GallioEchoPath = Path.Combine(gallioDirectory, @"bin\Gallio.Echo.exe");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the full path to the Gallio.Echo.exe file.
        /// </summary>
        [Persistent]
        public string GallioEchoPath { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Empty;
        }

        private static Version TryParseVersion(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            try
            {
                return new Version(s);
            }
            catch
            {
                return null;
            }
        }
    }
}
