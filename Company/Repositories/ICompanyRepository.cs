namespace Company.Repositories
{
    public interface ICompanyRepository<TEntity>
    {
        IList<TEntity> getAll();
        TEntity get(int id);
        void Create(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
    }
}
