using ApiClick.Models;
using ApiClick.Models.ArrayModels;
using Click.Models;
using Click.Models.LocalModels;
using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Water.BootleCategory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BootleInfo : ContentPage
    {
        private WaterBrandLocal _waterBrandData;

        public BootleInfo(int _waterBrandId)
        {
            InitializeComponent();

            //Баллы достаточно просто сбайндить
            Points.BindingContext = UsersViewModel.Instance;

            Task.Run(async () =>
            {
                var brand = await new BrandsViewModel(Kind.bottledWater, false).GetSpecificData(_waterBrandId);
                _waterBrandData = new WaterBrandLocal(brand);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ApplyData(_waterBrandData);
                });
            });
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

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void licension(object sender, EventArgs e)
        {
            //download licension
        }

        private void ApplyData(WaterBrandLocal _waterBrandLocal)
        {

            BrandName.Text = _waterBrandLocal.Brand.BrandName;
            BrandName2.Text = _waterBrandLocal.Brand.BrandName;
            Contact.Text = _waterBrandLocal.Brand.BrandInfo.Contact;
            Contact2.Text = _waterBrandLocal.Brand.BrandInfo.Contact;
            Address.Text = _waterBrandLocal.Brand.BrandInfo.Address;
            Logo.Source = _waterBrandLocal.Logo;

            #region schedule

            foreach (DayOfWeek dayOfWeek in DayOfWeekDictionaries.CorrectlyOrderedDays)
            {
                var found = _waterBrandLocal.Brand.ScheduleListElements.FirstOrDefault(e => e.DayOfWeek == dayOfWeek);
                string addedText;
                if (found != null)
                {
                    addedText = $"{found.OpenTime.ToString(@"hh\:mm")} - {found.CloseTime.ToString(@"hh\:mm")}";
                }
                else
                {
                    addedText = $"Выходной";
                }
                Schedule.Spans.Add(new Span() { Text = $"{DayOfWeekDictionaries.GetStringFromDayOfWeek[dayOfWeek]} {addedText} \n" });
            }

            #endregion
        }

        private void Confirm_Clicked(object sender, EventArgs e)
        {
            if(_waterBrandData != null) Navigation.PushModalAsync(new BottleOrderForm(_waterBrandData));
        }
    }
}