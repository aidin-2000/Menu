using Microsoft.EntityFrameworkCore;
using Menu.Models;
using Microsoft.Identity.Client;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) :base(options) 
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di=>new
            {
                di.DishId,
                di.IngredeientId    
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredeientId);
            modelBuilder.Entity<Dish>().HasData(new Dish { Id = 1, Name="Маргарита", Price=550, ImageUrl= "https://www.google.com/imgres?imgurl=https%3A%2F%2Flh3.googleusercontent.com%2F-F7-f2RyixFJ_0-MIGehlz7lp08CkWuy7Y64qDx8zcSrAyHA_uWVnJx1XOVAHg_qoFD7fW34aWScKlOz7tlHx8LeBxDoB64vaZ6LCKKMAPPnr8-QTpPpQVVK-xGPWFZomSVkVZXW&tbnid=KRWx8o3QDyUbEM&vet=12ahUKEwjFoouO05CFAxVlMhAIHUy2CzEQMygDegQIARBX..i&imgrefurl=https%3A%2F%2Fpizza.od.ua%2Fblog%2Fpitstsa-margarita-korolevskaya-pishcha-ili-eda-dlya-bednyakov.html&docid=UrQT4GHwqiqLjM&w=624&h=416&q=%D0%BC%D0%B0%D1%80%D0%B3%D0%B0%D1%80%D0%B8%D1%82%D0%B0%20%D0%BF%D0%B8%D1%86%D1%86%D0%B0&ved=2ahUKEwjFoouO05CFAxVlMhAIHUy2CzEQMygDegQIARBX" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 1, Name = "Сыр" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 2, Name = "Томатный соус" });
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredeientId = 1 },
                new DishIngredient { DishId = 1, IngredeientId = 2 }
                );
           

            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<Dish> Dishes { get; set; } 
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<DishIngredient> DishIngredients { get; set; }

    }
}
    