using Syncfusion.XForms.Border;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._edit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._edit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editpage : ContentPage
    {
        public edit1VM vm { get; set; }

        public editpage()
        {
            InitializeComponent();
        }

        public async Task render()
        {
            vm = new edit1VM();
            this.BindingContext = vm;
        }

        private void btn_close_clicked(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        async void toCart_clicked(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as SfButton;
            await ctr.ScaleTo(0.8, 1);

            await Navigation.PopAsync();

            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

        async void toSelectDrinkCb_tapped(object sender, EventArgs e)
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

        async void toNutritionInfo_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as SfBorder;
            await ctr.ScaleTo(0.8, 1);

            await Navigation.PushAsync(new nutritionInfoPage());

            await ctr.ScaleTo(1,250);
            this.IsEnabled = true;
        }

    }
}