using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSmartHouse.Models
{
    public interface IColor
    {
        void SelectColor(string idColor);
        string ReturnColor();
    }
}
