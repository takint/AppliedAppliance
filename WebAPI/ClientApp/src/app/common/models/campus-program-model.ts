import { BaseModel } from "./base-model";

export interface CampusProgramModel extends BaseModel {
  id: number,
  campusId: number,
  programId: number,
  startDate: Date,
  domTuition: number,
  intlTuition: number
}

export interface CampusProgramFormViewModel {
  campusProgram: CampusProgramModel;
}
