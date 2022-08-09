using CoreLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface IRepository
    {
        Task<Customer> AddCustomer(Customer entity);
        Task AddChart(Chart entity);
        Task CreateTestData(int sepetAdet, int musteriAdet);
    }
}
