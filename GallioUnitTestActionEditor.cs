using Inedo.BuildMaster;
using Inedo.BuildMaster.Extensibility.Actions;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;
using Inedo.Web.Controls;

namespace Inedo.BuildMasterExtensions.Gallio
{
    internal sealed class GallioUnitTestActionEditor : ActionEditorBase
    {
        private SourceControlFileFolderPicker txtTestFile;
        private ValidatingTextBox txtGroupName;

        /// <summary>
        /// Initializes a new instance of the <see cref="GallioUnitTestActionEditor" /> class.
        /// </summary>
        public GallioUnitTestActionEditor()
        {
        }

        public override void BindToForm(ActionBase extension)
        {
            this.EnsureChildControls();

            var gallioAction = (GallioUnitTestAction)extension;
            this.txtTestFile.Text = Util.Path2.Combine(gallioAction.OverriddenSourceDirectory, gallioAction.TestFile);
            this.txtGroupName.Text = gallioAction.GroupName;
        }
        public override ActionBase CreateFromForm()
        {
            this.EnsureChildControls();

            return new GallioUnitTestAction
            {
                OverriddenSourceDirectory = Util.Path2.GetDirectoryName(this.txtTestFile.Text),
                TestFile = Util.Path2.GetFileName(this.txtTestFile.Text),
                GroupName = this.txtGroupName.Text
            };
        }

        protected override void CreateChildControls()
        {
            this.txtTestFile = new SourceControlFileFolderPicker
            {
                Required = true,
                ServerId = this.ServerId,
                DisplayMode = SourceControlBrowser.DisplayModes.FoldersAndFiles
            };

            this.txtGroupName = new ValidatingTextBox
            {
                Width = 300
            };

            this.Controls.Add(
                 new FormFieldGroup("Test File",
                     "The assembly or project file to test against.",
                     false,
                     new StandardFormField("Test File:", this.txtTestFile)
                 ),
                 new FormFieldGroup("Group Name",
                     "The Group Name allows you to easily identify the unit test.",
                     true,
                     new StandardFormField("Group Name:", this.txtGroupName)
                 )
            );
        }
    }
}
