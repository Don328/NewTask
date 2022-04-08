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
    internal class NotaModelBuilder : IEntityTypeConfiguration<_Nota>
    {
        public void Configure(EntityTypeBuilder<_Nota> builder)
        {
            builder.Property(n => n.NotaId).ValueGeneratedOnAdd();
            builder.Property(n => n.OpusId);
            builder.Property(n => n.ParentNotaId);
            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Text).IsRequired();
            builder.HasKey(n => n.NotaId);
            builder.HasIndex(n => n.OpusId);
        }
    }
}
