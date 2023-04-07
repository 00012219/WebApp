import { Director } from './../director';
import { Component, OnInit } from '@angular/core';
import { MovieApiService } from '../movie-api.service';


@Component({
  selector: 'app-director-list',
  templateUrl: './director-list.component.html',
  styleUrls: ['./director-list.component.css']
})
export class DirectorListComponent implements OnInit {
  directors: Director[] = [];

  constructor(private movieService: MovieApiService
    ) { }

  ngOnInit(): void {
    this.movieService.getDirectors().subscribe(directors => this.directors = directors);
  }

  deleteDirector(id: number): void {
    this.movieService.deleteDirector(id).subscribe({
      next: () => {
        // Remove the deleted director from the directors array
        this.directors = this.directors.filter(director => director.id !== id);
        alert("Successfully deleted the director");
      },
      error: error => {
        console.error('Error deleting director:', error);
        alert('Error deleting director');
      }
    });
  }

  


  
}
