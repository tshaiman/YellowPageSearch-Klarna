import { Component, Input, OnInit } from '@angular/core';

import { SearchService } from '../../shared/search.service';
import { Person } from '../../shared/person.type';

@Component({
    selector: 'search',
    templateUrl: './search-list.component.html',
    styleUrls: ['./search-list.component.css']
})
export class SearchListComponent {

    resultsMessage: string;
    searchTerm: string;
    persons :Person[] ;

    constructor(private searchService: SearchService){
        this.resultsMessage = "";
    }
   
    
    updateUiState(){
        if (!this.searchTerm) {
            this.persons = null;
            this.resultsMessage = "";
            return;
        }
        if (!this.persons || this.persons.length == 0) {
           this.resultsMessage = "No results, please review your search or try a different one";
        }
        else{
             this.resultsMessage = "Search Results";
        }
    }

    //The search endpoint   
    //Todo : use RxJS for throtlling the keystroke and cancel previous request
    search() { 
     this.persons = null;
     if (this.searchTerm){
        this.searchService.search(this.searchTerm)
        .then(persons => {
             this.persons = persons;
             this.updateUiState();
        });
      }
      else {
         this.updateUiState();
      }
    }

    
}
