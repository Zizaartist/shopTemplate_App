using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubOrdersMain : ContentPage
    {
        public SubOrdersMain()
        {
            InitializeComponent();
            OrderCollection.BindingContext = new OrderHistoryViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void OrderCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                OrderCollection.SelectedItem = null;
                Navigation.PushModalAsync(new AboutOrder());
            }
        }
    }
}