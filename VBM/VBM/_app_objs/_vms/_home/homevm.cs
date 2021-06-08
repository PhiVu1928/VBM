using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace VBM._app_objs._vms._home
{
    public class homevm
    {
        public homevm()
        {
            createTitles();
            CreateEmes();
        }

        public ObservableCollection<titleGroup> titleGroups { get; set; }
        public ObservableCollection<emeRender> emes { get; set; }

        public void CreateEmes()
        {
            emes = new ObservableCollection<emeRender>();
            for (int i = 0; i < 10; i++)
            {
                emes.Add(new emeRender());
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

    }

    public class titleGroup:INotifyPropertyChanged
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
        public int index { get; set; }


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
    }

}
