import { BaseModel } from "./base-model";

export interface SchoolModel extends BaseModel {
  id: number;
  schoolName: string;
  email: string;
  countryCode: string;
  applicationFee: number;
  hasLeadIntegration: boolean;
  ieltSlisten: number;
  ieltSread: number;
  ieltSwrite: number;
  ieltSspeak: number;
  pgwp: string;
}

export interface SchoolFormViewModel {
  school: SchoolModel;
}
