import { BaseModel } from "./base-model";

export interface DocumentModel extends BaseModel {
  id: number,
  name: string,
  type: string,
  group: string
}

export interface DocumentFormViewModel {
  document: DocumentModel;
}
