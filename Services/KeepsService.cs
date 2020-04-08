using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    internal IEnumerable<Keep> GetMyKeeps(string userId)
    {
      return _repo.GetMyKeeps(userId);
    }

    internal Keep Get(int id)
    {
      //NOTE If you do not null check you could get a 204 (No Context) if the blog was not found
      Keep found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }





    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal object Delete(int id, string userId)
    {
      Keep found = Get(id);
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

    internal object Edit(Keep updatedKeep)
    {
      Keep found = Get(updatedKeep.Id);
      if (found.UserId != updatedKeep.UserId)
      {
        throw new Exception("Invalid Request");
      }
      found.Name = updatedKeep.Name;
      found.Description = updatedKeep.Description != null ? updatedKeep.Description : found.Description;
      found.Keeps = updatedKeep.Keeps;
      return _repo.Edit(found);
    }

    internal object GetKeepsByVaultId(int id)
    {
      return _repo.GetByVaultId(id);
    }
  }
}