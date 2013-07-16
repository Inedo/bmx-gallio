using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Inedo.BuildMaster.Extensibility;
using Inedo.BuildMaster.Extensibility.Configurers.Extension;
using Inedo.BuildMasterExtensions.Gallio;

[assembly: AssemblyTitle("Gallio")]
[assembly: AssemblyDescription("Contains a unit testing action for executing the Gallio test runner.")]

[assembly: ComVisible(false)]
[assembly: AssemblyCompany("Inedo, LLC")]
[assembly: AssemblyProduct("BuildMaster")]
[assembly: AssemblyCopyright("Copyright © 2008 - 2012")]
[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("0.0")]
[assembly: BuildMasterAssembly]
[assembly: CLSCompliant(false)]
[assembly: RequiredBuildMasterVersion("3.0.0")]
[assembly: ExtensionConfigurer(typeof(GallioExtensionConfigurer))]