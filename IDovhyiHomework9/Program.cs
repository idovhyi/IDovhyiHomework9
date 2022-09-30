﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IDovhyiHomework9
{
    abstract class Shape : IComparable<Shape>
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public Shape(string name)
        {
            this.name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();
        public int CompareTo(Shape other)
        {
            if (this.Area() - other.Area() < 0) return -1;
            if (this.Area() - other.Area() > 0) return 1; else return 0;
        }
    }
    class Circle : Shape
    {
        double radius;
        public double Radius { get { return radius; } set { radius = value; } }
        public Circle(string name, double radius) : base(name)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
    class Square : Shape
    {
        double side;
        public double Side { get { return side; } set { side = value; } }
        public Square(string name, double side) : base(name)
        {
            this.side = side;
        }
        public override double Area()
        {
            return side * side;
        }

        public override double Perimeter()
        {
            int sidesNumber = 4;
            return side * sidesNumber;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountShapes = 6;
            List<Shape> shapes = new List<Shape>(amountShapes);
            Console.Write($"Enter the number of circles (0..{amountShapes}): ");
            int circlesNumer = int.Parse(Console.ReadLine());
            for (int i = 0; i < circlesNumer; i++)
            {
                Console.Write("Shape " + (i + 1) + " is a circle. Enter the radius: ");
                double radius = double.Parse(Console.ReadLine());
                shapes.Add(new Circle("circle", radius));
            }
            for (int i = circlesNumer; i < amountShapes; i++)
            {
                Console.Write("Shape " + (i + 1) + " is a square. Enter the side: ");
                double side = double.Parse(Console.ReadLine());
                shapes.Add(new Square("square", side));
            }
            Console.WriteLine();


            var selectedAreaShapes = from shape in shapes
                                     where (shape.Area() >= 10) && (shape.Area() <= 100)
                                     select shape;
            string writePath1 = @"C:\Ihor\Study\SoftServe\Homework\IDovhyiHomework9\selectedAreaShapes.txt";
            using (StreamWriter sw = new StreamWriter(writePath1, false, System.Text.Encoding.Default))
            {
                foreach (Shape shape in selectedAreaShapes)
                {
                    sw.WriteLine($"{shape.Name} with area {shape.Area():0.00} and perimeter {shape.Perimeter():0.00}");
                }
            }

            var selectedAShapes = from shape in shapes
                                     where shape.Name.ToLower().Contains("a")
                                     select shape;
            string writePath2 = @"C:\Ihor\Study\SoftServe\Homework\IDovhyiHomework9\selectedAShapes.txt";
            using (StreamWriter sw = new StreamWriter(writePath2, false, System.Text.Encoding.Default))
            {
                foreach (Shape shape in selectedAShapes)
                {
                    sw.WriteLine($"{shape.Name} with area {shape.Area():0.00} and perimeter {shape.Perimeter():0.00}");
                }
            }

            var selectedPerimetrShapes = from shape in shapes
                                     where shape.Perimeter() < 5
                                     select shape;
            Console.WriteLine("Shapes with perimeter less then 5:");
            foreach (Shape shape in selectedPerimetrShapes) Console.WriteLine($"{shape.Name} with area {shape.Area():0.00} and perimeter {shape.Perimeter():0.00}");
            Console.WriteLine();
        }
    }
}
