import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MovieApiService } from './movie-api.service';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { RouterModule, Routes, ActivatedRoute } from '@angular/router';  // <-- Import the router module
import { ToastrService } from 'ngx-toastr';
import { ToastrModule } from 'ngx-toastr'; // Import ToastrModule




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovieListComponent } from './movie-list/movie-list.component';
import { CreateMovieComponent } from './create-movie/create-movie.component';
import { UpdateMovieComponent } from './update-movie/update-movie.component';


const routes: Routes = [  // <-- Configure the router
{ path: '', component: MovieListComponent },
{ path: 'create', component: CreateMovieComponent },
{path:':id/edit', component: UpdateMovieComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    MovieListComponent,
    CreateMovieComponent,
    UpdateMovieComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    ToastrModule.forRoot() // Add ToastrModule to imports
  ],
  providers: [MovieApiService, ToastrService, FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
