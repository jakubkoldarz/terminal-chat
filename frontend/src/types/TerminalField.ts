export interface TerminalField {
  name: string;
  validationPattern: RegExp;
  errorMessage: string;
  isPassword?: boolean;
}
