using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BonusHistory : ContentPage
    {
        public BonusHistory()
        {
            InitializeComponent();

            Points.BindingContext = UsersViewModel.Instance;

            var pointRegisterVM = new PointRegisterViewModel();
            Refreshable.BindingContext = pointRegisterVM;
            Task.Run(async () => await pointRegisterVM.GetInitialData.ExecuteAsync());
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
    }
}