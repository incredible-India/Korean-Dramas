import { Component } from '@angular/core';
import {CommunicationFromServer} from "src/app/Services/ClientService"

@Component({
  selector: 'app-all-movies',
  templateUrl: './all-movies.component.html',
  styleUrls: ['./all-movies.component.css']
})
export class AllMoviesComponent {
  constructor(private com: CommunicationFromServer){

  }

  TopShowsData :any;
  TopMovies : any[]=[]
  TopDramas : any[]=[]
  TopShows : any[]=[]
  tempMovies : any;
  ngOnInit(): void {

    this.com.GetOnlyMovies().subscribe(data=>{
  
      this.tempMovies =data;
        console.log(this.tempMovies)
      })
}
}
