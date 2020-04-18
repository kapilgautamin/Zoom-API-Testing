using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZoomConnection.Models;

namespace ZoomConnection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> GetMeeting()
        {
            ViewData["Message"] = "Your application description page.";

            ConnectionModel connect = new ConnectionModel();
            var zoomResponse = await connect.GetMeeting();
            return Ok(zoomResponse);
        }

        public async Task<IActionResult> CreateMeeting()
        {
            ViewData["Message"] = "Your contact page.";
            ConnectionModel connect = new ConnectionModel();
            var createMeetingResponse = await connect.CreateMeeting();
            return Ok(createMeetingResponse);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
