import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alert-simple-messages',
  templateUrl: './alert-simple-messages.component.html',
  styleUrls: ['./alert-simple-messages.component.scss']
})
export class AlertSimpleMessagesComponent implements OnInit {

    // Create array of messages
  public messages: Array<SimpleMessage> = new Array<SimpleMessage>();

  constructor() { }

  ngOnInit(): void {
    this.loadMockData();
  }

  // Create method to load MockData
  public loadMockData(): void {

    // Create Mockup data for the alert; array with 3 messages of type SimpleMessage

    // Create first message
    let message1 = new SimpleMessage();
    message1.message = "This is the first message";
    message1.type = "info";
    message1.title = "First message";
    message1.id = 1;
    message1.date = new Date();

    // Create second message
    let message2 = new SimpleMessage();
    message2.message = "This is the second message";
    message2.type = "warning";
    message2.title = "Second message";
    message2.id = 2;
    message2.date = new Date();

    // Create third message
    let message3 = new SimpleMessage();
    message3.message = "This is the third message";
    message3.type = "error";
    message3.title = "Third message";
    message3.id = 3;
    message3.date = new Date();

    // Create array of messages
    let messages = new Array<SimpleMessage>();
    messages.push(message1);
    messages.push(message2);
    messages.push(message3);

    this.messages = messages;

  }

  // Create method to format date
  public formatDate(date: Date): string {
    return date.toLocaleDateString() + " " + date.toLocaleTimeString();
  }








}

// Create class model or simple messages With ID, Title, Message, Type and Date
export class SimpleMessage {
  public id!: number;
  public title!: string;
  public message!: string;
  public type!: string;
  public date!: Date;
}
