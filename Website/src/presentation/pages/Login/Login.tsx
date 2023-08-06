import { useForm, SubmitHandler } from "react-hook-form";
import { IAuthenticate } from "@/domain/usecases/IAuthenticate";
import React, { useEffect, useState } from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { useHistory } from "react-router-dom";
import { Account } from "../../../domain/models/Account";
import { getCurrentAccount } from "../../../main/adapters/currentAccountAdapter";
import { useSetRecoilState } from "recoil";
import { AccountState } from "../../../presentation/components/Atoms";

type Props = {
  Authentication: IAuthenticate;
  SetCurrentAccount: (account: Account) => void;
};

interface IFormInput {
  email: string;
  password: string;
}

const Login: React.FC<Props> = ({ Authentication, SetCurrentAccount }) => {
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<IFormInput>();
  const [error, setError] = useState(null);
  const navigate = useHistory();
  const setAccountState = useSetRecoilState(AccountState);

  useEffect(() => {
    if (getCurrentAccount()) {
      navigate.replace("/");
    }
  });

  const onSubmit: SubmitHandler<IFormInput> = async (data) => {
    try {
      const account = await Authentication.auth({
        email: data.email,
        password: data.password,
      });
      setAccountState(account);
      SetCurrentAccount(account);
      navigate.push("/home");
    } catch (error) {
      setError(error.message);
    }
  };

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <Box
        sx={{
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography
          component="h1"
          variant="h5"
          sx={{
            fontFamily: "Lexend Deca, sans-serif",
          }}
        >
          Sign in
        </Typography>
        <Box
          component="form"
          onSubmit={handleSubmit(onSubmit)}
          noValidate
          sx={{ mt: 1 }}
        >
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

          {error && (
            <Typography
              component="span"
              color={"red"}
              sx={{
                fontFamily: "Lexend Deca, sans-serif",
                fontSize: 12,
              }}
            >
              {error}
            </Typography>
          )}
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign In
          </Button>
          <Grid container>
            <Grid item xs>
              <Link href="#" variant="body2">
                Forgot password?
              </Link>
            </Grid>
            <Grid item>
              <Link href="#" variant="body2">
                {"Don't have an account? Sign Up"}
              </Link>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
};

export default Login;
