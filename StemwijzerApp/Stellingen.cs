using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemwijzerApp
{
    public class Stellingen
    {
        public required int id { get; set; }
        public required int categorie_id { get; set; }
        public required string tekst { get; set; }
        public required string status { get; set; }
    }
    

}
