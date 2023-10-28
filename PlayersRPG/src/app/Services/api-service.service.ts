import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:7114/Home';

  constructor(private http : HttpClient) { }

  getAllPlayers() : Observable<any> {
    return this.http.get(`${this.apiUrl}`);
  }

  createPlayer(player: any) : Observable<any> {
    return this.http.post(`${this.apiUrl}`, player, ).pipe(
      catchError((error: any) => {
        console.log(error);
        throw error;
      })
    );
  }
  
  deletePlayer(id: any) : Observable<any>{
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
