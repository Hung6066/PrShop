using PrShop.Common;
using PrShop.Data.Infrastructure;
using PrShop.Data.Repositories;
using PrShop.Model.Models;

namespace ProShop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerReponsitory;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerResponsitory, IUnitOfWork unitOfWork)
        {
            _footerReponsitory = footerResponsitory;
            _unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerReponsitory.GetSingleByCondition(x=>x.ID== CommonConstants.DefaultFooterId);
        }
    }
}