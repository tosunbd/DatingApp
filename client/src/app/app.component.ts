import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService) { }
  // tslint:disable-next-line:typedef
  ngOnInit() {
    this.getUsers();
    this.setCurrentUser();
  }

  // tslint:disable-next-line:typedef
  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

  // tslint:disable-next-line:typedef
  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe(response => {
      this.users = response;
      }, error => {
        console.log(error);
      });
    }
  }
