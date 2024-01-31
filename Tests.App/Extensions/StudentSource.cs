using System.Text.Json;
using Tests.App.Cores;

namespace Tests.App.Extensions;

public class StudentSource : ISource<Student>
{
    public IEnumerable<Student>? Collection => GetSource();

    public IEnumerable<Student> GetSource()
    {
        if (File.Exists("students.json"))
        {
            using var fs = new FileStream("students.json", FileMode.Open);

            return JsonSerializer.Deserialize<IEnumerable<Student>>(fs) ?? Enumerable.Empty<Student>();
        }

        throw new Exception("File is not exists");
    }
}