using System.Collections.Generic;
using System.Linq;

namespace Exercise01.ProductInventoryManager
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }

        public Producto(int id, string nombre, int stock)
        {
            ID = id;
            Nombre = nombre;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Nombre}, Stock: {Stock}";
        }
    }

    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            if (productos.Any(p => p.ID == producto.ID))
            {
                Console.WriteLine($"Error: Product with ID {producto.ID} already exists");
                return;
            }

            productos.Add(producto);
            Console.WriteLine($"Product added: {producto.Nombre} (ID: {producto.ID})");
        }

        public Producto? BuscarPorID(int id)
        {
            return productos.FirstOrDefault(p => p.ID == id);
        }

        public void MostrarInventario()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("\n=== Current Inventory (sorted by ID) ===");
            var productosOrdenados = productos.OrderBy(p => p.ID);

            foreach (var producto in productosOrdenados)
            {
                Console.WriteLine(producto);
            }
        }

        public int ObtenerCantidad()
        {
            return productos.Count;
        }
    }

    class Program
    {
        static void Main()
        {
            Inventario inventario = new Inventario();

            Console.WriteLine("=== Product Inventory Manager ===\n");

            inventario.AgregarProducto(new Producto(105, "Laptop", 15));
            inventario.AgregarProducto(new Producto(102, "Mouse", 50));
            inventario.AgregarProducto(new Producto(108, "Keyboard", 30));
            inventario.AgregarProducto(new Producto(101, "Monitor", 20));

            Console.WriteLine($"\nTotal products in inventory: {inventario.ObtenerCantidad()}");

            inventario.MostrarInventario();

            Console.WriteLine("\n=== Search Test ===");
            Console.Write("Enter Product ID to search: ");
            int searchID;
            
            if (int.TryParse(Console.ReadLine(), out searchID))
            {
                Producto? found = inventario.BuscarPorID(searchID);
                
                if (found != null)
                {
                    Console.WriteLine($"\nProduct Found - {found}");
                }
                else
                {
                    Console.WriteLine($"\nProduct with ID {searchID} not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
