import { Director } from "./director";

export interface Movie {
    id: number;
    title: string;
    releaseDate: string;
    directors: Director[];
    genre: string;
  }