using Tests.App.Cores;
using Tests.App.Extensions;

namespace Tests.App;

class Program
{
    private static readonly StudentSource StudentSource;
    private static readonly ProductSource ProductSource;

    static Program()
    {
        StudentSource = new StudentSource();
        ProductSource = new ProductSource();
    }

    private static void Main(string[] args)
    {
        const string text = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.";
        Print(FilterStringsThatStartWithLetterA(text));
        
        Print(FindTheSameValuesOfTwoArrayInt32(GenerateArrayInt32(), GenerateArrayInt32()));
        
        if (StudentSource.Collection is not null)
        {
            var student = StudentWithGreaterAverageScore(StudentSource.Collection);
            Console.WriteLine($"{student.LastName} {student.FirstName} {student.AverageScore}");
        }

        if (ProductSource.Collection is not null)
        {
            Print(ProductGroupingByCategoryAndAverage(ProductSource.Collection));
        }
    }
    /// <summary>
    /// Task 1
    /// </summary>
    /// <param name="inner">text</param>
    /// <returns>Program returns collection of strings with words that start with 'A'</returns>
    private static IEnumerable<string> FilterStringsThatStartWithLetterA(string inner)
    {
        return inner
            .Split('.')
            .Where(str => str.Trim().StartsWith("a", StringComparison.OrdinalIgnoreCase));
    }
    
    /// <summary>
    /// Task 2
    /// </summary>
    /// <param name="left">array1</param>
    /// <param name="right">array2</param>
    /// <returns>Find the same values of two array Int32</returns>  
    private static IEnumerable<int> FindTheSameValuesOfTwoArrayInt32(int[] left, int[] right)
    {
        return left.Intersect(right);
    }

    /// <summary>
    /// Task 3
    /// </summary>
    /// <param name="students">source</param>
    /// <returns>Student that has max average score</returns>
    private static Student StudentWithGreaterAverageScore(IEnumerable<Student> students)
    {
        return students
            .OrderByDescending(s => s.AverageScore)
            .Select(s => s)
            .First();
    }

    /// <summary>
    /// Task 4
    /// </summary>
    /// <returns>Returns product that group by category and average price</returns>
    private static Dictionary<string, int> ProductGroupingByCategoryAndAverage(IEnumerable<Product> products)
    {
        return products
            .OrderBy(p => p.Price)
            .GroupBy(p => p.Category.Split('-')[0])
            .Select(p => new
            {
                Category = p.Key,
                Avarage = p.Sum(price => price.Price)
            })
            .ToDictionary(k => k.Category, sumOfPrices => sumOfPrices.Avarage);
    }
    
    /// <summary>
    /// Printed values of collection
    /// </summary>
    /// <param name="source">collection</param>
    /// <typeparam name="T">object</typeparam>
    private static void Print<T>(IEnumerable<T> source)
    {
        foreach (var obj in source)
        {
            Console.WriteLine(obj);
        }
    }
    
    /// <summary>
    /// Generate
    /// </summary>
    /// <returns>Array Int32</returns>
    private static int[] GenerateArrayInt32()
    {
        var size = Random.Shared.Next(0, 33);
        var array = Array.Empty<int>();

        for (var i = 0; i < size; i++)
        {
            array[i] = Random.Shared.Next(0, 43);
        }

        return array;
    }
}