using LinQ.Models;
using Newtonsoft.Json;


namespace LinQ.DAL
{
    public class Brand_Handler
    {
        static readonly string JSONPath = "D:\\Json\\Brands.JSON";

        /// <summary>
        /// Read Json file
        /// </summary>
        /// <returns>List of car</returns>
        /// <exception cref="Exception"></exception>
        public static List<Car> GetBrands()
        {            
            List<Car>? Cars = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(JSONPath));
            if (Cars != null)
            {
                Console.WriteLine("Cars from Json file");
                Console.WriteLine("-------------------");
                return Cars;
            }
            else
            {
                throw new Exception("LINQ.CODE.BRAND.HANDLER: No dummy cars");
            }
        }
        /// <summary>
        /// Write List of car to Json file
        /// </summary>
        public static void WriteBrandsToJSON()
        {
            try
            {                
                PrepareJsonFile();
                string Jstring = JsonConvert.SerializeObject(GetDummyCars());
                Console.WriteLine("Writing " + Jstring);
                Console.WriteLine("To " + JSONPath);
                File.WriteAllText(JSONPath, Jstring);
                Console.WriteLine($"Serialized and wrote objects to {JSONPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static List<Car> GetDummyCars()
        {
            List<Car> cars = new()
            {
                new Car { BrandName = "Ford", ModelName = "Escort", Year = 2000, Price = 1000.00 },
                new Car { BrandName = "Ford", ModelName = "Fiesta", Year = 2001, Price = 1250.00 },
                new Car { BrandName = "Ford", ModelName = "Ka", Year = 2000, Price = 900 },
                new Car { BrandName = "Opel", ModelName = "Mokka", Year = 2022, Price = 1000.00 },
                new Car { BrandName = "Opel", ModelName = "Kadet", Year = 1998, Price = 1250.00 },
                new Car { BrandName = "Opel", ModelName = "Corsa", Year = 1999, Price = 900 },
                new Car { BrandName = "Citroen", ModelName = "BX", Year = 2022, Price = 1000.00 },
                new Car { BrandName = "Citroen", ModelName = "XM", Year = 1998, Price = 1250.00 },
                new Car { BrandName = "Citroen", ModelName = "Saxo", Year = 1999, Price = 900 },
                new Car { BrandName = "Tesla", ModelName = "Model 3", Year = 2022, Price = 1000.00 },
                new Car { BrandName = "Tesla", ModelName = "Model X", Year = 2020, Price = 1250.00 },
                new Car { BrandName = "Tesla", ModelName = "Model Y", Year = 2019, Price = 9000 }
            };
            return cars;
        }

        private static void PrepareJsonFile()
        {
            // Check if the file exists
            if (File.Exists(JSONPath))
            {
                // Check if the file is open
                try
                {
                    using (FileStream fs = File.Open(JSONPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        Console.WriteLine("File is open. Closing it...");
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("File is not open.");
                }

                // Close and delete the file
                try
                {
                    File.Delete(JSONPath);
                    Console.WriteLine("File deleted.");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error deleting the file: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }

            // Create a new file
            try
            {
                using (File.Create(JSONPath)) { }
                Console.WriteLine("File created.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error creating the file: {e.Message}");
            }
        }
    }
}
