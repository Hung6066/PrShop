using ProShop.Data.Repositories;
using PrShop.Data.Infrastructure;
using PrShop.Model.Models;
using System;

namespace ProShop.Service
{
    public interface IContactDetailService
    {
        ContactDetail GetDefaultContact();
    }

    public class ContactDetailService : IContactDetailService
    {
        private IContactDetailRepository _contactDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ContactDetailService(IContactDetailRepository contactDetailRepository, IUnitOfWork unitOfWork)
        {
            _contactDetailRepository = contactDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public ContactDetail GetDefaultContact()
        {
            return _contactDetailRepository.GetSingleByCondition(x=>x.Status);
        }
    }
}