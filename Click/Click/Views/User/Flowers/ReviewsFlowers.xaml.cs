using Click.Models;
using Click.Models.LocalModels;
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
    public partial class MessagesFlowers : ContentPage
    {
        public MessagesFlowers(BrandLocal _brandLocal)
        {
            InitializeComponent();

            MessagesCollection.BindingContext = new ReviewsViewModel();
            NameLabel.Text = _brandLocal.Brand.BrandName;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void MessagesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}