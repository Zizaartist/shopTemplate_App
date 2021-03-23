using Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionOrganization : ContentPage
    {
        public DescriptionOrganization(BrandInfo brandInfo)
        {
            InitializeComponent();
            BindingContext = brandInfo;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}