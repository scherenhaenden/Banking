import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { SessionService } from 'src/app/services/session/session.service';

@Component({
  selector: 'app-main-up-bar',
  templateUrl: './main-up-bar.component.html',
  styleUrls: ['./main-up-bar.component.scss']
})
export class MainUpBarComponent implements OnInit {

  constructor(private sessionService: SessionService) { }

  ngOnInit(): void {
  }





  // Declare output emit for loggout
  @Output() logoutEvent = new EventEmitter();

  // Create method that logs user out
  public logout(): void {
    //this.sessionService.clearUserSession();
    this.logoutEvent.emit();
  }

}
