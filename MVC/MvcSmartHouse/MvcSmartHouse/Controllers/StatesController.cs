using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSmartHouse.Controllers
{
    public class StatesController : Controller
    {
       

        public ActionResult SwitchFrize(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IFrize)deviceList[id]).SwitchFrize();
             Session["Devices"] = deviceList;

             IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
             string filtr = Convert.ToString(Session["Filtr"]);            

             foreach (var item in deviceList)
             {
                 if (item.Value.Id == filtr)
                     filtrDevice.Add(item.Key, item.Value);
             }


             return View("~/Views/SmartHouse/Index.cshtml", filtrDevice);
        }

        public ActionResult SwitchMode(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IMode)deviceList[id]).ChangeMod();
            Session["Devices"] = deviceList;

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            return View("~/Views/SmartHouse/Index.cshtml", filtrDevice);
        }


        public ActionResult Switch(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];
            SelectListItem[]  deviceListItem = (SelectListItem[])Session["DropDown"];

            ((Models.IState)deviceList[id]).Switch();

            Session["Devices"] = deviceList;


            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }

            //deviceListItem = (SelectListItem[])Session["DropDown"];
            //ViewBag.DeviceListItem = deviceListItem;

            return View("~/Views/SmartHouse/Index.cshtml", filtrDevice);
        }
	}
}