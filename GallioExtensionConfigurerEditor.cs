using System.Web.UI.WebControls;
using Inedo.BuildMaster.Extensibility.Configurers.Extension;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;

namespace Inedo.BuildMasterExtensions.Gallio
{
    /// <summary>
    /// Custom editor for the <see cref="GallioExtensionConfigurer"/> class.
    /// </summary>
    internal sealed class GallioExtensionConfigurerEditor : ExtensionConfigurerEditorBase
    {
        private TextBox txtEchoExePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="GallioExtensionConfigurerEditor" /> class.
        /// </summary>
        public GallioExtensionConfigurerEditor()
        {
        }

        public override void InitializeDefaultValues()
        {
            this.BindToForm(new GallioExtensionConfigurer());
        }
        public override void BindToForm(ExtensionConfigurerBase extension)
        {
            this.EnsureChildControls();

            var config = (GallioExtensionConfigurer)extension;
            this.txtEchoExePath.Text = config.GallioEchoPath;
        }
        public override ExtensionConfigurerBase CreateFromForm()
        {
            this.EnsureChildControls();

            return new GallioExtensionConfigurer
            {
                GallioEchoPath = this.txtEchoExePath.Text
            };
        }

        protected override void CreateChildControls()
        {
            this.txtEchoExePath = new TextBox
            {
                Width = 300
            };

            this.Controls.Add(
                new FormFieldGroup(
                    "Gallio.Echo.exe Location",
                    "The full path to the Gallio.Echo.exe Gallio test runner utility.",
                    true,
                    new StandardFormField(
                        "Gallio.Echo.exe Location:",
                        this.txtEchoExePath
                    )
                )
            );
        }
    }
}
