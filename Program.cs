using LinQ.DAL;
using LinQ.Models;

class Program
{
    static void Main(string[] args)
    {
        bool ending = false;
        try
        {
            while (!ending)
            {
                Console.WriteLine();
                Console.WriteLine("press 1 for regenerate dummy data");
                Console.WriteLine("press 2 to try your linq query");
                Console.WriteLine("press 9 to end program");
                Console.Write("Enter option: ");
                string input = Console.ReadLine();
                
                if (input == "1")
                {

                    Console.Clear();
                    Console.WriteLine("regenerating data");

                    Brand_Handler.WriteBrandsToJSON();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    //Getbrands
                    List<Car> cars = Brand_Handler.GetBrands();

                    //// Alle opel auto's
                    //var brandsFilter = cars.Where(b => b.BrandName == "Opel").OrderByDescending(b => b.ModelName);

                    //// Alle ford auto's
                    //var brandsFilter = cars.Where(b => b.BrandName == "Ford");

                    //// Alle auto's van citroen of tesla gesorteerd op Model
                    //var brandsFilter = cars.Where(b => b.BrandName == "Tesla" || b.BrandName == "Citroen").OrderBy(b => b.ModelName);
                    //OF ALS:
                    var brandsFilter = (from car in cars
                                        where car.BrandName == "Tesla" || car.BrandName == "Citroen"
                                        orderby car.ModelName
                                        select car);//.ToList();


                    //// Een merk auto's sorteren op prijs van hoog naar laag en daarbinnen op Model van laag naar hoog
                    //var brandsFilter = cars.OrderByDescending(b => b.Price).ThenBy(b=> b.ModelName);
                    //OF ALS:
                    //var brandsFilter = (from car in cars
                    //                    orderby car.Price descending, car.BrandName
                    //                    select car);//.ToList();

                    foreach (Car C in brandsFilter)
                    {
                        Console.WriteLine($"Model auto: {C.ModelName, -10} - Prijs: {C.Price, 5}");
                    }
                    Console.WriteLine("========= End of linq query =========");
                }
                else if (input == "9") 
                {
                    ending = true;
                }
                else
                {
                    Console.Clear();             
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }
}