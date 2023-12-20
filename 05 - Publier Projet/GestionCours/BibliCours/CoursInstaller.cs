using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BibliCours
{
	[RunInstaller(true)]
	public partial class CoursInstaller : System.Configuration.Install.Installer
	{
		public CoursInstaller()
		{
			InitializeComponent();
		}

		public override void Install(IDictionary stateSaver)
		{
			base.Install(stateSaver);
			string param = this.Context.Parameters["base"];
			File.WriteAllText("C:\\Users\\59011-82-04\\Desktop", param);
		}
	}
}
