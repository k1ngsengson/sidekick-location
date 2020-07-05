using Common;
using Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GoogleMapService: IGoogleMapService
    {
        private readonly HttpClient _httpClientInstance;
        public GoogleMapService()
        {
            _httpClientInstance =  new HttpClient
            {
                BaseAddress = new Uri(StringConstants.GoogleApiPath)
            };
        }

        public async Task<PlacesLocationPredictions> GetPlacesPredictionsAsync(string search)
        {
            // TODO: Add throttle logic, Google begins denying requests if too many are made in a short amount of time

            CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"api/place/autocomplete/json?key={StringConstants.GooglePlacesApiKey}&input={WebUtility.UrlEncode(search)}"))
            { //Be sure to UrlEncode the search term they enter

                using (HttpResponseMessage message = await _httpClientInstance.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false))
                {
                    if (message.IsSuccessStatusCode)
                    {
                        string json = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

                        PlacesLocationPredictions predictionList = await Task.Run(() => JsonConvert.DeserializeObject<PlacesLocationPredictions>(json)).ConfigureAwait(false);

                        return predictionList;
                    }
                }
            }

            return null;
        }

        public async Task<AddressInfo> GetPlaceDetails(string placeId)
        {
            AddressInfo result = null;

            CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"api/place/details/json?placeid={Uri.EscapeUriString(placeId)}&key={StringConstants.GooglePlacesApiKey}"))
            using (HttpResponseMessage message = await _httpClientInstance.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false))
            {
                if (message.IsSuccessStatusCode)
                {
                    var json = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json) && json != "ERROR")
                    {
                        result = new AddressInfo(JObject.Parse(json));
                    }
                }
            }

            return result;
        }
    }
}
