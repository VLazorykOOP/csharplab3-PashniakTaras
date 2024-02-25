using System;

class ATriangle
{
    // Поля
    protected int a; // Катет a
    protected int b; // Катет b
    protected int c; // Колiр трикутника

    // Властивостi
    public int A
    {
        get { return a; }
        set { a = value; }
    }

    public int B
    {
        get { return b; }
        set { b = value; }
    }

    public int Color
    {
        get { return c; }
    }

    // Конструктор
    public ATriangle(int sideA, int sideB, int color)
    {
        a = sideA;
        b = sideB;
        c = color;
    }

    // Конструктор для генерації рандомних даних
    public ATriangle()
    {
        Random rand = new Random();
        a = rand.Next(1, 101); // Генеруємо випадкову довжину катета a в діапазоні від 1 до 100
        b = rand.Next(1, 101); // Генеруємо випадкову довжину катета b в діапазоні від 1 до 100
        c = rand.Next(1, 256); // Генеруємо випадковий колір від 1 до 255 (256 виключено)
    }

    // Методи
    public void DisplaySides()
    {
        Console.WriteLine($"Сторони трикутника: a = {a}, b = {b}");
    }

    public int CalculatePerimeter()
    {
        double perimeter = a + b + Math.Sqrt(a * a + b * b); // Обчислюємо периметр
        return (int)Math.Round(perimeter); // Округлюємо до цілого значення
    }

    public double CalculateArea()
    {
        return 0.5 * a * b;
    }

    public bool IsIsosceles()
    {
        return a == b;
    }
}

class Product
{
    protected string name;
    protected double price;

    public Product(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Назва: {name}, Цiна: {price}");
    }
}

class Toy : Product
{
    protected string manufacturer;

    public Toy(string name, double price, string manufacturer) : base(name, price)
    {
        this.manufacturer = manufacturer;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Виробник: {manufacturer}");
    }
}

class Goods : Product
{
    protected DateTime expirationDate;

    public Goods(string name, double price, DateTime expirationDate) : base(name, price)
    {
        this.expirationDate = expirationDate;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Дата закiнчення термiну придатностi: {expirationDate}");
    }
}

class MilkProduct : Goods
{
    public MilkProduct(string name, double price, DateTime expirationDate) : base(name, price, expirationDate)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Створити трикутник та вивести iнформацiю");
            Console.WriteLine("2. Показати iнформацiю про товари");
            Console.WriteLine("3. Вийти");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    TestATriangle();
                    break;
                case 2:
                    TestProducts();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Невiрний вибiр. Спробуйте знову.");
                    break;
            }
        }
    }

    static void TestProducts()
    {
        Random rand = new Random();
        Product[] products = new Product[3];
        products[0] = new Toy("М'яч", Math.Round(rand.NextDouble() * 100, 2), "Фабрика Забавок");
        products[1] = new MilkProduct("Молоко", Math.Round(rand.NextDouble() * 100, 2), DateTime.Today.AddDays(rand.Next(1, 365)));
        products[2] = new Product("Книга", Math.Round(rand.NextDouble() * 100, 2));

        Console.WriteLine("Виведення інформації про товари:");

        foreach (Product product in products)
        {
            product.Show();
            Console.WriteLine();
        }
    }



    public static void TestATriangle()
    {
        ATriangle triangle = new ATriangle(); // Використовуємо конструктор без параметрів для генерації рандомних даних

        Console.WriteLine("\niнформацiя про трикутник:");
        triangle.DisplaySides();
        Console.WriteLine($"Периметр: {triangle.CalculatePerimeter()}");
        Console.WriteLine($"Площа: {triangle.CalculateArea()}");
        Console.WriteLine($"Чи є рiвнобедреним: {triangle.IsIsosceles()}\n");
    }
}
