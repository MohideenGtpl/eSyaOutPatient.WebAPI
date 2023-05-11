﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSyaOutPatient.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtEcclco> GtEcclco { get; set; }
        public virtual DbSet<GtEcdcbn> GtEcdcbn { get; set; }
        public virtual DbSet<GtEcdcsn> GtEcdcsn { get; set; }
        public virtual DbSet<GtEfopcd> GtEfopcd { get; set; }
        public virtual DbSet<GtEfopnk> GtEfopnk { get; set; }
        public virtual DbSet<GtEfoppd> GtEfoppd { get; set; }
        public virtual DbSet<GtEfoppi> GtEfoppi { get; set; }
        public virtual DbSet<GtEfoppp> GtEfoppp { get; set; }
        public virtual DbSet<GtEfoppr> GtEfoppr { get; set; }
        public virtual DbSet<GtEfopsi> GtEfopsi { get; set; }
        public virtual DbSet<GtEfopvd> GtEfopvd { get; set; }
        public virtual DbSet<GtEfprdt> GtEfprdt { get; set; }
        public virtual DbSet<GtEfprpm> GtEfprpm { get; set; }
        public virtual DbSet<GtEopapd> GtEopapd { get; set; }
        public virtual DbSet<GtEopaph> GtEopaph { get; set; }
        public virtual DbSet<GtEopapq> GtEopapq { get; set; }
        public virtual DbSet<GtEopaps> GtEopaps { get; set; }
        public virtual DbSet<GtEopasr> GtEopasr { get; set; }
        public virtual DbSet<GtEsclst> GtEsclst { get; set; }
        public virtual DbSet<GtEsdobl> GtEsdobl { get; set; }
        public virtual DbSet<GtEsdocd> GtEsdocd { get; set; }
        public virtual DbSet<GtEsdocl> GtEsdocl { get; set; }
        public virtual DbSet<GtEsdold> GtEsdold { get; set; }
        public virtual DbSet<GtEsdos1> GtEsdos1 { get; set; }
        public virtual DbSet<GtEsdos2> GtEsdos2 { get; set; }
        public virtual DbSet<GtEsdosc> GtEsdosc { get; set; }
        public virtual DbSet<GtEsdosp> GtEsdosp { get; set; }
        public virtual DbSet<GtEsopcl> GtEsopcl { get; set; }
        public virtual DbSet<GtEsopsi> GtEsopsi { get; set; }
        public virtual DbSet<GtEsspbl> GtEsspbl { get; set; }
        public virtual DbSet<GtEsspcd> GtEsspcd { get; set; }
        public virtual DbSet<GtEssppa> GtEssppa { get; set; }
        public virtual DbSet<GtEuusms> GtEuusms { get; set; }
        public virtual DbSet<GtMaprem> GtMaprem { get; set; }
        public virtual DbSet<GtMaptrg> GtMaptrg { get; set; }
        public virtual DbSet<GtOpclin> GtOpclin { get; set; }
        public virtual DbSet<GtPtrgci> GtPtrgci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);
            });

            modelBuilder.Entity<GtEcclco>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear });

                entity.ToTable("GT_ECCLCO");

                entity.Property(e => e.FinancialYear).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TillDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEcdcbn>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear, e.DocumentId });

                entity.ToTable("GT_ECDCBN");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcdcsn>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DocumentId });

                entity.ToTable("GT_ECDCSN");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEfopcd>(entity =>
            {
                entity.HasKey(e => new { e.HospitalNumber, e.AddressType });

                entity.ToTable("GT_EFOPCD");

                entity.Property(e => e.AddressType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.AddressLine3).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEfopnk>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RUhid, e.Opnumber })
                    .HasName("PK_GT_EFOPNK_1");

                entity.ToTable("GT_EFOPNK");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.Opnumber).HasColumnName("OPNumber");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.KincontactAddress)
                    .IsRequired()
                    .HasColumnName("KINContactAddress")
                    .HasMaxLength(150);

                entity.Property(e => e.KinmobileNumber)
                    .IsRequired()
                    .HasColumnName("KINMobileNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Kinname)
                    .IsRequired()
                    .HasColumnName("KINName")
                    .HasMaxLength(75);

                entity.Property(e => e.Kinrelationship).HasColumnName("KINRelationship");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEfoppd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RUhid, e.Opnumber })
                    .HasName("PK_GT_EFOPPD_1");

                entity.ToTable("GT_EFOPPD");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.Opnumber).HasColumnName("OPNumber");

                entity.Property(e => e.AddressasperPp)
                    .IsRequired()
                    .HasColumnName("AddressasperPP")
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfIssue).HasColumnType("datetime");

                entity.Property(e => e.DateofBirth).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IsPpscanned).HasColumnName("IsPPScanned");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PassportExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PlaceOfIssue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VisaExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.VisaIssueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEfoppi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RUhid, e.Opnumber, e.SerialNumber })
                    .HasName("PK_GT_EFOPPI_1");

                entity.ToTable("GT_EFOPPI");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.Opnumber).HasColumnName("OPNumber");

                entity.Property(e => e.CoPayPerc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsuranceCardNo).HasMaxLength(25);

                entity.Property(e => e.InsuranceExpDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .HasMaxLength(25);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEfoppp>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RUhid });

                entity.ToTable("GT_EFOPPP");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RegistrationChargesValidTill).HasColumnType("datetime");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEfoppr>(entity =>
            {
                entity.HasKey(e => e.RUhid);

                entity.ToTable("GT_EFOPPR");

                entity.Property(e => e.RUhid)
                    .HasColumnName("R_UHID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeDd).HasColumnName("AgeDD");

                entity.Property(e => e.AgeMm).HasColumnName("AgeMM");

                entity.Property(e => e.AgeYy).HasColumnName("AgeYY");

                entity.Property(e => e.BillStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup).HasMaxLength(6);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EMailId)
                    .HasColumnName("eMailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsDobapplicable).HasColumnName("IsDOBApplicable");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasMaxLength(15);

                entity.Property(e => e.PatientLastVisitDate).HasColumnType("datetime");

                entity.Property(e => e.PatientStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationChargesValidTill).HasColumnType("datetime");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.SUhid).HasColumnName("S_UHID");

                entity.Property(e => e.Title).HasMaxLength(4);
            });

            modelBuilder.Entity<GtEfopsi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RUhid, e.UpcomingScheduleDate, e.FollowType });

                entity.ToTable("GT_EFOPSI");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.UpcomingScheduleDate).HasColumnType("datetime");

                entity.Property(e => e.FollowType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.VisitConfirmedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEfopvd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RUhid, e.Opnumber })
                    .HasName("PK_GT_EFOPVD_1");

                entity.ToTable("GT_EFOPVD");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.Opnumber).HasColumnName("OPNumber");

                entity.Property(e => e.AppointmentKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsMlc).HasColumnName("IsMLC");

                entity.Property(e => e.IsVip).HasColumnName("IsVIP");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PatientClass)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VisitDate).HasColumnType("datetime");

                entity.Property(e => e.VisitType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEfprdt>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear, e.BookTypeId, e.VoucherNumber });

                entity.ToTable("GT_EFPRDT");

                entity.Property(e => e.BookTypeId).HasColumnName("BookTypeID");

                entity.Property(e => e.AdvanceAdjAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.BillDocumentKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CancelledAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CollectedAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ConcessionAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(250);

                entity.Property(e => e.PaidorCollectedBy).HasMaxLength(100);

                entity.Property(e => e.RefVoucherDate).HasColumnType("datetime");

                entity.Property(e => e.RefVoucherKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RefundReason).HasMaxLength(250);

                entity.Property(e => e.TotalNetAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.VoucherAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.VoucherDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.VoucherType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEfprpm>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.VoucherKey });

                entity.ToTable("GT_EFPRPM");

                entity.Property(e => e.VoucherKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.ApprovalNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Badate)
                    .HasColumnName("BADate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BankTransferDate).HasColumnType("datetime");

                entity.Property(e => e.BankTransferNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BareferenceNumber)
                    .HasColumnName("BAReferenceNumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BatchNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardExpiryDate)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CardHolderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CardTerminal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ChequeDate).HasColumnType("datetime");

                entity.Property(e => e.ChequeNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepositedAtBranch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepostedAtCity)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DepostedOn).HasColumnType("datetime");

                entity.Property(e => e.DraweeBank)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.MpreferenceDate)
                    .HasColumnName("MPReferenceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpreferenceNumber)
                    .HasColumnName("MPReferenceNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceCharge).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransferAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransferFromBank)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TransferToBank)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEopapd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.AppointmentKey });

                entity.ToTable("GT_EOPAPD");

                entity.Property(e => e.AppointmentKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.Address1).HasMaxLength(150);

                entity.Property(e => e.Address2).HasMaxLength(150);

                entity.Property(e => e.Address3).HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FamilyId).HasColumnName("FamilyID");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PatientFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PatientMiddleName).HasMaxLength(50);

                entity.Property(e => e.PrimaryMemberFirstName).HasMaxLength(50);

                entity.Property(e => e.PrimaryMemberLastName).HasMaxLength(50);

                entity.Property(e => e.SecondaryMobileNumber).HasMaxLength(25);

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.HasOne(d => d.GtEopaph)
                    .WithOne(p => p.GtEopapd)
                    .HasPrincipalKey<GtEopaph>(p => new { p.BusinessKey, p.AppointmentKey })
                    .HasForeignKey<GtEopapd>(d => new { d.BusinessKey, d.AppointmentKey })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EOPAPD_GT_EOPAPH");
            });

            modelBuilder.Entity<GtEopaph>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear, e.DocumentId, e.DocumentNumber });

                entity.ToTable("GT_EOPAPH");

                entity.HasIndex(e => new { e.BusinessKey, e.AppointmentKey })
                    .HasName("IX_GT_EOPAPH")
                    .IsUnique();

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.AppointmentStatus)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.EpisodeType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.FeedbackComments).HasMaxLength(150);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.PromoCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.QueueTokenKey)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonforAppointment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReasonforCancellation).HasMaxLength(100);

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.VisitType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<GtEopapq>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.TokenDate, e.QueueTokenKey });

                entity.ToTable("GT_EOPAPQ");

                entity.Property(e => e.TokenDate).HasColumnType("date");

                entity.Property(e => e.QueueTokenKey)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AppointmentKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName).HasMaxLength(150);

                entity.Property(e => e.PatientType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.TokenStatus)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Uhid).HasColumnName("UHID");
            });

            modelBuilder.Entity<GtEopaps>(entity =>
            {
                entity.ToTable("GT_EOPAPS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentStatus)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");
            });

            modelBuilder.Entity<GtEopasr>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.AppointmentKey, e.ServiceId });

                entity.ToTable("GT_EOPASR");

                entity.Property(e => e.AppointmentKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<GtEsclst>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ClinicId, e.ConsultationId, e.ServiceId, e.RateType, e.CurrencyCode, e.EffectiveDate });

                entity.ToTable("GT_ESCLST");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Tariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEsdobl>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.BusinessKey });

                entity.ToTable("GT_ESDOBL");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsdocd>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("GT_ESDOCD");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowSms).HasColumnName("AllowSMS");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorRegnNo)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DoctorRemarks).HasMaxLength(150);

                entity.Property(e => e.DoctorShortName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Experience).HasMaxLength(150);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LanguageKnown).HasMaxLength(150);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TraiffFrom)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<GtEsdocl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.DoctorId, e.ClinicId, e.ConsultationId });

                entity.ToTable("GT_ESDOCL");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsdold>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.OnLeaveFrom });

                entity.ToTable("GT_ESDOLD");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.OnLeaveFrom).HasColumnType("datetime");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OnLeaveTill).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdold)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOLD_GT_ESDOCD");
            });

            modelBuilder.Entity<GtEsdos1>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ConsultationId, e.ClinicId, e.SpecialtyId, e.DoctorId, e.DayOfWeek, e.SerialNo });

                entity.ToTable("GT_ESDOS1");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DayOfWeek).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RoomNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdos1)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS1_GT_ESDOCD");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.GtEsdos1)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS1_GT_ESSPCD");
            });

            modelBuilder.Entity<GtEsdos2>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ConsultationId, e.ClinicId, e.SpecialtyId, e.DoctorId, e.ScheduleDate, e.SerialNo });

                entity.ToTable("GT_ESDOS2");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.ScheduleDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.XlsheetReference)
                    .IsRequired()
                    .HasColumnName("XLSheetReference")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdos2)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS2_GT_ESDOCD");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.GtEsdos2)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS2_GT_ESSPCD");
            });

            modelBuilder.Entity<GtEsdosc>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ConsultationId, e.ClinicId, e.SpecialtyId, e.DoctorId, e.ScheduleChangeDate });

                entity.ToTable("GT_ESDOSC");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.ScheduleChangeDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdosc)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOSC_GT_ESDOCD");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.GtEsdosc)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOSC_GT_ESSPCD");
            });

            modelBuilder.Entity<GtEsdosp>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.DoctorId })
                    .HasName("PK_GT_ESDOSP_1");

                entity.ToTable("GT_ESDOSP");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsopcl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ClinicId, e.ConsultationId });

                entity.ToTable("GT_ESOPCL");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsopsi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FollowType, e.ScheduleInterval });

                entity.ToTable("GT_ESOPSI");

                entity.Property(e => e.FollowType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsspbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId })
                    .HasName("PK_GT_ESSPBL_1");

                entity.ToTable("GT_ESSPBL");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsspcd>(entity =>
            {
                entity.HasKey(e => e.SpecialtyId);

                entity.ToTable("GT_ESSPCD");

                entity.Property(e => e.SpecialtyId)
                    .HasColumnName("SpecialtyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlliedServices)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalIcon).HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.SpecialtyDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpecialtyType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEssppa>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.ParameterId });

                entity.ToTable("GT_ESSPPA");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ParmPerc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ParmValue).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEuusms>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("GT_EUUSMS");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowMobileLogin)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeactivationReason).HasMaxLength(50);

                entity.Property(e => e.EMailId)
                    .IsRequired()
                    .HasColumnName("eMailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangeDate).HasColumnType("datetime");

                entity.Property(e => e.LoginDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(20);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OtpgeneratedDate)
                    .HasColumnName("OTPGeneratedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Otpnumber)
                    .HasColumnName("OTPNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.PhotoUrl)
                    .HasColumnName("PhotoURL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredLanguage).HasMaxLength(10);

                entity.Property(e => e.UserAuthenticatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserDeactivatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtMaprem>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Vnumber, e.ReminderType });

                entity.ToTable("GT_MAPREM");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Vnumber).HasColumnName("VNumber");

                entity.Property(e => e.ReminderType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ReminderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtMaptrg>(entity =>
            {
                entity.HasKey(e => new { e.Isdcode, e.MobileNumber, e.MemberId });

                entity.ToTable("GT_MAPTRG");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.AgeDd).HasColumnName("AgeDD");

                entity.Property(e => e.AgeMm).HasColumnName("AgeMM");

                entity.Property(e => e.AgeYy).HasColumnName("AgeYY");

                entity.Property(e => e.AppDeviceId).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EMailId)
                    .HasColumnName("eMailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FcmcreatedOn)
                    .HasColumnName("FCMCreatedOn")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.FcmregistrationToken)
                    .HasColumnName("FCMRegistrationToken")
                    .HasMaxLength(1000);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsDobapplicable).HasColumnName("IsDOBApplicable");

                entity.Property(e => e.LastAppSignInDate).HasColumnType("datetime");

                entity.Property(e => e.LastAppSignOutDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.RegSource)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityAnswer).HasMaxLength(250);
            });

            modelBuilder.Entity<GtOpclin>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Vnumber, e.TransactionId, e.Cltype, e.ClcontrolId });

                entity.ToTable("GT_OPCLIN");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Vnumber).HasColumnName("VNumber");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Cltype)
                    .HasColumnName("CLType")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ClcontrolId)
                    .HasColumnName("CLControlID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.ValueType).HasMaxLength(20);
            });

            modelBuilder.Entity<GtPtrgci>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RUhid, e.Opnumber, e.SerialNumber });

                entity.ToTable("GT_PTRGCI");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.Opnumber).HasColumnName("OPNumber");

                entity.Property(e => e.CaseType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.Complaint).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Episode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");
            });
        }
    }
}
