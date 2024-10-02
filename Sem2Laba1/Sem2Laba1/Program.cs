using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

class Program
{
    static string connectionString = "Server=mysql-a845c7c-stud-eb5a.d.aivencloud.com;Port=10724;Database=ComputerPartsStore;User ID=avnadmin;Password=AVNS_G59dsEh50R5E2AXKRfj;SslMode=Required;";
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            // Виведення меню для користувача
            Console.WriteLine("\n--- Меню ---");
            Console.WriteLine("1 - Показати таблиці");
            Console.WriteLine("2 - Додавання рядків в таблицю");
            Console.WriteLine("3 - Об’єднанням таблиць");
            Console.WriteLine("4 - Фільтрація по імені");
            Console.WriteLine("5 - Агрегатні функції");
            Console.WriteLine("6 - Вихід");
            Console.Write("Оберіть дію (1-6): ");

            // Зчитування вибору користувача
            string input = Console.ReadLine();
            int choice;

            // Перевірка коректності введення
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Виклик функції для показу таблиць
                        ShowTables();
                        break;
                    case 2:
                        // Виклик підменю для додавання рядків
                        AddRowsMenu();
                        break;
                    case 3:
                        // Виклик функції для об'єднання таблиць
                        JoinTables();
                        break;
                    case 4:
                        // Виклик функції для фільтрації по імені
                        FilterByName();
                        break;
                    case 5:
                        // Виклик функції для агрегатних функцій
                        UseAggregateFunctions();
                        break;
                    case 6:
                        // Вихід з програми
                        exit = true;
                        Console.WriteLine("Вихід з програми...");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Невірний ввід. Будь ласка, введіть число від 1 до 6.");
            }
        }
    }

    static void ShowTables()
    {
        // Логіка для показу таблиць
        Console.WriteLine("Показуємо таблиці...");
        DisplayTable("Client");
        DisplayTable("DiscountCard");
        DisplayTable("Employee");
        DisplayTable("Director");
        DisplayTable("Warehouse");
        DisplayTable("Supplier");
        DisplayTable("Product");
        DisplayTable("Store");
        DisplayTable("DeliveryService");
        DisplayTable("PickupPoint");
        DisplayTable("Manufacturer");
        DisplayTable("StoreProduct");
        DisplayTable("DeliveryServiceProduct");
        DisplayTable("PickupPointEmployee");
        DisplayTable("`Order`");
    }

    static void AddRowsMenu()
    {
        // Підменю для вибору таблиці
        Console.WriteLine("\n--- Додавання рядків в таблицю ---");
        Console.WriteLine("1 - Client");
        Console.WriteLine("2 - Employee");
        Console.WriteLine("3 - Store");
        Console.WriteLine("4 - Product");
        Console.WriteLine("5 - Order");
        Console.Write("Оберіть таблицю (1-5): ");

        string input = Console.ReadLine();
        int tableChoice;

        if (int.TryParse(input, out tableChoice))
        {
            switch (tableChoice)
            {
                case 1:
                    AddRowToFirstTable();
                    break;
                case 2:
                    AddRowToSecondTable();
                    break;
                case 3:
                    AddRowToThirdTable();
                    break;
                case 4:
                    AddRowToFourthTable();
                    break;
                case 5:
                    AddRowToFithTable();
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Невірний ввід. Будь ласка, введіть число від 1 до 4.");
        }
    }

    static void AddRowToFirstTable()
    {
        // Логіка для додавання рядка до першої таблиці
        Console.WriteLine("Додаємо рядок до першої таблиці...");
        InsertIntoTable("Client", new Dictionary<string, string>
        {
           { "full_name", "Josh Doe" },
           { "phone_number", "1234567890" },
           { "email", "john.doe@example.com" },
           { "discount_card_number", "NULL" }
        });
    }

    static void AddRowToSecondTable()
    {
        // Логіка для додавання рядка до другої таблиці
        Console.WriteLine("Додаємо рядок до другої таблиці...");
        InsertIntoTable("Employee", new Dictionary<string, string>
        {
           { "full_name", "Michael Scott" },
           { "position", "Regional Manager" },
           { "phone_number", "321-654-9870" },
           { "passport_data", "AB123456" },
           { "gender", "Male" }
        });
    }

    static void AddRowToThirdTable()
    {
        // Логіка для додавання рядка до третьої таблиці
        Console.WriteLine("Додаємо рядок до третьої таблиці...");
        InsertIntoTable("Store", new Dictionary<string, string>
        {
           { "store_id", "1" },
           { "director_id", "1" }, // Замініть на реальний ID директора
           { "name", "Best Computer Parts" },
           { "address", "123 Tech Ave, Silicon Valley" },
           { "employee_count", "5" }
        });
    }

    static void AddRowToFourthTable()
    {
        // Логіка для додавання рядка до четвертої таблиці
        Console.WriteLine("Додаємо рядок до четвертої таблиці...");
        InsertIntoTable("Product", new Dictionary<string, string>
        {
           { "article", "2001" },
           { "supplier_id", "1" }, // Замініть на реальний ID постачальника
           { "name", "Gaming Mouse" },
           { "warehouse_id", "1" }, // Замініть на реальний номер складу
           {"price", "20.00" },
           {"description", "Gaming Mouse" }
        });
    }

    static void AddRowToFithTable()
    {
        Console.WriteLine("Додаємо рядок до п'ятої таблиці...");
        InsertIntoTable("`Order`", new Dictionary<string, string>
        {
           { "order_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
           { "order_amount", "150.00" },
           { "payment_method", "Credit Card" },
           { "client_id", "1" }, // Замініть на реальний ID клієнта
           { "delivery_method", "Standard Shipping" },
           { "responsible_employee_id", "1" } // Замініть на реальний ID співробітника
        });
    }
    static void JoinTables()
    {
        // Логіка для об'єднання таблиць
        Console.WriteLine("Об'єднуємо таблиці...");
        DisplayClientOrders();
    }

    static void FilterByName()
    {
        // Логіка для фільтрації по імені
        Console.WriteLine("Фільтруємо таблиці по імені...");
        FilterClientOrders("Alice Smith");
    }

    static void UseAggregateFunctions()
    {
        // Логіка для виконання агрегатних функцій
        Console.WriteLine("Виконуємо агрегатні функції...");
        DisplayTotalSales();
    }
    static void DisplayTable(string tableName)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = $"SELECT * FROM {tableName}";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"Data from {tableName}:");
                Console.WriteLine(new string('-', 50)); // Роздільник

                // Виводимо заголовки
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i),-20}"); // Вирівнювання заголовків
                }
                Console.WriteLine();
                Console.WriteLine(new string('+', 50)); // Роздільник

                // Виводимо рядки
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i],-20}"); // Вирівнювання даних
                    }
                    Console.WriteLine();
                }
                reader.Close();
                Console.WriteLine(new string('-', 50)); // Роздільник
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }


    static void InsertIntoTable(string tableName, Dictionary<string, string> columnValues)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string columns = string.Join(", ", columnValues.Keys);
                string values = string.Join(", ", columnValues.Values.Select(v => v == "NULL" ? "NULL" : $"'{v}'"));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                Console.WriteLine($"Data inserted into {tableName} successfully.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }


    static void DisplayClientOrders()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                // Запит з включенням id замовлення
                string query = @"
                SELECT `Order`.order_id, Client.full_name, `Order`.order_date, `Order`.order_amount 
                FROM Client
                JOIN `Order` ON Client.client_id = `Order`.client_id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Client Orders:");
                Console.WriteLine(new string('-', 70)); // Роздільник
                Console.WriteLine($"{"Order ID",-10}{"Client Name",-20}{"Order Date",-20}{"Order Amount",-15}");
                Console.WriteLine(new string('-', 70)); // Роздільник

                // Виводимо рядки з замовленнями
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["order_id"],-10}{reader["full_name"],-20}{reader["order_date"],-20}{reader["order_amount"],-15}");
                }

                reader.Close();
                Console.WriteLine(new string('-', 70)); // Роздільник
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }


    static void FilterClientOrders(string clientName)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                // Запит для фільтрації замовлень за іменем клієнта
                string query = @"
                SELECT `Order`.order_id, Client.full_name, `Order`.order_date, `Order`.order_amount 
                FROM Client
                JOIN `Order` ON Client.client_id = `Order`.client_id
                WHERE Client.full_name = @name";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", clientName);
                MySqlDataReader reader = cmd.ExecuteReader();

                // Виведення заголовка та таблиці з результатами
                Console.WriteLine($"Orders for {clientName}:");
                Console.WriteLine(new string('-', 70)); // Роздільник
                Console.WriteLine($"{"Order ID",-10}{"Client Name",-20}{"Order Date",-20}{"Order Amount",-15}");
                Console.WriteLine(new string('-', 70)); // Роздільник

                // Виведення результатів
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["order_id"],-10}{reader["full_name"],-20}{reader["order_date"],-20}{reader["order_amount"],-15}");
                }

                reader.Close();
                Console.WriteLine(new string('-', 70)); // Роздільник
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }


    static void DisplayTotalSales()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = "SELECT SUM(order_amount) FROM `Order`";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                Console.WriteLine($"Total Sales: {result}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}