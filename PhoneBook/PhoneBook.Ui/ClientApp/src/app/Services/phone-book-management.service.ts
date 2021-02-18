import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PhoneBookManagementService {

  _baseURL: string = 'api/PhoneBook'
  constructor(private http: HttpClient) { }

  getAllPhoneBooks() {
    return this.http.get<BaseDtoModel<PhoneBookModel[]>>(`${this._baseURL}`);
  }
  getById(id: number) {
    return this.http.get<BaseDtoModel<PhoneBookModel>>(`${this._baseURL}/${id}`);
  }
  save(phonebookModel: PhoneBookModel) {
    return this.http.post<BaseDtoModel<PhoneBookModel>>(`${this._baseURL}`, phonebookModel);
  }
  update(phonebookModel: PhoneBookModel) {

    return this.http.put<BaseDtoModel<PhoneBookModel>>(`${this._baseURL}/${phonebookModel.PhoneBookId}`, phonebookModel);
  }
}
