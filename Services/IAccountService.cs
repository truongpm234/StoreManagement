using BusinessObject;

namespace Services
{
    public interface IAccountService
    {
        AccountMember GetAccountById(string id);
    }
}