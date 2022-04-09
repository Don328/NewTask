using NewTask.Core.Data.Fixtures;
using NewTask.Core.Models;
using NewTask.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Mappers
{
    internal class NotaMapper
    {
        private readonly NotaFixture notaFixture;

        internal NotaMapper(NotaFixture notaFixture)
        {
            this.notaFixture = notaFixture;
        }

        internal _Nota MapToDataModel(Nota nota)
        {
            return new _Nota
            {
                NotaId = nota.NotaId,
                OpusId = nota.OpusId,
                ParentNotaId = nota.ParentNotaId,
                Title = nota.Title,
                Text = nota.Text
            };
        }

        internal Nota MapToOutput(_Nota nota)
        {
            return new Nota
            {
                NotaId = nota.NotaId,
                OpusId = nota.OpusId,
                ParentNotaId = nota.ParentNotaId,
                Title = nota.Title,
                Text = nota.Text,
                SubNotas = GetChildNotas(nota.NotaId)
            };
        }

        internal List<Nota> GetOpusNotas(int opusId)
        {
            var notas = new List<Nota>();
            var dataModels = notaFixture.GetOpusNotas(opusId);
            foreach (var model in dataModels)
            {
                var nota = MapToOutput(model);
                notas.Add(nota);
            }

            return notas;
        }

        private List<Nota> GetChildNotas(int notaId)
        {
            var notas = new List<Nota>();
            var dataModels = notaFixture.GetNotaNotas(notaId);
            foreach (var model in dataModels)
            {
                var nota = MapToOutput(model);
                notas.Add(nota);
            }

            return notas;
        }   
    }
}
