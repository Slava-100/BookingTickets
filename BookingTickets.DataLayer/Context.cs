using System.Security.Cryptography.X509Certificates;
using BookingTickets.Core.Models.DTO;
using BookingTickets.Core.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DataLayer;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<FilmDto> Films { get; set; }
    public DbSet<SessionDto> Sessions { get; set; }
    public DbSet<HallDto> Halls { get; set; }
    public DbSet<CinemaDto> Cinemas { get; set; }
    public DbSet<UserDto> Users { get; set; }
    public DbSet<OrderDto> Orders { get; set; }
    public DbSet<OrderPlaceDto> OrderPlaces { get; set; }
    public DbSet<PlaceDto> Places { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FilmDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(f => f.Name).IsRequired();
            entity.Property(f => f.Duration).IsRequired();
        });

        modelBuilder.Entity<SessionDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(s => s.FilmId).IsRequired();
            entity.Property(s => s.HallId).IsRequired();
            entity.Property(s => s.Price).IsRequired();
            entity.Property(s => s.Time).IsRequired();
            
            entity.HasOne<HallDto>(s => s.Hall)
                .WithMany(h => h.Sessions)
                .HasForeignKey(s => s.HallId);
            
            entity.HasOne<FilmDto>(s => s.Film)
                .WithMany(f => f.Sessions)
                .HasForeignKey(s => s.FilmId);
        });

        modelBuilder.Entity<HallDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(h => h.Number).IsRequired();
            entity.Property(h => h.CinemaId).IsRequired();

            entity.HasOne<CinemaDto>(h => h.Cinema)
                .WithMany(c => c.Halls)
                .HasForeignKey(h => h.CinemaId);
        });

        modelBuilder.Entity<CinemaDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(h => h.Name).IsRequired();
        });
       
        modelBuilder.Entity<UserDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(u => u.FullName).IsRequired();
            entity.Property(u => u.Email).IsRequired();
            entity.Property(u => u.Password).IsRequired();

            entity.HasOne<CinemaDto>(u => u.Cinema)
                .WithMany(c => c.Users)
                .HasForeignKey(h => h.CinemaId);
        });

        modelBuilder.Entity<OrderDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(u => u.Code).IsRequired();
            entity.Property(u => u.UserId).IsRequired();

            entity.HasOne<UserDto>(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
        });

        modelBuilder.Entity<OrderPlaceDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(u => u.OrderId).IsRequired();
            entity.Property(u => u.SessionId).IsRequired();
            entity.Property(u => u.PlaceId).IsRequired();

            entity.HasOne<OrderDto>(o => o.Order)
                .WithMany(o => o.OrderPlaces)
                .HasForeignKey(o => o.OrderId);

            entity.HasOne<PlaceDto>(o => o.Place)
                .WithMany(p => p.OrderPlaces)
                .HasForeignKey(o => o.PlaceId);

            entity.HasOne<SessionDto>(o => o.Session)
                .WithMany(s => s.OrderPlaces)
                .HasForeignKey(o => o.SessionId);
        });

        modelBuilder.Entity<PlaceDto>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(u => u.Number).IsRequired();
            entity.Property(u => u.Row).IsRequired();
            entity.Property(u => u.HallId).IsRequired();

            entity.HasOne<HallDto>(p => p.Hall)
                .WithMany(h => h.Places)
                .HasForeignKey(p => p.HallId);
        });

    }
}