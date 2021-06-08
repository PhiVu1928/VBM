using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM.ctrls.pks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class datepk : ContentView
    {
        public datepk_vm vm { get; set; }
        public datepk()
        {
            InitializeComponent();
            vm = new datepk_vm();
            this.BindingContext = vm;
        }
    }

    public class datepk_vm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void PChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public datepk_vm()
        {
            curdate = DateTime.Now;
        }

        DateTime curdate_;
        public DateTime curdate
        {
            get
            {
                return curdate_;
            }
            set
            {
                curdate_ = value;
                cur_date_str = value.ToString("dd/MM/yyyy");
            }
        }

        string cur_date_str_;
        public string cur_date_str
        {
            get
            {
                return cur_date_str_;
            }
            set
            {
                cur_date_str_ = value;
                PChange("cur_date_str");
            }
        }

    }

}