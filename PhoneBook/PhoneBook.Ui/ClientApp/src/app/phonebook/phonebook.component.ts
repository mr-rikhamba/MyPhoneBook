import { Component, OnInit } from '@angular/core';
import { PhoneBookManagementService } from '../Services/phone-book-management.service';

import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-phonebook',
  templateUrl: './phonebook.component.html',
  styleUrls: ['./phonebook.component.css']
})
export class PhonebookComponent implements OnInit {

  public phonebooks: PhoneBookModel[];
  myForm: FormGroup;

  constructor(private phonebookService: PhoneBookManagementService, private fb: FormBuilder) { }

  ngOnInit() {
    this.myForm = new FormGroup({
      PhoneBookId: new FormControl()
      , Name: new FormControl()

    });
    this.myForm = this.fb.group({
      PhoneBookId: new FormControl(),
      Name: new FormControl()

    });
    this.phonebookService.getAllPhoneBooks().subscribe(data => {
      if (data.IsSuccessful) {

        this.phonebooks = data.DataSet;
      } else {
      }
    })
  }

  addNewPhoneBook() {
    if (this.myForm.value.Name == '') {
      alert("Please enter a valid phonebook name.")
      return;
    }
    this.phonebookService.save(this.myForm.value).subscribe(data => {

      alert(data.ResponseMessage);
    });
  }

}
