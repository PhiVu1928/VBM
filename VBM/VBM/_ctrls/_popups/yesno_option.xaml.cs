using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._ctrls._popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class yesno_option : Popup
    {
        public yesno_option()
        {
            InitializeComponent();
        }

        private void btnNo_Clicked(object sender, EventArgs e)
        {
            Dismiss("no");
        }

        private void btnYes_Clicked(object sender, EventArgs e)
        {
            Dismiss("yes");
        }

    }
}