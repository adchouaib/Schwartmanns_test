export interface IUpdateUserPassword {
  updatePass: (params: UpdateUserPasswordRequest) => Promise<boolean>;
}

export type UpdateUserPasswordRequest = {
  id: string;
  currentPassword: string;
  newPassword: string;
};
