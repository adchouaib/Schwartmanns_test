export class InvalidCredentialsError extends Error {
  constructor() {
    super("Invalid Credentials");
    this.name = "Invalid Credentials Error";
  }
}
