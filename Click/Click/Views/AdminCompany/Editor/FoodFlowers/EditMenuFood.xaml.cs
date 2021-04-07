using Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Editor.FoodFlowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMenuFood : ContentPage
    {
        GoodsFood goodsFood = new GoodsFood();
        public EditMenuFood()
        {
            InitializeComponent();
            addgoodsfood();
            FoodWrapper.BindingContext = goodsFood;
        }
        void addgoodsfood()
        {
            //need delete
            goodsFood.Image = "temp15.png";
            goodsFood.Title = "Биг Кинг ХХХ";
            goodsFood.Description = "Нежные булочки с сочной говяжьей котлетой, хрустящими огурчиками, свежими помидорами, луком, острым перцем. беконом, яйцом и сыром заправлен соусом bbq.";
            goodsFood.Price = "456";
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void ElementPhotoAdd_Clicked(object sender, EventArgs e)
        {

        }

        async private void NameElementEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите название");
            goodsFood.Title = result;
        }

        async private void DescriptionElementEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите описание");
            goodsFood.Description = result;
        }

        async private void PriceElementEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите цену");
            goodsFood.Price = result;
        }
    }
}