using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class GoodsFlowersViewModel : BindableObject
    {
        private ObservableCollection<GoodsFood> goodsFoods;
        public ObservableCollection<GoodsFood> GoodsFoods
        {
            get => goodsFoods;
            set
            {
                if (value == goodsFoods) return;
                goodsFoods = value;
                OnPropertyChanged();
            }
        }
        public GoodsFlowersViewModel()
        {
            GoodsFoods = new ObservableCollection<GoodsFood>()
            {
                new GoodsFood()
                {
                    Image = "temp26.png",
                    Title = "Спатифиллиум Вайт Тисенто",
                    Description = "Спатифиллум представляет из себя полукустарник высотой от 30 до 120 см в зависимости от сорта. Цветет в течение нескольких недель.",
                    Price = "499",
                },
                new GoodsFood()
                {
                    Image = "temp27.png",
                    Title = "Сансеверия бакуларис Микардо",
                    Description = "Отличается прямостоячими слегка разбросанными в стороны листьями трубчатой формы. В середине листовых пластин вдоль все длинны есть небольшая выемка",
                    Price = "478",
                },
                new GoodsFood()
                {
                    Image = "temp28.png",
                    Title = "Фикус микрокарпа",
                    Description = "Он произрастает от Китая через тропическую Азию и с Каролинских островов до Австралии.",
                    Price = "456",
                },
            };
        }
    }
}
