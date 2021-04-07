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
    public partial class BootleEdit : ContentPage
    {
        WaterCompany waterCompany = new WaterCompany();
        public BootleEdit()
        {
            InitializeComponent();
            addwatercompany();
            Wrapper.BindingContext = waterCompany;
        }
        void addwatercompany()
        {
            //need delete
            waterCompany.Name = "Ледник";
            waterCompany.Images = "wtemp1.png";
            waterCompany.Price = "120 руб. обмен";
            waterCompany.Discriptions = "";
        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        private void licension(object sender, EventArgs e)
        {
            
        }

        private void PhotoEdit_Clicked(object sender, EventArgs e)
        {

        }

        private void TimeWork_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TimeWorkEdit());
        }

        private void DownloadLicense_Clicked(object sender, EventArgs e)
        {

        }

        async private void ContactEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите контакты");
        }

        async private void NameEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите название");
            waterCompany.Name = result;
        }

        async private void AdressEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите адрес");
        }

        async private void PriceEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите стоимость");
            waterCompany.Price = result;

        }

        async private void PriceBottleEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите стоимость тары");
        }
    }
}