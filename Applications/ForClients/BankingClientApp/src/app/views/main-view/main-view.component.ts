import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/services/session/session.service';

@Component({
  selector: 'app-main-view',
  templateUrl: './main-view.component.html',
  styleUrls: ['./main-view.component.scss']
})
export class MainViewComponent implements OnInit {

  constructor(private sessionService: SessionService,
    ) { }

  ngOnInit(): void {
  }

    // Create method that logs user out
    public logout(): void {
      this.sessionService.clearUserSession();
    }

}
