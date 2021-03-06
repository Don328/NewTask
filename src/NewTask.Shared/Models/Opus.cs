using NewTask.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Shared.Models
{
    public class Opus
    {
        public int OpusId { get; set; }
        public string Title { get; set; } = string.Empty;
        public OpusStatus Status { get; set; } = 0;
        public List<Nota> Notas { get; set; } = new List<Nota>();
    }
}
