using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Data.ModelBuilders
{
    internal class OpusModelBuilder : IEntityTypeConfiguration<_Opus>
    {
        public void Configure(EntityTypeBuilder<_Opus> builder)
        {
            builder.Property(o => o.OpusId).ValueGeneratedOnAdd();
            builder.Property(o => o.Title).IsRequired();
            builder.Property(o => o.Status);
            builder.HasKey(o => o.OpusId);
        }
    }
}
