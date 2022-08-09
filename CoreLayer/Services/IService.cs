using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface IService
    {
        
        Task CreateTestData(int sepetAdet, int musteriAdet);
    }
}
