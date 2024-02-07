using System.Globalization;
using System.Security.Cryptography;

namespace DesignPatterns
{
    // Class for Printer
    // TODO#1: Convert to use Singleton pattern
    public class Printer
    {
        private Printer() { }

        private static Printer instance { get; set; } = default!;
        public static Printer GetInstance()
        {
            if (instance == null)
            {
                instance = new Printer();
            }
            return instance;
        }

        public void Print(string message)
        {
            // Output: print out the string message
            Console.WriteLine(message);

        }
    }

    // Class template for Exam classes
    // TODO#2: Convert to use Abstract Factory pattern
    // Create an Exam interface and an Abstract Factory to manage the creation of different exam types.

    public interface IExam
    {
        void Conduct();
        void Evaluate();
        void PublishResults();
    }


    public class MathExam : IExam
    {
        Printer p3 = Printer.GetInstance();
        public void Conduct()
        {
            // Output: "Conducting Math Exam", should use Printer class to print the message
            p3.Print("-------------------------------------\n" +
                "Conducting Math Exam\n");
        }

        public void Evaluate()
        {
            // Output: "Evaluating Math Exam", should use Printer class to print the message
            p3.Print("Evaluating Math Exam \n");
        }

        public void PublishResults()
        {
            // Output: "Publishing Math Exam Results", should use Printer class to print the message
            p3.Print("Publishing Math Exam \n" +
            "-------------------------------------");
        }
    }

    // TODO#5: Add new ScienceExam class

    public class ScienceExam : IExam
    {
        Printer p3 = Printer.GetInstance();
        public void Conduct()
        {
            // Output: "Conducting Science Exam", should use Printer class to print the message
            p3.Print("-------------------------------------\n" +
                "Conducting Science Exam \n");
        }

        public void Evaluate()
        {
            // Output: "Evaluating Science Exam", should use Printer class to print the message
            p3.Print("Evaluating Science Exam \n");
        }

        public void PublishResults()
        {
            // Output: "Publishing Science Exam Results", should use Printer class to print the message
            p3.Print("Publishing Science Exam \n" +
                "-------------------------------------");
        }
    }

    // TODO#6: Add another ProgrammingExam class

    public class ProgrammingExam : IExam
    {
        Printer p3 = Printer.GetInstance();
        public void Conduct()
        {
            // Output: "Conducting Programming Exam", should use Printer class to print the message
            p3.Print("-------------------------------------\n" +
                "Conducting Programming Exam \n");
        }

        public void Evaluate()
        {
            // Output: "Evaluating Programming Exam", should use Printer class to print the message
            p3.Print("Evaluating Programming Exam \n");
        }

        public void PublishResults()
        {
            // Output: "Publishing Programming Exam Results", should use Printer class to print the message
            p3.Print("Publishing Programming Exam \n" +
                "-------------------------------------");
        }
    }

    public abstract class ExamFactory
    {
        public abstract IExam CreateExam();
    }

    public class MathExamFactory : ExamFactory
    {
        public override IExam CreateExam() => new MathExam();
    }

    public class ScienceExamFactory : ExamFactory
    {
        public override IExam CreateExam() => new ScienceExam();
    }

    public class ProgrammingExamFactory : ExamFactory
    {
        public override IExam CreateExam() => new ProgrammingExam();
    }

    public class ExamClass
    {
        public static void Exams(ExamFactory factory)
        {
            IExam exam = factory.CreateExam();
            exam.Conduct();
            exam.Evaluate();
            exam.PublishResults();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // TODO#7: Initialize Printer that uses Singleton pattern
            Printer p1 = Printer.GetInstance();


            // TODO#8: Test that the created Printer works, by calling the Print method
            p1.Print("Hello BEEP BOOP!");

            // TODO#9: Ensure that only one Printer instance is used throughout the application.
            //         Try to create new Printer object and compare the two objects to check,
            //         that the new printer object is the same instance
            Printer p2 = Printer.GetInstance();

            if (p1 == p2)
            {
                Console.WriteLine("Printer object is in the same instance");
            }
            else
            {
                Console.WriteLine("Printer failed.");
            }

            // TODO#10: Use Abstract Factory to create different types of exams.

            ExamFactory mathExamFactory = new MathExamFactory();
            ExamFactory scienceExamFactory = new ScienceExamFactory();
            ExamFactory programmingExamFactory = new ProgrammingExamFactory();

            ExamClass.Exams(mathExamFactory);
            ExamClass.Exams(scienceExamFactory);
            ExamClass.Exams(programmingExamFactory);
            Console.ReadKey();

        }
    }

}
