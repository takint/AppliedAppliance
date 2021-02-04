import { BaseModel } from "./base-model";

export interface AgentModel extends BaseModel {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  companyName: string;
  mainSourceStudent: string;
  approved: boolean;
  manager: number;
}

export interface AgentFormViewModel {
  agent: AgentModel;
}
