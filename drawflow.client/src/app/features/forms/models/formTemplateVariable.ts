import { Auditable } from '../../../shared/models/auditable';
import { FormTemplateVariableOption } from './formTemplateVariableOption';
import { FormTemplateVariableValidation } from './formTemplateVariableValidation';
import { HtmlDataType } from './htmlDataType';
import { JavaDataType } from './javaDataType';

export interface FormTemplateVariable extends Auditable {
  id: number;
  formTemplateId: number;
  key: string;
  htmlDataType: HtmlDataType;
  javaDataType: JavaDataType;
  options: FormTemplateVariableOption[];
  validations: FormTemplateVariableValidation[];
}
