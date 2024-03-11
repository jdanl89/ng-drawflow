import { Auditable } from '../../../shared/models/auditable';
import { FormTemplateInputOption } from './formTemplateInputOption';
import { FormTemplateInputValidation } from './formTemplateInputValidation';
import { HtmlDataType } from './htmlDataType';
import { JavaDataType } from './javaDataType';

export interface FormTemplateInput extends Auditable {
  id: number;
  formTemplateId: number;
  key: string;
  htmlDataType: HtmlDataType;
  javaDataType: JavaDataType;
  options: FormTemplateInputOption[];
  validations: FormTemplateInputValidation[];
}
