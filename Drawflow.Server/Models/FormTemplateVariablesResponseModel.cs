namespace Drawflow.Server.Models;

using global::Drawflow.Server.Data.Models;

public class FormTemplateVariablesResponseModel
{
    public FormTemplateVariablesResponseModel()
    { }

    public FormTemplateVariablesResponseModel(IEnumerable<string> foundVariables, IEnumerable<FormTemplateVariable> knownVariables)
    {
        HashSet<string> _knownVariableKeys = new(StringComparer.OrdinalIgnoreCase);

        foreach (FormTemplateVariable _variable in knownVariables)
        {
            _knownVariableKeys.Add(_variable.Key);
            this.KnownVariables.Add(new(_variable));
        }

        foreach (string _variable in foundVariables)
        {
            if (!_knownVariableKeys.Contains(_variable))
            {
                this.NewVariables.Add(_variable);
            }
        }
    }

    public List<string> NewVariables { get; set; } = [];
    public List<FormTemplateVariableResponseModel> KnownVariables { get; set; } = [];

    public class FormTemplateVariableResponseModel
    {
        public FormTemplateVariableResponseModel()
        { }

        public FormTemplateVariableResponseModel(FormTemplateVariable variable)
        {
            this.Id = variable.Id;
            this.Key = variable.Key;
            this.HtmlDataType = variable.HtmlDataType;
            this.JavaDataType = variable.JavaDataType;
            this.Options = variable.Options.Select(o => new FormTemplateVariableOptionResponseModel(o));
            this.Validations = variable.Validations.Select(v => new FormTemplateVariableValidationResponseModel(v));
        }

        public long Id { get; set; }
        public string? Key { get; set; }
        public HtmlDataType HtmlDataType { get; set; }
        public JavaDataType JavaDataType { get; set; }
        public IEnumerable<FormTemplateVariableOptionResponseModel> Options { get; set; } = [];
        public IEnumerable<FormTemplateVariableValidationResponseModel> Validations { get; set; } = [];

        public class FormTemplateVariableOptionResponseModel
        {
            public FormTemplateVariableOptionResponseModel()
            { }

            public FormTemplateVariableOptionResponseModel(FormTemplateVariableOption option)
            {
                this.Id = option.Id;
                this.Value = option.Value;
            }

            public long Id { get; set; }
            public string? Value { get; set; }
        }

        public class FormTemplateVariableValidationResponseModel
        {
            public FormTemplateVariableValidationResponseModel()
            { }

            public FormTemplateVariableValidationResponseModel(FormTemplateVariableValidation validation)
            {
                this.Id = validation.Id;
                this.ValidationType = validation.ValidationType;
                this.ValidationLimit = validation.ValidationLimit;
                this.PrereqValidationId = validation.PrereqValidationId;
                this.PrereqValidationType = validation.PrereqValidationType;
                this.PrereqValidationLimit = validation.PrereqValidationLimit;
            }

            public long Id { get; set; }
            public InputValidationType ValidationType { get; set; }
            public string? ValidationLimit { get; set; }
            public long? PrereqValidationId { get; set; }
            public InputValidationType? PrereqValidationType { get; set; }
            public string? PrereqValidationLimit { get; set; }
        }
    }
}
