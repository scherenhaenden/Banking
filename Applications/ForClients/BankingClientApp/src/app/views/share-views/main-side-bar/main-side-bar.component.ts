import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-side-bar',
  templateUrl: './main-side-bar.component.html',
  styleUrls: ['./main-side-bar.component.scss']
})
export class MainSideBarComponent implements OnInit {



  constructor() { }

  ngOnInit(): void {
  }

}

export const SIDEMENU = {
  EMPLOYEES : "BA_TK_EMPLOYEES",
};

