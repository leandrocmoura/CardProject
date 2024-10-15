using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDomain.Entities
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Base64Image{ get; set; }
    }

}
