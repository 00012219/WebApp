import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from './movie';
import { Director } from './director';

@Injectable({
  providedIn: 'root'
})
export class MovieApiService {
  private movieApiUrl = 'https://localhost:44382/movies';
  private directorApiUrl = 'https://localhost:44382/directors';

  constructor(private http: HttpClient) { }

  getMovieById(id: string): Observable<Movie> {
    return this.http.get<Movie>(`${this.movieApiUrl}/${id}`);
  }

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.movieApiUrl);
  }

  createMovie(newMovie: any): Observable<any> {
    return this.http.post(`${this.movieApiUrl}`, newMovie);
  }

  deleteMovie(id: number): Observable<{}> {
    const url = `${this.movieApiUrl}/${id}`;
    return this.http.delete(url);
  }

  updateMovie(movie: Movie) {
    const url = `${this.movieApiUrl}/${movie.id}`;
    return this.http.put<Movie>(url, movie);
  }


  getDirectorById(id: string): Observable<Director> {
    return this.http.get<Director>(`${this.directorApiUrl}/${id}`);
  }

  getDirectors(): Observable<Director[]> {
    return this.http.get<Director[]>(this.directorApiUrl);
  }

  createDirector(newDirector: Director): Observable<any> {
    return this.http.post(`${this.directorApiUrl}`, newDirector);
  }

  deleteDirector(id: number): Observable<{}> {
    const url = `${this.directorApiUrl}/${id}`;
    return this.http.delete(url);
  }

  updateDirector(director: Director) {
    const url = `${this.directorApiUrl}/${director.id}`;
    return this.http.put<Director>(url, director);
  }


  assignDirectorToMovie(movieId: any, directorId: any): Observable<any> {
    const url = `${this.movieApiUrl}/${movieId}/directors/${directorId}`;
    console.log(url);
    return this.http.post(url, {});
  }
  



}
