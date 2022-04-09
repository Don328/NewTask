using NewTask.Core.Data.Fixtures;
using NewTask.Core.Interfaces;
using NewTask.Core.Mappers;
using NewTask.Shared.Enums;
using NewTask.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Output
{
    public class NotaOutput : IOutputNotas
    {
        private readonly NotaFixture fixture;
        private readonly NotaMapper mapper;

        internal NotaOutput(
            NotaFixture fixture,
            NotaMapper mapper)
        {
            this.fixture = fixture;
            this.mapper = mapper;
        }

        public int Add(Nota nota)
        {
            var dataModel = mapper.MapToDataModel(nota);
            return fixture.Add(dataModel);
        }

        public Result Delete(int notaId)
        {
            return fixture.Remove(notaId);
        }

        public List<Nota> GetAll()
        {
            var notas = new List<Nota>();
            var dataModels = fixture.GetAll();
            foreach (var model in dataModels)
            {
                notas.Add(mapper.MapToOutput(model));
            }

            return notas;
        }

        public List<Nota> GetForOpus(int opusId)
        {
            var notas = new List<Nota>();
            var dataModels = fixture.GetOpusNotas(opusId);
            foreach (var model in dataModels)
            {
                notas.Add(mapper.MapToOutput(model));
            }

            return notas;
        }

        public List<Nota> GetNotaNotas(int notaId)
        {
            var notas = new List<Nota>();
            var dataModels = fixture.GetNotaNotas(notaId);
            foreach (var model in dataModels)
            {
                notas.Add(mapper.MapToOutput(model));
            }

            return notas;
        }

        public Nota GetOne(int notaId)
        {
            var dataModel = fixture.GetOne(notaId);
            return mapper.MapToOutput(dataModel);
        }
    }
}
