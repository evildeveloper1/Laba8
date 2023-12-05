using System;
using System.Collections.Generic;
public interface ICloneable<T>
{
    T Clone();
}
public class Data : ICloneable<Data>
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Data Clone()
    {
        return new Data { Name = this.Name, Value = this.Value };
    }
}

public interface IDataFormatAdapter
{
    string ConvertDataToString(Data data);
    Data ConvertStringToData(string dataString);
}

public class CsvAdapter : IDataFormatAdapter
{
    public string ConvertDataToString(Data data)
    {
        return $"{data.Name},{data.Value}";
    }

    public Data ConvertStringToData(string dataString)
    {
        string[] parts = dataString.Split(',');
        if (parts.Length == 2 && int.TryParse(parts[1], out int value))
        {
            return new Data { Name = parts[0], Value = value };
        }
        return null;
    }
}

public class DataTemplate : ICloneable<DataTemplate>
{
    public Data DataTemplateValue { get; set; }

    public DataTemplate Clone()
    {
        return new DataTemplate { DataTemplateValue = this.DataTemplateValue?.Clone() };
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose source data format (CSV/JSON): ");
        string sourceFormat = Console.ReadLine();

        Console.WriteLine("Choose target data format (CSV/JSON): ");
        string targetFormat = Console.ReadLine();

        IDataFormatAdapter sourceAdapter = GetAdapter(sourceFormat);
        IDataFormatAdapter targetAdapter = GetAdapter(targetFormat);
        DataTemplate template = new DataTemplate
        {
            DataTemplateValue = new Data { Name = "Example", Value = 42 }
        };

        DataTemplate clonedTemplate = template.Clone();

        Console.WriteLine("Original Template:");
        Console.WriteLine(sourceAdapter.ConvertDataToString(template.DataTemplateValue));

        Console.WriteLine("Cloned Template:");
        Console.WriteLine(targetAdapter.ConvertDataToString(clonedTemplate.DataTemplateValue));

        Console.ReadLine();
    }
    static IDataFormatAdapter GetAdapter(string format)
    {
        switch (format.ToLower())
        {
            case "csv":
                return new CsvAdapter();
            default:
                Console.WriteLine("Invalid format");
                return null;
        }
    }
}
