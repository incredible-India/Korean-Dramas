import { Component } from '@angular/core';
import {CommunicationFromServer} from "src/app/Services/ClientService"

@Component({
  selector: 'app-all-shows',
  templateUrl: './all-shows.component.html',
  styleUrls: ['./all-shows.component.css']
})
export class AllShowsComponent {
  constructor(private com: CommunicationFromServer){

  }

  TopShowsData :any;
  TopMovies : any[]=[]
  TopDramas : any[]=[]
  TopShows : any[]=[]
  tempshows:any;

  ngOnInit(): void {

  this.com.GetOnlyTvShows().subscribe(data=>{
  
  this.tempshows =data;
    console.log(this.tempshows ,"is the shows")
  })
}
}
