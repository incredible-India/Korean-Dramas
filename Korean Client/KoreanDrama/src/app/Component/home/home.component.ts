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

ngOnInit(): void {
  
  this.com.GetAllActors().subscribe(data=>{
    console.log(data);
    this.ActorsData =data;
    
  })
}



}
