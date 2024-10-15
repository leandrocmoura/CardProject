using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApplication.Dtos
{
    public class CreateCardDto
    {
        public string Title { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
