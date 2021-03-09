using ApiClick.Models.RegisterModels;
using Click.StaticValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Click.ViewModels
{
    public class PointRegisterViewModel : CollectionViewModel
    {

        #region properties

        public ObservableCollection<LocalPointRegister> PointRegisters { get; } = new ObservableCollection<LocalPointRegister>();

        public PointRegisterViewModel()
        {
            GetInitialData = new GetDataCommand(async () => await GetInitial(), value => GetDataLock = value, () => GetDataLock);
            GetMoreData = new GetDataCommand(async () => await GetRemoteData(), value => GetDataLock = value, () => GetDataLock);
        }

        #endregion

        #region methods

        public async Task GetInitial()
        {
            PointRegisters.Clear();
            Page = 0;

            try
            {
                await GetMoreData.ExecuteAsSubtask();
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

        public async Task GetRemoteData() 
        {
            PointRegisters.Clear();

            try
            {
                HttpClient client = await createUserClient();

                //Получение всех продуктов по id меню
                HttpResponseMessage response = await client.GetAsync(ApiStrings.API_HOST + "api/" +
                                                                        ApiStrings.API_POINT_REGISTERS_CONTROLLER + Page);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<PointRegister> tempList = JsonConvert.DeserializeObject<List<PointRegister>>(result);
                    foreach (var item in tempList)
                    {
                        PointRegisters.Add(new LocalPointRegister() { PointRegister = item });
                    }
                }
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

        #endregion

    }

    public class LocalPointRegister
    {
        private PointRegister pointRegister;
        public PointRegister PointRegister 
        {
            get => pointRegister;
            set 
            {
                pointRegister = value;
                if (pointRegister.ReceiverId != default)
                {
                    Value = "+";
                }
                else 
                {
                    Value = "-";
                }
            }
        }

        private string sign;
        public string Value 
        {
            get => $"{sign} {PointRegister.Points}";
            set 
            {
                sign = value;
            }
        }
    }
}
