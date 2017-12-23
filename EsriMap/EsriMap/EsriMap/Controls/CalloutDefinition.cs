using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriMap.Controls
{
    public class CalloutDefinition
    {
        public MapPoint Location { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
