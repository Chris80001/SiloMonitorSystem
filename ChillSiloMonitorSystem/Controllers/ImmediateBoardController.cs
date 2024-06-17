using ChillSiloMonitorSystem.Models;
using ChillSiloMonitorSystem.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChillSiloMonitorSystem.Controllers
{
    public class ImmediateBoardController : Controller
    {
        ImmediateBoardService _ImmediateBoardService = new ImmediateBoardService();
        // GET: ImmediateBoard
        public ActionResult Index()
        {
            return View(SampleData.NavigationItemsWithIcon);
        }

        [HttpPost]
        public ContentResult TreeListChangeLeft(string TreeListType)
        {
            if (TreeListType == "Dyeing")
            {
                List<ImmediateBoardDyeing> ImmediateBoardDyeingList = _ImmediateBoardService.GetImmediateBoardDyeingList("左");
                return Content(JsonConvert.SerializeObject(ImmediateBoardDyeingList), "application/json");
            }
            if (TreeListType == "Multiple")
            {
                List<ImmediateBoardMultiple> ImmediateBoardMultipleList = _ImmediateBoardService.GetImmediateBoardMultipleList("左");
                return Content(JsonConvert.SerializeObject(ImmediateBoardMultipleList), "application/json");
            }
            if (TreeListType == "New")
            {
                List<ImmediateBoardNew> ImmediateBoardNewList = _ImmediateBoardService.GetImmediateBoardNewList("左");
                return Content(JsonConvert.SerializeObject(ImmediateBoardNewList), "application/json");
            }
            
            return Content(JsonConvert.SerializeObject(null), "application/json");
        }

        [HttpPost]
        public ContentResult TreeListChangeRight(string TreeListType)
        {
            if (TreeListType == "Dyeing")
            {
                List<ImmediateBoardDyeing> ImmediateBoardDyeingList = _ImmediateBoardService.GetImmediateBoardDyeingList("右");
                return Content(JsonConvert.SerializeObject(ImmediateBoardDyeingList), "application/json");
            }
            if (TreeListType == "Multiple")
            {
                List<ImmediateBoardMultiple> ImmediateBoardMultipleList = _ImmediateBoardService.GetImmediateBoardMultipleList("右");
                return Content(JsonConvert.SerializeObject(ImmediateBoardMultipleList), "application/json");
            }
            if (TreeListType == "New")
            {
                List<ImmediateBoardNew> ImmediateBoardNewList = _ImmediateBoardService.GetImmediateBoardNewList("右");
                return Content(JsonConvert.SerializeObject(ImmediateBoardNewList), "application/json");
            }
            
            return Content(JsonConvert.SerializeObject(null), "application/json");
        }
    }
}