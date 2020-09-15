import { HomeFood } from "@/models/interfaces/HomeFood.ts";
import { FoodType } from "@/models/enums/FoodType";
export const foodItemsService = { getFoodByType };

const backendUrl = process.env.VUE_APP_VERYDELI_API_URL_BASE;

async function getFoodByType(foodType: FoodType): Promise<Array<HomeFood>> {
  const requestOptions: RequestInit = {
    method: "GET",
    headers: { "Content-Type": "application/json", credentials: "include" },
  };
  //TODO fetch.then(check response status)
  const response = (await (
    await fetch(`${backendUrl}/Food/Type=${foodType}`, requestOptions)
  ).json()) as Promise<Array<HomeFood>>;

  return response;
}
