using ApiClick.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class ReviewLocal
    {
        public ReviewLocal(Review _review) 
        {
            Review = _review;

            foreach (var product in Review.Products) 
            {
                OrderedProducts += $"{product}, ";
            }
            if (!string.IsNullOrEmpty(OrderedProducts)) OrderedProducts = OrderedProducts.Remove(OrderedProducts.Length - 2);

            Emote = EmoteDictionary[Review.Rating];
        }

        public Review Review { get; private set; }
        public string OrderedProducts { get; private set; } = "";
        public ImageSource Emote { get; private set; }

        public static Dictionary<int, ImageSource> EmoteDictionary = new Dictionary<int, ImageSource>() 
        {
            { 1, (ImageSource)new ImageSourceConverter().ConvertFromInvariantString("SmileRatingOne.png") },
            { 2, (ImageSource)new ImageSourceConverter().ConvertFromInvariantString("SmileRatingTwo.png") },
            { 3, (ImageSource)new ImageSourceConverter().ConvertFromInvariantString("SmileRatingThree.png") },
            { 4, (ImageSource)new ImageSourceConverter().ConvertFromInvariantString("SmileRatingFour.png") },
            { 5, (ImageSource)new ImageSourceConverter().ConvertFromInvariantString("SmileRatingFive.png") },
        };
    }
}
