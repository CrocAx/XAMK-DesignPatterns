using System.Data;

namespace BuilderExercise.Models
{
    public class CustomHouseBuilder : HouseBuilder
    {
        public override void BuildFoundation()
        {
            Console.WriteLine("Choose a foundation type: ");
            Console.WriteLine("1: Wood piles");
            Console.WriteLine("2: Concrete piles");

            string Foundation;

            switch (Console.ReadLine())
            {
                case "1":
                    Foundation = "Wood piles";
                    break;

                case "2":
                    Foundation = "Concrete piles";
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    Foundation = "Wood piles";
                    break;
            }
            house.Foundation = Foundation;
        }
        public override void BuildWalls()
        {
            Console.WriteLine("Choose a wall type:");
            Console.WriteLine("1: Wood and glass");
            Console.WriteLine("2: Brick and glass");

            string wallsType;

            switch (Console.ReadLine())
            {
                case "1":
                    wallsType = "Wood and glass";
                    break;

                case "2":
                    wallsType = "Brick and glass";
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    wallsType = "Wood and glass";
                    break;
            }
            house.Walls = wallsType;
        }
        public override void BuildRoof()
        {
            Console.WriteLine("Choose roof type:");
            Console.WriteLine("1: Wooden Roof");
            Console.WriteLine("2: Tile Roof");

            string roofType;

            switch (Console.ReadLine())
            {
                case "1":
                    roofType = "Wooden Roof";
                    break;
                case "2":
                    roofType = "Tile Roof";
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    roofType = "Wooden Roof";
                    break;
            }

            house.Roof = roofType;
        }

        public override void BuildGarage()
        {
            Console.WriteLine("Would you like a garage? (yes/no)");
            house.HasGarage = Console.ReadLine().ToLower() == "yes";
        }

        public override void BuildGarden()
        {
            Console.WriteLine("Would you like a swimming pool? (yes/no)");
            house.HasSwimmingPool = Console.ReadLine().ToLower() == "yes";
        }

        public override void BuildSwimmingPool()
        {
            Console.WriteLine("Would you like a garden? (yes/no)");
            house.HasGarden = Console.ReadLine().ToLower() == "yes";
        }
    }
}
