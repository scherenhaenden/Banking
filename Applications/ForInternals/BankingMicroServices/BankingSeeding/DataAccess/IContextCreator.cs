using Microsoft.EntityFrameworkCore;

namespace BankingSeeding.DataAccess;

public interface IContextCreator<T> where T : DbContext

{
    T CreateContext(string connectionString);

    void DisposeContext(T context);
}