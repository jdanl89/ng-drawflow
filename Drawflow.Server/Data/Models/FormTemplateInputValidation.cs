namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

public class FormTemplateInputValidation : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [ForeignKey("FormTemplateInput")]
    public long FormTemplateInputId { get; set; }
    public virtual FormTemplateInput FormTemplateInput { get; set; }

    [Required]
    public InputValidationType ValidationType { get; set; }

    public string ValidationLimit { get; set; }

    public InputValidationType? PrereqValidationType { get; set; }

    public string? PrereqValidationLimit { get; set; }

    [ForeignKey("PrereqValidation")]
    public long? PrereqValidationId { get; set; }
    public FormTemplateInputValidation? PrereqValidation { get; set; }
}