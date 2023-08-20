import { Component } from '@angular/core';
import {CommunicationFromServer} from "src/app/Services/ClientService"
import  {Subscriber} from "rxjs"
import { OnInit } from '@angular/core';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private com: CommunicationFromServer){

  }


  ActorsData:any;
  TopShowsData :any;
  TopMovies : any[]=[]
  TopDramas : any[]=[]
  TopShows : any[]=[]
  TopImages :any[]=[];
ngOnInit(): void {
  
  this.com.GetAllActors().subscribe(data=>{
    
    this.ActorsData =data;
    
  })

  this.com.GetAllActorImages().subscribe(data=>{
    
    this.TopImages =data;
    console.log(this.TopImages,"actor images");
    
    
  })

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
