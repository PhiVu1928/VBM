using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VBM._app_objs._vms._edit
{
    public class drinkCbVM
    {

        public drinkCbVM()
        {
            createRows();
        }

        public ObservableCollection<rowDrinksRender> rows { get; set; }

        void createRows()
        {
            rows = new ObservableCollection<rowDrinksRender>();
            for (int i = 0; i < 5; i++)
            {
                rows.Add(new rowDrinksRender());
            }
        }

    }

    public class rowDrinksRender
    {
        public rowDrinksRender()
        {
            createEmes();
        }

        public ObservableCollection<drinkRender> drks { get; set; }

        void createEmes()
        {
            drks = new ObservableCollection<drinkRender>();
            for (int i = 0; i < 2; i++)
            {
                drks.Add(new drinkRender());
            }
        }

    }

    public class drinkRender
    {
        public drinkRender()
        {
            img = $"http://manage.vuabanhmi.com/SpImg/214201923316.jpg";
            name = "Cà phê sữa";
            nguyengia = 15000;
            dongia = 9000;
        }
        public string img { get; set; }
        public string name { get; set; }
        public double nguyengia { get; set; }
        public double dongia { get; set; }
    }

}
