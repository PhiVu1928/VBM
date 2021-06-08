using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VBM._app_objs._menu
{
    public class menuvm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void pchange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public menuvm()
        {
            createTitles();
            createRows();
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems);
        }

        public ObservableCollection<titleGroup> titleGroups { get; set; }

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

        bool isbusy_;
        public bool isbusy
        {
            get
            {
                return isbusy_;
            }
            set
            {
                isbusy_ = value;
                pchange("isbusy");
            }
        }

        public Command LoadMoreItemsCommand { get; set; }

        void createRows()
        {
            rowsRender = new ObservableCollection<rowEmesRender>();
            for (int i = 0; i < 3; i++)
            {
                rowsRender.Add(new rowEmesRender(i));
            }
        }

        public void createTitles()
        {
            titleGroups = new ObservableCollection<titleGroup>();
            for (int i = 1; i < 5; i++)
            {
                titleGroups.Add(new titleGroup(i));
            }
        }

        public async void LoadMoreItems(object obj)
        {
            isbusy = true;
            await Task.Delay(2500);
            var index = rowsRender.Count;
            if (index + 3 < 24)
            {
                for (int i = 0; i < 3; i++)
                {
                    rowsRender.Add(new rowEmesRender(i));
                }
            }
            else
            {
                for (int i = 0; i < 24-index; i++)
                {
                    rowsRender.Add(new rowEmesRender(i));
                }
            }
            isbusy = false;
        }

    }

    public class titleGroup : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        void pchange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public titleGroup(int id)
        {
            this.index = id;
            if (id == 1)
            {
                name_vn = "Bánh mì";
                name_en = "Bánh mì";
                selected = true;
            }
            if (id == 2)
            {
                name_vn = "Zeromeat";
                name_en = "Zeromeat";
            }
            if (id == 3)
            {
                name_vn = "Burger";
                name_en = "Burger";
            }
            if (id == 4)
            {
                name_vn = "Spaghetti";
                name_en = "Spaghetti";
            }
            vn = true;
        }

        bool selected_;
        Color textColor_;
        bool vn_;

        public int index { get; set; }

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
                    textColor = (Color)Application.Current.Resources["vbmgreen"];
                }
                else
                {
                    textColor = (Color)Application.Current.Resources["vbmlightgray"];
                }
                pchange("selected");
            }
        }

        public Color textColor
        {
            get
            {
                return textColor_;
            }
            set
            {
                textColor_ = value;
                pchange("textColor");
            }
        }

        public bool vn
        {
            get
            {
                return vn_;
            }
            set
            {
                vn_ = value;
                name = value ? name_vn : name_en;
            }
        }

        public string name
        {
            get;
            set;
        }
        public string name_vn { get; set; }
        public string name_en { get; set; }


    }

    public class rowEmesRender
    {

        public rowEmesRender() { }

        public rowEmesRender(int index)
        {
            this.index = index; 
            createEmes();
        }

        public int index { get; set; }
        public ObservableCollection<emeRender> emes { get; set; }

        void createEmes()
        {
            emes = new ObservableCollection<emeRender>();
            for (int i = 0; i < 2; i++)
            {
                emes.Add(new emeRender());
            }
        }

        public rowEmesRender clone()
        {
            ObservableCollection<emeRender> cops = new ObservableCollection<emeRender>();
            foreach (var item in emes)
            {
                cops.Add(item.clone());
            }
            return new rowEmesRender { emes = cops, index = this.index };
        }

    }

    public class emeRender
    {
        public emeRender()
        {
            img = $"http://manage.vuabanhmi.com/SpImg/14102020195918.jpg";
            name = "Bánh mì thịt chả";
            price = "25,000 đ";
        }
        public string img { get; set; }
        public string name { get; set; }
        public string price { get; set; }

        public emeRender clone()
        {
            return new emeRender
            {
                img = this.img, name = this.name, price = this.price 
            };
        }

    }

}
