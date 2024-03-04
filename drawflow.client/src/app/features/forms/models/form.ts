import { Auditable } from '../../../shared/models/auditable';
import { FormTemplate } from './formTemplate';

export interface Form extends Auditable {
  id: number;
  name: string;
  description: string;
  formTemplates: FormTemplate[];
}
