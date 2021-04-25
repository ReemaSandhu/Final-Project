using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TravelEntities.CustomEntities;



namespace TravelEntities.Entities
{
    public partial class TravelDbContext : DbContext
    {
        public TravelDbContext()
        {
        }

        public TravelDbContext(DbContextOptions<TravelDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<SignUp> SignUp { get; set; }
        public virtual DbSet<Login> Login { get; set; }

        public virtual DbSet<DisplayHotels> DisplayHotels { get; set; }
        public virtual DbSet<SearchHotels> SearchHotels { get; set; }
        public virtual DbSet<CombinedModel> CombinedModel { get; set; }

        public virtual DbSet<AvailableHotelSearchViewModel> AvailableHotelSearchViewModel { get; set; }

        public virtual DbSet<BookingViewModel> BookingViewModel { get; set; }
        public virtual DbSet<GetBookingId> GetBookingId { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.CheckIn).HasColumnType("date");

                entity.Property(e => e.CheckOut).HasColumnType("date");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_City");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Hotel");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("Guest");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GuestFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GuestLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.HotelImage).HasMaxLength(100);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotel_City");
            });

            modelBuilder.Entity<SignUp>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("SignUp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<SearchHotels>(entity => { });
            modelBuilder.Entity<DisplayHotels>(entity => { });
            modelBuilder.Entity<CombinedModel>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<AvailableHotelSearchViewModel>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<BookingViewModel>(entity => { });
            modelBuilder.Entity<GetBookingId>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<Login>(entity => { });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
