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
    rating: new FormControl('', [Validators.required]),
    genre: new FormControl('', [Validators.required])
  });

  constructor(private movieApiService: MovieApiService) { }

  ngOnInit():void { }

  createMovie() {
    const newMovie = this.movieForm.value;
    this.movieApiService.createMovie(newMovie).subscribe(
      (response) => {
        console.log(response);
        alert('Movie created successfully!');
      },
      (error) => {
        if(error.status == 400){
          alert("There are problems with the input fields");
        }else{
          alert("Sorry, something went wrong on our server. Please try again later.")
        }
      }
    );
  }
}
