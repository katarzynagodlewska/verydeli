interface UserRegisterModel {
  name: string;
  surname: string;
  email: string;
  password: string;
}

interface UserLoginModel {
  email: string;
  password: string;
}

interface UserLoginResponseModel {
  statusCode: number;
  token: string;
  message: string;
}

export { UserRegisterModel, UserLoginModel, UserLoginResponseModel };
