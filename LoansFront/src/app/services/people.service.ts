import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Person } from '../interfaces/person';

const URL = `${environment.apiUrl}/people`;

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Person[]> {
    return this.http.get<Person[]>(URL);
  }

  getOne(id: number): Observable<Person> {
    return this.http.get<Person>(`${URL}/${id}`);
  }

  create(person: Person): Observable<Person> {
    return this.http.post<Person>(URL, person);
  }

  update(person: Person): Observable<Person> {
    return this.http.put<Person>(`${URL}/${person.id}`, person);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${URL}/${id}`);
  }
}
