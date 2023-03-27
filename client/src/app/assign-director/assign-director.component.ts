import { MovieApiService } from './../movie-api.service';
import { Component, OnInit } from '@angular/core';
import { Director } from '../director';
import { Movie } from '../movie';

@Component({
  selector: 'app-assign-director',
  templateUrl: './assign-director.component.html',
  styleUrls: ['./assign-director.component.css']
})
export class AssignDirectorComponent implements OnInit {
  movies: Movie[] = [];
  directors: Director[] = [];
  selectedMovie: Movie = {} as Movie;
  selectedDirector: Director = {} as Director;

  constructor(private movieService: MovieApiService) {
  }

  ngOnInit() {
    this.movieService.getMovies().subscribe(movies => this.movies = movies);
    this.movieService.getDirectors().subscribe(directors => this.directors = directors);
  }

  onSubmit() {
    const movieId = this.selectedMovie.id;
    const directorId = this.selectedDirector.id;
    this.movieService.assignDirectorToMovie(movieId, directorId).subscribe({
      next: (response) => console.log('Response:', response),
      error: (error) => console.log('Error:', error)
    });
  }
}
