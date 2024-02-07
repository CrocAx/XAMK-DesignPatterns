namespace BuilderExercise.Models
{
    /// <summary>
    /// Director
    /// </summary>
    public class ConstructionCompany
    {
        /// <summary>
        /// Construct Wooden house
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public House ConstructWoodenHouse(HouseBuilder builder)
        {
            builder.BuildFoundation();
            builder.BuildWalls();
            builder.BuildRoof();
            return builder.GetHouse();
        }

        /// <summary>
        /// Construct Brick house with garage
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public House ConstructBrickHouse(HouseBuilder builder)
        {
            builder.BuildFoundation();
            builder.BuildWalls();
            builder.BuildRoof();
            builder.BuildSwimmingPool();
            builder.BuildGarage();
            return builder.GetHouse();
        }

        /// <summary>
        /// Construct Custom house
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public House ConstructCustomHouse(HouseBuilder builder)
        {
            builder.BuildFoundation();
            builder.BuildWalls();
            builder.BuildRoof();
            builder.BuildGarage();
            builder.BuildGarden();
            builder.BuildSwimmingPool();
            return builder.GetHouse();
        }
    }
}
