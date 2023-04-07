import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie';
import { MovieApiService } from '../movie-api.service';
import { Director } from '../director';


@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  movies: Movie[] = [];
  directors: Director[] = [];

  constructor(private movieService: MovieApiService
    ) { }

  ngOnInit(): void {
    this.movieService.getMovies().subscribe(movies => this.movies = movies);
    this.movieService.getDirectors().subscribe(directors => this.directors = directors);
  }

  deleteMovie(id: number): void {
    this.movieService.deleteMovie(id).subscribe({
      next: () => {
        // Remove the deleted movie from the movies array
        this.movies = this.movies.filter(movie => movie.id !== id);
        alert("Successfully deleted the movie")
      },
      error: error => {
        console.error('Error deleting movie:', error);
        alert('Error deleting movie');
      }
    });
  }

  


  
}
