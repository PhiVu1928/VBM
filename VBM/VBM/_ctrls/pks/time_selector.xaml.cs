using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM.ctrls.pks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class time_selector : PopupPage
    {
        timepk_vm timepk_Vm;
        public time_selector(timepk_vm timepk_Vm)
        {
            InitializeComponent();
            this.timepk_Vm = timepk_Vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            tpk.Time = timepk_Vm.curtime;
        }

        async void btnclose_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
        }

        async void btnok_Clicked(object sender, EventArgs e)
        {
            timepk_Vm.curtime = tpk.Time;
            await PopupNavigation.Instance.RemovePageAsync(this);
        }

    }
}