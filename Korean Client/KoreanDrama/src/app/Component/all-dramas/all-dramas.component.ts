import { Component } from '@angular/core';
import {CommunicationFromServer} from "src/app/Services/ClientService"

@Component({
  selector: 'app-all-dramas',
  templateUrl: './all-dramas.component.html',
  styleUrls: ['./all-dramas.component.css']
})
export class AllDramasComponent {
  constructor(private com: CommunicationFromServer){

  }

  TopShowsData :any;
  TopMovies : any[]=[]
  TopDramas : any[]=[]
  TopShows : any[]=[]

  ngOnInit(): void {

  this.com.GetAllTopShows().subscribe(data=>{
  
    for(let i in data){
      
      if(data[i].showType=="Drama"){

        this.TopDramas.push(data[i])
      }
      else if(data[i].showType=="Movie"){
        this.TopMovies.push(data[i])
      }
      else{
        this.TopShows.push(data[i])
      }
      
    }
    console.log(this.TopDramas,this.TopMovies,this.TopShows)
  })
}

}

