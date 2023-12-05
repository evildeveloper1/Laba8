using System;
public interface IScreen
{
    void Display();
}
public interface IProcessor
{
    void Process();
}

public interface ICamera
{
    void Capture();
}
public interface IProductFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
    ICamera CreateCamera();
}
public class SmartphoneScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("Smartphone Screen Displaying");
    }
}
public class LaptopScreen : IScreen
{
    public void Display()
    {
        Console.WriteLine("Laptop Screen Displaying");
    }
}
public class SmartphoneProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Smartphone Processor Processing");
    }
}
public class LaptopProcessor : IProcessor
{
    public void Process()
    {
        Console.WriteLine("Laptop Processor Processing");
    }
}
public class SmartphoneCamera : ICamera
{
    public void Capture()
    {
        Console.WriteLine("Smartphone Camera Capturing");
    }
}
public class LaptopCamera : ICamera
{
    public void Capture()
    {
        Console.WriteLine("Laptop Camera Capturing");
    }
}
public class ProductAssembler
{
    private IScreen screen;
    private IProcessor processor;
    private ICamera camera;

    public ProductAssembler(IProductFactory factory)
    {
        screen = factory.CreateScreen();
        processor = factory.CreateProcessor();
        camera = factory.CreateCamera();
    }
    public void AssembleProduct()
    {
        Console.WriteLine("Assembling product with:");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Choose the type of product to assemble (Smartphone/Laptop): ");
        string productType = Console.ReadLine();

        IProductFactory factory;

        switch (productType.ToLower())
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            default:
                Console.WriteLine("Invalid product type");
                return;
        }

        ProductAssembler assembler = new ProductAssembler(factory);
        assembler.AssembleProduct();

        Console.ReadLine();
    }
}