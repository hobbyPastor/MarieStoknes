import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public answer: string = '';
  public currentFeedback: string = "";
  public baseUrl;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public sendAnswer() {
    var param = this.answer;
    if (param == '') {
      param = 'Feil svar';
    }
    console.log(this.currentFeedback);
    this.http.get<questionResult>(this.baseUrl + 'api/SampleData/NextTip/' + param).subscribe(result => {
      this.currentFeedback = result.hint;
    }, error => console.error(error));
  }
}

interface questionResult {
  answer: string;
  hint: string;
}
