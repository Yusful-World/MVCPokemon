﻿// <auto-generated />
using System;
using MVCPokemon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCPokemon.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    [Migration("20250219020634_AddPhotoToDb")]
    partial class AddPhotoToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCPokemon.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("MVCPokemon.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Colour = "orange",
                            ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/0/6087/2437349-pikachu.png",
                            Name = "Pikachu",
                            Owner = "Tunji",
                            Power = "Lightening"
                        },
                        new
                        {
                            Id = 2,
                            Colour = "green",
                            ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891758-001bulbasaur.png",
                            Name = "Balbasaur",
                            Owner = "Yusuf",
                            Power = "Water"
                        },
                        new
                        {
                            Id = 3,
                            Colour = "darkorange",
                            ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891761-004charmander.png",
                            Name = "Charmander",
                            Owner = "Glory",
                            Power = "Fire"
                        },
                        new
                        {
                            Id = 4,
                            Colour = "teal",
                            ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891764-007squirtle.png",
                            Name = "Squirtle",
                            Owner = "Oscar",
                            Power = "Stone"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
