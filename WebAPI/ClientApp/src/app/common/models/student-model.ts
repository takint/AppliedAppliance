import { BaseModel } from "./base-model";

export interface StudentModel extends BaseModel {
  id: number;
  studentCode: string;
  firstName: string;
  lastName: string;
  middleName: string;
  email: string;
  agentId: number;
}

export interface StudentFormViewModel {
  student: StudentModel;
}
