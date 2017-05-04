import { Component, Input, OnInit } from '@angular/core';

import { SearchService } from '../../shared/search.service';
import { Person } from '../../shared/person.type';

@Component({
    selector: 'search',
    templateUrl: './search-list.component.html',
    styleUrls: ['./search-list.component.css']
})
export class SearchListComponent implements OnInit{

    showInputMessage: boolean;
    persons :Person[] ;

    constructor(private searchService: SearchService){
        this.showInputMessage = true;
    }
    
    ngOnInit() {
        this.searchService.getPeople()
         .then(persons => {
             this.persons = persons;
            });
    }
    onFocus(){
        this.showInputMessage = false;
    }
    onLostFocus(){
        this.showInputMessage = true;
    }

    onKey(event: any) { // without type info
     if(event.keyCode == 13){
         this.showInputMessage = false;
     }
  }
}
