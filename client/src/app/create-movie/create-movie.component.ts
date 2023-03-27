import { MovieApiService } from './../movie-api.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.css']
})
export class CreateMovieComponent implements OnInit {

  movieForm: FormGroup = new FormGroup({
    title: new FormControl('', [Validators.required]),
    releaseDate: new FormControl('', [Validators.required]),
    director: new FormControl('', [Validators.required]),
    genre: new FormControl('', [Validators.required])
  });

  constructor(private movieApiService: MovieApiService) { }

  ngOnInit():void { }

  createMovie() {
    const newMovie = this.movieForm.value;
    this.movieApiService.createMovie(newMovie).subscribe(
      (response) => {
        console.log(response);
        // TODO: Handle successful response
      },
      (error) => {
        console.error(error);
        // TODO: Handle error
      }
    );
  }
}
