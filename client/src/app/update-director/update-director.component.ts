import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MovieApiService } from './../movie-api.service';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Director } from '../director';


@Component({
  selector: 'app-update-director',
  templateUrl: './update-director.component.html',
  styleUrls: ['./update-director.component.css']
})
export class UpdateDirectorComponent {
  directorForm! : FormGroup;
  director! : Director;

  constructor(
    private route: ActivatedRoute,
    private movieService: MovieApiService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id')?.toString();
    this.movieService.getDirectorById(id!).subscribe(director => {
      this.director = director;
      this.directorForm = this.formBuilder.group({
        firstName: [this.director.firstName, Validators.required],
        lastName: [this.director.lastName, Validators.required],
        birthDate: [this.director.birthDate, Validators.required],
        email: [this.director.email, Validators.required]
      });
    });
  }
  

  onSubmit() {
    this.directorForm.patchValue({
      firstName: this.directorForm.value.firstName,
      lastName: this.directorForm.value.lastName,
      birthDate: this.directorForm.value.birthDate,
      email: this.directorForm.value.email
    });

    this.director = Object.assign({}, this.director, this.directorForm.value);

    this.movieService.updateDirector(this.director)
      .subscribe(() => {
        alert("Director is updated successfully!");
        console.log("updated the director data");
      }, error => {
        if(error.status == 400){
          alert("There are problems with the input fields");
        }else{
          console.log(error);
          alert("Sorry, something went wrong on our server. Please try again later.");
        }
      });
  }
}
