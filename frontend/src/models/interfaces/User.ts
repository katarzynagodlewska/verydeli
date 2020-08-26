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

export { UserRegisterModel, UserLoginModel };
