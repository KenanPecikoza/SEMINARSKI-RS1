﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeminarskiRS1.Model;

namespace eDnevnik.data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20200825180059_IzmjenaV2")]
    partial class IzmjenaV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeminarskiRS1.Model.Administrator", b =>
                {
                    b.Property<int>("AdministratorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoginID")
                        .HasColumnType("int");

                    b.Property<int>("PodaciRodjenjeID")
                        .HasColumnType("int");

                    b.Property<string>("Pol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StrucnaSpremaID")
                        .HasColumnType("int");

                    b.Property<int>("podaciStanovanjeID")
                        .HasColumnType("int");

                    b.HasKey("AdministratorID");

                    b.HasIndex("LoginID");

                    b.HasIndex("PodaciRodjenjeID");

                    b.HasIndex("StrucnaSpremaID");

                    b.HasIndex("podaciStanovanjeID");

                    b.ToTable("administrator");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Login", b =>
                {
                    b.Property<int>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginID");

                    b.ToTable("login");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.NastavnoOsoblje", b =>
                {
                    b.Property<int>("NastavnoOsobljeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeRoditelja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoginID")
                        .HasColumnType("int");

                    b.Property<string>("NppFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OstaliPodaciNastavnoOsobljeID")
                        .HasColumnType("int");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PodaciRodjenjeID")
                        .HasColumnType("int");

                    b.Property<int>("PodaciStanovanjeID")
                        .HasColumnType("int");

                    b.Property<string>("Pol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("podaciZanimanjeID")
                        .HasColumnType("int");

                    b.HasKey("NastavnoOsobljeID");

                    b.HasIndex("LoginID");

                    b.HasIndex("OstaliPodaciNastavnoOsobljeID");

                    b.HasIndex("PodaciRodjenjeID");

                    b.HasIndex("PodaciStanovanjeID");

                    b.HasIndex("podaciZanimanjeID");

                    b.ToTable("nastavnoOsoblje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Odjeljenje", b =>
                {
                    b.Property<int>("OdjeljenjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlagajnikID")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PredsjednikID")
                        .HasColumnType("int");

                    b.Property<int>("Razred")
                        .HasColumnType("int");

                    b.Property<int>("RazrednikID")
                        .HasColumnType("int");

                    b.Property<string>("Smjena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("skolskaGodinaID")
                        .HasColumnType("int");

                    b.HasKey("OdjeljenjeID");

                    b.HasIndex("BlagajnikID");

                    b.HasIndex("PredsjednikID");

                    b.HasIndex("RazrednikID");

                    b.HasIndex("skolskaGodinaID");

                    b.ToTable("odjeljenje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.OstaliPodaci", b =>
                {
                    b.Property<int>("OstaliPodaciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drzavljanstvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalnost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PorodicaID")
                        .HasColumnType("int");

                    b.HasKey("OstaliPodaciID");

                    b.HasIndex("PorodicaID");

                    b.ToTable("ostaliPodaci");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PodaciRodjenje", b =>
                {
                    b.Property<int>("PodaciRodjenjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("OpćinaRođenja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PodaciRodjenjeID");

                    b.HasIndex("DrzavaID");

                    b.HasIndex("GradID");

                    b.ToTable("podaciRodjenje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PodaciStanovanje", b =>
                {
                    b.Property<int>("PodaciStanovanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("OpćinaPrebivalista")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PodaciStanovanjeID");

                    b.HasIndex("DrzavaID");

                    b.HasIndex("GradID");

                    b.ToTable("podaciStanovanje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PodaciZanimanje", b =>
                {
                    b.Property<int>("PodaciZanimanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojDiplome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DrzavniIspit")
                        .HasColumnType("bit");

                    b.Property<int>("StrucnaSpremaID")
                        .HasColumnType("int");

                    b.Property<string>("ZavrsenFakultet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZavrsenaSkola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZavrsenoZanimanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PodaciZanimanjeID");

                    b.HasIndex("StrucnaSpremaID");

                    b.ToTable("podaciZanimanje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PodaciZavrsniIspit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPolaganja")
                        .HasColumnType("datetime2");

                    b.Property<int>("OcjenaOdbrane")
                        .HasColumnType("int");

                    b.Property<int>("OcjenaZavrsnogIspita")
                        .HasColumnType("int");

                    b.Property<int>("OcjenaZavrsnogRada")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("podaciZavrsniIspit");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Porodica", b =>
                {
                    b.Property<int>("PorodicaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusPorodiceUcenika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PorodicaID");

                    b.ToTable("porodica");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PredavaciPredmetiOdjeljenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PredmetiID")
                        .HasColumnType("int");

                    b.Property<int>("odjeljenjeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredmetiID");

                    b.HasIndex("odjeljenjeID");

                    b.ToTable("PredavaciPredmetiOdjeljenje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Predmeti", b =>
                {
                    b.Property<int>("PredmetiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Izborni")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredavacID")
                        .HasColumnType("int");

                    b.Property<string>("Razred")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PredmetiID");

                    b.HasIndex("PredavacID");

                    b.ToTable("predmeti");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Roditelj", b =>
                {
                    b.Property<int>("RoditeljID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PodaciStanovanjeID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StrucnaSpremaID")
                        .HasColumnType("int");

                    b.Property<string>("Zanimanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZaposlenjeID")
                        .HasColumnType("int");

                    b.HasKey("RoditeljID");

                    b.HasIndex("PodaciStanovanjeID");

                    b.HasIndex("StrucnaSpremaID");

                    b.HasIndex("ZaposlenjeID");

                    b.ToTable("roditelj");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.SkolskaGodina", b =>
                {
                    b.Property<int>("SkolskaGodinaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktuelna")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkolskaGodinaID");

                    b.ToTable("skolskaGodina");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.SlusaPredmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ZaključnaOcjena")
                        .HasColumnType("int");

                    b.Property<int>("predavaciPredmetiOdjeljenjeId")
                        .HasColumnType("int");

                    b.Property<int>("uceniciOdjeljenjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("predavaciPredmetiOdjeljenjeId");

                    b.HasIndex("uceniciOdjeljenjeId");

                    b.ToTable("slusaPredmet");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.StrucnaSprema", b =>
                {
                    b.Property<int>("StrucnaSpremaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StrucnaSpremaID");

                    b.ToTable("strucnaSprema");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Ucenici", b =>
                {
                    b.Property<int>("UceniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumUpisa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeRoditelja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OstaliPodaciID")
                        .HasColumnType("int");

                    b.Property<int>("PodaciRodjenjeID")
                        .HasColumnType("int");

                    b.Property<int>("PodaciStanovanjeID")
                        .HasColumnType("int");

                    b.Property<string>("Pol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZavrsniIspitID")
                        .HasColumnType("int");

                    b.HasKey("UceniciID");

                    b.HasIndex("OstaliPodaciID");

                    b.HasIndex("PodaciRodjenjeID");

                    b.HasIndex("PodaciStanovanjeID");

                    b.HasIndex("ZavrsniIspitID");

                    b.ToTable("ucenici");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.UceniciOdjeljenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojUDneviku")
                        .HasColumnType("int");

                    b.Property<int>("odjeljenjeID")
                        .HasColumnType("int");

                    b.Property<int>("uceniciID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("odjeljenjeID");

                    b.HasIndex("uceniciID");

                    b.ToTable("uceniciOdjeljenje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Zaposlenje", b =>
                {
                    b.Property<int>("ZaposlenjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipZaposljenja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZaposlenjeID");

                    b.ToTable("zaposlenje");
                });

            modelBuilder.Entity("eDnevnik.data.Models.AutorizacijskiToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("AutorizacijskiToken");
                });

            modelBuilder.Entity("eDnevnik.data.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivDrzave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skraćenica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaID");

                    b.ToTable("drzava");
                });

            modelBuilder.Entity("eDnevnik.data.Models.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivGrada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradID");

                    b.ToTable("grad");
                });

            modelBuilder.Entity("eDnevnik.data.Models.OstaliPodaciNastavnoOsoblje", b =>
                {
                    b.Property<int>("OstaliPodaciNastavnoOsobljeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drzavljanstvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalnost")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OstaliPodaciNastavnoOsobljeID");

                    b.ToTable("ostaliPodaciNastavnoOsoblje");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Administrator", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.Login", "login")
                        .WithMany()
                        .HasForeignKey("LoginID");

                    b.HasOne("SeminarskiRS1.Model.PodaciRodjenje", "PodaciRodjenje")
                        .WithMany()
                        .HasForeignKey("PodaciRodjenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.StrucnaSprema", "StrucnaSprema")
                        .WithMany()
                        .HasForeignKey("StrucnaSpremaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.PodaciStanovanje", "podaciStanovanje")
                        .WithMany()
                        .HasForeignKey("podaciStanovanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.NastavnoOsoblje", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.Login", "login")
                        .WithMany()
                        .HasForeignKey("LoginID");

                    b.HasOne("eDnevnik.data.Models.OstaliPodaciNastavnoOsoblje", "OstaliPodaciNastavnoOsoblje")
                        .WithMany()
                        .HasForeignKey("OstaliPodaciNastavnoOsobljeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.PodaciRodjenje", "PodaciRodjenje")
                        .WithMany()
                        .HasForeignKey("PodaciRodjenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.PodaciStanovanje", "PodaciStanovanje")
                        .WithMany()
                        .HasForeignKey("PodaciStanovanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.PodaciZanimanje", "podaciZanimanje")
                        .WithMany()
                        .HasForeignKey("podaciZanimanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Odjeljenje", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.Ucenici", "Blagajnik")
                        .WithMany()
                        .HasForeignKey("BlagajnikID");

                    b.HasOne("SeminarskiRS1.Model.Ucenici", "Predsjednik")
                        .WithMany()
                        .HasForeignKey("PredsjednikID");

                    b.HasOne("SeminarskiRS1.Model.NastavnoOsoblje", "Razrednik")
                        .WithMany()
                        .HasForeignKey("RazrednikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.SkolskaGodina", "skolskaGodina")
                        .WithMany()
                        .HasForeignKey("skolskaGodinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.OstaliPodaci", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.Porodica", "Porodica")
                        .WithMany()
                        .HasForeignKey("PorodicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PodaciRodjenje", b =>
                {
                    b.HasOne("eDnevnik.data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik.data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PodaciStanovanje", b =>
                {
                    b.HasOne("eDnevnik.data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eDnevnik.data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PodaciZanimanje", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.StrucnaSprema", "StrucnaSprema")
                        .WithMany()
                        .HasForeignKey("StrucnaSpremaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.PredavaciPredmetiOdjeljenje", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.Predmeti", "predmeti")
                        .WithMany()
                        .HasForeignKey("PredmetiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.Odjeljenje", "odjeljenje")
                        .WithMany()
                        .HasForeignKey("odjeljenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Predmeti", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.NastavnoOsoblje", "Predavac")
                        .WithMany()
                        .HasForeignKey("PredavacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Roditelj", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.PodaciStanovanje", "PodaciStanovnaje")
                        .WithMany()
                        .HasForeignKey("PodaciStanovanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.StrucnaSprema", "StrucnaSprema")
                        .WithMany()
                        .HasForeignKey("StrucnaSpremaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.Zaposlenje", "Zaposlenje")
                        .WithMany()
                        .HasForeignKey("ZaposlenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.SlusaPredmet", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.PredavaciPredmetiOdjeljenje", "predavaciPredmetiOdjeljenje")
                        .WithMany()
                        .HasForeignKey("predavaciPredmetiOdjeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.UceniciOdjeljenje", "uceniciOdjeljenje")
                        .WithMany()
                        .HasForeignKey("uceniciOdjeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRS1.Model.Ucenici", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.OstaliPodaci", "OstaliPodaci")
                        .WithMany()
                        .HasForeignKey("OstaliPodaciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.PodaciRodjenje", "PodaciRodjenje")
                        .WithMany()
                        .HasForeignKey("PodaciRodjenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.PodaciStanovanje", "PodaciStanovanje")
                        .WithMany()
                        .HasForeignKey("PodaciStanovanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.PodaciZavrsniIspit", "ZavrsniIspit")
                        .WithMany()
                        .HasForeignKey("ZavrsniIspitID");
                });

            modelBuilder.Entity("SeminarskiRS1.Model.UceniciOdjeljenje", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.Odjeljenje", "odjeljenje")
                        .WithMany()
                        .HasForeignKey("odjeljenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRS1.Model.Ucenici", "ucenici")
                        .WithMany()
                        .HasForeignKey("uceniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eDnevnik.data.Models.AutorizacijskiToken", b =>
                {
                    b.HasOne("SeminarskiRS1.Model.Login", "User")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
