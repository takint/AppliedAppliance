import { BaseModel } from "./base-model";

export interface CampusModel extends BaseModel {
  id: number,
  campusName: string,
  address: string,
  city: string,
  province: string,
  postalCode: string,
  phone: string,
  ext: string,
  processingFee: number,
  schoolId: number,
  brandId: number,
  submissionCode: number,
  leadCampusId: number,
  hasLeadIntegration: boolean
}

export interface CampusFormViewModel {
  campus: CampusModel;
}
