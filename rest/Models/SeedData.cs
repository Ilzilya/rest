using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using rest.Data;
using rest.Models;
using System;
using System.Linq;

namespace rest.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new restContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Tables.Any())
                {

                    context.Tables.AddRange(
                        new Table
                        {
                           Сapacity=4
                        },
                        new Table
                        {
                            Сapacity = 2
                        },
                        new Table
                        {
                            Сapacity = 4
                        },
                        new Table
                        {
                            Сapacity = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Statuses.Any())
                {

                    context.Statuses.AddRange(
                        new Status
                        {
                            Name="Готово к выдаче"
                        },
                        new Status
                        {
                            Name = "Готовится"
                        },
                        new Status
                        {
                            Name = "Принято"
                        },
                        new Status
                        {
                            Name = "Ожидает"
                        }
                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Guests.Any())
                {

                    context.Guests.AddRange(
                        new Guest
                        {
                            Surname="Иванов",
                            Name = "Иван",
                            Patronymic ="Иванович",
                            Tel=89112233441
                        }
                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Reservs.Any())
                {

                    context.Reservs.AddRange(
                        new Reserv
                        {
                            Data=new DateTime(22, 04, 11, 19, 0,0),
                            CountPerson = 2,
                            Notes="",
                            TableId=2,
                            GuestId=1
                        }
                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Units.Any())
                {

                    context.Units.AddRange(
                        new Unit
                        {
                            Name = "ст. ложка",
                        },
                        new Unit
                        {
                            Name = "ч. ложка",
                        },
                        new Unit
                        {
                            Name = "гр",
                        },
                        new Unit
                        {
                            Name = "мл",
                        },
                        new Unit
                        {
                            Name = "ст",
                        }
                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Ingreds.Any())
                {

                    context.Ingreds.AddRange(
                        new Ingred
                        {
                            Name = "Сыр Пармезан",
                            UnitId =3,
                            Kkal = 78
                        },
                        new Ingred
                        {
                            Name = "Сыр Моцарелла",
                            UnitId = 3,
                            Kkal = 0
                        },
                        new Ingred
                        {
                            Name = "Сыр Маасдам",
                            UnitId = 3,
                            Kkal = 0
                        },
                        new Ingred
                        {
                            Name = "Сыр Горгонзола",
                            UnitId = 3,
                            Kkal = 0
                        },
                        new Ingred
                        {
                            Name = "Масло оливковое",
                            UnitId = 1,
                            Kkal = 0
                        },
                        new Ingred
                        {
                            Name = "Орегано сушеный",
                            UnitId = 2,
                            Kkal = 0
                        }
                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Categories.Any())
                {

                    context.Categories.AddRange(
                        new Category
                        {
                            Name = "Пицца",
                        },
                         new Category
                         {
                             Name = "Напитки",
                         }, new Category
                         {
                             Name = "Десерты",
                         }, new Category
                         {
                             Name = "Паста",
                         }, new Category
                         {
                             Name = "Бургеры",
                         }
                    );
                    context.SaveChanges();
                }
            }
           
           
            using (var context = new restContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Dishes.Any())
                {
                    context.Dishes.AddRange(
                        new Dish
                        {
                            Name = "Пицца Четыре сыра",
                            Description = "а",
                            Kkal = 500,
                            Cook_tech = "1. Раскатываем тесто толщиной 2-3 мм, 2. Делаем бортики, 3. Смазываем основу оливковым маслом, посыпаем орегано",
                            Price = 700,
                            Menu = true,
                            Img = "j",
                            Portion = "32 см",
                            Weight = 550,
                            CategoryId = 1
                        }, new Dish
                        {
                            Name = "Пицца",
                            Description = "а",
                            Kkal = 500,
                            Cook_tech = "1. Раскатываем тесто толщиной 2-3 мм, 2. Делаем бортики, 3. Смазываем основу оливковым маслом, посыпаем орегано",
                            Price = 700,
                            Menu = true,
                            Img = "j",
                            Portion = "32 см",
                            Weight = 550,
                            CategoryId = 1
                        }

                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.IngredOnDish.Any())
                {

                    context.IngredOnDish.AddRange(
                        new IngredOnDish
                        {
                            Amt = 100,
                            IngredId = 1,
                            DishId = 2
                        }, new IngredOnDish
                        {
                            Amt = 100,
                            IngredId = 2,
                            DishId = 2
                        }, new IngredOnDish
                        {
                            Amt = 50,
                            IngredId = 3,
                            DishId = 2
                        }, new IngredOnDish
                        {
                            Amt = 50,
                            IngredId = 4,
                            DishId = 2
                        }, new IngredOnDish
                        {
                            Amt = 1,
                            IngredId = 5,
                            DishId = 2
                        }, new IngredOnDish
                        {
                            Amt = 1,
                            IngredId = 6,
                            DishId = 2
                        }, new IngredOnDish
                        {
                            Amt = 100,
                            IngredId = 1,
                            DishId = 1
                        }, new IngredOnDish
                        {
                            Amt = 100,
                            IngredId = 2,
                            DishId = 1
                        }, new IngredOnDish
                        {
                            Amt = 50,
                            IngredId = 3,
                            DishId = 1
                        }, new IngredOnDish
                        {
                            Amt = 50,
                            IngredId = 4,
                            DishId = 1
                        }, new IngredOnDish
                        {
                            Amt = 1,
                            IngredId = 5,
                            DishId = 1
                        }, new IngredOnDish
                        {
                            Amt = 1,
                            IngredId = 6,
                            DishId = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
            using (var context = new restContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<restContext>>()))
            {
                // Look for any movies.
                if (!context.Orders.Any())
                {

                    context.Orders.AddRange(
                        new Orders
                        {
                            ReservId = 1,
                            Payment = false,
                            Price = 100,
                            Time = 45
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}