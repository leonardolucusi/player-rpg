import { Component, Input } from '@angular/core';
import { ApiService } from '../Services/api-service.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent {
  @Input() PlayerInput :any = {};

  constructor(private apiService: ApiService){}

  fnDeletePlayer(id: number){
    this.apiService.deletePlayer(id).subscribe(
      () => {
        console.log('Player deleted Succesfully!');
      },
      (error)=>{
        console.log('Error deleting data from API:', error);
      }
    )
  }
}
