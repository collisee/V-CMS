using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace RoloService
{
    [RunInstaller(true)]
    public partial class RoloInstaller : Installer
    {
        public RoloInstaller()
        {
            InitializeComponent();
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //# Service Account Information
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //# Service Information

            serviceInstaller.DisplayName = "Rolo service";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            //# set in the constructor of WindowsService.cs

            serviceInstaller.ServiceName = "RoloService";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);

        }
    }
}