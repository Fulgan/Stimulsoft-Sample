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
    [Route(@"{controller}/{action}")]
    public class DesignerController : Controller
    {
        static DesignerController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult PreviewReport()
        {
            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);
            report.RegBusinessObject("InvoiceReminderUserReport", InvoiceReminderUserReport.GetSample());
            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

        private string ReportFileName => "Reports/PeppermintBO.mrt";// StiNetCoreHelper.MapPath(this, "Reports/BusinessObjects_IEnumerable_BO.mrt");
        public IActionResult GetReportIEnumerableBO()
        {
            var report = new StiReport();
            report.Load(ReportFileName);
            report.RegBusinessObject("InvoiceReminderUserReport", InvoiceReminderUserReport.GetSample());
            report.Dictionary.SynchronizeBusinessObjects(2);

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult SaveReport()
        {
            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);
            report.Save(ReportFileName);
            return StiNetCoreDesigner.SaveReportResult(this);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
    }
}