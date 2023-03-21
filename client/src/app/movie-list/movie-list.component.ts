import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie';
import { MovieApiService } from '../movie-api.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  movies: Movie[] = [];

  constructor(private movieService: MovieApiService,
    private toastr: ToastrService
    ) { }

  ngOnInit(): void {
    this.movieService.getMovies().subscribe(movies => this.movies = movies);
  }

  deleteMovie(id: number): void {
    this.movieService.deleteMovie(id).subscribe({
      next: () => {
        // Remove the deleted movie from the movies array
        this.movies = this.movies.filter(movie => movie.id !== id);
      },
      error: error => {
        console.error('Error deleting movie:', error);
        this.toastr.error('Error deleting movie', 'Error');
      }
    });
  }

  


  
}
