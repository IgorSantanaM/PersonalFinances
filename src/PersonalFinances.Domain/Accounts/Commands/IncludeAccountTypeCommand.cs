namespace PersonalFinances.Domain.Accounts.Commands
{
    public class IncludeAccountTypeCommand : BaseAccountTypeCommand
    {
        public IncludeAccountTypeCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}