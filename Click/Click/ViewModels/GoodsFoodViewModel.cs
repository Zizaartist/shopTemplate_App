using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class GoodsFoodViewModel : BindableObject
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
        public GoodsFoodViewModel()
        {
            GoodsFoods = new ObservableCollection<GoodsFood>()
            {
                new GoodsFood()
                {
                    Image = "temp15.png",
                    Title = "Биг Кинг ХХХ",
                    Description = "Нежные булочки с сочной говяжьей котлетой, хрустящими огурчиками, свежими помидорами, луком, острым перцем. беконом, яйцом и сыром заправлен соусом bbq.",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp16.png",
                    Title = "Воппер Джуниор",
                    Description = "Воппер Джуниор приготовленный на огне бифштекс из 100% говядины, сочный помидор, свежий нарезанный салат, густой майонез, хрустящие огурчики и свежий лук на мягкой булочке, посыпанный кунжутом.",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp17.png",
                    Title = "Воппер Ролл",
                    Description = "Воппер Ролл со вкусом Воппера! Два приготовленных на огне бифштекса из 100% говядины, листовой салат, сочные помидоры, лук, маринованные огурчики и многосоуса - все за что любят",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp15.png",
                    Title = "Биг Кинг ХХХ",
                    Description = "Нежные булочки с сочной говяжьей котлетой, хрустящими огурчиками, свежими помидорами, луком, острым перцем. беконом, яйцом и сыром заправлен соусом bbq.",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp16.png",
                    Title = "Воппер Джуниор",
                    Description = "Воппер Джуниор приготовленный на огне бифштекс из 100% говядины, сочный помидор, свежий нарезанный салат, густой майонез, хрустящие огурчики и свежий лук на мягкой булочке, посыпанный кунжутом.",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp17.png",
                    Title = "Воппер Ролл",
                    Description = "Воппер Ролл со вкусом Воппера! Два приготовленных на огне бифштекса из 100% говядины, листовой салат, сочные помидоры, лук, маринованные огурчики и многосоуса - все за что любят",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp15.png",
                    Title = "Биг Кинг ХХХ",
                    Description = "Нежные булочки с сочной говяжьей котлетой, хрустящими огурчиками, свежими помидорами, луком, острым перцем. беконом, яйцом и сыром заправлен соусом bbq.",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp16.png",
                    Title = "Воппер Джуниор",
                    Description = "Воппер Джуниор приготовленный на огне бифштекс из 100% говядины, сочный помидор, свежий нарезанный салат, густой майонез, хрустящие огурчики и свежий лук на мягкой булочке, посыпанный кунжутом.",
                    Price = "456",
                },
                new GoodsFood()
                {
                    Image = "temp17.png",
                    Title = "Воппер Ролл",
                    Description = "Воппер Ролл со вкусом Воппера! Два приготовленных на огне бифштекса из 100% говядины, листовой салат, сочные помидоры, лук, маринованные огурчики и многосоуса - все за что любят",
                    Price = "456",
                },
            };
        }
    }
}
