interface HomeFood extends Food {
  description: string;
  image: ImageBitmap;
}

interface Food {
  title: string;
  price: number;
  id: string;
}

export { HomeFood, Food };
