using System;

// Батьківський клас
public class ParentClass
{
    // Подія, яку можна генерувати
    public event EventHandler EventOccurred;

    // Метод, що генерує подію
    protected virtual void OnEventOccurred(EventArgs e)
    {
        EventHandler handler = EventOccurred;
        if (handler != null)
        {
            handler(this, e);
        }
    }
}

// Дочірній клас
public class ChildClass : ParentClass
{
    public void DoSomething()
    {
        // Виклик події у дочірньому класі
        OnEventOccurred(EventArgs.Empty);
    }
}

// Головний клас програми
public class Program
{
    public static void Main(string[] args)
    {
        ChildClass child = new ChildClass();
        child.EventOccurred += Child_EventOccurred;

        child.DoSomething();
    }

    // Обробник події у головному класі
    private static void Child_EventOccurred(object sender, EventArgs e)
    {
        Console.WriteLine("Подія сталася в дочірньому класі.");
    }
}
