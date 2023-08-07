export interface IDeleteUser {
  delete: (params: DeleteUserRequest) => Promise<boolean>;
}

export type DeleteUserRequest = {
  id: string;
};
