using ApiClick.Models;
using Click.StaticValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Click.ViewModels
{
    public class RegistrationViewModel : ViewModel
    {

        #region properties

        private bool codeIsValid;
        public bool CodeIsValid 
        {
            get => codeIsValid;
            set 
            {
                if (codeIsValid == value) return;
                codeIsValid = value;
                OnPropertyChanged("AllFieldsValid");
            }
        }

        private string phone;
        public string Phone
        {
            get => phone;
            set
            {
                if (phone == value) return;
                phone = value;
                OnPropertyChanged("IsValidNumber");
            }
        }

        private string code;
        public string Code
        {
            get => code;
            set
            {
                if (code == value) return;
                code = value;
                OnPropertyChanged("AllFieldsValid");
            }
        }

        private bool agreement1;
        public bool Agreement1 
        {
            get => agreement1;
            set 
            {
                if (agreement1 == value) return;
                agreement1 = value;
                OnPropertyChanged("AllFieldsValid");
            }
        }

        private bool agreement2;
        public bool Agreement2
        {
            get => agreement2;
            set
            {
                if (agreement2 == value) return;
                agreement2 = value;
                OnPropertyChanged("AllFieldsValid");
            }
        }

        public string CorrectPhone { get; set; }

        public bool IsValidNumber 
        { 
            get 
            {
                if (Phone == null) return false;
                return Regex.Match(Phone, @"^((8|\+7|7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$").Success;
            }
        }

        public bool AllFieldsValid
        {
            get
            {
                return IsValidNumber && agreement1 && agreement2;
            }
        }

        #endregion

        public async Task<HttpResponseMessage> SmsCheck()
        {
            try
            {
                CodeIsValid = false;
                var client = HttpClientSingleton.Instance;
                var response = await client.PostAsync(ApiStrings.API_HOST + "/api/SmsCheck/" + "?phone=" + Phone, null);
                return response;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        public async Task<HttpResponseMessage> CodeCheck()
        {
            try
            {
                var client = HttpClientSingleton.Instance;
                var response = await client.PostAsync(ApiStrings.API_HOST + "/api/CodeCheck/" + "?code=" + Code + "&phone=" + Phone, null);
                return response;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        public async Task<HttpResponseMessage> Registration()
        {
            try
            {
                var client = HttpClientSingleton.Instance;
                User user = new User()
                {
                    Phone = Phone
                };
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(ApiStrings.API_HOST + "api/" + ApiStrings.API_USERS_CONTROLLER + "?code=" + Code, data);
                return response;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        //Проверяет наличие пользователя с таким номером
        public async Task<HttpResponseMessage> validatePhone()
        {
            try
            {
                HttpClient client = HttpClientSingleton.Instance;

                HttpResponseMessage msg = await client.PostAsync(ApiStrings.API_HOST + "api/" + ApiStrings.API_VERIFY_NUMBER + "?phone=" + Phone, null);
                CorrectPhone = await msg.Content.ReadAsStringAsync();
                return msg;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }
    }
}
