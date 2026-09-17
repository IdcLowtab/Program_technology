namespace PrintingHouse;

internal class CsvRepository
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

        if (!File.Exists(path)) return result;

        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "") continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 3) continue;

            Department d = new Department();
            d.Id = int.Parse(parts[0]);
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

        if (!File.Exists(path)) return result;

        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "") continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 4) continue;   // Id, FullName, Experience, Specialty

            Editor e = new Editor();
            e.Id = int.Parse(parts[0]);
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

        if (!File.Exists(path)) return result;

        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "") continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 6) continue;

            Edition ed = new Edition();
            ed.Id = int.Parse(parts[0]);
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
