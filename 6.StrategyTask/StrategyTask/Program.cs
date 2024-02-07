using System;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace StrategyTask
{
    public class MovementSimulator
    {
        public static void Main(string[] args)
        {
            Bird mallard = new MallardDuck();
            Bird emperor = new EmperorPenguin();
            Bird eagle = new BaldEagle();
            Bird ostrich = new Ostrich();
            Bird rubberduck = new YelloRubberDuck();

            Console.WriteLine($"Number of birds in the simulation: {Bird.GetBirdCount()}\n");

            mallard.performMove();
            emperor.performMove();
            eagle.performMove();
            ostrich.performMove();
            rubberduck.performMove();
        }

    }
    public interface MovementBehavior
    {
        public void move();
    }

    public class FlyWithWings : MovementBehavior
    {
        
        public void move()
        {
            Console.Write("*FLIES BY FLAPPING WINGS*");
        }
    }

    public class SlideOnBelly : MovementBehavior
    {
        public void move() 
        {
            Console.Write("*SLIDES ON ITS BELLY*");
        }
    }

    public class HideHead : MovementBehavior
    {
        public void move() 
        {
            Console.Write("*HIDES HEAD IN THE SAND AS IT CANNOT FLY*");
        }
    }

    public class FloatInWater : MovementBehavior
    {
        public void move()
        {
            Console.Write("*FLOATS IN WATER*");
        }
    }

    public abstract class Bird
    {
        protected MovementBehavior behavior;

        private static int birdCount = 0;

        public Bird()
        {
            birdCount++;
        }

        public static int GetBirdCount()
        {
            return birdCount;
        }
        public abstract void display();

        public void performMove()
        {
            display();
            behavior.move();
            Console.WriteLine();
        }

    }

    public class MallardDuck : Bird 
    {
        public MallardDuck()
        {
            behavior = new FlyWithWings();
            
            
        }
        public override void display()
        {
            Console.Write("Here is the Mallard Duck's movement behaviour: ");
        }
    }

    public class EmperorPenguin : Bird
    {
        public EmperorPenguin()
        {
            behavior = new SlideOnBelly();
        }
        public override void display()
        {
            Console.Write("Here is the Emperor Penguin movement behaviour: ");
        }
    }

    public class BaldEagle : Bird
    {
        public BaldEagle()
        {
            behavior = new FlyWithWings();
        }
        public override void display()
        {
            Console.Write("Here is the Bald Eagle's movement behaviour: ");
        }
    }

    public class Ostrich : Bird
    {
        public Ostrich()
        {
            behavior = new HideHead();
        }
        public override void display()
        {
            Console.Write("Here is the Ostrich's movement behaviour: ");
        }
    }

    public class YelloRubberDuck : Bird
    {
        public YelloRubberDuck()
        {
            behavior = new FloatInWater();
        }

        public override void display()
        {
            Console.Write("Here is the Yellow Rubber Duck's movement behaviour: ");
        }
    }
   
}