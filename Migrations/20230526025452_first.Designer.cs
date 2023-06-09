﻿// <auto-generated />
using System;
using Labrary2023.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labrary2023.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230526025452_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Labrary2023.Models.author", b =>
                {
                    b.Property<int>("idAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAuthor"), 1L, 1);

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAuthor");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("Labrary2023.Models.book", b =>
                {
                    b.Property<int>("idbook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idbook"), 1L, 1);

                    b.Property<int>("copies")
                        .HasColumnType("int");

                    b.Property<int>("idcat")
                        .HasColumnType("int");

                    b.Property<DateTime>("publish")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idbook");

                    b.HasIndex("idcat");

                    b.ToTable("book");
                });

            modelBuilder.Entity("Labrary2023.Models.book_author", b =>
                {
                    b.Property<int>("idBo_Au")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idBo_Au"), 1L, 1);

                    b.Property<int>("idAuthor")
                        .HasColumnType("int");

                    b.Property<int>("idbook")
                        .HasColumnType("int");

                    b.HasKey("idBo_Au");

                    b.HasIndex("idAuthor");

                    b.HasIndex("idbook");

                    b.ToTable("book_Authors");
                });

            modelBuilder.Entity("Labrary2023.Models.category", b =>
                {
                    b.Property<int>("idcat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idcat"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idcat");

                    b.ToTable("category");
                });

            modelBuilder.Entity("Labrary2023.Models.fine", b =>
                {
                    b.Property<int>("idfn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idfn"), 1L, 1);

                    b.Property<DateTime>("fine_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("fine_amount")
                        .HasColumnType("int");

                    b.Property<int>("idlon")
                        .HasColumnType("int");

                    b.HasKey("idfn");

                    b.HasIndex("idlon");

                    b.ToTable("fines");
                });

            modelBuilder.Entity("Labrary2023.Models.fine_payment", b =>
                {
                    b.Property<int>("idfi_pa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idfi_pa"), 1L, 1);

                    b.Property<DateTime>("DatePay")
                        .HasColumnType("datetime2");

                    b.Property<int>("idmeb")
                        .HasColumnType("int");

                    b.Property<int>("payamount")
                        .HasColumnType("int");

                    b.HasKey("idfi_pa");

                    b.HasIndex("idmeb");

                    b.ToTable("fine_Payments");
                });

            modelBuilder.Entity("Labrary2023.Models.loan", b =>
                {
                    b.Property<int>("idlo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idlo"), 1L, 1);

                    b.Property<int>("idbook")
                        .HasColumnType("int");

                    b.Property<int>("idmeb")
                        .HasColumnType("int");

                    b.Property<DateTime>("loan_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("return_date")
                        .HasColumnType("datetime2");

                    b.HasKey("idlo");

                    b.HasIndex("idbook");

                    b.HasIndex("idmeb");

                    b.ToTable("loans");
                });

            modelBuilder.Entity("Labrary2023.Models.member", b =>
                {
                    b.Property<int>("idmeb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idmeb"), 1L, 1);

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idmeb_sta")
                        .HasColumnType("int");

                    b.Property<DateTime>("joinedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("idmeb");

                    b.HasIndex("idmeb_sta");

                    b.ToTable("members");
                });

            modelBuilder.Entity("Labrary2023.Models.member_state", b =>
                {
                    b.Property<int>("idmeb_sta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idmeb_sta"), 1L, 1);

                    b.Property<bool>("value_state")
                        .HasColumnType("bit");

                    b.HasKey("idmeb_sta");

                    b.ToTable("member_States");
                });

            modelBuilder.Entity("Labrary2023.Models.reservation", b =>
                {
                    b.Property<int>("idres")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idres"), 1L, 1);

                    b.Property<int>("idbook")
                        .HasColumnType("int");

                    b.Property<int>("idmeb")
                        .HasColumnType("int");

                    b.Property<DateTime>("reservation_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("reservation_states_id")
                        .HasColumnType("int");

                    b.HasKey("idres");

                    b.HasIndex("idbook");

                    b.HasIndex("idmeb");

                    b.HasIndex("reservation_states_id");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("Labrary2023.Models.reservation_state", b =>
                {
                    b.Property<int>("idres_sta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idres_sta"), 1L, 1);

                    b.Property<bool>("value_state")
                        .HasColumnType("bit");

                    b.HasKey("idres_sta");

                    b.ToTable("reservation_States");
                });

            modelBuilder.Entity("Labrary2023.Models.book", b =>
                {
                    b.HasOne("Labrary2023.Models.category", "Category")
                        .WithMany("books")
                        .HasForeignKey("idcat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Labrary2023.Models.book_author", b =>
                {
                    b.HasOne("Labrary2023.Models.author", "Author")
                        .WithMany("book_authors")
                        .HasForeignKey("idAuthor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labrary2023.Models.book", "Book")
                        .WithMany("book_author")
                        .HasForeignKey("idbook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Labrary2023.Models.fine", b =>
                {
                    b.HasOne("Labrary2023.Models.loan", "Loan")
                        .WithMany("Fine")
                        .HasForeignKey("idlon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Labrary2023.Models.fine_payment", b =>
                {
                    b.HasOne("Labrary2023.Models.member", "singelmember")
                        .WithMany("fine_Payments")
                        .HasForeignKey("idmeb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("singelmember");
                });

            modelBuilder.Entity("Labrary2023.Models.loan", b =>
                {
                    b.HasOne("Labrary2023.Models.book", "Book")
                        .WithMany("loans")
                        .HasForeignKey("idbook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labrary2023.Models.member", "Member")
                        .WithMany("loans")
                        .HasForeignKey("idmeb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Labrary2023.Models.member", b =>
                {
                    b.HasOne("Labrary2023.Models.member_state", "Member_State")
                        .WithMany("Members")
                        .HasForeignKey("idmeb_sta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member_State");
                });

            modelBuilder.Entity("Labrary2023.Models.reservation", b =>
                {
                    b.HasOne("Labrary2023.Models.book", "Book")
                        .WithMany("reservations")
                        .HasForeignKey("idbook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labrary2023.Models.member", "Member")
                        .WithMany("reservations")
                        .HasForeignKey("idmeb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labrary2023.Models.reservation_state", "reservation_states")
                        .WithMany("reservations")
                        .HasForeignKey("reservation_states_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");

                    b.Navigation("reservation_states");
                });

            modelBuilder.Entity("Labrary2023.Models.author", b =>
                {
                    b.Navigation("book_authors");
                });

            modelBuilder.Entity("Labrary2023.Models.book", b =>
                {
                    b.Navigation("book_author");

                    b.Navigation("loans");

                    b.Navigation("reservations");
                });

            modelBuilder.Entity("Labrary2023.Models.category", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("Labrary2023.Models.loan", b =>
                {
                    b.Navigation("Fine");
                });

            modelBuilder.Entity("Labrary2023.Models.member", b =>
                {
                    b.Navigation("fine_Payments");

                    b.Navigation("loans");

                    b.Navigation("reservations");
                });

            modelBuilder.Entity("Labrary2023.Models.member_state", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Labrary2023.Models.reservation_state", b =>
                {
                    b.Navigation("reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
