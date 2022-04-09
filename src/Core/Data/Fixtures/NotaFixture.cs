using NewTask.Core.Models;
using NewTask.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Data.Fixtures
{
    internal class NotaFixture
    {
        private readonly InMemDbContext inMem;

        internal NotaFixture(InMemDbContext inMem)
        {
            this.inMem = inMem;
        }

        internal List<_Nota> GetAll()
        {
            return inMem.Notas.ToList();
        }

        internal List<_Nota> GetOpusNotas(int opusId)
        {
            return (from n in inMem.Notas
                    where n.OpusId == opusId
                    && n.ParentNotaId == null
                    select n).ToList();
        }

        internal List<_Nota> GetNotaNotas(int parentId)
        {
            return (from n in inMem.Notas
                    where n.ParentNotaId == parentId
                    select n).ToList();
        }

        internal _Nota GetOne(int notaId)
        {
            return (from n in inMem.Notas
                    where n.NotaId == notaId
                    select n).FirstOrDefault()
                    ?? new _Nota();
        }

        internal int Add(_Nota nota)
        {
            inMem.Add(nota);
            inMem.SaveChanges();

            return nota.NotaId;
        }

        internal Result Remove(int notaId)
        {

            var nota = (from n in inMem.Notas
                        where n.NotaId == notaId
                        select n).FirstOrDefault();
            if (nota != null)
            {
                RemoveChildNotas(notaId);
                inMem.Remove(nota);
                inMem.SaveChanges();
                return Result.Success;
            }

            return Result.Fail;
        }

        internal void RemoveOpusNotas(int opusId)
        {
            var notas = (from n in inMem.Notas
                         where n.OpusId == opusId
                         select n).ToList();

            foreach(var nota in notas)
            {
                RemoveChildNotas(nota.NotaId);
                inMem.Notas.Remove(nota);
            }

            inMem.SaveChanges();
        }

        private void RemoveChildNotas(int notaId)
        {
            var notas = (from n in inMem.Notas
                         where n.ParentNotaId == notaId
                         select n).ToList();
            
            foreach (var nota in notas)
            {
                RemoveChildNotas(nota.NotaId);
                inMem.Remove(nota);
            }
        }
    }
}
