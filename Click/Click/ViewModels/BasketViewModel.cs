using Click.Models;
using Click.ViewModels.Help;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class BasketViewModel : BindableObject
    {
        public ObservableCollection<Grouping<string, GoodsFood>> GoodsFoodsGroups { get; set; }
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
        public BasketViewModel()
        {
            GoodsFoods = new ObservableCollection<GoodsFood>()
            {
                new GoodsFood()
                {
                    Image = "temp15.png",
                    Title = "Биг Кинг ХХХ",
                    Description = "Нежные булочки с сочной говяжьей котлетой, хрустящими огурчиками, свежими помидорами, луком, острым перцем. беконом, яйцом и сыром заправлен соусом bbq.",
                    Price = "319",
                    OwnerName = "Бургер Кинг",
                    OwnerLogo = "temp5.png",
                    DeliveryTerms = "Доставка по городу 149 рублей. Радиус доставки - 7 км. Оплата только по безналичному расчету через терминал",
                    QuantityGoods = "1",
                },
                new GoodsFood()
                {
                    Image = "temp15.png",
                    Title = "Чикен Кинг",
                    Description = "Нежные булочки с сочной говяжьей котлетой, хрустящими огурчиками, свежими помидорами, луком, острым перцем. беконом, яйцом и сыром заправлен соусом bbq.",
                    OwnerName = "Бургер Кинг",
                    OwnerLogo = "temp5.png",
                    DeliveryTerms = "Доставка по городу 149 рублей. Радиус доставки - 7 км. Оплата только по безналичному расчету через терминал",
                    QuantityGoods = "2",
                    Price = "299",
                },
                new GoodsFood()
                {
                    Image = "temp26.png",
                    Title = "Спатифиллиум Вайт Тисенто",
                    Description = "Воппер Джуниор приготовленный на огне бифштекс из 100% говядины, сочный помидор, свежий нарезанный салат, густой майонез, хрустящие огурчики и свежий лук на мягкой булочке, посыпанный кунжутом.",
                    Price = "499",
                    OwnerName = "Time Flowers",
                    OwnerLogo = "temp21.png",
                    DeliveryTerms = "Доставка по городу 149 рублей. Радиус доставки - 7 км. Оплата только по безналичному расчету через терминал",
                    QuantityGoods = "1",
                },
                new GoodsFood()
                {
                    Image = "temp27.png",
                    Title = "Сансеверия бакуларис Микардо",
                    Description = "Воппер Джуниор приготовленный на огне бифштекс из 100% говядины, сочный помидор, свежий нарезанный салат, густой майонез, хрустящие огурчики и свежий лук на мягкой булочке, посыпанный кунжутом.",
                    Price = "478",
                    OwnerName = "Time Flowers",
                    OwnerLogo = "temp21.png",
                    DeliveryTerms = "Доставка по городу 149 рублей. Радиус доставки - 7 км. Оплата только по безналичному расчету через терминал",
                    QuantityGoods = "1",
                },
                new GoodsFood()
                {
                    Image = "temp28.png",
                    Title = "Фикус микрокарпа",
                    Description = "Воппер Джуниор приготовленный на огне бифштекс из 100% говядины, сочный помидор, свежий нарезанный салат, густой майонез, хрустящие огурчики и свежий лук на мягкой булочке, посыпанный кунжутом.",
                    Price = "456",
                    OwnerName = "Time Flowers",
                    OwnerLogo = "temp21.png",
                    DeliveryTerms = "Доставка по городу 149 рублей. Радиус доставки - 7 км. Оплата только по безналичному расчету через терминал",
                    QuantityGoods = "3",
                },
            };
            var groups = GoodsFoods.GroupBy(p => p.OwnerName).Select(g => new Grouping<string, GoodsFood>(g.Last().OwnerName, g.Last().OwnerLogo, g.Last().DeliveryTerms, g));
            GoodsFoodsGroups = new ObservableCollection<Grouping<string, GoodsFood>>(groups);
        }
    }
}
