using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsStoringState.DataLayer.Entities;

namespace ProductsStoringState.DataLayer
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) 
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Мобільний телефон Samsung Galaxy A34 8/256GB Black", Price = 15299, InStock = 45 },
                new Product { Id = 2, Name = "Ноутбук ASUS TUF Gaming F15", Price = 42999, InStock = 12 },
                new Product { Id = 3, Name = "Телевізор LG 50UR78006LK", Price = 21499, InStock = 26 },
                new Product { Id = 4, Name = "Мобільний телефон Realme C55 8/256GB Gold", Price = 8299, InStock = 73 },
                new Product { Id = 5, Name = "Зарядна станція EcoFlow RIVER 2 Pro", Price = 32999, InStock = 105 },
                new Product { Id = 6, Name = "Планшет Lenovo Tab M10 Plus (3rd Gen) 4/128 LTE Storm Grey", Price = 14999, InStock = 37 },
                new Product { Id = 7, Name = "УМБ Xiaomi Mi Power Bank 20000 mAh 22.5W Fast Charge", Price = 999, InStock = 209 },
                new Product { Id = 8, Name = "Маршрутизатор ASUS TUF-AX3000", Price = 4469, InStock = 24 },
                new Product { Id = 9, Name = "Мобільний телефон Samsung Galaxy S21 FE 6/128GB Graphite", Price = 21599, InStock = 19 },
                new Product { Id = 10, Name = "Монітор 34\" Samsung Odyssey G5 LC34G55T Black", Price = 15999, InStock = 30 },
                new Product { Id = 11, Name = "Ігрова приставка PS5 PlayStation 5", Price = 22699, InStock = 45 },
                new Product { Id = 12, Name = "Смарт-годинник Samsung Galaxy Watch 6 40mm Black", Price = 11999, InStock = 80 },
                new Product { Id = 13, Name = "БФП Canon PIXMA G2410", Price = 8799, InStock = 11 },
                new Product { Id = 14, Name = "Навушники Razer Blackshark V2 X Black", Price = 2799, InStock = 35 },
                new Product { Id = 15, Name = "Razer DeathAdder Essential USB Black", Price = 1199, InStock = 44 },
                new Product { Id = 16, Name = "Ноутбук Acer Extensa 15 EX215-23-R2EZ", Price = 24599, InStock = 20 },
                new Product { Id = 17, Name = "Навушники HyperX Cloud Stinger 2 Wireless Black", Price = 3999, InStock = 50 }
                );
        }
    }
}
