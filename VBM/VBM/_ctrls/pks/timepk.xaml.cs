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
    public partial class timepk : ContentView
    {
       public  timepk_vm vm;
        public timepk()
        {
            InitializeComponent();
            vm = new timepk_vm();
            this.BindingContext = vm;
        }
    }

    public class timepk_vm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void PChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public timepk_vm()
        {
            curtime = DateTime.Now.TimeOfDay;
        }

        TimeSpan curtime_;
        public TimeSpan curtime
        {
            get
            {
                return curtime_;
            }
            set
            {
                curtime_ = value;
                cur_time_str = $"{value.Hours}:{value.Minutes}:{value.Seconds}";
            }
        }

        string cur_time_str_;
        public string cur_time_str
        {
            get
            {
                return cur_time_str_;
            }
            set
            {
                cur_time_str_ = value;
                PChange("cur_time_str");
            }
        }
    }


}