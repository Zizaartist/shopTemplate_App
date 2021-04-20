using ApiClick.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class HashtagLocal : ObservableObject
    {
        public HashtagLocal(Hashtag _hashtag, Command _command) 
        {
            Hashtag = _hashtag;
            OnClick = _command;
        }

        public Hashtag Hashtag { get; set; }
        public Command OnClick { get; set; }

        private bool toggled = false;
        private bool Toggled 
        {
            get => toggled;
            set 
            { 
                SetProperty(ref toggled, value);
                OnPropertyChanged("Style");
            }
        }

        public Style Style 
        {
            get 
            {
                if (Toggled)
                {
                    return App.Instance.tagOrangeSelected;
                }
                else 
                {
                    return App.Instance.tagOrange;
                }
            }
        }

        public void Toggle() => Toggled = !Toggled;
        public void Reset() => Toggled = false;
    }
}
