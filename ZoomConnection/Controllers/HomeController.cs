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
        public async Task<IActionResult> Index()
        {
            Connection connect = new Connection();
            var zoomResponse = await connect.GetMeeting();
            return Ok(zoomResponse);

            //var createMeetingResponse = await connect.CreateMeeting();
            //return Ok(createMeetingResponse);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
