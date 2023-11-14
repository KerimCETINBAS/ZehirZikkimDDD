using Microsoft.EntityFrameworkCore;

namespace ZehirZikkim.Infrastructure.Persistence.EFCore.Models;

[Owned]
public class ImageUrlModel {
    
    public required string Src { get; set; }

    public required  string Alt { get; set; }
}