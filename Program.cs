using System;
using System.Collections.Generic;

class Food
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }

    // Constructor de Food
    public Food(string name, int calories, bool isSpicy, bool isSweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSweet = isSweet;
    }
}

class Buffet
{
    public List<Food> Menu { get; set; }

    // Constructor de Buffet
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Pizza", 800, true, false),
            new Food("Ice Cream", 300, false, true),
            new Food("Sushi", 500, true, false),
            new Food("Chocolate Cake", 600, false, true),
            new Food("Salad", 200, false, false),
            new Food("Curry", 900, true, false),
            new Food("Fruit Salad", 150, false, true),
        };
    }

    public Food Serve()
    {
        Random random = new Random();
        int randomIndex = random.Next(Menu.Count);
        return Menu[randomIndex];
    }
}

class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory { get; set; }

    // Constructor de Ninja
    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }

    public bool IsFull
    {
        get { return calorieIntake > 1200; }
    }

    public void Eat(Food item)
    {
        if (!IsFull)
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine($"Ninja eats {item.Name}. Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}");
        }
        else
        {
            Console.WriteLine("Ninja is full and cannot eat more!");
        }
    }
}

class Program
{
    static void Main()
    {
        Buffet buffet = new Buffet();
        Ninja ninja = new Ninja();

        while (!ninja.IsFull)
        {
            Food servedFood = buffet.Serve();
            ninja.Eat(servedFood);
        }
    }
}
