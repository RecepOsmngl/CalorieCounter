using CalorieCounterEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterDataAccess.Configuration
{
    public class MealCategoryConfiguration : IEntityTypeConfiguration<MealCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<MealCategoryEntity> builder)
        {
            // Primary Key
            builder.HasKey(x => x.MealCategoryID);
        }
    }
}
