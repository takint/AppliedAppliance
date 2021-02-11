import { BaseModel } from "./base-model";

export interface SchoolDocumentModel extends BaseModel{
  id: number,
  schoolId: number,
  documentId: number,
  document: {
    name: string,
    group: string,
  },
  type: string, 
  isRequired: boolean,
  description: string,
  preTemplate: string
}


export interface SchoolDocumentFormViewModel {
  schoolDocument: SchoolDocumentModel;
}
