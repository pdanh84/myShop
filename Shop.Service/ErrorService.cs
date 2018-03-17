using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public interface IErrorService
    {
        Error Add(Error error);

        void Update(Error error);

        Error Delete(int id);

        IEnumerable<Error> GetAll();

        void Save();
    }
    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }

        public Error Add(Error error)
        {
            return _errorRepository.Add(error);
        }

        public Error Delete(int id)
        {
            return _errorRepository.Delete(id);
        }

        public IEnumerable<Error> GetAll()
        {
            return _errorRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Error error)
        {
            _errorRepository.Update(error);
        }
    }
}
