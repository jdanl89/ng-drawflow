namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

public class FormTemplateVariableValidation : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [ForeignKey("FormTemplateVariable")]
    public long FormTemplateVariableId { get; set; }
    public virtual FormTemplateVariable FormTemplateVariable { get; set; }

    [Required]
    public InputValidationType ValidationType { get; set; }

    public string? ValidationLimit { get; set; }

    public InputValidationType? PrereqValidationType { get; set; }

    public string? PrereqValidationLimit { get; set; }

    [ForeignKey("PrereqValidation")]
    public long? PrereqValidationId { get; set; }
    public FormTemplateVariableValidation? PrereqValidation { get; set; }
}