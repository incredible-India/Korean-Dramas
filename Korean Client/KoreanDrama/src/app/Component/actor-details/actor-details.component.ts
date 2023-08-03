import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {CommunicationFromServer} from "src/app/Services/ClientService"

@Component({
  selector: 'app-actor-details',
  templateUrl: './actor-details.component.html',
  styleUrls: ['./actor-details.component.css']
})
export class ActorDetailsComponent {
constructor(private route: ActivatedRoute,private com: CommunicationFromServer){

}
  actorId = this.route.snapshot.paramMap.get('id');
  actordeatils:any

  ngOnInit(): void {
  
    this.com.GetActorDetails(this.actorId).subscribe(data=>{
      
      this.actordeatils = data;
      console.log(this.actordeatils);
      
      
    })
  }

}
