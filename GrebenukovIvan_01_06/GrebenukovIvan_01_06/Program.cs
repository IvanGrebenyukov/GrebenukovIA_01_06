
using System.Xml.Linq;
using WarehouseLibrary;

List <BaseWarehouse> elements = new List <BaseWarehouse>();

try
{
    while (true)
    {
        Console.WriteLine(@"Введите действие: 
1. Добавление нового элемента
2. Вывод всех элементов
Выход - любая другая клавиша");
        int choice = int.Parse(Console.ReadLine());
        if(choice == 1)
        {
            elements.Add(AddElement());
        } else if(choice == 2)
        {
            PrintElements(elements);
        } else
        {
            
        }
    }
}
catch
{

}

BaseWarehouse AddElement()
{
    int choice;
    while (true)
    {
        Console.WriteLine(@"Введите элемент какого класса добавить: " +
            "1. Базового" +
            " 2. Наследника");

        if(int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
        {
            break;
        }
        Console.WriteLine("Выберите 1 или 2");
    }

    Console.WriteLine("Введите название товара: ");
    string productName;
    while (true)
    {
        productName = Console.ReadLine();
        if(!string.IsNullOrEmpty(productName) )
        {
            break;
        }
        Console.WriteLine("Ошибка! Введите название товара: ");
    }

    Console.WriteLine("Введите цену товара: ");
    double price;
    while (true)
    {
        if(double.TryParse(Console.ReadLine(), out price) && price > 0)
        {
            break;
        }
        Console.WriteLine("Ошибка! Введите цену товара больше 0: ");
    }

    Console.WriteLine("Введите количество товара: ");
    int count;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out count) && count > 0)
        {
            break;
        }
        Console.WriteLine("Ошибка! Введите количество товара больше 0: ");
    }

    if(choice == 1)
    {
        BaseWarehouse baseElement = new BaseWarehouse(productName, price, count);
        return baseElement;
    }

    Console.WriteLine("Введите год выпуска товара: ");
    int yearRelease;
    while (true)
    {
        if ((int.TryParse(Console.ReadLine(), out yearRelease) && (yearRelease > 1900 || yearRelease <= DateTime.Now.Year)))
        {
            break;
        }
        Console.WriteLine("Ошибка! Введите год выпуска товара больше 1900 и меньше текущего года: ");
    }

    WarehouseChild childElement = new WarehouseChild(productName, price, count, yearRelease);
    return childElement;
}

void PrintElements(List<BaseWarehouse> elements)
{
    for (int i = 0; i < elements.Count; i++)
    {
        Console.WriteLine($"Номер объекта класса {i}: {elements[i].ToString()}");
    }
}