import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PhoneBookManagementService {

  _baseURL: string = 'PhoneBook'
  constructor(private http: HttpClient) { }

  getAllPhoneBooks() {
    return this.http.get<BaseDtoModel<PhoneBookModel[]>>(`${this._baseURL}/GetAll`);
  }
  getById(id: number) {
    return this.http.get<BaseDtoModel<PhoneBookModel>>(`${this._baseURL}/GetById?id=${id}`);
  }
  save(phonebookModel: PhoneBookModel) {
    return this.http.post<BaseDtoModel<PhoneBookModel>>(`${this._baseURL}/Post`, phonebookModel);
  }
  update(phonebookModel: PhoneBookModel) {

    return this.http.post<BaseDtoModel<PhoneBookModel>>(`${this._baseURL}/Edit`, phonebookModel);
  }
}
