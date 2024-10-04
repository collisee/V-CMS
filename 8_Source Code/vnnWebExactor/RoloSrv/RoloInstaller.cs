using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace RoloSrv
{
    [RunInstaller(true)]
    public partial class RoloInstaller : Installer
    {
        public RoloInstaller()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}