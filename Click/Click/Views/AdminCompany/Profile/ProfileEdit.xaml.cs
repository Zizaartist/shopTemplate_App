using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEdit : ContentPage
    {
        public ProfileEdit()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Documentation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProfileDocumentation());
        }

        private void ExitProfile_Clicked(object sender, EventArgs e)
        {

        }
    }
}