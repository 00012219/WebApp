import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MovieApiService } from './movie-api.service';
import { ReactiveFormsModule, FormBuilder, FormsModule } from '@angular/forms';
import { RouterModule, Routes, ActivatedRoute } from '@angular/router';  // <-- Import the router module
import { ToastrService } from 'ngx-toastr';
import { ToastrModule } from 'ngx-toastr'; // Import ToastrModule




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovieListComponent } from './movie-list/movie-list.component';
import { CreateMovieComponent } from './create-movie/create-movie.component';
import { UpdateMovieComponent } from './update-movie/update-movie.component';
import { DirectorCreateComponent } from './director-create/director-create.component';
import { DirectorListComponent } from './director-list/director-list.component';
import { UpdateDirectorComponent } from './update-director/update-director.component';
import { AssignDirectorComponent } from './assign-director/assign-director.component';


const routes: Routes = [  // <-- Configure the router
{ path: 'movies', component: MovieListComponent },
{ path: 'movies/create', component: CreateMovieComponent },
{path:'movies/:id/edit', component: UpdateMovieComponent},
{path:'directors', component: DirectorListComponent},
{path:'directors/create', component: DirectorCreateComponent},
{path:'directors/:id/edit', component: UpdateDirectorComponent},
{path:'assign-director', component:AssignDirectorComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    MovieListComponent,
    CreateMovieComponent,
    UpdateMovieComponent,
    DirectorCreateComponent,
    DirectorCreateComponent,
    DirectorListComponent,
    UpdateDirectorComponent,
    AssignDirectorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot(routes),
    ToastrModule.forRoot() // Add ToastrModule to imports
  ],
  providers: [MovieApiService, ToastrService, FormBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
