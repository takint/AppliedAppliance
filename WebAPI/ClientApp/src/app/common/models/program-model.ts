import { BaseModel } from "./base-model";

export interface ProgramModel extends BaseModel {
  id: number,
  schoolId: number,
  programCategoryId: number,
  brandId: number,
  leadProgramId: number,
  eaTemplateId: number,
  additionalDocumentId: number,
  programName: string,
  programLevel: number,
  startDate: Date,
  programLength: number,
  province: string,
  hasLeadIntegration: boolean
}

export interface ProgramFormViewModel {
  program: ProgramModel;
}
