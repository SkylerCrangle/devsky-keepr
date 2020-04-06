using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsKeepsService
  {
    private readonly VaultsKeepsRepository _repo;
    public VaultsKeepsService(VaultsKeepsRepository repo)
    {
      _repo = repo;
    }
    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }

    internal VaultKeep Delete(int id, string UserId)
    {
      VaultKeep found = _repo.Get(id);
      if (found.UserId != UserId)
      {
        throw new UnauthorizedAccessException("Invalid Request");
      }
      if (_repo.Delete(id))
      {
        return found;
      }
      throw new Exception("Something went terribly wrong");
    }
  }
}