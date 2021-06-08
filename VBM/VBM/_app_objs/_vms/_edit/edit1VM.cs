using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VBM._app_objs._vms._edit
{
    public class edit1VM
    {
        public edit1VM()
        {
            banners = new ObservableCollection<int> { 1, 2, 3 };
        }

        public ObservableCollection<int> banners { get; set; }

    }

}
