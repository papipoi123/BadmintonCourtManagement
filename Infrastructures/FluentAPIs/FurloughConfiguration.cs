﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPIs
{
    public class FurloughConfiguration : IEntityTypeConfiguration<Furlough>
    {
        public void Configure(EntityTypeBuilder<Furlough> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Furloughs)
                   .HasForeignKey(x => x.userId);
        }
    }
}
