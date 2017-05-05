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
    resultsMessage: string;
    persons :Person[] ;

    constructor(private searchService: SearchService){
        this.showInputMessage = true;
        this.resultsMessage = "";
    }
    
    ngOnInit() {
        //Testing 
        /*this.searchService.getPeople()
         .then(persons => {
             this.persons = persons;
            });*/
    }
    update(term: string){
        if(term) {
            this.showInputMessage = false;
        }else{
            this.showInputMessage = true;
        }
    }
    
    updateUiState(){
        if(!this.persons || this.persons.length==0){
           this.resultsMessage = "No results, please review your search or try a different one";
        }
        else{
             this.resultsMessage = "Search Results";
        }
    }

    search(term: string) { // without type info
     this.persons = null;
     if(term){
        this.showInputMessage = false;
        this.persons = null;
        this.searchService.search(term)
        .then(persons => {
             this.persons = persons;
             this.updateUiState();
        });
      }
      else {
          this.persons = null;
      }
    }

    
}
