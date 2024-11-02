﻿using System;

public interface IBeverage
{
    double GetCost();          // Получить стоимость напитка
    string GetDescription();    // Получить описание напитка
}

public class Coffee : IBeverage
{
    public double GetCost()
    {
        return 50.0;  // Стоимость кофе
    }

    public string GetDescription()
    {
        return "Coffee";
    }
}

public abstract class BeverageDecorator : IBeverage
{
    protected IBeverage _beverage;

    public BeverageDecorator(IBeverage beverage)
    {
        _beverage = beverage;
    }

    public virtual double GetCost()
    {
        return _beverage.GetCost();
    }

    public virtual string GetDescription()
    {
        return _beverage.GetDescription();
    }
}

public class MilkDecorator : BeverageDecorator
{
    public MilkDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 10.0;  // Стоимость с добавлением молока
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Milk";
    }
}

public class SugarDecorator : BeverageDecorator
{
    public SugarDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 5.0;  // Стоимость с добавлением сахара
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Sugar";
    }
}

public class ChocolateDecorator : BeverageDecorator
{
    public ChocolateDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 15.0;  // Стоимость с добавлением шоколада
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Chocolate";
    }
}

public class VanillaDecorator : BeverageDecorator
{
    public VanillaDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 12.0;  // Стоимость с добавлением ванили
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Vanilla";
    }
}

public class CinnamonDecorator : BeverageDecorator
{
    public CinnamonDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 8.0;  // Стоимость с добавлением корицы
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Cinnamon";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем базовый напиток — кофе
        IBeverage beverage = new Coffee();
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем молоко
        beverage = new MilkDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем сахар
        beverage = new SugarDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем шоколад
        beverage = new ChocolateDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем ваниль
        beverage = new VanillaDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем корицу
        beverage = new CinnamonDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");
    }
}

