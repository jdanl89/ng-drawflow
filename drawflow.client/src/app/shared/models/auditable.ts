import { EntityStatus } from './entityStatus';

export interface Auditable {
  createdAt: string | undefined | null;
  createdBy: string | undefined | null;
  createdOn: Date | undefined | null;
  lastModAt: string | undefined | null;
  lastModBy: string | undefined | null;
  lastModOn: Date | undefined | null;
  deletedAt: string | undefined | null;
  deletedBy: string | undefined | null;
  deletedOn: Date | undefined | null;
  status: EntityStatus | undefined | null;
}
