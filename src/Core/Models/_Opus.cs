using NewTask.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Models
{
    internal class _Opus
    {
        public int OpusId { get; set; }
        public string Title { get; set; } = string.Empty;
        public OpusStatus Status { get; set; } = 0;
    }
}
