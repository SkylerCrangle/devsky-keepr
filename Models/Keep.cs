namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string UserId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public string Img { get; set; }
    public bool IsPrivate { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }

  }
  public class VaultKeepViewModel : Keep
  {
    public int VaultKeepId { get; set; }
  }


  // NOTE for Many-To-Many Table
  public class VaultKeep
  {
    public int Id { get; set; }
    public int KeepId { get; set; }
    public int VaultId { get; set; }
    public string UserId { get; set; }
  }



}