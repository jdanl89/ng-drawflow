namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations;

#nullable disable

public abstract class Auditable
{
    [Required]
    [MaxLength(200)]
    public string CreatedAt { get; set; }

    [Required]
    [MaxLength(200)]
    public string CreatedBy { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [MaxLength(200)]
    public string LastModAt { get; set; }

    [MaxLength(200)]
    public string LastModBy { get; set; }

    public DateTime? LastModOn { get; set; }

    [MaxLength(200)]
    public string DeletedAt { get; set; }

    [MaxLength(200)]
    public string DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    [Required]
    public EntityStatus Status { get; set; } = EntityStatus.Active;
}
