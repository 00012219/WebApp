import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MovieApiService } from './../movie-api.service';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../movie';


@Component({
  selector: 'app-update-movie',
  templateUrl: './update-movie.component.html',
  styleUrls: ['./update-movie.component.css']
})
export class UpdateMovieComponent {
  movieForm! : FormGroup;
  movie! : Movie;

  constructor(
    private route: ActivatedRoute,
    private movieService: MovieApiService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id')?.toString();
    this.movieService.getMovieById(id!).subscribe(movie => {
      this.movie = movie;
      this.movieForm = this.formBuilder.group({
        title: [this.movie.title, Validators.required],
        director: [this.movie.director, Validators.required],
        releaseDate: [this.movie.releaseDate, Validators.required],
        genre: [this.movie.genre, Validators.required]
      });
    });
  }
  

  onSubmit() {
    this.movieForm.patchValue({
      title: this.movieForm.value.title,
      director: this.movieForm.value.director,
      releaseDate: this.movieForm.value.releaseDate,
      genre: this.movieForm.value.genre
    });

    this.movie = Object.assign({}, this.movie, this.movieForm.value);

    this.movieService.updateMovie(this.movie)
      .subscribe(() => {
        console.log("updated the movie data");
        // handle success
      }, error => {
        console.log("there was an error updating the data")
        // handle error
      });
  }
}
