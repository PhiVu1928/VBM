using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VBM._app_objs._vms._cart
{
    public class cartvm
    {
        public cartvm()
        {
            createProds();
        }

        public ObservableCollection<cartProd> prods { get; set; }

        public void createProds()
        {
            prods = new ObservableCollection<cartProd> { new cartProd(1), new cartProd(2), new cartProd(3) };
        }

    }

    public class cartProd
    {
        public cartProd(int type)
        {
            if(type == 1)
            {
                mainSp = new mainCartProdType(true);
                drinkCbSp = new drinkCbCartProd(false, 0);
                recommendCb = new cbRecommend(true);
            }
            if (type == 2)
            {
                mainSp = new mainCartProdType(true);
                drinkCbSp = new drinkCbCartProd(true, 0);
                recommendCb = new cbRecommend(false);
            }
            if (type == 3)
            {
                mainSp = new mainCartProdType(false);
                drinkCbSp = new drinkCbCartProd(true, 1);
                recommendCb = new cbRecommend(false);
            }
        }

        public mainCartProdType mainSp { get; set; }
        public drinkCbCartProd drinkCbSp { get; set; }
        public cbRecommend recommendCb { get; set; }

    }

    public class mainCartProdType
    {
        public mainCartProdType(bool isvis)
        {
            this.isvis = isvis;
            img = $"http://manage.vuabanhmi.com/SpImg/14102020195918.jpg";
            name = "Bánh mì xíu mại";
            price = 25000;
            slg = 1;
            spis = "Không ớt, nhiều dưa leo, ít nước tương";
            exts = new ObservableCollection<cartProdExtra> { new cartProdExtra(), new cartProdExtra(), new cartProdExtra() };
        }

        public string img { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int slg { get; set; }
        public string spis { get; set; }
        public bool isvis { get; set; }
        public ObservableCollection<cartProdExtra> exts { get; set; }

    }

    public class drinkCbCartProd
    {
        public drinkCbCartProd(bool isvis, int type)
        {
            img = "http://manage.vuabanhmi.com/SpImg/214201923316.jpg";
            name = "Cà phê sữa";
            nguyengia = 15000;
            dongia = 9000;
            spis = "Ít sữa đặc nhiều cà phê";
            this.isvis = isvis;
            if (type == 0)
            {
                visnguyengia = true;
                visChangeSlg = false;
            }
            if (type == 1)
            {
                visnguyengia = false;
                visChangeSlg = true;
            }
        }

        public string img { get; set; }
        public string name { get; set; }
        public double nguyengia { get; set; }
        public bool visnguyengia { get; set; }
        public bool visChangeSlg { get; set; }
        public double dongia { get; set; }
        public string spis { get; set; }
        public bool isvis { get; set; }

    }

    public class cbRecommend
    {
        public cbRecommend(bool isvis)
        {
            this.isvis = isvis;
        }

        public bool isvis { get; set; }

    }

    public class cartProdExtra
    {
        public cartProdExtra()
        {
            name = "Thêm chả x1";
        }

        public string name { get; set; }

    }

}
