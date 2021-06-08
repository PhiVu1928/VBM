using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class outline_page : FlyoutPage
    {
        public outline_page()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            localdb._manager = new _app_objs._general.app_manager();
            localdb._manager._contents._outline_page = this;
            Task.Run(() =>
            {
                localdb._manager._cached.get_cached_values();
                localdb._manager._tools.start_prepare_data();
            });
        }

        public async void start_app()
        {
            var hpage = new _pages._main.home_page();
            flypage.Detail = hpage;
            hpage.render();
            var flo = new _pages._main.profile_page();
            flo.Title = "vbm";
            flypage.Flyout = flo;
        }

        public void open_flyout()
        {
            flypage.IsPresented = true;
        }

    }
}