﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShooterLink.API.Data;

#nullable disable

namespace ShooterLink.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ShooterLink.API.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1ca61828-4c2b-4af5-b551-498f97b864b7"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("6239f1d1-6dae-40c0-bf45-9ff9fd75216f"),
                            Name = "Athlete"
                        },
                        new
                        {
                            Id = new Guid("b1106934-acd5-4000-a4e3-0b789d28f494"),
                            Name = "Coach"
                        },
                        new
                        {
                            Id = new Guid("d7309100-d517-403c-8584-b005a406847d"),
                            Name = "Office"
                        },
                        new
                        {
                            Id = new Guid("e5e88f2c-953c-4fe2-862e-0e5ff74242fd"),
                            Name = "Guest"
                        });
                });

            modelBuilder.Entity("ShooterLink.API.Data.Entities.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool?>("BoolValue")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Timestamp")
                        .HasDefaultValue(new DateTime(2024, 3, 8, 18, 39, 27, 344, DateTimeKind.Local).AddTicks(7301));

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateValue")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("DoubleValue")
                        .HasColumnType("double precision");

                    b.Property<int?>("IntValue")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Timestamp")
                        .HasDefaultValue(new DateTime(2024, 3, 8, 18, 39, 27, 344, DateTimeKind.Local).AddTicks(7794));

                    b.Property<Guid>("ModifierId")
                        .HasColumnType("uuid");

                    b.Property<string>("SettingName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("StringValue")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("ShooterLink.API.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Timestamp")
                        .HasDefaultValue(new DateTime(2024, 3, 8, 18, 39, 27, 344, DateTimeKind.Local).AddTicks(8741));

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NickName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Token")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("Verified")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("ShooterLink.API.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShooterLink.API.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShooterLink.API.Data.Entities.Setting", b =>
                {
                    b.HasOne("ShooterLink.API.Data.Entities.User", "Creator")
                        .WithMany("CreatedSettings")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShooterLink.API.Data.Entities.User", "Modifier")
                        .WithMany("ModifiedSettings")
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("ShooterLink.API.Data.Entities.User", b =>
                {
                    b.Navigation("CreatedSettings");

                    b.Navigation("ModifiedSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
