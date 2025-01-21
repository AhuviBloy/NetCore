﻿// <auto-generated />
using System;
using EventCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241226224330_addForiegnKey")]
    partial class addForiegnKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Event.Core.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ClientStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("clientDbSet");
                });

            modelBuilder.Entity("Event.Core.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.Property<string>("ProducerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ProducerStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("producersDbSet");
                });

            modelBuilder.Entity("Event.Core.Models.SingleEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventPrice")
                        .HasColumnType("int");

                    b.Property<bool>("EventStatus")
                        .HasColumnType("bit");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("eventDbSet");
                });

            modelBuilder.Entity("Event.Core.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EventId");

                    b.ToTable("ticketDbSet");
                });

            modelBuilder.Entity("Event.Core.Models.SingleEvent", b =>
                {
                    b.HasOne("Event.Core.Models.Producer", null)
                        .WithMany("ProducerEvents")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Event.Core.Models.Ticket", b =>
                {
                    b.HasOne("Event.Core.Models.Client", "Client")
                        .WithMany("ClientTicketList")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event.Core.Models.SingleEvent", "Event")
                        .WithMany("TicketList")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Event.Core.Models.Client", b =>
                {
                    b.Navigation("ClientTicketList");
                });

            modelBuilder.Entity("Event.Core.Models.Producer", b =>
                {
                    b.Navigation("ProducerEvents");
                });

            modelBuilder.Entity("Event.Core.Models.SingleEvent", b =>
                {
                    b.Navigation("TicketList");
                });
#pragma warning restore 612, 618
        }
    }
}
