using PrShop.Common;
using PrShop.Data.Infrastructure;
using PrShop.Data.Repositories;
using PrShop.Model.Models;
using System.Collections.Generic;
using System;

namespace ProShop.Service
{
   
    public interface ICommonService
    {
        IEnumerable<Slide> GetSlides();
        Footer GetFooter();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerReponsitory;
        private IUnitOfWork _unitOfWork;
        private ISlideRepository _slideReponsitory;

        public CommonService(IFooterRepository footerResponsitory, IUnitOfWork unitOfWork, ISlideRepository slideReponsitory)
        {
            _footerReponsitory = footerResponsitory;
            _unitOfWork = unitOfWork;
            _slideReponsitory = slideReponsitory;
        }

        public Footer GetFooter()
        {
            return _footerReponsitory.GetSingleByCondition(x=>x.ID== CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideReponsitory.GetMulti(x => x.Status);
        }
    }
}