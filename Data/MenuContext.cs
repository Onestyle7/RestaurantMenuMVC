using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Models;

namespace RestaurantMenu.Data
{
    public class MenuContext : DbContext
    {
        private readonly DbContextOptions<MenuContext> _options;
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId); 
            
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);


            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Pizza", Price = 10.99, ImageUrl = "https://winotoskanii.pl/data/include/img/news/1472125853.jpg" },
                new Dish { Id = 2, Name = "Burger", Price = 5.99, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReXSN25NGHfgqSQMr73w0b0S66sz5dFq8VlZvIq3RWBg&s" },
                new Dish { Id = 3, Name = "Pasta", Price = 8.99, ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2013/05/Puttanesca-fd5810c.jpg?quality=90&resize=556,505" });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Chicken" },
                new Ingredient { Id = 2, Name = "Beef" },
                new Ingredient { Id = 3, Name = "Salmon" },
                new Ingredient { Id = 4, Name = "Tomatoes" },
                new Ingredient { Id = 5, Name = "Spinach" },
                new Ingredient { Id = 6, Name = "Mozzarella Cheese" },
                new Ingredient { Id = 7, Name = "Spaghetti Pasta" },
                new Ingredient { Id = 8, Name = "Mushrooms" },
                new Ingredient { Id = 9, Name = "Onion" },
                new Ingredient { Id = 10, Name = "Garlic" },
                new Ingredient { Id = 11, Name = "Bell Pepper" },
                new Ingredient { Id = 12, Name = "Basil" },
                new Ingredient { Id = 13, Name = "Olive Oil" },
                new Ingredient { Id = 14, Name = "Apples" },
                new Ingredient { Id = 15, Name = "Carrot" },
                new Ingredient { Id = 16, Name = "Milk" },
                new Ingredient { Id = 17, Name = "Wheat Bread" },
                new Ingredient { Id = 18, Name = "Black Pepper" },
                new Ingredient { Id = 19, Name = "Sea Salt" },
                new Ingredient { Id = 20, Name = "Lemons" });

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 6 },
                new DishIngredient { DishId = 1, IngredientId = 4 },
                new DishIngredient { DishId = 1, IngredientId = 13 },
                new DishIngredient { DishId = 1, IngredientId = 12 },
                new DishIngredient { DishId = 1, IngredientId = 19 },
                new DishIngredient { DishId = 2, IngredientId = 1 },
                new DishIngredient { DishId = 2, IngredientId = 17 },
                new DishIngredient { DishId = 2, IngredientId = 4 },
                new DishIngredient { DishId = 2, IngredientId = 9 },
                new DishIngredient { DishId = 2, IngredientId = 10 },
                new DishIngredient { DishId = 2, IngredientId = 11 },
                new DishIngredient { DishId = 2, IngredientId = 18 },
                new DishIngredient { DishId = 3, IngredientId = 7 },
                new DishIngredient { DishId = 3, IngredientId = 13 },
                new DishIngredient { DishId = 3, IngredientId = 9 },
                new DishIngredient { DishId = 3, IngredientId = 10 },
                new DishIngredient { DishId = 3, IngredientId = 11 },
                new DishIngredient { DishId = 3, IngredientId = 12 },
                new DishIngredient { DishId = 3, IngredientId = 19 });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
