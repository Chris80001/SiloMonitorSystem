using ChillSiloMonitorSystem.Models;
using ChillSiloMonitorSystem.Service;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChillSiloMonitorSystem.Controllers
{
    public class HistoryBoardController : Controller
    {
        HistoryBoardService _HistoryBoardService = new HistoryBoardService();
        // GET: HistoryBoard
        public ActionResult Index()
        {
            return View(SampleData.NavigationItemsWithIcon);
        }

        [HttpPost]
        public ContentResult TreeListChangePath(string TreeListType)
        {
            if (TreeListType == "Dyeing") 
            {
                List<HistoryBoardPathDyeing> HistoryBoardPathDyeingList = _HistoryBoardService.GetHistoryBoardPathDyeingList();
                return Content(JsonConvert.SerializeObject(HistoryBoardPathDyeingList), "application/json");
            }
            if (TreeListType == "Multiple")
            {
                List<HistoryBoardPathMultiple> HistoryBoardPathMultipleList = _HistoryBoardService.GetHistoryBoardPathMultipleList();
                return Content(JsonConvert.SerializeObject(HistoryBoardPathMultipleList), "application/json");
            }
            if (TreeListType == "New")
            {
                List<HistoryBoardPathNew> HistoryBoardPathNewList = _HistoryBoardService.GetHistoryBoardPathNewList();
                return Content(JsonConvert.SerializeObject(HistoryBoardPathNewList), "application/json");
            }
            //List<Employee> EmployeeList = _HistoryBoardService.GetEmployeeList(TreeListType);
            ////return Json(_new_DyeingPackageDayWaitConfirmList);
            //return Content(JsonConvert.SerializeObject(EmployeeList), "application/json");
            return Content(JsonConvert.SerializeObject(null), "application/json");
        }

        [HttpPost]
        public ContentResult TreeListChangeException(string TreeListType)
        {
            if (TreeListType == "Dyeing")
            {
                List<HistoryBoardExceptionDyeing> HistoryBoardExceptionDyeingList = _HistoryBoardService.GetHistoryBoardExceptionDyeingList();
                return Content(JsonConvert.SerializeObject(HistoryBoardExceptionDyeingList), "application/json");
            }
            if (TreeListType == "Multiple")
            {
                List<HistoryBoardExceptionMultiple> HistoryBoardExceptionMultipleList = _HistoryBoardService.GetHistoryBoardExceptionMultipleList();
                return Content(JsonConvert.SerializeObject(HistoryBoardExceptionMultipleList), "application/json");
            }
            if (TreeListType == "New")
            {
                List<HistoryBoardExceptionNew> HistoryBoardExceptionNewList = _HistoryBoardService.GetHistoryBoardExceptionNewList();
                return Content(JsonConvert.SerializeObject(HistoryBoardExceptionNewList), "application/json");
            }
            //List<Employee> EmployeeList = _HistoryBoardService.GetEmployeeList(TreeListType);
            ////return Json(_new_DyeingPackageDayWaitConfirmList);
            //return Content(JsonConvert.SerializeObject(EmployeeList), "application/json");
            return Content(JsonConvert.SerializeObject(null), "application/json");
        }
        //public ActionResult SimpleArrayPlainStructure()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult GetTreeViewDepartmentData(DataSourceLoadOptions loadOptions)
        //{
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(TreeViewHierarchicalData.TreeViewDepartments, loadOptions)), "application/json");
        //}
    }
}