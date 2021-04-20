using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels.Templates
{
    public class DateTimePicker : ContentView, INotifyPropertyChanged
    {
        public Entry _entry { get; private set; } = new Entry();
        public DatePicker _datePicker { get; private set; } = new DatePicker() { MinimumDate = DateTime.Today, IsVisible = false };
        public TimePicker _timePicker { get; private set; } = new TimePicker() { IsVisible = false };

        string _stringFormat { get; set; }
        public string StringFormat { get { return _stringFormat ?? "dd/MM/yyyy HH:mm"; } set { _stringFormat = value; } }

        public DateTime? DateAndTime
        {
            get { return (DateTime?)GetValue(DateAndTimeProperty); }
            set { SetValue(DateAndTimeProperty, value); OnPropertyChanged("DateTime"); }
        }

        private DateTime Layer { get => DateAndTime ?? _datePicker.MinimumDate; }

        private TimeSpan _time
        {
            get
            {
                return TimeSpan.FromTicks(Layer.Ticks);
            }
            set
            {
                DateAndTime = new DateTime(Layer.Date.Ticks).AddTicks(value.Ticks);
            }
        }

        private DateTime _date
        {
            get
            {
                return Layer.Date;
            }
            set
            {
                DateAndTime = new DateTime(Layer.TimeOfDay.Ticks).AddTicks(value.Ticks);
            }
        }

        public static BindableProperty DateAndTimeProperty = BindableProperty.Create("DateTime", typeof(DateTime?), typeof(DateTimePicker), null, BindingMode.TwoWay, propertyChanged: DTPropertyChanged);
        
        public DateTimePicker()
        {
            //BindingContext = this;

            Content = new StackLayout()
            {
                Children =
                {
                    _datePicker,
                    _timePicker,
                    _entry
                }
            };

            _entry.HeightRequest = 40;
            _entry.Placeholder = "Например ДД/ММ 00:00";
            _entry.Style = new App().entryGray;
            _entry.IsEnabled = false;

            _datePicker.SetBinding<DateTimePicker>(DatePicker.DateProperty, p => p._date);
            _timePicker.SetBinding<DateTimePicker>(TimePicker.TimeProperty, p => p._time);
            _timePicker.Unfocused += (sender, args) => _time = _timePicker.Time;
            _datePicker.Focused += (s, a) => UpdateEntryText();

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => _datePicker.Focus())
            });
            _entry.Focused += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() => _datePicker.Focus());
            };
            _datePicker.Unfocused += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _timePicker.Focus();
                    _date = _datePicker.Date;
                    UpdateEntryText();
                });
            };
        }

        private void UpdateEntryText()
        {
            _entry.Text = DateAndTime?.ToString(StringFormat);
        }

        static void DTPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var timePicker = (bindable as DateTimePicker);
            timePicker.UpdateEntryText();
        }
    }
}
