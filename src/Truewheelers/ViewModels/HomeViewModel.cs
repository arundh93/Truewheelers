using Truewheelers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Truewheelers.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Bicycles> model { get; set; }
        public int buttonID { get; set; }
    }
}
