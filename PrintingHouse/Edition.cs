namespace PrintingHouse;

public class Edition
{
    /// <summary>
    /// Идентификатор издания
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Название издания уник
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Идентификатор отдела 
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// Идентификатор редактора 
    /// </summary>
    public int EditorId { get; set; }

    /// <summary>
    /// Количество страниц
    /// </summary>
    private int _pages;

    public int Pages
    {
        get { return _pages; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_pages), "Amount of withdrawal must be positive");
            }
            else
            {
                _pages = value;
            }
        }
    }

    /// <summary>
    /// Цена издания (руб.)
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Является ли издание толстым
    /// </summary>
    public bool IsThick
    {
        get
        {
            return Pages > 500;
        }
    }

    /// <summary>
    /// Цена за одну страницу
    /// </summary>
    public decimal PricePerPage
    {
        get
        {
            if (Pages == 0) return 0m;
            return Price / Pages;
        }
    }

    /// <summary>
    /// Строковое представление издания
    /// </summary>
    public string GetInfo()
    {
        return Title + " (" + Pages + " стр., " + Price + " руб.)";
    }
    public Edition(int id)
    {
        Id = id;
    }
}
