using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BLL.DTOs
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //[JsonConverter(typeof(IsoDateTimeConverter))]
        public System.DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
