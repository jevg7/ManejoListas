using System;
using System.IO;

  public struct Product
{
    public double Id;
    public string Name;
    public double Price;
    public double Quantity; 

    public Product(double id, string name, double price, double quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

public class Program
{
    private const string Inventario = "Inventario.txt";

    public static void Main()
    {
        
        string opcion;
        do
        {
            Console.WriteLine("Bienvenido al sistema de inventario");
            Console.WriteLine("1. Mostrar productos");
            Console.WriteLine("2. Agregar producto");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Seleccione una opción:");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ShowProduct();
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    AddProduct();
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    UpdateProduct();
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    DeleteProduct();
                    Console.WriteLine("Presione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    Console.WriteLine("Gracias por usar el sistema de inventario");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        } while (opcion != "5");
    }

    public static void ShowProduct()
    {
        if (File.Exists(Inventario))
        {
            List<Product> products = new List<Product>(); 

            using (BinaryReader reader = new BinaryReader(File.Open(Inventario, FileMode.Open)))
            {
                try
                {
                    while (true)
                    {
                        Product product = new Product();
                        product.Id = reader.ReadDouble();
                        product.Name = reader.ReadString();
                        product.Price = reader.ReadDouble();
                        product.Quantity = reader.ReadDouble();
                        products.Add(product);
                    }
                }
                catch (EndOfStreamException)
                {
                    reader.Close();
                }
            }

            foreach (Product product in products)
            {
                Console.WriteLine($"ID: {product.Id}");
                Console.WriteLine($"Nombre: {product.Name}");
                Console.WriteLine($"Precio: {product.Price}");
                Console.WriteLine($"Cantidad: {product.Quantity}");
                Console.WriteLine();
            }
        }
    }

    public static void AddProduct()
    {
        Console.WriteLine("Ingrese el ID del producto:");
        double id = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Ingrese el nombre del producto:");
        string name = Console.ReadLine();
        Console.WriteLine("Ingrese el precio del producto:");
        double price = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Ingrese la cantidad del producto:");
        double quantity = Convert.ToDouble(Console.ReadLine());

        Product product = new Product(id, name, price, quantity);

        using (BinaryWriter writer = new BinaryWriter(File.Open(Inventario, FileMode.Append)))
        {
            writer.Write(product.Id);
            writer.Write(product.Name);
            writer.Write(product.Price);
            writer.Write(product.Quantity);
        }
    }

    public static void UpdateProduct()
    {
        Console.WriteLine("Ingrese el ID del producto a actualizar:");
        double id = Convert.ToDouble(Console.ReadLine());

        using (BinaryReader reader = new BinaryReader(File.Open(Inventario, FileMode.Open)))
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("temp.txt", FileMode.Create)))
            {
                try
                {
                    while (true)
                    {
                        Product product = new Product();
                        product.Id = reader.ReadDouble();
                        product.Name = reader.ReadString();
                        product.Price = reader.ReadDouble();
                        product.Quantity = reader.ReadDouble();

                        if (product.Id == id)
                        {
                            Console.WriteLine("Ingrese el nuevo nombre del producto:");
                            product.Name = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo precio del producto:");
                            product.Price = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Ingrese la nueva cantidad del producto:");
                            product.Quantity = Convert.ToDouble(Console.ReadLine());
                        }

                        writer.Write(product.Id);
                        writer.Write(product.Name);
                        writer.Write(product.Price);
                        writer.Write(product.Quantity);
                    }
                }
                catch (EndOfStreamException)
                {
                    reader.Close();
                    writer.Close();
                }
            }
        }
    }

    public static void DeleteProduct()
    {
        Console.WriteLine("Ingrese el ID del producto a eliminar:");
        double id = Convert.ToDouble(Console.ReadLine());

        using (BinaryReader reader = new BinaryReader(File.Open(Inventario, FileMode.Open)))
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("temp.txt", FileMode.Create)))
            {
                try
                {
                    while (true)
                    {
                        Product product = new Product();
                        product.Id = reader.ReadDouble();
                        product.Name = reader.ReadString();
                        product.Price = reader.ReadDouble();
                        product.Quantity = reader.ReadDouble();

                        if (product.Id != id)
                        {
                            writer.Write(product.Id);
                            writer.Write(product.Name);
                            writer.Write(product.Price);
                            writer.Write(product.Quantity);
                        }
                    }
                }
                catch (EndOfStreamException)
                {
                    reader.Close();
                    writer.Close();
                }
            }
        }

        File.Delete(Inventario);
        File.Move("temp.txt", Inventario);
    }
}









