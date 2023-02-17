using CalorieCounterEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterDataAccess.Configuration
{
    public class PhotographConfiguration : IEntityTypeConfiguration<PhotographEntity>
    {
        public void Configure(EntityTypeBuilder<PhotographEntity> builder)
        {
            // Primary Key
            builder.HasKey(x => x.PhotographID);
        }
    }
}
