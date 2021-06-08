using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            #if DEBUG
            HotReloader.Current.Run(this);
            #endif
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDIzMzcyQDMxMzkyZTMxMmUzMFd5Q3VEbkFlWFIzY0F3bExsZlRlK2ExSzREZFVHdUxHSTlJL002eDQreEU9");
            MainPage = new NavigationPage(new _pages._main.outline_page());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
