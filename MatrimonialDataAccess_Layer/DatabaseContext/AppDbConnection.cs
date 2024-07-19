using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialDataAccess_Layer.DatabaseContext
{
    public class AppDbConnection : DbContext
    {
        public AppDbConnection(DbContextOptions<AppDbConnection> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateMaster>()
                .HasOne<CountryMaster>(s => s.CountryMaster)
                .WithMany(g => g.StateMasters)
                .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<DistrictMaster>()
               .HasOne<StateMaster>(s => s.StateMaster)
               .WithMany(g => g.DistrictMasters)
               .HasForeignKey(s => s.StateId);

            modelBuilder.Entity<GotraMaster>()
              .HasOne<SubCasteMaster>(s => s.SubCasteMaster)
              .WithMany(g => g.GotraMasters)
              .HasForeignKey(s => s.SubCasteId);

            modelBuilder.Entity<MultipleImageProfile>()
           .HasOne<NewRegistrationModel>(s => s.newRegistrationModel)
           .WithMany(g => g.multipleImageProfiles)
           .HasForeignKey(s =>s.ProfileId);
        }

        public Task savechangesasync()
        {
            throw new NotImplementedException();
        }

        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<DistrictMaster> DistrictMasters { get; set; }
        public DbSet<QualificationMaster> qualificationMasters { get; set; }
        public DbSet<ProfessionMaster> professionMasters { get; set; }
        public DbSet<SubCasteMaster> subCasteMasters { get; set; }
        public DbSet<GotraMaster> gotraMasters { get; set; }
        public DbSet<Enquiry> enquiries { get; set; }
        public DbSet<MultipleImageProfile> multipleImageProfiles { get; set; }
        public DbSet<RegisterModel> RegisterTable { get; set; }

        public DbSet<NewRegistrationModel> NewRegistrationModels { get; set; }

    }
}
