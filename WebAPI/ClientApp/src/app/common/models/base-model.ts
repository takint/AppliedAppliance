export interface BaseModel {
  created?: Date;
  createdBy?: string;
  lastModified?: Date;
  lastModifiedBy?: string;
  archived?: boolean;
  deleted?: boolean;
}
