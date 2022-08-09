using CoreLayer.IUnitOfWork;
using CoreLayer.Repositories;
using CoreLayer.Services;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository _repo;

        public Service(IUnitOfWork unitOfWork, IRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public async Task CreateTestData(int musteriAdet, int sepetAdet)
        {
            await _repo.CreateTestData(musteriAdet, sepetAdet);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
