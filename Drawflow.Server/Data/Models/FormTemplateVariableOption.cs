namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

public class FormTemplateVariableOption : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string Value { get; set; }

    [Required]
    [ForeignKey("FormTemplateVariable")]
    public long FormTemplateVariableId { get; set; }
    public virtual FormTemplateVariable FormTemplateVariable { get; set; }
}