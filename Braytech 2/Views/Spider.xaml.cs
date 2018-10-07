using Braytech_2.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Braytech_2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Spider : Page
    {

        ObservableCollection<Models.Item> ItemsList = new ObservableCollection<Models.Item>();

        public Spider()
        {
            this.InitializeComponent();

            Request();
        }

        private async void Request()
        {
            //Create an HTTP client object
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            //Add a user-agent header to the GET request. 
            var headers = httpClient.DefaultRequestHeaders;

            //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
            //especially if the header value is coming from user input.
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }

            Uri requestUri = new Uri("https://api.braytech.org/?key=5afd1373be0bc&request=vendor&hash=863940356");

            //Send the GET request asynchronously and retrieve the response as a string.
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                Render(httpResponseBody);

            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
        }

        private async void Render(string json)
        {
            VendorData request = JsonConvert.DeserializeObject<VendorData>(json);

            //help plz
            var materialIndexes = new int[2];

            foreach (var category in request.response.data[0].categories)
            {
                if (category.displayCategoryIndex == 1)
                {
                    materialIndexes = category.itemIndexes;
                }
            }

            foreach (var item in request.response.data[0].sales)
            {

                if (materialIndexes.Contains(item.vendorItemIndex))
                {
                    ItemsList.Add(new Models.Item
                    {
                        Name = item.item.displayProperties.name.Replace("Purchase ", ""),
                        Icon = $"https://www.bungie.net{ item.item.displayProperties.icon }",
                        Quantity = item.quantity.ToString(),
                        Cost = $"{ item.costs[0].quantity.ToString() } {item.costs[0].displayProperties.name}"
                    });
                }


            }

        }
    }
}
