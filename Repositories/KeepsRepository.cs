using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"
            INSERT INTO keeps 
            (name, description, userId, img, isPrivate, views, shares, keeps) 
            VALUES 
            (@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID()";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);

      return KeepData;
    }

    internal Keep Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { Id = id });

    }

    internal IEnumerable<Keep> GetMyKeeps(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @UserId";
      return _db.Query<Keep>(sql, new { userId });
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { id });
      return removed == 1;
    }

    internal object Edit(Keep updatedKeep)
    {
      string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @IsPrivate,
            views = @Views,
            shares = @Shares,
            keeps = @Keeps
            WHERE id = @Id
            ";
      _db.Execute(sql, updatedKeep);
      return updatedKeep;
    }

    internal object GetByVaultId(int VaultId)
    {
      string sql = @"
                SELECT 
                k.*,
                kt.id AS VaultKeepId
                FROM vaultkeeps kt
                INNER JOIN keeps k ON k.id = kt.keepId
                WHERE vaultId = @VaultId AND isPrivate = 0";
      return _db.Query<VaultKeepViewModel>(sql, new { VaultId });
    }
  }
}