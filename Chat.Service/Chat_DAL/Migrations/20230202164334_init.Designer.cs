﻿// <auto-generated />
using System;
using Chat_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chat_DAL.Migrations
{
    [DbContext(typeof(ChatDataContext))]
    [Migration("20230202164334_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("Chat_Models.Models.ChatConnection", b =>
                {
                    b.Property<string>("ChatId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChatterId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ChatId");

                    b.HasIndex("ChatterId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Chat_Models.Models.Chatter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Chatters");
                });

            modelBuilder.Entity("Chat_Models.Models.Message", b =>
                {
                    b.Property<Guid>("MessageeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChatID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReceived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NewMessage")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("TEXT");

                    b.HasKey("MessageeID");

                    b.HasIndex("ChatID");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Chat_Models.Models.ChatConnection", b =>
                {
                    b.HasOne("Chat_Models.Models.Chatter", "Chatter")
                        .WithMany("Chats")
                        .HasForeignKey("ChatterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chatter");
                });

            modelBuilder.Entity("Chat_Models.Models.Message", b =>
                {
                    b.HasOne("Chat_Models.Models.ChatConnection", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chat_Models.Models.Chatter", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chat_Models.Models.Chatter", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Chat_Models.Models.ChatConnection", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Chat_Models.Models.Chatter", b =>
                {
                    b.Navigation("Chats");
                });
#pragma warning restore 612, 618
        }
    }
}
