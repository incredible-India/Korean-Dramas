import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Component/header/header.component';
import { HomeComponent } from './Component/home/home.component';
import { AllActorsComponent } from './Component/all-actors/all-actors.component';
import { AllDramasComponent } from './Component/all-dramas/all-dramas.component';
import { AllMoviesComponent } from './Component/all-movies/all-movies.component';
import { AllShowsComponent } from './Component/all-shows/all-shows.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    AllActorsComponent,
    AllDramasComponent,
    AllMoviesComponent,
    AllShowsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
