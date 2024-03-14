import { Auditable } from '../../../shared/models/auditable';
import { InputValidationType } from './inputValidationType';

export interface FormTemplateVariableValidation extends Auditable {
  id: number;
  formTemplateVariableId: number;
  validationType: InputValidationType;
  validationLimit: string;
  prereqValidationType: InputValidationType | null;
  prereqValidationLimit: string | null;
  prereqValidationId: number | null;
}
