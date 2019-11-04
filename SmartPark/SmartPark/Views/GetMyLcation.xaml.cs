using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


namespace SmartPark.Views
{
   
    public partial class GetMyLcation : ContentPage
    {
        public GetMyLcation()
        {
            InitializeComponent();
        }
  
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void btnLocation_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                string address = txtAddress.Text;
                if (!string.IsNullOrEmpty(address))
                {
                    var locations = await Geocoding.GetLocationsAsync(address);

                    var location = locations?.FirstOrDefault();

                    if (location != null)
                    {
                        var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                        var placemark = placemarks?.FirstOrDefault();
                        if (placemark != null)
                     
                        {
                            lblAdminArea.Text = "Admin Area: " + placemark.AdminArea;
                            lblCountryName.Text = "Country Name:" + placemark.CountryName;
                            lblCountryCode.Text = "Country Code:" + placemark.CountryCode;
                            lblLocality.Text = "Locality:" + placemark.Locality;
                            lblSubAdminArea.Text = "SubAdmin Area:" + placemark.SubAdminArea;
                            lblSublocality.Text = "SubLocality:" + placemark.SubLocality;
                            lblPostalcode.Text = "PostalCode:" + placemark.PostalCode;
         
                        }
                    }
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }

        }
    }
}