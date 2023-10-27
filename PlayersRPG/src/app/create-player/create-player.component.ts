import { Component, ElementRef, ViewChild } from '@angular/core';
import { ApiService } from '../Services/api-service.service';

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css']
})

export class CreatePlayerComponent {
  name!: string;
  level!: number;

  constructor(private apiService: ApiService) {}

  player = {
    Id: null,
    Name: '',
    Level: 0
  }

  onSubmit(event: Event){
    event.preventDefault();
    this.player.Name = this.name;
    this.player.Level = this.level;
    console.log(this.player);
    this.apiService.createPlayer(this.player).subscribe({
      next: (response) => console.log('Player created successfully:', response),
      error: (error) => console.error('Error creating player:', error),
      complete: () => console.info('complete')
    })
  }
}
