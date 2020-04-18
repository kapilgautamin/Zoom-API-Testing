using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
//using System.Text.Json;

namespace ZoomConnection.Models
{
    public class Connection
    {
        private string baseUrl = "https://api.zoom.us/v2/";
        public async Task<GetMeetingResponse> GetMeeting()
        {
			try
			{
                //Uri: https://api.zoom.us/v2/meetings/{meetingId}"

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IkF1dkhVY29RU2ctdlVPeThEbWp6QXciLCJleHAiOjE1ODcyODA4MDcsImlhdCI6MTU4NzE5NDQwN30.RVdSAZ7HcGRaRVRE9Lv-Ll-qJD-Vh7O9nm5-ORyFM4c");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.GetAsync(baseUrl + "meetings/94389134556");

                var zoomResponse = JsonConvert.DeserializeObject<GetMeetingResponse>(await responseMessage.Content.ReadAsStringAsync());
                return zoomResponse;
            }
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<CreateMeetingResponseModel> CreateMeeting()
        {
            var createMeeting = new CreateMeetingRequestModel();
            //createMeeting.
            //Add default or fake property values

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiIsInYiOiIyLjAiLCJraWQiOiIxYThmOGMwMS0wYjFjLTQxNTgtODVhMC1jM2RlYzA0YjgyMzEifQ.eyJ2ZXIiOiI2IiwiY2xpZW50SWQiOiJWT3hTZzd4R1RzNnVHTnJPQUVjUnciLCJjb2RlIjoiUGZuaWpCS1F4S19jSDhmVDlCM1JUT2hNR3A3QWtjSjNnIiwiaXNzIjoidXJuOnpvb206Y29ubmVjdDpjbGllbnRpZDpWT3hTZzd4R1RzNnVHTnJPQUVjUnciLCJhdXRoZW50aWNhdGlvbklkIjoiNDIzODljYjQ3MjQ5MWQwYTA5MjQ2MjFlOTM2MGU2MTAiLCJ1c2VySWQiOiJjSDhmVDlCM1JUT2hNR3A3QWtjSjNnIiwiZ3JvdXBOdW1iZXIiOjAsImF1ZCI6Imh0dHBzOi8vb2F1dGguem9vbS51cyIsImFjY291bnRJZCI6IkItQ2RwalJEUmhPY3hYalp5TVMyemciLCJuYmYiOjE1ODcwOTc1MzEsImV4cCI6MTU4NzEwMTEzMSwidG9rZW5UeXBlIjoiYWNjZXNzX3Rva2VuIiwiaWF0IjoxNTg3MDk3NTMxLCJqdGkiOiI5MzRkZjZlNi02MWYwLTQxNDctOTU5Ni1iN2JkOWY5MTkzYjkiLCJ0b2xlcmFuY2VJZCI6MH0.5ceykq-pvQktti9xluMMGhabpi6Fum3riYBSSlyt5Tw2wsHZ2tEyBIjuRAHAA5soyrKLyvlUk5YbiBjLj-QYrA");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var responseMessage = await client.GetAsync("https://api.zoom.us/v2/meetings/92918799433");

            var stringContent = new StringContent(JsonConvert.SerializeObject(createMeeting));
            var responseMessage = await client.PostAsync("https://api.zoom.us/v2/users/me/meetings", stringContent);

            var createMeetingResponse = JsonConvert.DeserializeObject<CreateMeetingResponseModel>(await responseMessage.Content.ReadAsStringAsync());
            return createMeetingResponse;
        }

        
    }
}
