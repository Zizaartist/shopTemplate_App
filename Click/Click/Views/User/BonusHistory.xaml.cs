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
            BonusCollection.BindingContext = new BonusViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}