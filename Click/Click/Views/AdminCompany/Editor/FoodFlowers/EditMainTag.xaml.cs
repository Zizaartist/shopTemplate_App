using Click.Models;
using Click.ViewModels;
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
    public partial class EditMainTag : ContentPage
    {
        public EditMainTag()
        {
            InitializeComponent();
            TagCollection.BindingContext = new TagFoodViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Tag_Clicked(object sender, EventArgs e)
        {
            
        }

        private void AddTag_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}