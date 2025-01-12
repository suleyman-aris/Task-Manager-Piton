using System.Text.Json.Serialization;
using TaskManager.Entities.Abstract;

namespace TaskManager.Entities.Concrete;

public class User : BaseEntity, IEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}