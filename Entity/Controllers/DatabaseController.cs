using Entity.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entity.Models;


namespace Entity.Controllers
{
    public class DatabaseController : Controller
    {
        private DevicesContext dbconnect = new DevicesContext();
        //
        // GET: /Database/
        public ActionResult Index()
        {

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            return View(filtrDevice);
        }

        public ActionResult ChouseDevice(string id)
        {           
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
                           
            switch(id)
            {
                case"lamp":

                    Models.Devices.Lamp lamp;
                    
                      var dev1 = dbconnect.Lamp.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev1)
                      {
                          lamp = new Models.Devices.Lamp("0");

                          lamp.Name = l.Name;
                          lamp.Brightness = l.Brightness;
                          lamp.State = l.State;
                          lamp.currentcolor = l.CurrentColor;

                          filtrDevice.Add(l.Id,lamp);                         
                      }


                    break;
                case "tv":

                     Models.Devices.TeleVision tV;
                     Models.Devices.Bluray bluray = new Models.Devices.Bluray("0");

                      var dev = dbconnect.Bluray;
                      var dev2 = dbconnect.TeleVision.Include(p=>p.Device).ToList();    
                            
                      foreach(var l in dev2)
                      {
                          foreach(var d in dev)
                          {                             
                              bluray.IsDiskboxOpen = d.IsDiskboxOpen;
                              bluray.IsPlay = d.IsPlay;
                              bluray.Name = d.Name;
                          }

                          tV = new Models.Devices.TeleVision("0",bluray,Models.Addition.Chanel.ICTV);

                          tV.Name = l.Name;
                          tV.State = l.State;
                          tV.Brightness = l.Brightness;
                          tV.Mode = l.Mode;
                          tV.Volume = l.Volume;

                            switch(l.CurrentChanel)
                            {
                                case "ICTV":
                                    tV.Chanel = Models.Addition.Chanel.ICTV;
                                    break;
                                case "NationalGeographics":
                                    tV.Chanel = Models.Addition.Chanel.NationalGeographics;
                                    break;
                                case "M1":
                                    tV.Chanel = Models.Addition.Chanel.M1;
                                    break;
                                case "Інтер":
                                    tV.Chanel = Models.Addition.Chanel.Інтер;
                                    break;
                                case "Україна":
                                    tV.Chanel = Models.Addition.Chanel.Україна;
                                    break;
                            }

                          filtrDevice.Add(l.Id,tV);                          
                      }

                    break;
                case "ss":

                    Models.Devices.StereoSystem SSys;

                    var dev3 = dbconnect.StereoSystem.Include(p => p.Device).ToList();                                
                      foreach(var l in dev3)
                      {
                          SSys = new Models.Devices.StereoSystem("0");

                          SSys.Name = l.Name;
                          SSys.State = l.State;
                          SSys.Mode = l.Mode;
                          SSys.Volume = l.Volume;

                          filtrDevice.Add(l.Id, SSys);                          
                      }

                    break;
                case "kettle":

                   Models.Devices.Kettle ket;
                    
                      var dev4 = dbconnect.Kettle.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev4)
                      {
                          ket = new Models.Devices.Kettle("0");

                          ket.Name = l.Name;
                          ket.State = l.State;

                          filtrDevice.Add(l.Id, ket);                         
                      }

                    break;
                case "fridge":

                    Models.Devices.Fridge fridge;
                    
                      var dev5 = dbconnect.Fridge.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev5)
                      {
                          fridge = new Models.Devices.Fridge("0");

                          fridge.Name = l.Name;
                          fridge.State = l.State;
                          fridge.StateFrize = l.StateFrize;
                          fridge.Programm = l.Programm;
                          
                          filtrDevice.Add(l.Id, fridge);
                         
                      }

                    break;
                case "aircond":

                    Models.Devices.AirConditioning airconde;

                   var dev6 = dbconnect.AirConditioning.Include(p => p.Device).ToList();                                
                      foreach(var l in dev6)
                      {
                          airconde = new Models.Devices.AirConditioning("0");

                          airconde.Name = l.Name;
                          airconde.State = l.State;
                          airconde.Programm = l.Programm;

                          filtrDevice.Add(l.Id, airconde);                         
                      }

