import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';  

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  
  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get('http://localhost:5000/api/products').subscribe((res :any) =>{
      console.log(res);
    }, error => {
      console.log(error);
    });
    
  }
  
}
