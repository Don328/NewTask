using NewTask.Core.Models;
using NewTask.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Data.Fixtures
{
    internal class OpusFixture
    {
        private readonly InMemDbContext inMemDb;
        private readonly NotaFixture notasFixture;

        internal OpusFixture(
            InMemDbContext inMemDb,
            NotaFixture notasFixture)
        {
            this.inMemDb = inMemDb;
            this.notasFixture = notasFixture;
        }

        internal List<_Opus> GetAll()
        {
            return inMemDb.Opera.ToList();
        }

        internal List<_Opus> GetNovus()
        {
            return (from o in inMemDb.Opera
                    where o.Status == OpusStatus.Novus
                    select o).ToList();
        }

        internal List<_Opus> GetAccedent()
        {
            return (from o in inMemDb.Opera
                   where o.Status == OpusStatus.Accedent
                   select o).ToList();
        }        
        
        internal List<_Opus> GetPendente()
        {
            return (from o in inMemDb.Opera
                   where o.Status == OpusStatus.Pendente
                   select o).ToList();
        }
                
        internal List<_Opus> GetCompletum()
        {
            return (from o in inMemDb.Opera
                   where o.Status == OpusStatus.Completum
                   select o).ToList();
        }
        
        internal _Opus GetOne(int opusId)
        {
            return (from o in inMemDb.Opera
                    where o.OpusId == opusId
                    select o).FirstOrDefault()
                    ?? new _Opus();
        }

        internal int Add(_Opus opus)
        {
            inMemDb.Add(opus);
            inMemDb.SaveChanges();

            return opus.OpusId;
        }
    
        internal Result ChangeStatus(
            int opusId,
            OpusStatus status)
        {
            var opus = (from o in inMemDb.Opera
                        where o.OpusId == opusId
                        select o).FirstOrDefault();

            if (opus != null)
            {
                opus.Status = status;
                inMemDb.Update(opus);
                inMemDb.SaveChanges();
                return Result.Success;
            }

            return Result.Fail;
        }

        internal Result Remove(int opusId)
        {
            var opus = (from o in inMemDb.Opera
                        where o.OpusId == opusId
                        select o).FirstOrDefault();

            if (opus != null)
            {
                notasFixture.RemoveOpusNotas(opusId);
                inMemDb.Opera.Remove(opus);
                inMemDb.SaveChanges();
                return Result.Success;
            }

            return Result.Fail;
        }
    }
}
