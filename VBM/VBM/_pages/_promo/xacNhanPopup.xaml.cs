using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._promo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class xacNhanPopup : Popup
    {

        public bool isXacNhan { get; set; }

        public xacNhanPopup()
        {
            InitializeComponent();
        }

        private void btnDone_Clicked(object sender, EventArgs e)
        {
            isXacNhan = true;
            Dismiss("xn");
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Dismiss("xn");
        }

    }
}