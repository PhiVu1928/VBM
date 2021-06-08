using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._change_address
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class change_add_page : ContentPage
    {
        public change_add_page()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        public void lazyview_loading()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                lazy_map.LoadViewAsync();
            });
        }

        private void ffimg_turnback_tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
    }
}