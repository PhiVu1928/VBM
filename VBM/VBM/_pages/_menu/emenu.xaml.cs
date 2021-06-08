using Syncfusion.XForms.Border;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._pages._edit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class emenu : ContentView
    {
        public emenu()
        {
            InitializeComponent();
        }

        async void editEmenu_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as Grid;
            await ctr.ScaleTo(0.8, 1);
            ctr.BackgroundColor = (Color)Application.Current.Resources["vbmpagebackground"];

            var page = new editpage();
           await  Navigation.PushAsync(page);
            page.render();

            ctr.BackgroundColor = Color.Transparent;
            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }

    }
}