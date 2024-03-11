namespace Drawflow.Server.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#nullable disable

public class FormTemplateInput : Auditable
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

    public virtual ICollection<FormTemplateInputOption> Option { get; set; }
    public virtual ICollection<FormTemplateInputValidation> Validations { get; set; }
}