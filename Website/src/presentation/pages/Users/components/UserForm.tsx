import { ICreateUser, UserType } from "@/domain/usecases";
import {
  Box,
  Button,
  Dialog,
  DialogTitle,
  MenuItem,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { Dispatch, SetStateAction } from "react";
import { SubmitHandler, useForm } from "react-hook-form";

type Props = {
  createUser: ICreateUser;
  setActionPerformed: Dispatch<SetStateAction<boolean>>;
  setsnackBarOpen: Dispatch<SetStateAction<boolean>>;
  setMessage: Dispatch<SetStateAction<string>>;
  handleClose: () => void;
  open: boolean;
};

interface IFormInput {
  name: string;
  email: string;
  password: string;
  type: UserType;
}

const UserForm: React.FC<Props> = ({
  createUser,
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
      const res = await createUser.create({
        email: data.email,
        name: data.email,
        password: data.password,
        type: data.type,
      });
      handleClose();
      setActionPerformed(res);

      setMessage("item added");
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
      <DialogTitle>Create User</DialogTitle>
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
          id="name"
          label="Name"
          autoComplete="name"
          autoFocus
          {...register("name", {
            required: "Name is required",
            minLength: {
              value: 3,
              message: "Name must be contain at least 3 characters",
            },
          })}
          aria-invalid="true"
        />
        {errors.name && (
          <Typography
            component="span"
            color={"red"}
            sx={{
              fontFamily: "Lexend Deca, sans-serif",
              fontSize: 12,
            }}
          >
            {errors.name.message}
          </Typography>
        )}
        <TextField
          margin="normal"
          required
          fullWidth
          id="email"
          label="Email Address"
          autoComplete="email"
          autoFocus
          {...register("email", {
            required: "Email is required",
            pattern: {
              value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i,
              message: "invalid Email address",
            },
          })}
          aria-invalid="grammar"
        />
        {errors.email && (
          <Typography
            component="span"
            color={"red"}
            sx={{
              fontFamily: "Lexend Deca, sans-serif",
              fontSize: 12,
            }}
          >
            {errors.email.message}
          </Typography>
        )}
        <TextField
          margin="normal"
          required
          fullWidth
          label="Password"
          type="password"
          id="password"
          autoComplete="current-password"
          {...register("password", {
            required: "Password is required",
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
        {errors.password && (
          <Typography
            component="span"
            color={"red"}
            sx={{
              fontFamily: "Lexend Deca, sans-serif",
              fontSize: 12,
            }}
          >
            {errors.password.message}
          </Typography>
        )}
        <Select
          label="User Type"
          fullWidth
          defaultValue={UserType.USER} // Set a default value if needed
          {...register("type")}
        >
          <MenuItem value={UserType.USER} selected>
            User
          </MenuItem>
          <MenuItem value={UserType.ADMIN}>Admin</MenuItem>
        </Select>
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Create
        </Button>
      </Box>
    </Dialog>
  );
};

export default UserForm;
