import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie';
import { MovieApiService } from '../movie-api.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  movies: Movie[] = [];

  constructor(private movieApi: MovieApiService) { }

  ngOnInit(): void {
    this.movieApi.getMovies().subscribe(movies => this.movies = movies);
  }
}
