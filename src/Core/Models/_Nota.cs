using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Models
{
    internal class _Nota
    {
        public int NotaId { get; set; }
        public int OpusId { get; set; }
        public int? ParentNotaId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
