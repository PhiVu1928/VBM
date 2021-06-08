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
    public partial class date_selector : PopupPage
    {
        datepk_vm Datepk_Vm;
        DateTime sd;
        DateTime ed;
        public date_selector(datepk_vm Datepk_Vm, DateTime sd, DateTime ed)
        {
            InitializeComponent();
            this.Datepk_Vm = Datepk_Vm;
            this.sd = sd;
            this.ed = ed;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dpk.Date = Datepk_Vm.curdate;
            dpk.MinimumDate = sd;
            dpk.MaximumDate = ed;
        }

        async void btnclose_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
        }

        async void btnok_Clicked(object sender, EventArgs e)
        {
            Datepk_Vm.curdate = dpk.Date;
            await PopupNavigation.Instance.RemovePageAsync(this);
        }

    }
}