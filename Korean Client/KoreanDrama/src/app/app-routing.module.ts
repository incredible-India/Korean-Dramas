import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './Component/home/home.component';
import { AllActorsComponent } from './Component/all-actors/all-actors.component';
import { AllDramasComponent } from './Component/all-dramas/all-dramas.component';
import { AllMoviesComponent } from './Component/all-movies/all-movies.component';
import { AllShowsComponent } from './Component/all-shows/all-shows.component';
import { ActorDetailsComponent } from './Component/actor-details/actor-details.component';

const routes: Routes = [

  {path: '' , component:HomeComponent},
  {path:"actors", component:AllActorsComponent},
  {path:"dramas", component:AllDramasComponent},
  {path:"movies", component:AllMoviesComponent},
  {path:"tShows", component:AllShowsComponent},
  {path:"getActorDetails/:id", component:ActorDetailsComponent},
  {path : "user",loadChildren:()=>import('./Modules/users/users.module').then(mod=>mod.UsersModule)}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
