import { BaseModel } from "./base-model";

export interface ProgramCategoryModel extends BaseModel {
  id: number;
  name: string;
  description: string;
}

export interface ProgramCategoryFormViewModel {
  programCategory: ProgramCategoryModel;
}
