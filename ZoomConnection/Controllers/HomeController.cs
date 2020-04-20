using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZoomConnection.Models;
using Newtonsoft.Json;

namespace ZoomConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        ConnectionModel connect = new ConnectionModel();

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/getmeeting")]
        public async Task <IActionResult> GetMeeting()
        {
            //ViewData["Message"] = "Your application description page.";
            var getMeetingResponse = await connect.GetMeeting();
            return Ok(getMeetingResponse);
        }

        [HttpGet("/createmeeting")]
        public async Task<IActionResult> CreateMeeting()
        {
            //ViewData["Message"] = "Your contact page.";
            var createMeetingResponse = await connect.CreateMeeting();
            return Ok(createMeetingResponse);
        }

        [HttpGet("/updatemeeting")]
        public async Task<IActionResult> UpdateMeeting()
        {
            var updatingResponse = await connect.UpdateMeeting();
            return Ok(updatingResponse);
        }

        [HttpPost("/meeting/{meetingId}/user")]
        public async Task<IActionResult> AddUserToMeeting(string meetingId, AddUserRequestModel reqBody)
        {
            // TODO: parse body and validate request

            var response = await connect.AddUserToMeeting(meetingId, reqBody);

            return Ok(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
