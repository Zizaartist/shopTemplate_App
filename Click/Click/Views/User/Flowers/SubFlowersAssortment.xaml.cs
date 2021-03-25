using Click.Models;
using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Flowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubFlowersAssortment : ContentPage
    {
        GoodsFood getItemSelectedData;
        int Price;
        public SubFlowersAssortment(FoodCategory foodCategory, BrandInfo brandInfo)
        {
            InitializeComponent();
            FoodCollection.BindingContext = new GoodsFlowersViewModel();
            CategoryLabel.Text = foodCategory.Name;
            NameLabel.Text = brandInfo.Name;
        }

        private void FoodCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                FoodCollection.SelectedItem = null;
                getItemSelectedData = e.CurrentSelection.FirstOrDefault() as GoodsFood;
                LabelQuantity.Text = "1";
                ImageProduct.Source = getItemSelectedData.Image;
                LabelTitle.Text = getItemSelectedData.Title;
                LabelDescription.Text = getItemSelectedData.Description;
                SpanPrice.Text = getItemSelectedData.Price;
                Price = Convert.ToInt32(SpanPrice.Text);
                AboutProductGrid.IsVisible = true;
            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void Basket_Clicked(object sender, EventArgs e)
        {

        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            AboutProductGrid.IsVisible = false;
        }

        private void Plus_Clicked(object sender, EventArgs e)
        {
            PlusMinusGoods("Plus");
        }

        private void Minus_Clicked(object sender, EventArgs e)
        {
            PlusMinusGoods("Minus");
        }
        private void PlusMinusGoods(string TypeButton)
        {           
            switch (TypeButton)
            {
                case "Plus":
                    LabelQuantity.Text = (Convert.ToInt32(LabelQuantity.Text) + 1).ToString();
                    break;
                case "Minus":
                    if (Convert.ToInt32(LabelQuantity.Text) > 1)
                    {
                        LabelQuantity.Text = (Convert.ToInt32(LabelQuantity.Text) - 1).ToString();
                    }
                    break;
            }
            SpanPrice.Text = (Price * Convert.ToInt32(LabelQuantity.Text)).ToString();
        }
    }
}