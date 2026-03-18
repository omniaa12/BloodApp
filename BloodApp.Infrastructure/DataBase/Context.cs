using BloodApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Infrastructure.DataBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodBag> BloodBags { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<InventorySummary> InventorySummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. كيس الدم: السيريال هو المفتاح الأساسي
            modelBuilder.Entity<BloodBag>()
                .HasKey(b => b.BagSerial);

            // 2. علاقة المتبرع بالأكياس (1:M)
            modelBuilder.Entity<BloodBag>()
                .HasOne(b => b.Donor)
                .WithMany(d => d.BloodBags)
                .HasForeignKey(b => b.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. علاقة البنك بالأكياس (1:M)
            modelBuilder.Entity<BloodBag>()
                .HasOne(b => b.Bank)
                .WithMany(bk => bk.Inventory)
                .HasForeignKey(b => b.BankId);

            // 4. علاقة الزيارة بالأكياس (المريض بياخد كذا كيس)ئ
            modelBuilder.Entity<BloodBag>()
                .HasOne<PatientVisit>()
                .WithMany(pv => pv.ConsumedBags)
                .HasForeignKey(b => b.PatientVisitId);

            base.OnModelCreating(modelBuilder);
        }
    }       
}
