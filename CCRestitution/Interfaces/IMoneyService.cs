using CCRestitution.Services;

namespace CCRestitution.Interfaces
{
    public interface IMoneyService
    {
        Task<List<MoneyAccountInfo>> GetAccountInfo(int AccountId);
        Task<List<MoneyDTO>?> GetCVAF(int AccountId);
        Task<List<MoneyDTO>?> GetDWI(int AccountId);
        Task<List<MoneyDTO>?> GetFine(int AccountId);
        Task<List<MoneyDTO>?> GetMandatorySurcharge(int AccountId);
        Task<List<MoneyDTO>?> GetMisc(int AccountId);
        Task<List<MoneyDTO>?> GetRestitution(int AccountId);
        Task<List<MoneyDTO>?> GetSurcharge(int AccountId);
        Task setValue(int id, MoneyUpdateObject update);
    }
}
