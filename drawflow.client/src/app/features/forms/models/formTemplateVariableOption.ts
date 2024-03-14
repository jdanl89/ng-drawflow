import { Auditable } from '../../../shared/models/auditable';
import { FormTemplate } from './formTemplate';

export interface FormTemplateVariableOption extends Auditable {
  id: number;
  value: string;
  formTemplateVariableId: number;
}
