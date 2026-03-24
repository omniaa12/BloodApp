using BloodApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodApp.Infrastructure.DataBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        // ==========================================
        // 1. الجداول (DbSets)
        // ==========================================
        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodBag> BloodBags { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<InventorySummary> InventorySummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ==========================================
            // 2. إعداد المفاتيح الأساسية (Primary Keys)
            // ==========================================
            modelBuilder.Entity<BloodBag>()
                .HasKey(b => b.BagSerial);

            // ==========================================
            // 3. إعدادات العلاقات (Relationships & Delete Behavior)
            // ==========================================

            // أ. علاقة المتبرع بأكياس الدم
            modelBuilder.Entity<BloodBag>()
                .HasOne(b => b.Donor)
                .WithMany(d => d.BloodBags)
                .HasForeignKey(b => b.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ب. علاقة بنك الدم بأكياس الدم
            modelBuilder.Entity<BloodBag>()
                .HasOne(b => b.Bank)
                .WithMany(bk => bk.BloodBags)
                .HasForeignKey(b => b.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            // ج. علاقة زيارة المريض بأكياس الدم
            modelBuilder.Entity<BloodBag>()
                .HasOne(b => b.PatientVisit)
                .WithMany(v => v.ConsumedBags)
                .HasForeignKey(b => b.PatientVisitId)
                .OnDelete(DeleteBehavior.SetNull);

            // د. علاقة بنك الدم بالمتبرعين
            modelBuilder.Entity<Donor>()
                .HasOne(d => d.Bank)
                .WithMany(b => b.Donors)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            // هـ. علاقة بنك الدم بزيارات المرضى
            modelBuilder.Entity<PatientVisit>()
                .HasOne(pv => pv.BloodBank)
                .WithMany(b => b.PatientVisits)
                .HasForeignKey(pv => pv.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            // و. علاقة المتبرع بطلبات التبرع
            modelBuilder.Entity<DonationRequest>()
                .HasOne(dr => dr.Donor)
                .WithMany(d => d.DonationRequests)
                .HasForeignKey(dr => dr.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ز. علاقة بنك الدم بطلبات التبرع
            modelBuilder.Entity<DonationRequest>()
                .HasOne(dr => dr.Bank)
                .WithMany(b => b.DonationRequests)
                .HasForeignKey(dr => dr.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            // ح. علاقة المخزن ببنك الدم (هنا Cascade عشان لو البنك اتمسح، المخزن بتاعه يتمسح)
            modelBuilder.Entity<InventorySummary>()
                .HasOne(i => i.Bank)
                .WithMany(b => b.InventorySummaries)
                .HasForeignKey(i => i.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            // ==========================================
            // 4. القيود والشروط (Unique Constraints)
            // ==========================================

            // منع تكرار الرقم القومي ورقم الهاتف للمتبرع
            modelBuilder.Entity<Donor>()
                .HasIndex(d => d.NationalId)
                .IsUnique();

            modelBuilder.Entity<Donor>()
                .HasIndex(d => d.Phone)
                .IsUnique();

            // منع تكرار الإيميل ورقم الهاتف لبنك الدم
            modelBuilder.Entity<BloodBank>()
                .HasIndex(b => b.Email)
                .IsUnique();

            modelBuilder.Entity<BloodBank>()
                .HasIndex(b => b.Phone)
                .IsUnique();

            // منع تكرار نفس الفصيلة ونفس المكون جوه نفس بنك الدم
            modelBuilder.Entity<InventorySummary>()
                .HasIndex(i => new { i.BankId, i.BloodGroup, i.ComponentType })
                .IsUnique();

            // ==========================================
            // 5. تحويل الـ Enums لنصوص (String Conversions)
            // ==========================================

            modelBuilder.Entity<BloodBag>()
                .Property(b => b.BloodGroup)
                .HasConversion<string>();

            modelBuilder.Entity<BloodBag>()
                .Property(b => b.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Donor>()
                .Property(d => d.BloodGroup)
                .HasConversion<string>();

            modelBuilder.Entity<Donor>()
                .Property(d => d.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<PatientVisit>()
                .Property(v => v.PatientBloodType)
                .HasConversion<string>();

            modelBuilder.Entity<InventorySummary>()
                .Property(i => i.BloodGroup)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}