import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable, catchError,map,of} from "rxjs";
import {  Injectable } from "@angular/core";
import { newUser } from "../Models/newuser";


@Injectable({
    providedIn :"root"
})


export class CommunicationFromServer{


    constructor(private http:HttpClient){}

    private baseurl = "https://localhost:7197"
    

    GetAllActors():Observable<any>{

        const url =  this.baseurl + "/api/actor/getallactors";

       
        
        const header = new HttpHeaders().set('x-api-key',"Namya&Himanshu");

        var res = this.http.get(url,{headers:header})

     
       
        return res;

    }

    //To get top shows (drama,movie and tvshows)
    GetAllTopShows():Observable<any>{

        const url =  this.baseurl + "/api/actor/GetAllTopShows";

       
        
        const header = new HttpHeaders().set('x-api-key',"Namya&Himanshu").set('Content-Type','application/json');

        var res = this.http.get(url,{headers:header})
console.log(res);

     
       
        return res;

    }
    GetActorDetails(actorId:any):Observable<any>{

        const url =  this.baseurl + `/api/actor/getactor/${actorId}`;

       
        
        const header = new HttpHeaders().set('x-api-key',"Namya&Himanshu");

        var res = this.http.get(url,{headers:header})

     
       
        return res;

    }

//new user registration
NewUser(body:newUser):Observable<any>{
const url = this.baseurl + '/api/user/newuser';
const header = new HttpHeaders().set('x-api-key',"Namya&Himanshu");
console.log(body);

var res=this.http.post(url, body,{ headers : header });
return res;

}

}