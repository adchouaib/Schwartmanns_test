import * as React from "react";
import Snackbar from "@mui/material/Snackbar";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";

type Props = {
  open: boolean;
  setOpen: React.Dispatch<React.SetStateAction<boolean>>;
  setMessage: React.Dispatch<React.SetStateAction<string>>;
  message: string;
};

const SnackBar: React.FC<Props> = ({ open, setOpen, setMessage, message }) => {
  const handleClose = (reason?: string) => {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
    setMessage("");
  };

  const action = (
    <React.Fragment>
      <IconButton
        size="small"
        aria-label="close"
        color="inherit"
        onClick={() => handleClose()}
      >
        <CloseIcon fontSize="small" />
      </IconButton>
    </React.Fragment>
  );

  return (
    <div>
      {message != null && (
        <Snackbar
          open={open}
          autoHideDuration={2000}
          onClose={() => handleClose()}
          message={message}
          action={action}
        />
      )}
    </div>
  );
};

export default SnackBar;
