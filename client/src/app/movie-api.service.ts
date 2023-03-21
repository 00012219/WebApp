import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from './movie';

@Injectable({
  providedIn: 'root'
})
export class MovieApiService {
  private apiUrl = 'https://localhost:44382/movies';

  constructor(private http: HttpClient) { }

  getMovieById(id: string): Observable<Movie> {
    return this.http.get<Movie>(`${this.apiUrl}/${id}`);
  }

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.apiUrl);
  }

  createMovie(newMovie: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, newMovie);
  }

  deleteMovie(id: number): Observable<{}> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }

  updateMovie(movie: Movie) {
    const url = `${this.apiUrl}/${movie.id}`;
    console.log("movie object => title:" +  movie.title + " director:" + movie.director + " genre:" + movie.genre + " ");
    return this.http.put<Movie>(url, movie);
  }


}
