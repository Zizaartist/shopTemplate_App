using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class BonusViewModel : BindableObject
    {
        private ObservableCollection<Bonus> bonuss;
        public ObservableCollection<Bonus> Bonuss
        {
            get => bonuss;
            set
            {
                if (value == bonuss) return;
                bonuss = value;
                OnPropertyChanged();
            }
        }
        public BonusViewModel()
        {
            Bonuss = new ObservableCollection<Bonus>()
            {
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "+211",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "+157",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "-102",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "-102",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "+654",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "+123",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "-322",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "-157",
                },
                new Bonus()
                {
                    Date = "29 января 2021, 12:56",
                    Ball = "+321",
                },
            };
        }
    }
}
