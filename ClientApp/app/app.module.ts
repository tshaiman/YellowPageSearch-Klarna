import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { SearchListComponent } from './components/search/search-list/search-list.component';
import { PersonDetailComponent } from './components/search/person-detail/person-detail.component';
import { SearchService } from './components/shared/search.service';
import { FormsModule }   from '@angular/forms';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        SearchListComponent,
        PersonDetailComponent

    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'search', pathMatch: 'full' },
            { path: 'search', component: SearchListComponent },
            { path: '**', redirectTo: 'search' }
        ])
    ],
    providers: [ SearchService ]
})
export class AppModule {
}
