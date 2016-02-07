using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truewheelers.Models;

namespace Truewheelers.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<Bicycles> model { get; set; }
    }
}
