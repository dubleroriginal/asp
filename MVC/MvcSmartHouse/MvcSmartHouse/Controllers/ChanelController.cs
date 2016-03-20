using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSmartHouse.Controllers
{
    public class ChanelController : Controller
    {
             

        public ActionResult Nextchanel(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IChanel)deviceList[id]).ChanelUp();
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

        public ActionResult Beakchanel(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IChanel)deviceList[id]).ChanelDown();
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

        public ActionResult Chusechanel(int id, string chanel)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];

            ((Models.IChanel)deviceList[id]).ChuseChanel(chanel);
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
	}
}