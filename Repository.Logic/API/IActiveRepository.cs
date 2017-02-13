using DomainModel;

namespace TIRepository.API
{
    public interface IActiveDataRepository<in T>
    {
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}