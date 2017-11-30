using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Service
{
    [RunInstaller(true)]
    public class ServiceInstaller : Installer
    {
        public ServiceInstaller()
        {
            Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem,
                Username = null,
                Password = null
            });

            Installers.Add(new System.ServiceProcess.ServiceInstaller
            {
                DisplayName = "My New C# Windows Service",
                StartType = ServiceStartMode.Automatic,
                ServiceName = "My Windows Service"
            });
        }
    }
}