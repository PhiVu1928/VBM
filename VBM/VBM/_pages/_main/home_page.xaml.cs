using Acr.UserDialogs;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using Syncfusion.XForms.Border;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._home;
using VBM._pages._edit;
using VBM._pages._promo;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home_page : ContentPage
    {
        VisualContainer visualContainer;
        homevm vm { get; set; }
        public home_page()
        {
            InitializeComponent();
        }

        public async Task render()
        {
            vm = new homevm();
            this.BindingContext = vm;
            visualContainer = lsvMenu.GetVisualContainer();
        }

        private void ffimg_left_tapped(object sender, EventArgs e)
        {
            localdb._manager._contents._outline_page.open_flyout();
        }

        async void ffimg_right_tapped(object sender, EventArgs e)
        {
            var page = new _pages._login.login_page();
            await Navigation.PushAsync(page);
        }

        async void lbl_menu_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            try
            {
                using (var progress = UserDialogs.Instance.Loading("...", null, null, true, MaskType.Black))
                {
                    var menupage = new _menu.menu_page();
                    await Navigation.PushAsync(menupage,true);
                    menupage.render();
                    this.IsEnabled = true;
                };
            }
            catch (Exception ex)
            {
                //alert
                //log error
                this.IsEnabled = true;
            }
        }

        async void tocart_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await bd_cart.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                using (var progress = UserDialogs.Instance.Loading("...", null, null, true, MaskType.Black))
                {
                    var cart = new _pages._cart.cart_page();
                    await Navigation.PushAsync(cart);
                    cart.render();
                    this.IsEnabled = true;
                    await bd_cart.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }
            }
            catch
            {
                //alert
                //log error
                this.IsEnabled = true;
                await bd_cart.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void editEme_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as Grid;
            await ctr.ScaleTo(0.8, 1);
            ctr.BackgroundColor = (Color)Application.Current.Resources["vbmpagebackground"];

            var page = new editpage();
            await Navigation.PushAsync(page);
            page.render();

            ctr.BackgroundColor = Color.Transparent;
            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

        private void lsvMenu_scrollStateChanged(object sender, Syncfusion.ListView.XForms.ScrollStateChangedEventArgs e)
        {
            if (e.ScrollState == ScrollState.Dragging)
            {
                var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
                var index = (int)lastIndex / 3 + 1;
                foreach (var item in vm.titleGroups)
                {
                    if (item.index == index)
                    {
                        item.selected = true;
                    }
                    else
                    {
                        item.selected = false;
                    }
                }
                lsvTitle.ScrollTo((index-1) * 100, true);
            }
        }

        async void stlTitle_tapped(object sender, EventArgs e)
        {
            var ctr = sender as StackLayout;
            await ctr.ScaleTo(0.8, 1);

            titleGroup cv = (titleGroup)ctr.BindingContext;
            foreach (var item in vm.titleGroups)
            {
                if (item.index == cv.index)
                {
                    item.selected = true;
                }
                else
                {
                    item.selected = false;
                }
            }

            lsvTitle.ScrollTo((cv.index-1) * 100, true);
            lsvMenu.ScrollTo((cv.index - 1) * 240, true);

            await ctr.ScaleTo(1, 250);
        }

        async void promotion_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as SfBorder;
            await ctr.ScaleTo(0.8, 1);

            var page = new promoDetailPage();
            await Navigation.PushAsync(page);
            page.render();

            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

    }
}