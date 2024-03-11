namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

public class FormTemplateInputOption : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string Value { get; set; }

    [Required]
    [ForeignKey("FormTemplateInput")]
    public long FormTemplateInputId { get; set; }
    public virtual FormTemplateInput FormTemplateInput { get; set; }
}