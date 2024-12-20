using Xamarin.Essentials;
using Xamarin.Forms;

namespace API
{
  public static class Constants
  {
    // URL of REST service
    //public static string RestUrl = "https://YOURPROJECT.azurewebsites.net:8081/api/todoitems/{0}";

    // URL of REST service (Android does not use localhost)
    // Use http cleartext for local deployment. Change to https for production
    public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.0.106" : "https://localhost:7170";
  }
}
