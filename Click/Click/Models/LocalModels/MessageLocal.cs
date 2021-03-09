using ApiClick.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class MessageLocal
    {
        public MessageLocal(Message _message) 
        {
            Message = _message;

            Message.OrderedProducts.ForEach(e => OrderedProducts += $", {e.ProductName}");
            if (!string.IsNullOrEmpty(OrderedProducts)) OrderedProducts.Substring(2);

            Emote = EmoteDictionary[Message.Rating];
        }

        public Message Message { get; private set; }
        public string OrderedProducts { get; private set; } = "";
        public string Emote { get; private set; }

        public static Dictionary<int, string> EmoteDictionary = new Dictionary<int, string>() 
        {
            { 1, "SmileRatingOne.png" },
            { 2, "SmileRatingTwo.png" },
            { 3, "SmileRatingThree.png" },
            { 4, "SmileRatingFour.png" },
            { 5, "SmileRatingFive.png" },
        };
    }
}
