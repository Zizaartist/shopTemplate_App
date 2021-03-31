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
    public partial class FlowersAssortment : ContentPage
    {
        BrandLocal brandLocal;

        public FlowersAssortment(BrandLocal _brandLocal)
        {
            InitializeComponent();

            brandLocal = _brandLocal;

            //Загружаем меню
            var brandMenuVM = new BrandMenuViewModel(_brandLocal.Brand);
            Refreshable.BindingContext = brandMenuVM;
            Task.Run(() => brandMenuVM.GetCachedData());

            //Получаем количество отзывов
            var messagesVM = new MessagesViewModel(_brandLocal.Brand.BrandId);
            ReviewCount.BindingContext = messagesVM;
            Task.Run(() => messagesVM.GetReviewCount());

            Points.BindingContext = UsersViewModel.Instance;

            //brand-related
            BrandName.Text = _brandLocal.Brand.BrandName;
            BrandLogo.Source = _brandLocal.Logo;
            BrandBanner.Source = _brandLocal.Banner;
            Star.BindingContext = _brandLocal;
        }

        protected override void OnAppearing()
        {
            Task.Run(() => UsersViewModel.Instance.GetPoints());
            base.OnAppearing();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void CategoriesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                var brandMenuLocal = CategoriesCollection.SelectedItem as BrandMenuLocal;
                CategoriesCollection.SelectedItem = null;
                Navigation.PushModalAsync(new SubFlowersAssortment(brandMenuLocal));
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DescriptionOrganizationFlowers(brandLocal));
        }

        private void Reviews_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReviewsFlowers(brandLocal));
        }
    }
}