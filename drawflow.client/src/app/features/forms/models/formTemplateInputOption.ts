import { Auditable } from '../../../shared/models/auditable';
import { FormTemplate } from './formTemplate';

export interface FormTemplateInputOption extends Auditable {
  id: number;
  value: string;
  formTemplateInputId: number;
}
