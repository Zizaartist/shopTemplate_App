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
    public partial class EditMainTimeWork : ContentPage
    {
        public EditMainTimeWork()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}