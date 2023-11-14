using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZehirZikkim.Infrastructure.Persistence.EFCore.Models;



public class BaseModel {

    [Key, Column(Order = 0)]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; } = DateTime.UtcNow;
}