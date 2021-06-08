using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._promoMultiSteps;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._promo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class promoDetailPage : ContentPage
    {
        multiStepsVM vm { get; set; }

        public promoDetailPage()
        {
            InitializeComponent();
        }

        public async Task render()
        {
            vm = new multiStepsVM();
            this.BindingContext = vm;
        }

        async void selectEmenu_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as Grid;
            await ctr.ScaleTo(0.8, 1);

            if (vm.step < 3)
            {
                vm.step++;
            }
            else
            {
                var page = new xacNhanPopup();
                await Navigation.ShowPopupAsync(page);
                if (page.isXacNhan)
                {
                    Navigation.RemovePage(this);
                }
            }

            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;

        }

        async void lblPreStep_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as Label;
            await ctr.ScaleTo(0.8, 1);

            if (vm.step > 1)
            {
                vm.step--;
            }

            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

    }
}