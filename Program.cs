using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public List<string> Predators { get; } = new List<string>();
        public List<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        public string PreyList() => string.Join(",", this.Prey);

        // Convert this method to an expression member
        public string PredatorList() => string.Join(",", this.Predators);

        // Convert this to expression method
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Predators = new List<string>()
            {
                "Shark",
                "Eagle",
                "Lion",
                "Tiger",
                "Hawk"
            };

            List<string> Prey = new List<string>()
            {
                "Fish",
                "Rabbit",
                "Buffalo",
                "Deer",
                "Mice"
            };

            Bug bug1 = new Bug("Yolo", "Ladybug", Predators, Prey);
            Console.WriteLine(bug1.FormalName);
            Console.WriteLine(bug1.Eat("a leaf"));
        }
    }
}