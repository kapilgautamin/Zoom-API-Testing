using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoomConnection.Models
{
    public class ZoomResponse
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("start_url")]
        public string StartUrl { get; set; }

        [JsonProperty("join_url")]
        public string JoinUrl { get; set; }

        [JsonProperty("host_id")]
        public string HostId { get; set; }

        [JsonProperty("settings")]
        public ZoomResponseSetting Settings { get; set; }
    }

    public class ZoomResponseSetting
    {
        [JsonProperty("host_video")]
        public bool HostVideo { get; set; }

        [JsonProperty("audio")]
        public string Audio { get; set; }

        [JsonProperty("auto_recording")]
        public string AutoRecording { get; set; }
    }
}
