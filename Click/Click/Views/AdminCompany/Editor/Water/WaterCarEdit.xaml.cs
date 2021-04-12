using Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Editor.Water
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaterCarEdit : ContentPage
    {
        WaterCompany waterCompany = new WaterCompany();
        public WaterCarEdit()
        {
            InitializeComponent();
            addwatercompany();
            Wrapper.BindingContext = waterCompany;
        }
        void addwatercompany()
        {
            //need delete
            waterCompany.Name = "Ледник";
            waterCompany.Price = "120 руб. обмен";
            waterCompany.Images = "wtemp1.png";
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void PhotoEdit_Clicked(object sender, EventArgs e)
        {

        }

        private void TimeWork_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TimeWorkEdit());
        }

        async private void ContactsEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите контакты");
        }

        async private void NameEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите название");
            waterCompany.Name = result;
        }

        async private void PriceEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите цену куб. воды");
            waterCompany.Price = result;
        }
    }
}