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
    public class OpusOutput : IOutputOpera
    {
        private readonly OpusFixture fixture;
        private readonly OpusMapper mapper;

        internal OpusOutput(
            OpusFixture fixture,
            OpusMapper mapper)
        {
            this.fixture = fixture;
            this.mapper = mapper;
        }

        public int Add(Opus opus)
        {
            var model = mapper.MapToDataModel(opus);
            return fixture.Add(model);
        }

        public Result ChangeStatus(int opusId, OpusStatus newStatus)
        {
            return fixture.ChangeStatus(opusId, newStatus);
        }

        public Result Delete(int opusId)
        {
            return fixture.Remove(opusId);
        }

        public List<Opus> GetAccedent()
        {
            var opera = new List<Opus>();
            var models = fixture.GetAccedent();
            foreach (var model in models)
            {
                opera.Add(mapper.MapToOutput(model));
            }

            return opera;
        }

        public List<Opus> GetAll()
        {
            var opera = new List<Opus>();
            var models = fixture.GetAll();
            foreach (var model in models)
            {
                opera.Add(mapper.MapToOutput(model));
            }

            return opera;
        }

        public List<Opus> GetCompletum()
        {
            var opera = new List<Opus>();
            var models = fixture.GetCompletum();
            foreach (var model in models)
            {
                opera.Add(mapper.MapToOutput(model));
            }

            return opera;
        }

        public List<Opus> GetNovus()
        {
            var opera = new List<Opus>();
            var models = fixture.GetNovus();
            foreach (var model in models)
            {
                opera.Add(mapper.MapToOutput(model));
            }

            return opera;
        }

        public Opus GetOne(int opusId)
        {
            var model = fixture.GetOne(opusId);
            return mapper.MapToOutput(model);
        }

        public List<Opus> GetPendente()
        {
            var opera = new List<Opus>();
            var models = fixture.GetPendente();
            foreach (var model in models)
            {
                opera.Add(mapper.MapToOutput(model));
            }

            return opera;
        }
    }
}
