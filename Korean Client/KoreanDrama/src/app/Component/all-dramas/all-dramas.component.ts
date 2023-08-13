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
  tempDramas : any;
  ngOnInit(): void {

    this.com.GetOnlyDramas().subscribe(data=>{
  
      this.tempDramas =data;
        console.log(this.tempDramas ,"is the shows")
      })
}

}

