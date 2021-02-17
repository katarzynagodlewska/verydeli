import { Food } from "@/models/interfaces/Food.ts";
const backendUrl = process.env.VUE_APP_VERYDELI_API_URL_BASE;

export const searchService = { getItemsForSearch };

async function getItemsForSearch(
    searchText: string
  ): Promise<Array<Food>> {
    // const requestOptions: RequestInit = {
    //   method: "GET",
    //   headers: { "Content-Type": "application/json", credentials: "include" },
    // };
  
    // const response = (await (
    //   await fetch(`${backendUrl}search/searchItem?searchText = ${searchText}`, requestOptions)
    // ).json()) as Promise<Array<Food>> ;
  
    // return response;
   let items : Array<Food> = [
    { title: "Pancakes with strawberries", price: 26, id: "111" },
    { title: "Pancakes with strawberries", price: 29, id: "112" },
    { title: "Pancakes with strawberries", price: 17, id: "113" },
    { title: "English breakfast", price: 25, id: "114" },
    { title: "Pizza pepperoni", price: 19, id: "115" },
  ];
    return new Promise<Array<Food>>((resolve) => {
        return resolve(items);
    });
  }