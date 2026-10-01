namespace PrintingHouse;

/// <summary>
/// Чтение данных из CSV-файлов
/// </summary>
public class CsvRepository
{
    private string _basePath;

    /// <summary>
    /// Конструктор с указанием базовой папки с CSV-файлами
    /// </summary>
    public CsvRepository(string basePath)
    {
        _basePath = basePath;
    }

    /// <summary>
    /// Читает отделы из departments.csv
    /// </summary>
    public List<Department> GetDepartments()
    {
        List<Department> result = new List<Department>();
        string path = Path.Combine(_basePath, "departments.csv");

        if (!File.Exists(path))
            throw new FileNotFoundException("Не найден файл: " + path);

        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2)
            throw new InvalidDataException("Файл пуст: " + path);

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "") continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 3) continue;

            int id = int.Parse(parts[0]);
            Department d = new Department(id);
            d.Name = parts[1];
            d.Head = parts[2];

            result.Add(d);
        }

        return result;
    }

    /// <summary>
    /// Читает редакторов из editors.csv
    /// </summary>
    public List<Editor> GetEditors()
    {
        List<Editor> result = new List<Editor>();
        string path = Path.Combine(_basePath, "editors.csv");

        if (!File.Exists(path))
            throw new FileNotFoundException("Не найден файл: " + path);

        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2)
            throw new InvalidDataException("Файл пуст: " + path);

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "") continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 4) continue;

            int id = int.Parse(parts[0]);
            Editor e = new Editor(id);
            e.FullName = parts[1];
            e.Experience = int.Parse(parts[2]);
            e.Specialty = parts[3];

            result.Add(e);
        }

        return result;
    }

    /// <summary>
    /// Читает издания из editions.csv
    /// </summary>
    public List<Edition> GetEditions()
    {
        List<Edition> result = new List<Edition>();
        string path = Path.Combine(_basePath, "editions.csv");

        if (!File.Exists(path))
            throw new FileNotFoundException("Не найден файл: " + path);

        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2)
            throw new InvalidDataException("Файл пуст: " + path);

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "") continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 6) continue;

            int id = int.Parse(parts[0]);
            Edition ed = new Edition(id);
            ed.Title = parts[1];
            ed.DepartmentId = int.Parse(parts[2]);
            ed.EditorId = int.Parse(parts[3]);
            ed.Pages = int.Parse(parts[4]);
            ed.Price = decimal.Parse(parts[5]);

            result.Add(ed);
        }

        return result;
    }
}