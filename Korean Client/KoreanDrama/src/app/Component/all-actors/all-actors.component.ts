import { Component } from '@angular/core';
import {CommunicationFromServer} from "src/app/Services/ClientService"

@Component({
  selector: 'app-all-actors',
  templateUrl: './all-actors.component.html',
  styleUrls: ['./all-actors.component.css']
})
export class AllActorsComponent {
  constructor(private com: CommunicationFromServer){

  }

  ActorsData:any;
  ActorImage :any;

  ngOnInit(): void {
  
    this.com.GetAllActors().subscribe(data=>{
      
      this.ActorsData =data;
      
    })
    this.com.GetAllActorImages().subscribe(data=>{
    
      this.ActorImage =data;
    
      
      
    })
  
  }
}
