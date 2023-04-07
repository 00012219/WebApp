import { MovieApiService } from './../movie-api.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-create-director',
  templateUrl: './director-create.component.html',
  styleUrls: ['./director-create.component.css']
})
export class DirectorCreateComponent implements OnInit {

  directorForm: FormGroup = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    birthDate: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required])
  });

  constructor(private movieApiService: MovieApiService) { }

  ngOnInit():void { }

  createDirector() {
    const newDirector = this.directorForm.value;
    console.log("new Director");
    this.movieApiService.createDirector(newDirector).subscribe(
      (response) => {
        alert("Director is created successfully!");
      },
      (error) => {
        if(error.status==400){
          console.log(error);
          alert("There are problems with the input fields");
        }else{
          console.log(error);
          alert("Sorry, something went wrong on our server. Please try again later.");
        }
      }
    );
  }
}
