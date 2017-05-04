import { Component, Input} from '@angular/core';

import { SearchService } from '../../shared/search.service';
import { Person } from '../../shared/person.type';

@Component({
    selector: 'person-detail',
    templateUrl: './person-detail.component.html',
    styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent {

     @Input() person :Person ;

    constructor(){
    }
    
}

