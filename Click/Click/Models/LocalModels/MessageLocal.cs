using ApiClick.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class ReviewLocal
    {
        public ReviewLocal(Review _message) 
        {
            Review = _message;

            foreach (var product in Review.Products) 
            {
                OrderedProducts += $", {product}";
            }
            if (!string.IsNullOrEmpty(OrderedProducts)) OrderedProducts.Substring(2);

            Emote = EmoteDictionary[Review.Rating];
        }

        public Review Review { get; private set; }
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
