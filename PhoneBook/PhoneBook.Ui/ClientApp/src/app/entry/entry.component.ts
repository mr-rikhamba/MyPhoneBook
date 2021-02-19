import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntryManagementService } from '../Services/entry-management.service';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.css']
})
export class EntryComponent implements OnInit {

  public entries: EntryModel[];
  myForm: FormGroup;
  phoneBookId: number;
  constructor(private entryService: EntryManagementService, private fb: FormBuilder, private route: ActivatedRoute) { }

  ngOnInit() {
    this.phoneBookId = this.route.snapshot.params.id;


    this.fetchEntries();
    this.myForm = this.fb.group({
      PhoneBookId: [this.phoneBookId],
      Name: new FormControl(),
      PhoneNumber: new FormControl()
    });
  }


  addNewEntry() {
  
    this.myForm.value.PhoneBookId = this.phoneBookId;
    this.entryService.save(this.myForm.value).subscribe(data => {

      alert(data.ResponseMessage);
      this.myForm.reset();
      this.fetchEntries();

    });
  }
  updateEntry(entryModel: EntryModel) {
    if (entryModel.Name === '' || entryModel.Name === null) {
      alert("Please enter a valid entry name.")
      return;
    }
    this.entryService.update(entryModel).subscribe(data => {
      alert(data.ResponseMessage);
      this.fetchEntries();
    });
  }

  fetchEntries() {

    this.entryService.getByPhoneBookId(this.phoneBookId).subscribe(data => {
      if (data.IsSuccessful) {

        this.entries = data.DataSet;
      } else {
      }
    });

  }

}
