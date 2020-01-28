using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp.Models
{
    public class ExchangeModel
    {
        public IList<Rate> rates { get; set; }
        public string baseCode {get;set;}
        public string date { get; set; }    
    }
}
