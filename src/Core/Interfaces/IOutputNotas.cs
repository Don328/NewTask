using NewTask.Shared.Enums;
using NewTask.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Interfaces
{
    public interface IOutputNotas
    {
        public List<Nota> GetAll();
        public List<Nota> GetForOpus(int opusId);
        public List<Nota> GetNotaNotas(int notaId);
        public Nota GetOne(int notaId);
        public int Add(Nota nota);
        public Result Delete(int notaId);
    }
}
