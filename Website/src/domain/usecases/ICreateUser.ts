export interface ICreateUser {
  create: (params: CreateUserRequest) => Promise<boolean>;
}

export type CreateUserRequest = {
  name: string;
  email: string;
  password: string;
  type: UserType;
};

export enum UserType {
  ADMIN = 0,
  USER = 1,
}
