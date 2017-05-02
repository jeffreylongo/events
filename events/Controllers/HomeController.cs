using events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AddQuestion()
        {
            HttpRuntime.Cache["timeStamp"] = null;

            HttpRuntime.Cache.Remove("timeStamp");

            HttpRuntime.Cache
                    .Add("timeStamp",
                    DateTime.Now,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(8, 0, 0),
                    System.Web.Caching.CacheItemPriority.Low,
                    null
                    );


            return View();
        }

        public ActionResult Index()
        {
            var eventsFromCache = HttpRuntime.Cache["events"];
            if (eventsFromCache == null)
            {
                //display the events
                var events = new ApplicationDbContext().Events.OrderBy(o => o.Title).ToList();
                //add events to cache
                HttpRuntime.Cache.Add(
                    "events",
                    events,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High,
                    null);
                eventsFromCache = HttpRuntime.Cache["events"];

            }
            return View(eventsFromCache);



            /*var timeToDisplay = HttpRuntime.Cache["timeStamp"];

            if (timeToDisplay == null)
            {
                //was not in cache
                //TODO: place db call here

                HttpRuntime.Cache
                    .Add("timeStamp",
                    DateTime.Now,
                    null,
                    DateTime.MaxValue,
                    new TimeSpan(8, 0, 0),
                    System.Web.Caching.CacheItemPriority.High,
                    null
                    );
                timeToDisplay = HttpRuntime.Cache["timeStamp"];
            }
            else
            {
                //was in cache
            }
            ViewBag.FromCache = timeToDisplay;

            //session per user
            var timeUserFirstCameToSite = Session["userTime"];
            if (timeUserFirstCameToSite == null)
            {
                Session.Add("userTime", DateTime.Now);
            }
            ViewBag.FromSession = Session["userTime"];

            return View();*/
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}