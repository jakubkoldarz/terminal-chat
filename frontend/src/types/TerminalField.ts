export interface TerminalField {
  name: string;
  label?: string;
  validationPattern: RegExp;
  errorMessage: string;
  isPassword?: boolean;
}
