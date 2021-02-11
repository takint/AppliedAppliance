
export interface LoginViewModel {
  email: string;
  password: string;
  rememberMe: boolean;
}

export interface UserModel {
  id: string;
  accessFailedCount: number;
  userName: string;
  email: string;
  emailConfirmed: boolean;
  password: string;
  passwordConfirmed: string;
  lockoutEnabled: boolean;
  phoneNumber: string;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
}

export interface UserViewModel {
  user: UserModel;
}
