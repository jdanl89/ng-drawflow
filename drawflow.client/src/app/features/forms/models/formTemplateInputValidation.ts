import { Auditable } from '../../../shared/models/auditable';
import { InputValidationType } from './inputValidationType';

export interface FormTemplateInputValidation extends Auditable {
  id: number;
  formTemplateInputId: number;
  validationType: InputValidationType;
  validationLimit: string;
  prereqValidationType: InputValidationType | null;
  prereqValidationLimit: string | null;
  prereqValidationId: number | null;
}
