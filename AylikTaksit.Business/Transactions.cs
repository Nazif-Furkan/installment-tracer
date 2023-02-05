using AutoMapper;
using AylikTaksit.Api.Models.Transaction;
using AylikTaksit.DataAccess;

namespace AylikTaksit.Business;

public class TransactionsBll : IDisposable
{
    private Mapper mapper;
    public TransactionsBll()
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
            cfg.CreateMap<AddTransactionRequest,Transaction >()
        );
        mapper = new Mapper(config);
    }
    private AylikTaksitDbContext _dbContext = new AylikTaksitDbContext();
    public IEnumerable<Transaction> GetTransactions()
    {
        return _dbContext.Transactions;
    }

    public int AddTransaction(AddTransactionRequest transaction)
    {
        var t =  mapper.Map<Transaction>(transaction);
        var entity = _dbContext.Add(t);
        _dbContext.SaveChanges();
        
        return t.Id;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}

public class PaymentAccountBll : IDisposable
{
    private AylikTaksitDbContext _dbContext = new AylikTaksitDbContext();
    public IEnumerable<PaymentAccount> GetAllAccounts()
    {
        return _dbContext.PaymentAccounts;
    }

    public bool AddTransaction(PaymentAccount account)
    {
        _dbContext.Add(account);
        _dbContext.SaveChanges();
        return true;
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}