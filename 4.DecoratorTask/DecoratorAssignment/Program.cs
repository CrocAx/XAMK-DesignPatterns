namespace DecoratorTask
{
    // Instructions
    // You can implement your whole solution here
    // Optionally you can use folder structure if you deem it necessary
    // For this Assignment we will use Decorator pattern example introduced in the book Head First Design Patterns by O'Reilly
    // Chapeter 3 the DecoratorPattern: Decorating Objects (starts at page 79)
    // Link to pdf: https://github.com/ajitpal/BookBank/blob/master/%5BO%60Reilly.%20Head%20First%5D%20-%20Head%20First%20Design%20Patterns%20-%20%5BFreeman%5D.pdf
    // NOTE: Remember that the code examples in this book are written in java so you can't just copy the code examples given there
    internal class Program
    {
        static void Main(string[] args)
        {

        }

    }

    public abstract class Beverage
    {
        protected string description = "Unknown Beverage";
        public virtual string GetDescription()
        {
            return description;
        }

        public abstract decimal Cost();
    }

    public abstract class CondimentDecorator : Beverage
        {
            public abstract override string GetDescription();
        }

        public class Espresso : Beverage
        {
            public Espresso()
            {
                description = "Espresso";
            }

            public override decimal Cost()
            {
                return 1.99M;
            }
        }

        public class HouseBlend : Beverage
        {
            public HouseBlend()
            {
                description = "House Blend Coffee";
            }

            public override decimal Cost()
            {
                return 0.89M;
            }
        }

        public class Decaf : Beverage
        {
            public Decaf()
            {
                description = "Decaf Coffee";
            }

            public override decimal Cost()
            {
                return 1.05M;
            }
        }

        public class DarkRoast : Beverage
        {
            public DarkRoast()
            {
                description = "Dark Roast Coffee";
            }

            public override decimal Cost()
            {
                return 0.99M;
            }
        }

        public class Mocha : CondimentDecorator
        {
            private Beverage beverage;

            public Mocha(Beverage beverage)
            {
                this.beverage = beverage;
            }

            public override string GetDescription()
            {
                return beverage.GetDescription() + ", Mocha";
            }

            public override decimal Cost()
            {
                return 0.20M + beverage.Cost();
            }
        }

    public class Whip : CondimentDecorator
    {
        private Beverage beverage;

        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whip";
        }

        public override decimal Cost()
        {
            return 0.10M + beverage.Cost();
        }
    }

    public class Soy : CondimentDecorator
    {
        private Beverage beverage;

        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soy";
        }

        public override decimal Cost()
        {
            return 0.15M + beverage.Cost();
        }
    }

}
