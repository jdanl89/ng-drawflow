namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

public class FormTemplateVariable : Auditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [ForeignKey("FormTemplate")]
    public long FormTemplateId { get; set; }
    public virtual FormTemplate FormTemplate { get; set; }

    public string Key { get; set; }

    public HtmlDataType HtmlDataType { get; set; }

    public JavaDataType JavaDataType { get; set; }

    public virtual ICollection<FormTemplateVariableOption> Options { get; set; }
    public virtual ICollection<FormTemplateVariableValidation> Validations { get; set; }
}