using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._edit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class nutritionInfoPage : ContentPage
    {
        public nutritionInfoPage()
        {
            InitializeComponent();
        }

        void back_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
             Navigation.RemovePage(this);
            this.IsEnabled = true;
        }

    }
}