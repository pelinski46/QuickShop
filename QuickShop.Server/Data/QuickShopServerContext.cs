using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickShop.Shared.Models;

namespace QuickShop.Server.Data;

public class QuickShopServerContext : IdentityDbContext
{
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<CartItem> CartItems { get; set; } = default!;
    public QuickShopServerContext(DbContextOptions<QuickShopServerContext> options)
        : base(options)
    {
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

        modelBuilder.Entity<CartItem>()
            .HasOne(ci=>ci.Product)
            .WithMany(p=>p.CartItems)
            .HasForeignKey(ci => ci.ProductId)
            .IsRequired();

    }



}