using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class ReviewsViewModel : BindableObject
    {
        private ObservableCollection<Reviews> reviewss;
        public ObservableCollection<Reviews> Reviewss
        {
            get => reviewss;
            set
            {
                if (value == reviewss) return;
                reviewss = value;
                OnPropertyChanged();
            }
        }
        public ReviewsViewModel()
        {
            Reviewss = new ObservableCollection<Reviews>()
            {
                new Reviews()
                {
                    Name = "Артур",
                    Text = "Доставили точно в срок, никаких задержек 😍",
                    Goods = "Чикен Кинг, Coca-cola, Воппер Джуниор",
                    Date = "01 февраля в 14:54",
                    Rating = "4",
                    RatingImage = "SmileRatingFour.png",
                },
                new Reviews()
                {
                    Name = "Артур",
                    Text = "В бургерах поменялись булочки, они стали намного вкуснее и нежнее! И котлеты вкуснее стали, Молодцы! Буду у вас заказывать 👍",
                    Goods = "Чикен Кинг, Coca-cola, Воппер Джуниор",
                    Date = "01 февраля в 14:54",
                    Rating = "5",
                    RatingImage = "SmileRatingFive.png",
                },
                new Reviews()
                {
                    Name = "Артур",
                    Text = "Бургер отвратительный, на вкус как бумага. Наггетсы более-менее. Больше у данного заведения заказывать не буду.",
                    Goods = "Чикен Кинг, Coca-cola, Воппер Джуниор",
                    Date = "01 февраля в 14:54",
                    Rating = "3",
                    RatingImage = "SmileRatingThree.png",
                },
                new Reviews()
                {
                    Name = "Артур",
                    Text = "Кетчуп вместо кисло сладкого сунули. Да и вообще почему на фото хайнз а на деле не вкусный кетчуп",
                    Goods = "Чикен Кинг, Coca-cola, Воппер Джуниор",
                    Date = "01 февраля в 14:54",
                    Rating = "1",
                    RatingImage = "SmileRatingOne.png",
                },
                new Reviews()
                {
                    Name = "Артур",
                    Text = "Бургер отвратительный, на вкус как бумага. Наггетсы более-менее. Больше у данного заведения заказывать не буду.",
                    Goods = "Чикен Кинг, Coca-cola, Воппер Джуниор",
                    Date = "01 февраля в 14:54",
                    Rating = "2",
                    RatingImage = "SmileRatingTwo.png",
                },
            };
        }
    }
}
