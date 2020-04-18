using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace ZoomConnection.Models
{
    public class ConnectionModel
    {
        private string baseUrl = "https://api.zoom.us/v2/";
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();
        static AuthenticationHeaderValue authroizationKey = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IkF1dkhVY29RU2ctdlVPeThEbWp6QXciLCJleHAiOjE1ODcyODA4MDcsImlhdCI6MTU4NzE5NDQwN30.RVdSAZ7HcGRaRVRE9Lv-Ll-qJD-Vh7O9nm5-ORyFM4c");
        static MediaTypeWithQualityHeaderValue headerValue = new MediaTypeWithQualityHeaderValue("application/json");

        public async Task<GetMeetingResponseModel> GetMeeting()
        {
			try
			{
                //Get Uri: https://api.zoom.us/v2/meetings/{meetingId}"
                var getMeetingRequestMeetingId = "94389134556";

                client.DefaultRequestHeaders.Authorization = authroizationKey;
                client.DefaultRequestHeaders.Accept.Add(headerValue);

                var responseMessage = await client.GetAsync($"{baseUrl}meetings/{getMeetingRequestMeetingId}");
                var zoomResponse = JsonConvert.DeserializeObject<GetMeetingResponseModel>(await responseMessage.Content.ReadAsStringAsync());
                
                return zoomResponse;
            }
			catch (Exception)
			{
				throw;
			}
        }

        public async Task<CreateMeetingResponseModel> CreateMeeting()
        {
            try
            {
                //Post Uri: https://api.zoom.us/v2/users/{userId}/meetings"

                var createMeeting = new CreateMeetingRequestModel();
                createMeeting.Topic = "Zoom Testing through API";
                createMeeting.Type = 1;
                //createMeeting.StartTime = "2020-04-18T15:00:00";
                createMeeting.Duration = 30;

                createMeeting.Settings = new CreateMeetingRequestSettings();
                createMeeting.Settings.HostVideo = false;
                createMeeting.Settings.ParticipantVideo = false;
                createMeeting.Settings.JoinBeforeHost = true;
                createMeeting.Settings.MuteUponEntry = true;
                createMeeting.Settings.Watermark = true;

                var createMeetingRequestParameterUserId = "me";

                client.DefaultRequestHeaders.Authorization = authroizationKey;
                client.DefaultRequestHeaders.Accept.Add(headerValue);

                var stringContent = new StringContent(JsonConvert.SerializeObject(createMeeting));
                var responseMessage = client.PostAsJsonAsync<CreateMeetingRequestModel>($"{baseUrl}users/{createMeetingRequestParameterUserId}/meetings",createMeeting);
                var createMeetingResponse = JsonConvert.DeserializeObject<CreateMeetingResponseModel>(await responseMessage.Result.Content.ReadAsStringAsync());
                
                return createMeetingResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
