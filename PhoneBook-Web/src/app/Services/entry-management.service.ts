import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EntryManagementService {
  _baseURL: string = `${environment.baseURL}/Entry`
  constructor(private http: HttpClient) { }

  getByPhoneBookId(id: number) {
    return this.http.get<BaseDtoModel<EntryModel[]>>(`${this._baseURL}/${id}`);
  }
  save(EntryModel: EntryModel) {
    return this.http.post<BaseDtoModel<EntryModel>>(`${this._baseURL}`, EntryModel);
  }
  update(EntryModel: EntryModel) {

    return this.http.put<BaseDtoModel<EntryModel>>(`${this._baseURL}/${EntryModel.EntryId}`, EntryModel);
  }
}
