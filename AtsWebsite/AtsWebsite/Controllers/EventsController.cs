using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AtsWebsite.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            DataTable eventsTable = new DataTable();
            eventsTable.Columns.Add("ID", typeof(int));
            eventsTable.Columns.Add("Event Title", typeof(string));
            eventsTable.Columns.Add("Date", typeof(DateTime));
            eventsTable.Columns.Add("Major", typeof(string));
            eventsTable.Columns.Add("Description", typeof(string));
            eventsTable.Columns.Add("Dress Code", typeof(string));
            eventsTable.Columns.Add("Off Campus", typeof(bool));
            //eventsTable.Columns.Add("Address", typeof(string));
            //eventsTable.Columns.Add("City", typeof(string));
            //eventsTable.Columns.Add("State", typeof(string));
            //eventsTable.Columns.Add("Zipcode", typeof(int));

            eventsTable.Rows.Add(1, "Eagle Expo", new DateTime(2018,2,4), "All", 
                "We need ambassadors to help provide tours to prospective engineering students.", "No");
            eventsTable.Rows.Add(2, "Solar Go-Kart", new DateTime(2018,4,7), "All", 
                "Responsibilities include cone set up, traffic direction, clean up, etc.", "No");
            eventsTable.Rows.Add(3, "VIP Student Tours", DateTime.Now, "All", 
                "Ongoing tours for high school seniors invited to the VIP program.", "No");

            DataView view = new DataView(eventsTable);
            DataTable viewTable = view.ToTable(true, "Event Title", "Date", "Description", "Major", "Dress Code");

            return View(viewTable);
        }

        public IActionResult SignUp()
        {
            return View();
        }


        //
        //EventCopy eventCopy
        //public async Task<ActionResult> Details(int? id)
        //{

        //}
    }
}