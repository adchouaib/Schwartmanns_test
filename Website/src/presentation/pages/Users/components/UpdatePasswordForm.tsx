import { IUpdateUserPassword } from "@/domain/usecases/IUpdateUserPassword";
import {
  Box,
  Button,
  Dialog,
  DialogTitle,
  TextField,
  Typography,
} from "@mui/material";
import { Dispatch, SetStateAction } from "react";
import { SubmitHandler, useForm } from "react-hook-form";

type Props = {
  userId: string;
  updateUserPassword: IUpdateUserPassword;
  setActionPerformed: Dispatch<SetStateAction<boolean>>;
  setsnackBarOpen: Dispatch<SetStateAction<boolean>>;
  setMessage: Dispatch<SetStateAction<string>>;
  handleClose: () => void;
  open: boolean;
};

interface IFormInput {
  currentPassword: string;
  newPassword: string;
}

const UpdatePasswordForm: React.FC<Props> = ({
  userId,
  updateUserPassword,
  setActionPerformed,
  setsnackBarOpen,
  setMessage,
  handleClose,
  open,
}) => {
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<IFormInput>();

  const onSubmit: SubmitHandler<IFormInput> = async (data, event) => {
    event?.preventDefault();
    try {
      console.log(data);
      const res = await updateUserPassword.updatePass({
        id: userId,
        currentPassword: data.currentPassword,
        newPassword: data.newPassword,
      });
      handleClose();
      setActionPerformed(res);
      setMessage("user password updated");
      setsnackBarOpen(true);
    } catch (error) {
      console.log(error);
    }
  };

  const handleFormClick: React.MouseEventHandler<HTMLFormElement> = (event) => {
    event.stopPropagation();
  };

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Update User Password</DialogTitle>
      <Box
        component="form"
        onSubmit={handleSubmit(onSubmit)}
        noValidate
        sx={{ margin: 2 }}
        onClick={handleFormClick}
      >
        <TextField
          margin="normal"
          required
          fullWidth
          label="Current Password"
          type="password"
          id="currentPassword"
          autoComplete="current-password"
          {...register("currentPassword", {
            required: "currentPassword is required",
          })}
        />
        {errors.currentPassword && (
          <Typography
            component="span"
            color={"red"}
            sx={{
              fontFamily: "Lexend Deca, sans-serif",
              fontSize: 12,
            }}
          >
            {errors.currentPassword.message}
          </Typography>
        )}
        <TextField
          margin="normal"
          required
          fullWidth
          label="New Password"
          type="password"
          id="newPassword"
          autoComplete="new-password"
          {...register("newPassword", {
            required: "New Password is required",
            minLength: {
              value: 8,
              message: "Password must be contain at least 8 characters",
            },
            validate: (value) => {
              return (
                [/[a-z]/, /[A-Z]/, /[0-9]/, /[^a-zA-Z0-9]/].every((pattern) =>
                  pattern.test(value)
                ) ||
                "Password must include lower, upper, number, and special chars"
              );
            },
          })}
        />
        {errors.newPassword && (
          <Typography
            component="span"
            color={"red"}
            sx={{
              fontFamily: "Lexend Deca, sans-serif",
              fontSize: 12,
            }}
          >
            {errors.newPassword.message}
          </Typography>
        )}
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Update Password
        </Button>
      </Box>
    </Dialog>
  );
};

export default UpdatePasswordForm;
