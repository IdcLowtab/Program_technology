/// <summary>
/// Редактор изданий
/// </summary>
public class Editor
{
    /// <summary>
    /// Идентификатор редактора
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// ФИО редактора (не уникально)
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Стаж работы (в годах)
    /// </summary>
    public int Experience { get; set; }

    /// <summary>
    /// Специальность редактора
    /// </summary>
    public string Specialty { get; set; }

    /// <summary>
    /// Является ли редактор старшим (стаж больше 10 лет)
    /// </summary>
    public bool IsSenior
    {
        get 
        { 
            return Experience > 10; 
        }
    }

    /// <summary>
    /// Строковое представление редактора
    /// </summary>
    public string GetInfo()
    {
        return FullName + " (" + Experience + " лет опыта)";
    }
    public Editor(int id)
    {
        Id = id;
    }
}