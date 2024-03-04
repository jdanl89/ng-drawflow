import { Auditable } from '../../../shared/models/auditable';

export interface FormTemplate extends Auditable {
  id: number;
  name: string;
  description: string;
  fileLocation: string;
  formId: number;
}
