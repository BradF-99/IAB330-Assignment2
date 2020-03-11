# IAB330-Assignment2

Assignment 2 (and 3) for QUT's IAB330 unit (Mobile App Development), Semester 2, 2019.

## Authors 

* Charly Shin (CharlyShin)
* DaeHan Jung (DanJung-01)
* Cody Darlington (CodyDarlington)
* Brad Fuller (BradF-99)

## Dependencies and Testing

### Development and Deployment Dependencies

* Visual Studio 2019 is used for app development.
* Xcode 11 (on macOS 10.15 Catalina) is used for building, code-signing and deployment to iOS devices.
* Android 6.0 (API level 23) Rev. 2 SDK is used for building and deployment to Android devices. 
* Visual Studio Code and NPM 6+ is used for backend development.

### App Dependencies

* The app uses Xamarin as an app development framework. 
* The app is targeted to Android 6.0 and above (API level 23) as well as iOS 8 and later.
* An API key for Google Maps v2 (Android only) and Microsoft App Centre is required for the app to function.

### Backend Dependencies

* Node.js 10+ and Redis 4.0+ are required to run the backend.
* (Recommended) Docker to deploy the backend as an image.

GitHub generates a full list of dependencies which can be found [here](https://github.com/BradF-99/IAB330-Assignment2/network/dependencies).

## Notes
* The app will not function as-is, as the app searches for a back-end server that no longer exists. Modification (namely, changing the URL to the correct back-end) is required for the app to work as intended.
* Images and app icons may not work as intended due to broken file references. This does not affect the usage of the app.
* iOS signing needs to be set in the Xcode project before testing on real iOS devices can take place. This can be done using [Free Provisioning](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/).
* Any API keys that were used as part of development are no longer available for use. Any URLs referenced have been deactivated. The app will likely not function without these.
* This project was designed for a fictional use-case in a university assignment, and may not be production-ready. 
Re-use and/or modification are not allowed in any circumstances. All rights reserved.
* This project (in it's entirety) has been processed by the QUT MoSS system, and any plagiarism will be detected 
automatically.
