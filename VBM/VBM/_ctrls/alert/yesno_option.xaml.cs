using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM.ctrls.alert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class yesno_option : PopupPage
    {
        private readonly Action<bool> setResultAction;
        string body;
        string btntext;
        int type;

        public yesno_option(string a, string b, int type, Action<bool> act)
        {
            //1:ok
            //2:warning
            InitializeComponent();
            setResultAction = act;
            body = a;
            btntext = b;
            this.type = type;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lblmsg.Text = body;
            btnOK.Text = btntext;
            this.BindingContext = new yesnopopup_vm(type);
        }

        async void btnOK_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            setResultAction?.Invoke(false);
        }

    }

    public class yesnopopup_vm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void PChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public yesnopopup_vm(int type)
        {
            //1:ok
            //2:warning
            if (type == 1)
            {
                color = (Color)Application.Current.Resources["vbmlightgreen"];
                source = "okicon";
            }
            if (type == 2)
            {
                color = (Color)Application.Current.Resources["vbmwarning"];
                source = "waringicon";
            }
        }

        public Color color { get; set; }
        public string source { get; set; }

    }


}