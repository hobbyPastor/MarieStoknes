import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public title: string = "Tid igjen til Bursdagskickoff:";
  public happyBirthday: boolean = false;

  public itsTime() {
    this.happyBirthday = true;
    this.title = "Gratulerer så masse med dagen Marie ❤️"
  }

}
