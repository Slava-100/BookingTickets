﻿// <auto-generated />
using System;
using BookingTickets.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookingTickets.DataLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240503155041_RenamedLoginUserToEmail")]
    partial class RenamedLoginUserToEmail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.CinemaDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_cinemas");

                    b.ToTable("cinemas", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.HallDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uuid")
                        .HasColumnName("cinema_id");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.HasKey("Id")
                        .HasName("pk_halls");

                    b.HasIndex("CinemaId")
                        .HasDatabaseName("ix_halls_cinema_id");

                    b.ToTable("halls", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.OrderDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_user_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.OrderPlaceDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("uuid")
                        .HasColumnName("place_id");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid")
                        .HasColumnName("session_id");

                    b.HasKey("Id")
                        .HasName("pk_order_places");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_places_order_id");

                    b.HasIndex("PlaceId")
                        .HasDatabaseName("ix_order_places_place_id");

                    b.HasIndex("SessionId")
                        .HasDatabaseName("ix_order_places_session_id");

                    b.ToTable("order_places", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.PlaceDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid")
                        .HasColumnName("hall_id");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<int>("Row")
                        .HasColumnType("integer")
                        .HasColumnName("row");

                    b.HasKey("Id")
                        .HasName("pk_places");

                    b.HasIndex("HallId")
                        .HasDatabaseName("ix_places_hall_id");

                    b.ToTable("places", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.SessionDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uuid")
                        .HasColumnName("film_id");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid")
                        .HasColumnName("hall_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("time");

                    b.HasKey("Id")
                        .HasName("pk_sessions");

                    b.HasIndex("FilmId")
                        .HasDatabaseName("ix_sessions_film_id");

                    b.HasIndex("HallId")
                        .HasDatabaseName("ix_sessions_hall_id");

                    b.ToTable("sessions", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.UserDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<Guid?>("CinemaId")
                        .HasColumnType("uuid")
                        .HasColumnName("cinema_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Position")
                        .HasColumnType("integer")
                        .HasColumnName("position");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("salt");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("CinemaId")
                        .HasDatabaseName("ix_users_cinema_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.Dto.FilmDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_films");

                    b.ToTable("films", (string)null);
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.HallDto", b =>
                {
                    b.HasOne("BookingTickets.Core.Models.DTO.CinemaDto", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_halls_cinemas_cinema_id");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.OrderDto", b =>
                {
                    b.HasOne("BookingTickets.Core.Models.DTO.UserDto", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.OrderPlaceDto", b =>
                {
                    b.HasOne("BookingTickets.Core.Models.DTO.OrderDto", "Order")
                        .WithMany("OrderPlaces")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_places_orders_order_id");

                    b.HasOne("BookingTickets.Core.Models.DTO.PlaceDto", "Place")
                        .WithMany("OrderPlaces")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_places_places_place_id");

                    b.HasOne("BookingTickets.Core.Models.DTO.SessionDto", "Session")
                        .WithMany("OrderPlaces")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_places_sessions_session_id");

                    b.Navigation("Order");

                    b.Navigation("Place");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.PlaceDto", b =>
                {
                    b.HasOne("BookingTickets.Core.Models.DTO.HallDto", "Hall")
                        .WithMany("Places")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_places_halls_hall_id");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.SessionDto", b =>
                {
                    b.HasOne("BookingTickets.Core.Models.Dto.FilmDto", "Film")
                        .WithMany("Sessions")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sessions_films_film_id");

                    b.HasOne("BookingTickets.Core.Models.DTO.HallDto", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sessions_halls_hall_id");

                    b.Navigation("Film");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.UserDto", b =>
                {
                    b.HasOne("BookingTickets.Core.Models.DTO.CinemaDto", "Cinema")
                        .WithMany("Users")
                        .HasForeignKey("CinemaId")
                        .HasConstraintName("fk_users_cinemas_cinema_id");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.CinemaDto", b =>
                {
                    b.Navigation("Halls");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.HallDto", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.OrderDto", b =>
                {
                    b.Navigation("OrderPlaces");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.PlaceDto", b =>
                {
                    b.Navigation("OrderPlaces");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.SessionDto", b =>
                {
                    b.Navigation("OrderPlaces");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.DTO.UserDto", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BookingTickets.Core.Models.Dto.FilmDto", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
