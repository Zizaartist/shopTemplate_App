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
    public partial class EditAdBannerAdd : ContentPage
    {
        AdBannerFood adBannerFood = new AdBannerFood();
        public EditAdBannerAdd(AdBannerFood _adBannerFood)
        {
            InitializeComponent();
            Wrapper.BindingContext = _adBannerFood;
            adBannerFood = _adBannerFood;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void EditPhoto_Clicked(object sender, EventArgs e)
        {

        }

        async private void DescriptionEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите описание");
            adBannerFood.Text = result;
        }
    }
}