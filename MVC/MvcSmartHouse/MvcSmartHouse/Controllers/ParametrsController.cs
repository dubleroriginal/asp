using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSmartHouse.Controllers
{
    public class ParametrsController : Controller
    {
        public ActionResult Output()
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];
            SelectListItem[] deviceListItem = (SelectListItem[])Session["DropDown"];

            Session["Devices"] = deviceList;
            deviceListItem = (SelectListItem[])Session["DropDown"];
            ViewBag.DeviceListItem = deviceListItem;



            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }


            return View("~/Views/SmartHouse/Index.cshtml", filtrDevice);
        }

        public ActionResult VolumeDown(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IVolume)deviceList[id]).VolumeDown();
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


        public ActionResult VolumeUp(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IVolume)deviceList[id]).VolumeUp();
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


        public ActionResult BrightnessDown(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IBrightness)deviceList[id]).BrightnessDown();
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


        public ActionResult BrightnessUp(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IBrightness)deviceList[id]).BrightnessUp();
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


        public ActionResult ProgramBack(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IProgramm)deviceList[id]).ProgrammDown();
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

        public ActionResult ProgramNext(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IProgramm)deviceList[id]).ProgrammUp();
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

        public ActionResult ColorSellect(int id, string chanel)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IColor)deviceList[id]).SelectColor(chanel);
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

        public ActionResult DVDstate(int id,string chanel)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];            

            if(chanel=="diskbox")
            {
                ((Models.Devices.TeleVision)deviceList[id]).DVDcommand(chanel);
                 Session["Devices"] = deviceList;
            }
            else if (chanel=="state")
            {
                ((Models.Devices.TeleVision)deviceList[id]).DVDcommand(chanel);
                Session["Devices"] = deviceList;
            }


            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = Convert.ToString(Session["Filtr"]);

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }
            
            return View("~/Views/SmartHouse/Index.cshtml", filtrDevice);
            
        }
	}
}