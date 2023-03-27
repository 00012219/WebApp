import { Director } from './../director';
import { Component, OnInit } from '@angular/core';
import { MovieApiService } from '../movie-api.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-director-list',
  templateUrl: './director-list.component.html',
  styleUrls: ['./director-list.component.css']
})
export class DirectorListComponent implements OnInit {
  directors: Director[] = [];

  constructor(private movieService: MovieApiService,
    private toastr: ToastrService
    ) { }

  ngOnInit(): void {
    this.movieService.getDirectors().subscribe(directors => this.directors = directors);
  }

  deleteDirector(id: number): void {
    this.movieService.deleteDirector(id).subscribe({
      next: () => {
        // Remove the deleted director from the directors array
        this.directors = this.directors.filter(director => director.id !== id);
      },
      error: error => {
        console.error('Error deleting director:', error);
        this.toastr.error('Error deleting director', 'Error');
      }
    });
  }

  


  
}
