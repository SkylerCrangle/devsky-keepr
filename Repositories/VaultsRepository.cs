using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal object Get(string userId)
    {
      string sql = "SELECT * FROM Vaults WHERE userId = @UserId;";
      return _db.Query<Vault>(sql, new { userId });
    }

    internal object Create(Vault newVault)
    {
      string sql = @"
            INSERT INTO vaults 
            (name, description, userId) 
            VALUES 
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID()";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);

      return newVault;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { id });
      return removed == 1;
    }

    internal Vault GetSingleVault(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { Id = id });
    }
  }
}