using NewTask.Shared.Enums;
using NewTask.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Interfaces
{
    public interface IOutputOpera
    {
        public List<Opus> GetAll();
        public List<Opus> GetNovus();
        public List<Opus> GetAccedent();
        public List<Opus> GetPendente();
        public List<Opus> GetCompletum();
        public Opus GetOne(int opusId);
        public int Add(Opus opus);
        public Result ChangeStatus(int opusId, OpusStatus newStatus);
        public Result Delete(int opusId);
        
    }
}
