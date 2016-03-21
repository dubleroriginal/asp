using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Entity
{
    public class Device
    {
        public int Id { get;set; }       
        public string Type { get; set; }
        public string img { get; set; }
        public int? DeviceId { get; set; }

        public virtual ICollection<AirConditioning> Cond { get; set; }
        public virtual ICollection<Fridge> Fridges { get; set; }
        public virtual ICollection<Kettle> Kettles { get; set; }
        public virtual ICollection<Lamp> Lamps { get; set; }
        public virtual ICollection<StereoSystem> SSyss { get; set; }
        public virtual ICollection<TeleVision> TelVisions { get; set; }
    }
}