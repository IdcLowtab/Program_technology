namespace PrintingHouse;

/// <summary>
/// Хранилище тестовых данных в памяти
/// </summary>
public class InMemoryRepository
{
    private List<Department> _departments;
    private List<Editor> _editors;
    private List<Edition> _editions;

    /// <summary>
    /// Конструктор, заполняющий списки тестовыми данными
    /// </summary>
    public InMemoryRepository()
    {
        _departments = new List<Department>
        {
            new Department(1) { Name = "Художественная литература", Head = "Смирнова Е.В." },
            new Department(2) { Name = "Научная литература", Head = "Иванов П.С." },
            new Department(3) { Name = "Детская литература", Head = "Петрова А.И." },
            new Department(4) { Name = "Учебная литература", Head = "Соколов А.А." }
        };

        _editors = new List<Editor>
        {
            new Editor(1) { FullName = "Смирнова Е.В.", Experience = 15, Specialty = "Русская классика" },
            new Editor(2) { FullName = "Иванов П.С.", Experience = 8, Specialty = "Физика" },
            new Editor(3) { FullName = "Петрова А.И.", Experience = 12, Specialty = "Детские сказки" },
            new Editor(4) { FullName = "Кузнецов Д.М.", Experience = 5, Specialty = "История" },
            new Editor(5) { FullName = "Орлова М.Н.", Experience = 20, Specialty = "Химия" }
        };

        _editions = new List<Edition>
        {
            new Edition(1) { Title = "Тихий Дон", DepartmentId = 1, EditorId = 1, Pages = -600, Price = 1200m },
            new Edition(2) { Title = "Война и мир", DepartmentId = 1, EditorId = 1, Pages = 600, Price = 1800m },
            new Edition(3) { Title = "Преступление и наказание", DepartmentId = 1, EditorId = 4, Pages = 400, Price = 900m  },
            new Edition(4) { Title = "Курс физики", DepartmentId = 2, EditorId = 2, Pages = 350, Price = 1800m },
            new Edition(5) { Title = "Квантовая механика", DepartmentId = 2, EditorId = 2, Pages = 300, Price = 2000m },
            new Edition(6) { Title = "Общая химия", DepartmentId = 2, EditorId = 5, Pages = 500, Price = 1400m },
            new Edition(7) { Title = "Колобок", DepartmentId = 3, EditorId = 3, Pages = 50,  Price = 300m  },
            new Edition(8) { Title = "Сказки Пушкина", DepartmentId = 3, EditorId = 3, Pages = 100, Price = 500m  },
            new Edition(9) { Title = "История России", DepartmentId = 4, EditorId = 4, Pages = 300, Price = 1600m }
        };
    }

    /// <summary>Возвращает список отделов</summary>
    public List<Department> GetDepartments()
    {
        return _departments;
    }

    /// <summary>Возвращает список редакторов</summary>
    public List<Editor> GetEditors()
    {
        return _editors;
    }

    /// <summary>Возвращает список изданий</summary>
    public List<Edition> GetEditions()
    {
        return _editions;
    }
}