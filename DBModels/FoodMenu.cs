namespace HomeControl.DBModels
{
    public class FoodMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }

        public override string ToString()
        {
            return $"{Name} {Description}";
        }
    }
}
