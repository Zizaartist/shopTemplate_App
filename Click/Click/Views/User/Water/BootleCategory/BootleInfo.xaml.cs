using Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Water.BootleCategory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BootleInfo : ContentPage
    {
        public BootleInfo(WaterCompany waterCompany)
        {
            InitializeComponent();
            WrapperStack.BindingContext = waterCompany;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }
        private void licension(object sender, EventArgs e)
        {
            //download licension
        }

        private void Confirm_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BottleOrderForm());
        }
    }
}