                    break;
            }
           
            return View("Index",filtrDevice);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("~/Views/AddDevice.cshtml");
        }
        [HttpPost]
        public ActionResult Add(string type, string Namedevice)
        {           
            
            switch (type)
            {
                case "aircond":

                    Device d = new Device { Type = "aircond", img = "~/Content/Images/MainScreen/cond.jpg" };
                    AirConditioning c = new AirConditioning { Name = Namedevice, State = false, Programm = 2, Device = d };  
                    

                    Session["Filtr"] = type;
                    dbconnect.AirConditioning.Add(c);
                    dbconnect.SaveChanges();
                    

                    break;
                case "ss":

                    Device d1 = new Device { Type = "ss", img = "~/Content/Images/MainScreen/TR.jpg" };
                    StereoSystem ss = new StereoSystem { Name = Namedevice, State = false, Mode = false, Volume = 20, Device = d1 };                    

                    Session["Filtr"] = type;  
                    dbconnect.StereoSystem.Add(ss);
                    dbconnect.SaveChanges();
                    break;
                case "lamp":

                    Device d2 = new Device { Type = "lamp", img = "~/Content/Images/MainScreen/lamp.jpg" };
                    Lamp l = new Lamp { Name = Namedevice, State = false, Brightness = 20, CurrentColor = 1, Device = d2 };            

                    Session["Filtr"] = type;  
                    dbconnect.Lamp.Add(l);
                    dbconnect.SaveChanges();

                    break;
                case "fridge":

                    Device d3 = new Device { Type = "fridge", img = "~/Content/Images/MainScreen/fridge.jpg" };
                    Fridge f = new Fridge { Name = Namedevice, State = false, StateFrize = false, Programm = 1, Device = d3 };         

                    Session["Filtr"] = type;  
                    dbconnect.Fridge.Add(f);
                    dbconnect.SaveChanges();

                    break;
                case "kettle":

                    Device d4 = new Device { Type = "kettle", img = "~/Content/Images/MainScreen/kettle.jpg" };
                    Kettle k = new Kettle { Name = Namedevice, State = false, Device = d4 };         

                    Session["Filtr"] = type;  
                    dbconnect.Kettle.Add(k);
                    dbconnect.SaveChanges();

                    break;
                case "tv":

                     Device d5 = new Device { Type = "tv", img = "~/Content/Images/MainScreen/tv.jpg" };
                     TeleVision tv = new TeleVision { Name = Namedevice, State = false, CurrentChanel = "ICTV",
                                                      Volume = 20, Brightness = 30, Mode = false, Device = d5 };
                     Bluray bluray = new Bluray { State = false, IsDiskboxOpen = false, IsPlay = false, TeleVision = tv };

                    Session["Filtr"] = type;  
                    dbconnect.TeleVision.Add(tv);
                    dbconnect.Bluray.Add(bluray);
                    dbconnect.SaveChanges();

                    break;


            }



            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            return View("Index", filtrDevice);

        }


       
       
        public ActionResult Delete(int id, string chanel)
        {
            IDictionary<int, string> del=new SortedDictionary<int, string>();
            del.Add(id,chanel);
            return View(del);
        }        
        public ActionResult Del(int id, string chanel)
        {
            try
            {
               switch(chanel)
               {
                   case "aircond":

                       AirConditioning c = dbconnect.AirConditioning.Find(id);

                       dbconnect.AirConditioning.Remove(c);                      
                       dbconnect.SaveChanges();

                       break;
                   case "ss":

                       StereoSystem ss = dbconnect.StereoSystem.Find(id);
                       dbconnect.StereoSystem.Remove(ss);                      
                       dbconnect.SaveChanges();
                       break;
                   case "lamp":

                       Lamp l = dbconnect.Lamp.Find(id);
                       dbconnect.Lamp.Remove(l);
                       dbconnect.SaveChanges();

                       break;
                   case "fridge":

                       Fridge f = dbconnect.Fridge.Find(id);
                       dbconnect.Fridge.Remove(f);
                       dbconnect.SaveChanges();

                       break;
                   case "kettle":

                       Kettle k = dbconnect.Kettle.Find(id);
                       dbconnect.Kettle.Remove(k);
                       dbconnect.SaveChanges();

                       break;
                   case "tv":

                      
                       TeleVision tv = dbconnect.TeleVision.Include(p => p.Blurays).Where(p => p.Id == id).FirstOrDefault();                   
                      dbconnect.TeleVision.Remove(tv);
                      dbconnect.SaveChanges();

                       break;
               }

               IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
               return View("Index", filtrDevice);
            }
            catch
            {
                IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
                return View("Index", filtrDevice);
            }
        }

        public ActionResult ToWebApi()
        {
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
             
                     Models.Devices.TeleVision tV;
                     Models.Devices.Bluray bluray = new Models.Devices.Bluray("0");

                      var dev = dbconnect.Bluray;
                      var dev2 = dbconnect.TeleVision.Include(p=>p.Device).ToList();    
                            
                      foreach(var l in dev2)
                      {
                          foreach(var d in dev)
                          {                             
                              bluray.IsDiskboxOpen = d.IsDiskboxOpen;
                              bluray.IsPlay = d.IsPlay;
                              bluray.Name = d.Name;
                          }

                          tV = new Models.Devices.TeleVision("0",bluray,Models.Addition.Chanel.ICTV);

                          tV.Name = l.Name;
                          tV.State = l.State;
                          tV.Brightness = l.Brightness;
                          tV.Mode = l.Mode;
                          tV.Volume = l.Volume;

                            switch(l.CurrentChanel)
                            {
                                case "ICTV":
                                    tV.Chanel = Models.Addition.Chanel.ICTV;
                                    break;
                                case "NationalGeographics":
                                    tV.Chanel = Models.Addition.Chanel.NationalGeographics;
                                    break;
                                case "M1":
                                    tV.Chanel = Models.Addition.Chanel.M1;
                                    break;
                                case "Інтер":
                                    tV.Chanel = Models.Addition.Chanel.Інтер;
                                    break;
                                case "Україна":
                                    tV.Chanel = Models.Addition.Chanel.Україна;
                                    break;
                            }


                          filtrDevice.Add(l.Id,tV);                          
                      }
                      return View("~/Views/JS/JS.cshtml", filtrDevice);

        }
    }
}
