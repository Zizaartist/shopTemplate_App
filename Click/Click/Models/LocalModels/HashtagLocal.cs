using ApiClick.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class HashtagLocal
    {
        public HashtagLocal(Hashtag _hashtag, Command _command) 
        {
            Hashtag = _hashtag;
            OnClick = _command;
        }

        public Hashtag Hashtag { get; set; }
        public Command OnClick { get; set; }
    }
}
