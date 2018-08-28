namespace PrShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}