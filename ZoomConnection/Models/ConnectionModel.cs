using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ZoomConnection.Models
{
    public class ConnectionModel
    {
        private string baseUrl = "https://api.zoom.us/v2/";
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();
        static AuthenticationHeaderValue authorizationKey = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IkF1dkhVY29RU2ctdlVPeThEbWp6QXciLCJleHAiOjE1ODc4NjI1MDQsImlhdCI6MTU4NzI1NzcwNH0.U2ljATOnc4b38OW6hIofCpTwsbqGAcpg-epI-1ZVsnE");
        static MediaTypeWithQualityHeaderValue headerValue = new MediaTypeWithQualityHeaderValue("application/json");

        public async Task<GetMeetingResponseModel> GetMeeting()
        {
			try
			{
                //Get Uri: https://api.zoom.us/v2/meetings/{meetingId}"
                var getMeetingRequestMeetingId = "94389134556";

                client.DefaultRequestHeaders.Authorization = authorizationKey;
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
                createMeeting.Type = 2;
                createMeeting.StartTime = "2020-04-18T22:00:00";
                createMeeting.Duration = 30;

                createMeeting.Settings = new CreateMeetingRequestSettings();
                createMeeting.Settings.HostVideo = false;
                createMeeting.Settings.ParticipantVideo = false;
                createMeeting.Settings.JoinBeforeHost = true;
                createMeeting.Settings.MuteUponEntry = true;
                createMeeting.Settings.Watermark = true;

                var createMeetingRequestParameterUserId = "me";

                client.DefaultRequestHeaders.Authorization = authorizationKey;
                var stringContent = new StringContent(JsonConvert.SerializeObject(createMeeting), System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync($"{baseUrl}users/{createMeetingRequestParameterUserId}/meetings", stringContent);
                var createMeetingResponse = JsonConvert.DeserializeObject<CreateMeetingResponseModel>(await responseMessage.Content.ReadAsStringAsync());
                
                return createMeetingResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> UpdateMeeting()
        {
            try
            {
                //Patch Uri: https://api.zoom.us/v2/meetings/{meetingId}"
                //Returns 204 status code on success

                var updateMeeting = new UpdateMeetingRequestModel();
                updateMeeting.Type = 2; //This needs to be included in every minimal PATCH request, it cannot be null/0
                updateMeeting.Topic = "Zoom Patch Update Test";
                updateMeeting.Duration = 40;
                updateMeeting.Agenda = "For Testing Zoom API";

                updateMeeting.Settings = new UpdateMeetingRequestSettings();
                updateMeeting.Settings.HostVideo = true;
                updateMeeting.Settings.ParticipantVideo = true;
                updateMeeting.Settings.JoinBeforeHost = true;
                updateMeeting.Settings.MuteUponEntry = true;
                updateMeeting.Settings.Watermark = true;

                var getMeetingRequestMeetingId = "94316422464";

                client.DefaultRequestHeaders.Authorization = authorizationKey;

                var stringContent = new StringContent(JsonConvert.SerializeObject(updateMeeting), System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PatchAsync($"{baseUrl}meetings/{getMeetingRequestMeetingId}", stringContent);
                return responseMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> AddUserToMeeting(string meetingId, AddUserRequestModel userInfo)
        {
            //POST Uri: https://api.zoom.us/v2/meetings/{meetingId}/registrants"
            //Returns 204 status code on success
            client.DefaultRequestHeaders.Authorization = authorizationKey;

            var payload = new StringContent(JsonConvert.SerializeObject(userInfo), System.Text.Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync($"{baseUrl}meetings/{meetingId}", payload);

            return responseMessage;
        }

    }
}
