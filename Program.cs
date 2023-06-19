public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(View.Introduction());
        while (true) { Controller.Play(); }
    }
}
