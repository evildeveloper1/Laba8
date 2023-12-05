using System;
public interface IChart
{
    void Draw();
}
public class LineChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing Line Chart");
    }
}

public class BarChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
    }
}

public class PieChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
    }
}
public abstract class GraphFactory
{
    public abstract IChart CreateChart();
}

public class LineChartFactory : GraphFactory
{
    public override IChart CreateChart()
    {
        return new LineChart();
    }
}

public class BarChartFactory : GraphFactory
{
    public override IChart CreateChart()
    {
        return new BarChart();
    }
}

public class PieChartFactory : GraphFactory
{
    public override IChart CreateChart()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of chart (Line/Bar/Pie): ");
        string chartType = Console.ReadLine();

        GraphFactory factory;

        switch (chartType.ToLower())
        {
            case "line":
                factory = new LineChartFactory();
                break;
            case "bar":
                factory = new BarChartFactory();
                break;
            case "pie":
                factory = new PieChartFactory();
                break;
            default:
                Console.WriteLine("Invalid chart type");
                return;
        }

        IChart chart = factory.CreateChart();
        chart.Draw();

        Console.ReadLine();
    }
}
