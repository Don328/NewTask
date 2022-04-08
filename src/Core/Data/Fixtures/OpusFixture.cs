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

        internal OpusFixture(InMemDbContext inMem)
        {
            this.inMemDb = inMem;
        }

        internal List<_Opus> GetAll()
        {
            return inMemDb.Opera.ToList();
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

        internal Result Remove(int opusId)
        {
            var opus = (from o in inMemDb.Opera
                        where o.OpusId == opusId
                        select o).FirstOrDefault();

            if (opus != null)
            {
                inMemDb.Opera.Remove(opus);
                inMemDb.SaveChanges();
                return Result.Success;
            }

            return Result.Fail;
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
    }
}
