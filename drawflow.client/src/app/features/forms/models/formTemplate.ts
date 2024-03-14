import { Auditable } from '../../../shared/models/auditable';
import { FormTemplateVariable } from './formTemplateVariable';

export interface FormTemplate extends Auditable {
  id: number;
  name: string;
  description: string;
  fileLocation: string;
  formId: number;
  formTemplateVariables: FormTemplateVariable[];
}
