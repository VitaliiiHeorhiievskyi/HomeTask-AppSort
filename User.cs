using System;

namespace AppSort
{
    public class User
    {
        public User(string name, int age, double weight)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name is null");

            Age = age < 0 ? throw new ArgumentException("Age < 0", nameof(age)) : age;

            Weight = weight < 0 ? throw new ArgumentException("Weight < 0", nameof(weight)) : weight;
        }

        public int Age { get; }
        public string Name { get; }
        public double Weight { get; }

        public override string ToString()
        {
            return $"Name: {Name}\t Age: {Age}\t Weight: {Weight}";
        }
    }
}