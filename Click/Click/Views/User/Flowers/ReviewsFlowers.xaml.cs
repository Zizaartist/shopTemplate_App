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
    public partial class ReviewsFlowers : ContentPage
    {
        public ReviewsFlowers(BrandInfo brandInfo)
        {
            InitializeComponent();
            ReviewsCollection.BindingContext = new ReviewsViewModel();
            NameLabel.Text = brandInfo.Name;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void ReviewsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}