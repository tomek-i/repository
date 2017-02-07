namespace TIRepository.API
{
    public interface IActiveDataRepository<in T> where T : class
    {
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}