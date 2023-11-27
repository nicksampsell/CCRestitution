using CCRestitution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CCRestitution.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasMany(x => x.Crimes)
                .WithMany(x => x.Accounts)
                .UsingEntity<AccountCrime>(
                l => l.HasOne<Crime>().WithMany().HasForeignKey("Id"),
                r => r.HasOne<Account>().WithMany().HasForeignKey("AccountId"));
        
        }

        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<ArrestingAgency> ArrestingAgencies { get; set; } = default!;
        public DbSet<Attorney> Attorneys { get; set; } = default!;
        public DbSet<Court> Courts { get; set; } = default!;
        public DbSet<Crime> Crimes { get; set; } = default!;
        public DbSet<Defendant> Defendants { get; set; } = default!;
        public DbSet<DefendantPriorResidence> DefendantPriorResidences { get; set; } = default!;
        public DbSet<DetentionFacility> DetentionFacilities { get; set; } = default!;
        public DbSet<Judge> Judges { get; set; } = default!;
        public DbSet<MoneyOrdered> MoneyOrdered { get; set; }
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<ProbationDepartment> ProbationDepartments { get; set; } = default!;
        public DbSet<ProbationOfficer> ProbationOfficers { get; set; } = default!;
        public DbSet<TreatmentAgency> TreatmentAgencies { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Victim> Victims { get; set; } = default!;


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.Updated = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.Created = utcNow;
                            trackable.Updated = utcNow;
                            break;
                    }
                }
            }
        }
    }
}
