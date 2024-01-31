using System.Text.Json;
using Tests.App.Cores;

namespace Tests.App.Extensions;

public class ProductSource : ISource<Product>
{
    public IEnumerable<Product>? Collection => GetSource();

    public IEnumerable<Product> GetSource()
    {
        if (File.Exists("products.json"))
        {
            using var fs = new FileStream("products.json", FileMode.Open);

            return JsonSerializer.Deserialize<IEnumerable<Product>>(fs) ?? Enumerable.Empty<Product>();
        }

        throw new Exception("File is not exists");
    }
}