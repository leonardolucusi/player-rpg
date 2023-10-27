import { Component } from '@angular/core';
import { ApiService } from '../Services/api-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {
  apiData?: any[];

  constructor(private apiService: ApiService) { }
  
  ngOnInit(): void {
    this.apiService.getAllPlayers().subscribe({
        next: (data) => this.apiData = data,
        error: (e) => console.error('Error fetching data from API:', e),
        complete: () => console.info('complete') 
    });
  }
}
