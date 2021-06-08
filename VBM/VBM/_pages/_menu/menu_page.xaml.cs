using Acr.UserDialogs;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VBM._app_objs._menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menu_page : ContentPage
    {
        VisualContainer visualContainer;
        menuvm vm { get; set; }
        public menu_page()
        {
            InitializeComponent();
        }

        public async Task render()
        {
            vm = new menuvm();
            this.BindingContext = vm;
            busyindicator.IsBusy = false;
            busyindicator.IsVisible = false;
            visualContainer = lsvMenu.GetVisualContainer();
            //visualContainer.ScrollRows.Changed += ScrollRows_Changed;
            lsvMenu.ScrollStateChanged += ListView_ScrollStateChanged;
        }

        private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
        {
            var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
            var index = (int)lastIndex / 6 + 1;
            changeTitle(index);
        }

        private void ListView_ScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {
            if (e.ScrollState == ScrollState.Dragging)
            {
                var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
                var index = (int)lastIndex / 6 + 1;
                changeTitle(index);
            }
        }

        void changeTitle(int index)
        {
            foreach (var item in vm.titleGroups)
            {
                if (item.index == index)
                {
                    item.selected = true;
                    lsvTitles.ScrollTo((index - 1) * 107, true);
                }
                else
                {
                    item.selected = false;
                }
            }
        }

        async void tocart_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            try
            {
                using (var progress = UserDialogs.Instance.Loading("...", null, null, true, MaskType.Black))
                {
                    var cart = new _pages._cart.cart_page();
                    await Navigation.PushAsync(cart);
                    cart.render();
                    this.IsEnabled = true;
                }
            }
            catch
            {
                //alert
                //log error
                await this.FadeTo(1, 100);
            }
        }

        async void stlTitle_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as StackLayout;
            await ctr.ScaleTo(0.8, 1);
            var cv = (titleGroup)ctr.BindingContext;

            var startIndex = vm.rowsRender.Count;
            var index = cv.index;

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

            if (vm.rowsRender.Count < index * 6)
            {
                busyindicator.IsVisible = true;
                for (int i = startIndex; i < index * 6; i++)
                {
                    vm.rowsRender.Add(new rowEmesRender(i));
                }
            }

            busyindicator.IsVisible = false;
            lsvTitles.ScrollTo((index-1) * 107, true);
            lsvMenu.ScrollTo((index-1) * 220, true);

            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

    }
}