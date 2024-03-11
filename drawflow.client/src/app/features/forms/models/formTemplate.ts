import { Auditable } from '../../../shared/models/auditable';
import { FormTemplateInput } from './formTemplateInput';

export interface FormTemplate extends Auditable {
  id: number;
  name: string;
  description: string;
  fileLocation: string;
  formId: number;
  formTemplateInputs: FormTemplateInput[];
}
