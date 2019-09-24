using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SmartPark.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(-27.476944,153.028056), Distance.FromKilometers(1.0)))
            {
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            if(Device.RuntimePlatform == Device.Android) // we have to handle location perm ourselves
            {
                
            }

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
         }
    }
}
