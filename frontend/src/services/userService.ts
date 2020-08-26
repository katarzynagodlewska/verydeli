import {
  UserLoginModel,
  UserRegisterModel,
  UserLoginResponseModel,
} from "@/models/interfaces/User.ts";

export const userService = { login, register };

const backendUrl = process.env.VUE_APP_VERYDELI_API_URL_BASE;

async function login(
  userData: UserLoginModel
): Promise<UserLoginResponseModel> {
  const requestOptions: RequestInit = {
    method: "POST",
    body: JSON.stringify({
      login: userData.email,
      password: userData.password,
    }),
    headers: { "Content-Type": "application/json", credentials: "include" },
  };

  const response = (await (
    await fetch(`${backendUrl}/User/login`, requestOptions)
  ).json()) as Promise<UserLoginResponseModel>;

  return response;
}

async function register(
  userData: UserRegisterModel
): Promise<UserLoginResponseModel> {
  const requestOptions: RequestInit = {
    method: "POST",
    body: JSON.stringify({
      login: userData.email,
      password: userData.password,
      surname: userData.surname,
      firstname: userData.name,
    }),
    headers: { "Content-Type": "application/json", credentials: "include" },
  };

  const response = (await (
    await fetch(`${backendUrl}/User/register`, requestOptions)
  ).json()) as Promise<UserLoginResponseModel>;

  return response;
}
