using PersonalFinances.Domain.Accounts.Commands;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        CommandResponse Commit();
    }
}
