using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CSharpIntro
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World");

            // This is a comment. The program will ignore it.

            // Use Ctrl + F5 to run the program into the console.

            // Create a integer variable and display it
            int nbPeople = 3;
            Console.WriteLine(nbPeople);

            // Add 1 to the variable
            nbPeople = nbPeople + 1;
            Console.WriteLine(nbPeople);

            // String (text) variables
            string greetings = "Hello";
            string target = "you";

            // Use + with string for concatenations
            Console.WriteLine(greetings + target);
            Console.WriteLine(greetings + " " + target);
            
            // Say hello several times
            for (int i = 0; i < nbPeople; i++)
            {
                Console.WriteLine("Hello you");
            }

            // Same and display i
            for (int i = 0; i < nbPeople; i++)
            {
                Console.WriteLine("Hello you");
                Console.WriteLine(i);
            }

            // A list of names
            List<String> names = new List<string>();
            names.Add("Annie");
            names.Add("Brandon");
            names.Add("Caitlyn");
            names.Add("Darius");
            Console.WriteLine(names);

            // We want to display the names properly
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            // Variation, to display the indexes
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }


            // A function to automate a name add
            void AddElise()
            {
                names.Add("Elise");
                nbPeople = names.Count;
            }

            // A smarter function to automate a name add
            void AddName(string name)
            {
                names.Add(name);
                nbPeople = names.Count;
            }
            AddName("Elise");

            // ?? Create a function to say hello to all names and display the names count
            void Greetings()
            {
                foreach (string name in names)
                {
                    Console.WriteLine("Hello " + name);
                }
                Console.WriteLine("Number of hello: " + names.Count);
            }
            Greetings();

            // ?? Create a function to say hello in the reverse order
            void GreetingsReverse()
            {
                int count = names.Count;
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(names[count - 1 - i]);
                }
            }
            GreetingsReverse();

            // Conditions
            int maxPeople = 7;
            if(nbPeople < maxPeople)
            {
                Greetings();
            }
            else
            {
                Console.WriteLine("Hello everybody");
            }

            // ?? Create a function that takes a parameter for the threshould and test
            void LazyGreetings(int threshold)
            {
                if (nbPeople < threshold)
                {
                    Greetings();
                }
                else
                {
                    Console.WriteLine("Hello everybody");
                }
            }
            LazyGreetings(2);
            LazyGreetings(10);

            // Using while to empty the list
            while(names.Count > 0)
            {
                names.RemoveAt(names.Count - 1);
            }
            LazyGreetings(5);
        }
    }
}
