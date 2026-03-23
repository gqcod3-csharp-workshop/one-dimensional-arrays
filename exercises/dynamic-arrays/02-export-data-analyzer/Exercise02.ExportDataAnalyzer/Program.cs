namespace Exercise02.ExportDataAnalyzer
{
    public class ProductoExportacion
    {
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Producto { get; set; }
        public int Anio { get; set; }
        public decimal Monto { get; set; }
        public double Peso { get; set; }

        public ProductoExportacion(string pais, string region, string producto, int anio, decimal monto, double peso)
        {
            Pais = pais;
            Region = region;
            Producto = producto;
            Anio = anio;
            Monto = monto;
            Peso = peso;
        }

        public override string ToString()
        {
            return $"{Pais}, {Region}, {Producto}, {Anio}, ${Monto:N2}, {Peso}MT";
        }
    }

    class Program
    {
        static void Main()
        {
            List<ProductoExportacion> productos;

            string csvPath = "../ProductosExportacion.csv";
            
            if (File.Exists(csvPath))
            {
                Console.WriteLine($"\nLoading data from: {csvPath}\n");
                productos = CargarDatosDesdeCSV(csvPath);
            }
            else
            {
                Console.WriteLine("CSV file not found. Using sample data.\n");
                productos = GenerarDatosMuestra();
            }

            Console.WriteLine($"Loaded {productos.Count} records\n");

            MostrarTotalPorPais(productos);
            MostrarProductoLider2024(productos);
            MostrarConteoNorteamerica(productos);
            MostrarPromedioCentroamerica(productos);
        }

        static List<ProductoExportacion> GenerarDatosMuestra()
        {
            return new List<ProductoExportacion>
            {
                new ProductoExportacion("México", "Norteamérica", "Electrónicos", 2024, 150000m, 45.5),
                new ProductoExportacion("Estados Unidos", "Norteamérica", "Textiles", 2024, 200000m, 120.0),
                new ProductoExportacion("Canadá", "Norteamérica", "Alimentos", 2023, 180000m, 300.0),
                new ProductoExportacion("Guatemala", "Centroamérica", "Café", 2024, 80000m, 50.0),
                new ProductoExportacion("Costa Rica", "Centroamérica", "Frutas", 2024, 95000m, 75.0),
                new ProductoExportacion("México", "Norteamérica", "Automotriz", 2024, 300000m, 500.0),
                new ProductoExportacion("Panamá", "Centroamérica", "Banano", 2023, 60000m, 100.0),
                new ProductoExportacion("Estados Unidos", "Norteamérica", "Tecnología", 2023, 250000m, 80.0),
                new ProductoExportacion("Honduras", "Centroamérica", "Textiles", 2024, 45000m, 60.0),
                new ProductoExportacion("Canadá", "Norteamérica", "Minería", 2024, 400000m, 800.0)
            };
        }

        static List<ProductoExportacion> CargarDatosDesdeCSV(string filePath)
        {
            List<ProductoExportacion> productos = new List<ProductoExportacion>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string? line = sr.ReadLine(); 

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 6)
                        {
                            string pais = values[0].Trim();
                            string region = values[1].Trim();
                            string producto = values[2].Trim();

                            if (int.TryParse(values[3].Trim(), out int anio) &&
                                decimal.TryParse(values[4].Trim(), out decimal monto) &&
                                double.TryParse(values[5].Trim(), out double peso))
                            {
                                productos.Add(new ProductoExportacion(pais, region, producto, anio, monto, peso));
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return productos;
        }

        static void MostrarTotalPorPais(List<ProductoExportacion> productos)
        {
            var totalesPorPais = productos
                .GroupBy(p => p.Pais)
                .Select(g => new
                {
                    Pais = g.Key,
                    Total = g.Sum(p => p.Monto)
                })
                .OrderByDescending(x => x.Total);

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("1. Total Export Amount by Country:");
            Console.WriteLine(new string('=', 50));

            foreach (var item in totalesPorPais)
            {
                Console.WriteLine($"   {item.Pais,-20} ${item.Total:N2}");
            }
        }

        static void MostrarProductoLider2024(List<ProductoExportacion> productos)
        {
            var productoLider = productos
                .Where(p => p.Anio == 2024)
                .GroupBy(p => p.Producto)
                .Select(g => new
                {
                    Producto = g.Key,
                    Total = g.Sum(p => p.Monto)
                })
                .OrderByDescending(x => x.Total)
                .FirstOrDefault();

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("2. Leading Product in 2024 (by Revenue):");
            Console.WriteLine(new string('=', 50));

            if (productoLider != null)
            {
                Console.WriteLine($"   Product: {productoLider.Producto}");
                Console.WriteLine($"   Total Amount: ${productoLider.Total:N2}");
            }
            else
            {
                Console.WriteLine("   No data available for 2024");
            }
        }

        static void MostrarConteoNorteamerica(List<ProductoExportacion> productos)
        {
            var conteoPorAnio = productos
                .Where(p => p.Region == "Norteamérica")
                .GroupBy(p => p.Anio)
                .Select(g => new
                {
                    Anio = g.Key,
                    Cantidad = g.Count()
                })
                .OrderBy(x => x.Anio);

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("3. Annual Product Count in North America:");
            Console.WriteLine(new string('=', 50));

            foreach (var item in conteoPorAnio)
            {
                Console.WriteLine($"   {item.Anio}: {item.Cantidad} product(s)");
            }
        }

        static void MostrarPromedioCentroamerica(List<ProductoExportacion> productos)
        {
            var productosCentro = productos
                .Where(p => p.Region == "Centroamérica")
                .ToList();

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("4. Average Weight in Central America:");
            Console.WriteLine(new string('=', 50));

            if (productosCentro.Count > 0)
            {
                double promedio = productosCentro.Average(p => p.Peso);
                Console.WriteLine($"   Average: {promedio:F2} metric tons");
                Console.WriteLine($"   Total products: {productosCentro.Count}");
            }
            else
            {
                Console.WriteLine("   No data available for Central America");
            }
        }
    }
}
