using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class HamsterConfiguration : IEntityTypeConfiguration<Hamster>
    {
        public void Configure(EntityTypeBuilder<Hamster> builder)
        {
            builder.HasData(
                        new Hamster
                        {
                            Id = 1,
                            Name = "Scooby",
                            ImageUrl = "/Content/Images/hamster-1.jpg",
                            Age = 1,
                            Loves = "World of Warcraft",
                            FavoriteFood = "Chinese food"
                        },
                        new Hamster
                        {
                            Id = 2,
                            Name = "Shaggy",
                            ImageUrl = "/Content/Images/hamster-2.jpg",
                            Age = 2,
                            Loves = "Rugby",
                            FavoriteFood = "Broccoli"
                        },
                        new Hamster
                        {
                            Id = 3,
                            Name = "Fred",
                            ImageUrl = "/Content/Images/hamster-3.jpg",
                            Age = 3,
                            Loves = "Football",
                            FavoriteFood = "Chicken and Rice"
                        },
                        new Hamster
                        {
                            Id = 4,
                            Name = "George",
                            ImageUrl = "/Content/Images/hamster-4.jpg",
                            Age = 1,
                            Loves = "Skateboarding",
                            FavoriteFood = "Pizza"
                        },
                        new Hamster
                        {
                            Id = 5,
                            Name = "Harry",
                            ImageUrl = "/Content/Images/hamster-5.jpg",
                            Age = 1,
                            Loves = "Running",
                            FavoriteFood = "Chinese food"
                        },
                        new Hamster
                        {
                            Id = 6,
                            Name = "Ron",
                            ImageUrl = "/Content/Images/hamster-6.jpg",
                            Age = 1,
                            Loves = "Golfing",
                            FavoriteFood = "McDonalds"
                        },
                        new Hamster
                        {
                            Id = 7,
                            Name = "Dumbledore",
                            ImageUrl = "/Content/Images/hamster-7.jpg",
                            Age = 1,
                            Loves = "Sleeping",
                            FavoriteFood = "Carrots"
                        },
                        new Hamster
                        {
                            Id = 8,
                            Name = "Göran",
                            ImageUrl = "/Content/Images/hamster-35.jpg",
                            Age = 1,
                            Loves = "Liseberg",
                            FavoriteFood = "Pasta"
                        }
                );
        }

    }
}
