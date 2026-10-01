namespace PrintingHouse;

public class Department
{         
    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Название отдела уник
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Заведующий отделом
    /// </summary>
    public string Head { get; set; }

    /// <summary>
    /// Является ли отдел художественной литературой
    /// </summary>
    public bool IsFiction
    {
        get { return Name == "Художественная литература"; }
    }

    /// <summary>
    /// Строковое представление отдела
    /// </summary>
    public string GetInfo()
    {
        return Name + " (зав.: " + Head + ")";
    }
    public Department(int id)
    {
        Id = id;
    }
}
