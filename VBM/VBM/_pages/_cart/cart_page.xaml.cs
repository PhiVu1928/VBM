using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._cart;
using VBM._pages._edit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._cart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cart_page : ContentPage
    {

        cartvm vm { get; set; }

        public cart_page()
        {
            InitializeComponent();
        }

        public async Task render()
        {
            vm = new cartvm();
            this.BindingContext = vm;
            busyindicator.IsBusy = false;
            busyindicator.IsVisible = false;
        }

        private void ffimg_turnback_tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        async void lblchange_add_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await lbl_change_add.ScaleTo(0.9, 1);
            await this.FadeTo(0.8, 1);
            try
            {
                using (var progress = UserDialogs.Instance.Loading("...", null, null, true, MaskType.Black))
                {
                    var change_page = new _change_address.change_add_page();
                    await Navigation.PushAsync(change_page);
                    Task.Run(() =>change_page.lazyview_loading());
                    this.IsEnabled = true;
                    await lbl_change_add.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }
            }
            catch
            {
                //alert
                //log error
                this.IsEnabled = true;
                await lbl_change_add.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void selectDrinkCb_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as Grid;
            ctr.BackgroundColor = (Color)Application.Current.Resources["vbmpagebackground"];

            var page = new _drinkCb.cbDrink();
            await Navigation.PushAsync(page);
            page.render();

            ctr.BackgroundColor = Color.Transparent;
            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

        async void toEditPage_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as Grid;
            await ctr.ScaleTo(0.8, 1);

            var page = new editpage();
            await Navigation.PushAsync(page);
            page.render();

            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

    }
}