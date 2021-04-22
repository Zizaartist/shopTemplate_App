﻿using ApiClick.Models;
using Akavache;
using Click.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;
using System.Reactive.Linq;
using Xamarin.Forms.Xaml;
using Click.StaticValues;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Click.ViewModels
{
    public class UsersViewModel : ViewModel //Слишком часто юзается, придется делать синглтон
    {
        private static object syncRoot = new Object();
        private static UsersViewModel instance;
        public static UsersViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new UsersViewModel();
                        }
                    }
                }

                return instance;
            }
        }

        private decimal points = 0m;
        public decimal Points 
        {
            get => points;
            set { SetProperty(ref points, value); }
        }

        public AsyncCommand UpdatePoints { get; } //Пока лучший способ предотвращения параллельных вызовов

        public UsersViewModel() 
        {
            UpdatePoints = new AsyncCommand(UpdatePointsTask, allowsMultipleExecutions: false);
        }

        private async Task UpdatePointsTask()
        {
            try
            {
                HttpClient client = await createUserClient();

                var response = await client.GetAsync(ApiStrings.HOST + ApiStrings.USERS_POINTS);
                string result = await response.Content.ReadAsStringAsync();
                Points = JsonConvert.DeserializeObject<decimal>(result);
            }
            catch (NoConnectionException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        public async Task<HttpResponseMessage> ChangeNumber(string newNumber, string code)
        {
            try
            {
                var client = await createUserClient();
                return await client.PutAsync(ApiStrings.HOST + ApiStrings.USERS_PHONE_CHANGE + "?newPhoneNumber=" + newNumber + "&code=" + code, null);
            }
            catch (NoConnectionException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }
    }
}
