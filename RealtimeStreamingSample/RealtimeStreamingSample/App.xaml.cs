using Microsoft.Extensions.DependencyInjection;

namespace RealtimeStreamingSample
{
    public partial class App : Application
    {
        public App()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JHaF1cXmhOYVZpR2NbeU5xdl9EaFZTRGYuP1ZhSXxVdkNjXH9ecnxXQ2VUVk19XEE=");
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}