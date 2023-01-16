import {Component, Inject} from '@angular/core';
import {MatDatepickerInputEvent} from "@angular/material/datepicker";
import { IComboSelectionChangingEventArgs} from 'igniteui-angular';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  public rates: Rate[] = [];
  private http: HttpClient;
  private baseUrl: string;
  public selectedValueKey: string = "not selected";


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  datePickerChange(event: MatDatepickerInputEvent<Date>){
    if(!event?.value)
    {
      return;
    }
    this.http.get<Rate[]>(this.baseUrl + 'api/rate/'+event.value?.toJSON()).subscribe(result => {
      this.rates = result;
      console.log(this.rates)
    }, error => console.error(error));
  }

  public singleSelection(event: IComboSelectionChangingEventArgs) {
    console.log("asasas");
    if (event.added.length) {
      event.newSelection = event.added;
    }
  }
}

interface Rate {
  Currency: string;
  Rate: string;
}
