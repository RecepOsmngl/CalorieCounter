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
    public class MealConfiguration : IEntityTypeConfiguration<MealEntity>
    {
        public void Configure(EntityTypeBuilder<MealEntity> builder)
        {
            // Primary Key
            builder.HasKey(x => x.MealID);

            // OneToMany Relation
            builder.HasOne(x => x.UserEntity)
                   .WithMany(x => x.MealEntity)
                   .HasForeignKey(x => x.UserID);

            builder.HasOne(x => x.MealCategoryEntity)
                   .WithMany(x => x.MealEntity)
                   .HasForeignKey(x => x.MealCategoryID);

            builder.HasOne(x => x.FoodEntity)
                   .WithMany(x => x.MealEntity)
                   .HasForeignKey(x => x.FoodID);

        }
    }
}
