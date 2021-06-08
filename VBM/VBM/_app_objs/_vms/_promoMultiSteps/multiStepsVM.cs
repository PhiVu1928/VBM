using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace VBM._app_objs._vms._promoMultiSteps
{
    public class multiStepsVM:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        void pchange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public multiStepsVM()
        {
            itemsInvi = new ObservableCollection<item_invidicator>();
            for (int i = 1; i < 4; i++)
            {
                itemsInvi.Add(new item_invidicator(i));
            }
            step = 1;
        }

        int step_;
        ObservableCollection<rowEmesRender> rowsRender_;

        public ObservableCollection<rowEmesRender> rowsRender 
        {
            get
            {
                return rowsRender_;
            }
            set
            {
                rowsRender_ = value;
                pchange("rowsRender");
            }
        }

        public ObservableCollection<item_invidicator> itemsInvi { get; set; }

        public int step
        {
            get
            {
                return step_;
            }
            set
            {
                step_ = value;
                var rrd = new ObservableCollection<rowEmesRender>();
                for (int i = 0; i < 5; i++)
                {
                    rrd.Add(new rowEmesRender(i, step));
                }
                rowsRender = rrd;
                foreach (var item in itemsInvi)
                {
                    if (item.index == value)
                    {
                        item.selected = true;
                    }
                    else
                    {
                        item.selected = false;
                    }
                }
            }
        }

        public async Task showToast()
        {
            string noti = $"Mời bạn chọn sản phẩm bước {step}";
            var options = new SnackBarOptions
            {
                MessageOptions = new MessageOptions
                {
                    Font = (Font)Application.Current.Resources["lbo"],
                    Foreground = (Color)Application.Current.Resources["vbmgreen"],
                    Message = noti,
                    Padding = 10
                },
                BackgroundColor = (Color)Application.Current.Resources["vbmlightgray"],
                Duration = TimeSpan.FromSeconds(2)
            };
        }

    }

    public class rowEmesRender
    {

        public rowEmesRender() { }

        public rowEmesRender(int index, int step)
        {
            this.index = index;
            this.step = step;
            createEmes();
        }

        public int index { get; set; }
        public int step { get; set; }
        public ObservableCollection<emeRender> emes { get; set; }

        void createEmes()
        {
            emes = new ObservableCollection<emeRender>();
            for (int i = 0; i < 2; i++)
            {
                emes.Add(new emeRender(step));
            }
        }

    }

    public class emeRender
    {
        public emeRender(int step)
        {
            if (step == 1 || step == 3)
            {
                img = $"http://manage.vuabanhmi.com/SpImg/14102020195918.jpg";
                name = "Bánh mì thịt chả";
                price = "25,000 đ";
            }
            else
            {
                img = $"http://manage.vuabanhmi.com/SpImg/214201923316.jpg";
                name = "Cà phê sữa";
                price = "15,000 đ";
            }
        }
        public string img { get; set; }
        public string name { get; set; }
        public string price { get; set; }

    }

    public class item_invidicator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void pchange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public item_invidicator(int index)
        {
            this.index = index;
        }

        #region bien tam
        Color indivicatorItemColor_ = Color.LightGray;
        bool selected_;
        #endregion

        #region official value
        public Color indivicatorItemColor
        {
            get
            {
                return indivicatorItemColor_;
            }
            set
            {
                indivicatorItemColor_ = value;
                pchange("indivicatorItemColor");
            }
        }
        public bool selected
        {
            get
            {
                return selected_;
            }
            set
            {
                selected_ = value;
                if (value)
                {
                    indivicatorItemColor = Color.Green;
                }
                else
                {
                    indivicatorItemColor = Color.LightGray;
                }
            }
        }
        public int index { get; set; }
        #endregion

        #region functions
        #endregion

    }
        

}
