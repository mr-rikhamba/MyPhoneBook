import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PhonebookComponent } from './phonebook/phonebook.component';
import { PhoneBookManagementService } from './Services/phone-book-management.service';
import { EntryComponent } from './entry/entry.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PhonebookComponent,
    EntryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: PhonebookComponent, pathMatch: 'full' },
      { path: 'entry/:id', component: EntryComponent },
    ])
  ],
  providers: [PhoneBookManagementService],
  bootstrap: [AppComponent]
})
export class AppModule { }
