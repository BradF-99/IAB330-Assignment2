using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

/*
 * TO DO
 * Actually handle exceptions
 * Get user position (doesn't seem to work?)
 * Check that pin drops work
 */


namespace SmartPark.ViewModels
{
    public class LocationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public LocationViewModel()
        {

            PinCollection.Add(new Pin() { Position = UserPosition, Type = PinType.Generic, Label = "Test Pin" });

            Task.Run(async () =>
            {
                try
                {
                    GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium); // change accuracy if needed
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {
                        if (location.IsFromMockProvider)
                        {
                            UserPosition = new Position(location.Latitude, location.Longitude);
                        }
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }
            });
        }

        private ObservableCollection<Pin> _pinCollection = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> PinCollection { get { return _pinCollection; } set { _pinCollection = value; OnPropertyChanged(); } }

        private Position _userPosition = new Position(-37.8141, 144.9633);
        public Position UserPosition { get { return _userPosition; } set { _userPosition = value; OnPropertyChanged(); } }
    }
}