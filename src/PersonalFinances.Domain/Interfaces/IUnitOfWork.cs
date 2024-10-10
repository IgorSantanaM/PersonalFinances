using PersonalFinances.Domain.Commands;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        CommandResponse Commit();
    }
}
