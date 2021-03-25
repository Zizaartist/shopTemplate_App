﻿using Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Flowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionOrganizationFlowers : ContentPage
    {
        public DescriptionOrganizationFlowers(BrandInfo brandInfo)
        {
            InitializeComponent();
            WrapperGrid.BindingContext = brandInfo;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}