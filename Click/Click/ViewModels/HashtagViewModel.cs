using Akavache;
using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class HashtagViewModel : ViewModel
    {
        public ObservableCollection<HashtagLocal> Hashtags { get; } = new ObservableCollection<HashtagLocal>();

        public ObservableCollection<HashtagLocal> SelectedHashtags = new ObservableCollection<HashtagLocal>();

        public Command OnClick { get; set; }
        public Command Erase { get; set; }

        public HashtagViewModel()
        {
            OnClick = new Command<HashtagLocal>(async (_hashtag) => await ToggleTag(_hashtag));
            Erase = new Command<HashtagLocal>(async (_hashtag) => await EraseTags());
        }

        public async Task GetData(Kind _kind)
        {
            Hashtags.Clear();

            Hashtags.Add(new HashtagLocal(new Hashtag() { HashTagId = -1, HashTagName = "Все" }, Erase));

            //Пытаемся вытащить данные из кэша, при неудаче создаем пустую ячейку для предотвращения KeyNotFoundException
            List<Hashtag> cachedHashtags = await new CacheFunctions().tryToGet<List<Hashtag>>(Caches.HASHTAGS_CACHE.key + "_" +
                                                                                                    _kind.ToString(), CacheFunctions.BlobCaches.LocalMachine);

            //В случае если кэш не пуст
            if (cachedHashtags != null)
            {
                foreach (Hashtag hashtag in cachedHashtags)
                {
                    Hashtags.Add(new HashtagLocal(hashtag, OnClick));
                }
            }
            //В случае если он пуст
            else
            {
                try
                {
                    HttpClient client = await createUserClient();

                    //Получение всех хэштегов по id категории
                    HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                         ApiStrings.HASHTAGS_CONTROLLER + (int)_kind);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        List<Hashtag> tempList = JsonConvert.DeserializeObject<List<Hashtag>>(result);
                        await BlobCache.LocalMachine.InsertObject(Caches.HASHTAGS_CACHE.key + "_" +
                                                                    _kind.ToString(), tempList);
                        foreach (var item in tempList)
                        {
                            Hashtags.Add(new HashtagLocal(item, OnClick));
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
        }

        public async Task ToggleTag(HashtagLocal _hashtag) 
        {
            if (SelectedHashtags.Contains(_hashtag))
            {
                SelectedHashtags.Remove(_hashtag);
            }
            else 
            {
                SelectedHashtags.Add(_hashtag);
            }
        }

        public async Task EraseTags() 
        {
            SelectedHashtags.Clear();
        }
    }
}
