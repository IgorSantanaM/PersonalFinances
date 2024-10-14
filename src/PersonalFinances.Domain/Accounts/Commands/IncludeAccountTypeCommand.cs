namespace PersonalFinances.Domain.Account.Commands
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