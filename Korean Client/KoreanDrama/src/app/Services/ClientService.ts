import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable, catchError,map,of} from "rxjs";
import {  Injectable } from "@angular/core";


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


}