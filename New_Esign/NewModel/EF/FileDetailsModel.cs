using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewModel.EF
{
    public class FileDetailsModel
    {
        public int? Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
