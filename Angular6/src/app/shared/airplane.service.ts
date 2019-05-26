import { Injectable } from '@angular/core';
import { Airplane } from './airplane.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {
formData : Airplane;
listaAirplane : Airplane[];
readonly rootURL = 'http://localhost:14969/api'
  constructor(private http : HttpClient) { }

  PostAirPlane(formData : Airplane){
  return this.http.post(this.rootURL+'/AirPlanes',formData);
  }

  PutAirPlane(formData : Airplane){
    return this.http.put(this.rootURL+'/AirPlanes/'+formData.id,formData);
  }
  populaAirPlane(){
    return this.http.get(this.rootURL+'/AirPlanes')
    .toPromise().then(res => this.listaAirplane = res as Airplane[]);
  }
  apagaAirPlane(id:number){
    return this.http.delete(this.rootURL+'/AirPlanes/'+id);
  }

}
