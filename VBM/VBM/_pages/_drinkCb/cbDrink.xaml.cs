using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._edit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._drinkCb
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cbDrink : ContentPage
    {
        drinkCbVM vm { get; set; }

        public cbDrink()
        {
            InitializeComponent();
        }

        public async Task render()
        {
            vm = new drinkCbVM();
            this.BindingContext = vm;
        }

        private void drink_tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}