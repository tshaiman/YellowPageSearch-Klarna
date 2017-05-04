
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

import { Person } from './person.type';


@Injectable()
export class SearchService {
    constructor(private http: Http) {

    }

    search(term: String) {
        return this.http.get(`api/Search/TermSearch/${term}`)
           .map(response => response.json() as Person[])
            .toPromise();
    }

      getPeople() {
        return this.http.get(`api/Search/GetPeople`)
           .map(response => response.json() as Person[])
            .toPromise();
    }

    
}