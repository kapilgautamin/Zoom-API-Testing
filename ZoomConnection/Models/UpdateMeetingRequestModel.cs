﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZoomConnection.Models
{
    public class UpdateMeetingRequestModel
    {
        [JsonProperty("topic")]     //Meeting topic
        public string Topic { get; set; }

        [JsonProperty("schedule_for")]     //email/user-id you want to schedule meeting for another user
        public string ScheduleFor { get; set; }

        [JsonProperty("type")]  //1-instant, 2-scheduled,3-recurring with no fixed time,8-recurring with fixed time, default:2
        public int Type { get; set; }

        [JsonProperty("start_time")]   //Meeting start time in GMT/UTC, format: date-time
        public string StartTime { get; set; }

        [JsonProperty("duration")]  //in minutes
        public int Duration { get; set; }

        [JsonProperty("timezone")]  //Refer to different time zones here:https://marketplace.zoom.us/docs/api-reference/other-references/abbreviation-lists#timezones
        public string Timezone { get; set; }

        [JsonProperty("agenda")]
        public string Agenda { get; set; }

        [JsonProperty("password")]  //minimum length : 8
        public string Password { get; set; }

        [JsonProperty("tracking_fields")]
        public UpdateMeetingRequestTrackingFields TrackingFields { get; set; }

        [JsonProperty("settings")]
        public UpdateMeetingRequestSettings Settings { get; set; }

        [JsonProperty("recurrence")]
        public UpdateMeetingRequestRecurrence Recurrence { get; set; }
    }

    public class UpdateMeetingRequestTrackingFields
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class UpdateMeetingRequestSettings
    {
        [JsonProperty("host_video")]    //start video when host joins
        public bool HostVideo { get; set; }

        [JsonProperty("participant_video")]     //start video when participant joins
        public bool ParticipantVideo { get; set; }

        [JsonProperty("cn_meeting")]    //host meeting in china, defualt:false
        public bool CnMeeting { get; set; }

        [JsonProperty("in_meeting")]    //host meeting in china, defualt:false
        public bool InMeeting { get; set; }

        [JsonProperty("join_before_host")]  //allow participant to join before host joins in scheduled/recurring meeting,default:false
        public bool JoinBeforeHost { get; set; }

        [JsonProperty("mute_upon_entry")]   //Mute participants upon entry,default:false
        public bool MuteUponEntry { get; set; }

        [JsonProperty("watermark")]   //Add watermark when viewing a shared screen,default:false
        public bool Watermark { get; set; }

        [JsonProperty("use_pmi")]   //Use pmi for scheduled/recurring meeting,default:false
        public bool UsePmi { get; set; }

        [JsonProperty("approval_type")]   //0-auto approve,1-manual approve,2-no approval,default:2, registration not for basic user
        public int ApprovalType { get; set; }

        [JsonProperty("registration_type")]   //used for recurring meeting, allowed:1,2,3,default:1
        public int RegistrationType { get; set; }

        [JsonProperty("audio")] //allowed- both,telephony,voip, default:both
        public string Audio { get; set; }

        [JsonProperty("auto_recording")]    //allowed-local,cloud,none,default:none
        public string AutoRecording { get; set; }

        //enforce_login and enforce_login_domains deprecated in getMeeting API, so not included here

        [JsonProperty("alternative_hosts")]   //alternative host ID/email
        public string AlternativeHosts { get; set; }

        [JsonProperty("close_registration")]   //Close registration after event date,default:false
        public bool CloseRegistration { get; set; }

        [JsonProperty("waiting_room")]   //Enable waiting room,default:false
        public bool WaitingTime { get; set; }

        //TODO : Should add global_dial_in_countries or not!!!!

        [JsonProperty("contact_name")]   //Contact name for registrant
        public string ContactName { get; set; }

        [JsonProperty("contact_email")]   //Contact email for registrant
        public string ContactEmail { get; set; }

        [JsonProperty("registrants_email_notification")]   //email notification to registrations about approval,cancellation or denial of registration, should be 'true' to use 'registrants_confirmation_email' property
        public bool RegistrantsEmailNotification { get; set; }

        [JsonProperty("meeting_authentication")]   //Only authenticated users can join
        public bool MeetingAuthentication { get; set; }

        [JsonProperty("authentication_option")]   //meeting authentication option id
        public string AuthenticationOption { get; set; }

        //TODO : Should add authentication_domains and authentication_name or not!!!! check : https://support.zoom.us/hc/en-us/articles/360037117472-Authentication-Profiles-for-Meetings-and-Webinars#h_5c0df2e1-cfd2-469f-bb4a-c77d7c0cca6f
    }

    public class UpdateMeetingRequestRecurrence
    {
        [JsonProperty("type")]  //Recurring meeting type : 1-daily,2-weekly,3-monthly
        public int Type { get; set; }

        [JsonProperty("repeat_interval")]
        public int RepeatInterval { get; set; }

        [JsonProperty("weekly_days")]   //allowed 1,2,3,4,5,6,7 based on days of week
        public string WeeklyDays { get; set; }

        [JsonProperty("monthly_day")]
        public int MontlyDay { get; set; }

        [JsonProperty("monthly_week")]  //allowed -1,1,2,3,4 depending on the time of week, -1 is last week
        public int MonthlyWeek { get; set; }

        [JsonProperty("monthly_week_day")]  //allowed 1,2,3,4,5,6,7
        public int MonthlyWeekDay { get; set; }

        [JsonProperty("end_times")] ///how many times to recur before it is cancelled, default:1, max:50
        public int EndTimes { get; set; }

        [JsonProperty("end_date_time")] //format:date-time
        public string Status { get; set; }
    }

}