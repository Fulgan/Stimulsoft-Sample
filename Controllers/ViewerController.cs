using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Using_Business_Objects_in_the_Report.Models;

namespace Using_Business_Objects_in_the_Report.Controllers
{
    public class ViewerController : Controller
    {
        static ViewerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index()
        {
            return View("Index");
        }


        public IActionResult ViewReport()
        {
            return View("View");
        }

        public IActionResult GetReport()
        {
            var report = new StiReport();
            report.Load("Reports/PeppermintBO.mrt");
            report.RegData("InvoiceReminderUserReport", InvoiceReminderUserReport.GetSample());

            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}