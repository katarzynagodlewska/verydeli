interface Food {
  title: string;
  price: number;
  id: string;
}

interface CartFood extends Food {
  image?: ImageBitmap;
}

interface HomeFood extends CartFood {
  description: string;
}

export { HomeFood, Food, CartFood };
