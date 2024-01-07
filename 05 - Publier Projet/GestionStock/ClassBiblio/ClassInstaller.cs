using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBiblio
{
	[RunInstaller(true)]
	public partial class ClassInstaller : System.Configuration.Install.Installer
	{
		public ClassInstaller()
		{
			InitializeComponent();
		}

		public override void Install(IDictionary stateSaver)
		{
			base.Install(stateSaver);
			string param = this.Context.Parameters["base"];
			File.WriteAllText("C:\\Users\\Toyger\\Bureau\\test.txt", param);
		}
	}
}
