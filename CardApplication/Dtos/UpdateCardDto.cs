using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardApplication.Dtos
{
    public class UpdateCardDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
