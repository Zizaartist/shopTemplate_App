using ApiClick.Models;
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
    public partial class MainFlowers : ContentPage
    {
        private static Kind CATEGORY = Kind.flowers;

        public MainFlowers()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            AdFoodCollection.BindingContext = new AdBannerFlowersViewModel();

            //Загружаем теги
            var hashtagsVM = new HashtagViewModel();
            TagCollection.BindingContext = hashtagsVM;
            Task.Run(() => hashtagsVM.GetData(CATEGORY));

            //Баллы достаточно просто сбайндить
            Points.BindingContext = UsersViewModel.Instance;

            //Загружаем бренды
            var brandVM = new BrandsViewModel(CATEGORY, false, hashtagsVM.SelectedHashtags);
            Working.BindingContext = brandVM;
            Refreshable.BindingContext = brandVM;
            Task.Run(() => brandVM.GetCachedData());
        }

        protected override void OnAppearing()
        {
            Task.Run(() => UsersViewModel.Instance.GetPoints());
            base.OnAppearing();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void Find_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new FindFlowers());
        }

        private void OrganisationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                var selectedBrand = OrganisationCollection.SelectedItem as BrandLocal;
                OrganisationCollection.SelectedItem = null;
                Navigation.PushModalAsync(new FlowersAssortment(selectedBrand));
            }
        }

        private void Tag_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
        }
    }
}