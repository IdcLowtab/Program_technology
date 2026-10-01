namespace PrintingHouse
{
    /// <summary>
    /// Главный класс программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Находит редактора издания по названию
        /// Если издание или редактор не найдены — возвращает null
        /// </summary>
        static Editor FindEditor(List<Edition> editions, List<Editor> editors, string title)
        {
            Edition found = null;
            for (int i = 0; i < editions.Count; i++)
            {
                if (editions[i].Title == title)
                {
                    found = editions[i];
                    break;
                }
            }

            if (found == null) return null;

            for (int i = 0; i < editors.Count; i++)
            {
                if (editors[i].Id == found.EditorId)
                {
                    return editors[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Находит отдел издания
        /// Если отдел не найден — возвращает null
        /// </summary>
        static Department FindDepartment(List<Department> departments, Edition edition)
        {
            if (edition == null) return null;

            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Id == edition.DepartmentId)
                {
                    return departments[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Суммарное число страниц всех изданий
        /// Для пустого списка возвращает 0
        /// </summary>
        static int GetTotalPages(List<Edition>? editions)
        {
            if (editions is null) return 0;
            int total = 0;
            for (int i = 0; i < editions.Count; i++)
            {
                total += editions[i].Pages;
            }
            return total;
        }

        /// <summary>
        /// Редактор с максимальным суммарным числом страниц
        /// При равенстве — первый в списке редакторов
        /// Если изданий нет - возвращает null
        /// </summary>
        static Editor GetEditorWithMostPages(List<Edition> editions, List<Editor> editors)
        {
            if (editions is null || editions.Count == 0) return null;
            if (editors is null || editors.Count == 0) return null;

            int bestEditorId = -1;
            int bestTotal = -1;

            for (int i = 0; i < editors.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < editions.Count; j++)
                {
                    if (editions[j].EditorId == editors[i].Id)
                    {
                        sum += editions[j].Pages;
                    }
                }
                if (sum > bestTotal)
                {
                    bestTotal = sum;
                    bestEditorId = editors[i].Id;
                }
            }

            if (bestEditorId == -1) return null;

            for (int i = 0; i < editors.Count; i++)
            {
                if (editors[i].Id == bestEditorId)
                {
                    return editors[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Сумма страниц конкретного редактора
        /// </summary>
        static int GetPagesByEditor(List<Edition> editions, int editorId)
        {
            int total = 0;
            for (int i = 0; i < editions.Count; i++)
            {
                if (editions[i].EditorId == editorId)
                {
                    total += editions[i].Pages;
                }
            }
            return total;
        }

        /// <summary>
        /// Выводит все издания с указанием редактора и отдела.
        /// Если связанный объект не найден — выводится "—".
        /// </summary>
        static void PrintAllEditions(List<Edition> editions, List<Editor> editors, List<Department> departments)
        {
            if (editions == null || editors == null || departments == null) return;
            for (int i = 0; i < editions.Count; i++)
            {
                Edition e = editions[i];
                Editor editor = null;
                for (int j = 0; j < editors.Count; j++)
                {
                    if (editors[j].Id == e.EditorId)
                    {
                        editor = editors[j];
                        break;
                    }
                }

                Department dep = null;
                for (int j = 0; j < departments.Count; j++)
                {
                    if (departments[j].Id == e.DepartmentId)
                    {
                        dep = departments[j];
                        break;
                    }
                }
                string editorName = editor != null ? editor.FullName : "—";
                string depName = dep != null ? dep.Name : "—";
                Console.WriteLine("\"" + e.GetInfo() + "\" - редактор " + editorName + ", отдел \"" + depName + "\"");
            }
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static internal void Main()
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - InMemory");
            Console.WriteLine("2 - CSV");
            Console.Write("Ваш выбор: ");

            int choice = int.Parse(Console.ReadLine());

            List<Department> departments;
            List<Editor> editors;
            List<Edition> editions;
            try
            {
                switch (choice)
                {
                    case 1:



                        InMemoryRepository mem = new InMemoryRepository();
                        departments = mem.GetDepartments();
                        editors = mem.GetEditors();
                        editions = mem.GetEditions();
                        break;

                    case 2:

                        CsvRepository csv = new CsvRepository("data");
                        departments = csv.GetDepartments();
                        editors = csv.GetEditors();
                        editions = csv.GetEditions();

                        break;

                    default:
                        Console.WriteLine("Неверный выбор");
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Файл не найден: " + ex.Message);
                return;
            }
            Console.WriteLine();

            Editor editor = FindEditor(editions, editors, "Тихий Дон");
            if (editor != null)
                Console.WriteLine("1. FindEditor(\"Тихий Дон\"): " + editor.GetInfo());
            else
                Console.WriteLine("1. FindEditor(\"Тихий Дон\"): null");

            Edition target = null;
            for (int i = 0; i < editions.Count; i++)
            {
                if (editions[i].Title == "Тихий Дон")
                {
                    target = editions[i];
                    break;
                }
            }

            Department dep = FindDepartment(departments, target);
            if (dep != null)
                Console.WriteLine("2. FindDepartment(edition \"Тихий Дон\"): " + dep.GetInfo());
            else
                Console.WriteLine("2. FindDepartment(edition \"Тихий Дон\"): null");
            Console.WriteLine();

            Console.WriteLine("3. GetTotalPages: " + GetTotalPages(editions));

            Editor top = GetEditorWithMostPages(editions, editors);
            if (top != null)
            {
                int topPages = GetPagesByEditor(editions, top.Id);
                Console.WriteLine("4. GetEditorWithMostPages: " + top.FullName + " (" + topPages + ")");
            }
            else
            {
                Console.WriteLine("4. GetEditorWithMostPages: null");
            }

            Console.WriteLine("5. PrintAllEditions:");
            PrintAllEditions(editions, editors, departments);

            Console.WriteLine();
            Editor missing = FindEditor(editions, editors, "Неизвестное издание");
            if (missing != null)
                Console.WriteLine("Не найдено: FindEditor(\"Неизвестное издание\") -> " + missing.GetInfo());
            else
                Console.WriteLine("Не найдено: FindEditor(\"Неизвестное издание\") -> null");
        }
    }
}