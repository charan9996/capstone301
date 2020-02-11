using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel
{
    public partial class ReviewManagementContext : DbContext
    {

        //private readonly string DbConnectionString;
        //public RestaurantManagementContext()
        //{
        //}

        public ReviewManagementContext(DbContextOptions<ReviewManagementContext> options)
            : base(options)
        {
        }
        //public RestaurantManagementContext(string connectionstring)
        //{
        //    DbConnectionString = connectionstring;
        //}


        public virtual DbSet<TblRating> TblRating { get; set; }
        public virtual DbSet<TblRestaurant> TblRestaurant { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //  optionsBuilder.UseSqlServer(@"Server=tcp:capstoneteam1server.database.windows.net,1433;Initial Catalog=RestaurantManagement;Persist Security Info=False;user id=cpadmin;password=Mindtree@12;");
                // optionsBuilder.UseSqlServer(DbConnectionString);

               // optionsBuilder.UseSqlServer("Server=.;Database=RestaurantManagement;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           


            modelBuilder.Entity<TblRating>(entity =>
            {
                entity.ToTable("tblRating");

                entity.Property(e => e.Id).HasColumnName("ID");


                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RecordTimeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RecordTimeStampCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TblCustomerId)
                    .HasColumnName("tblCustomerId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TblRestaurantId)
                    .HasColumnName("tblRestaurantID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserCreated).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserModified).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.TblRestaurant)
                    .WithMany(p => p.TblRating)
                    .HasForeignKey(d => d.TblRestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRating_tblRestaurantID");
            });

            modelBuilder.Entity<TblRestaurant>(entity =>
            {
                entity.ToTable("tblRestaurant");

                entity.Property(e => e.Id).HasColumnName("ID");

         

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(225)
                    .HasDefaultValueSql("('')");

        

         
            });

        }
    }
}
