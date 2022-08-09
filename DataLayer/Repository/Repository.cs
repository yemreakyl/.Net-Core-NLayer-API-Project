using CoreLayer.EntityModels;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Customer> _customer;
        private readonly DbSet<Chart> _chart;
        public Repository(AppDbContext context)
        {
            _context = context;
            _customer = context.Set<Customer>();
            _chart = context.Set<Chart>();

        }
        public static string GenerateRandomString(int num)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[num];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
        public static List<Product> GetProducts(int num)
        {
            var products = new List<Product>();

            for (int k = 0; k < num; k++)
            {
                var random = new Random();
                var price = random.Next(100, 1000);
                var product = new Product { Price = price };
                products.Add(product);
            }
            return products;
        }

        public async Task AddChart(Chart entity)
        {
            await _chart.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<Customer> AddCustomer(Customer entity)
        {
             await _context.AddAsync(entity);
             _context.SaveChanges();
            return await _customer.FindAsync(entity.Id);    
        }
       
        public async Task CreateTestData(int sepetAdet, int musteriAdet)
        {
            var cities = new List<string>(){"Ankara","İstanbul","Konya", "Diyarbakır", "Edirne", "Rize", "Antalya", "İzmir", "Bursa", "Van" };
            var id = new List<int>();
           
            var random = new Random();
            int num; 

            for (int k = 0; k < musteriAdet; k++)
            {
                var name = GenerateRandomString(5);
                var surname = GenerateRandomString(5);
                int number = random.Next(0, 10);
                var customer = new Customer { Name = name, Surname = surname, City = cities[number] };

                var response=await AddCustomer(customer);
                id.Add(response.Id);
            }           
            for (int m = 0; m < sepetAdet; m++)
            {
                var products = GetProducts(5);
                num = random.Next(0, musteriAdet);
                var chart = new Chart { CustomerId = id[num], Products = products };
                foreach(var product in chart.Products)
                {
                    product.ChartId=chart.Id;
                }
                
                await AddChart(chart);
            }
        }

    }

}
