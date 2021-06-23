using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.ViewModel
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }
    }
}
