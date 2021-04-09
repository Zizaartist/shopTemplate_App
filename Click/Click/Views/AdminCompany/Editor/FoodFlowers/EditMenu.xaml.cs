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
    public partial class EditMenu : ContentPage
    {
        FoodCategory foodCategory = new FoodCategory();
        public EditMenu()
        {
            InitializeComponent();
            newfoodcategory();
            CategoryWrapper.BindingContext = foodCategory;
        }
        void newfoodcategory()
        {
            //need delete
            foodCategory.Name = "Бургеры с говядиной";
            foodCategory.Image = "temp8.png";
        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void CategoryPhotoAdd_Clicked(object sender, EventArgs e)
        {

        }

        async private void NameCategoryEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите имя категории");
            foodCategory.Name = result;
        }

        private void AddCategoryForm_Clicked(object sender, EventArgs e)
        {

        }

        private void AddFoodCategory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditMenuFood());
        }
    }
}