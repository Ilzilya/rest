namespace rest.Models
{
    public class IngredOnDish
    {
        public int Id { get; set; }
        public double Amt { get; set; }
        public int IngredId { get; set; }
        public Ingred Ingred { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
