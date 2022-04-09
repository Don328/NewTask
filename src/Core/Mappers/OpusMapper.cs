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
    internal class OpusMapper
    {
        private readonly NotaMapper notaMapper;
        
        public OpusMapper(
            NotaMapper notaMapper,
            NotaFixture notaFixture)
        {
            this.notaMapper = notaMapper;
        }

        internal _Opus MapToDataModel(Opus opus)
        {
            return new _Opus
            {
                OpusId = opus.OpusId,
                Title = opus.Title,
                Status = opus.Status,
            };
        }

        internal Opus MapToOutput(_Opus opus)
        {
            var notas = notaMapper.GetOpusNotas(opus.OpusId);
            return new Opus
            {
                OpusId = opus.OpusId,
                Title = opus.Title,
                Status = opus.Status,
                Notas = notas
            };
        }
    }
}
