using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.DBO
{
    public class ImageOut
    {
        public Guid Id { get; set; }
        public string Base64String { get; set; }
        public string Path { get; set; }

    }
}
