using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal object Get(string userId)
    {
      return _repo.Get(userId);
    }

    internal object Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal object Delete(int id, string userId)
    {
      Vault found = GetSingleVault(id);
      if (found.UserId != userId)
      {
        throw new Exception("Invalid Request");
      }
      if (_repo.Delete(id))
      {
        return found;
      }
      throw new Exception("Something went terribly wrong");
    }

    internal Vault GetSingleVault(int id)
    {
      Vault found = _repo.GetSingleVault(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
  }
}