import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { HomeComponent } from './home/home.component';
import { PeopleListComponent } from './people/people-list/people-list.component';
import { PersonCreateComponent } from './people/person-create/person-create.component';
import { PersonDetailsComponent } from './people/person-details/person-details.component';
import { PersonEditComponent } from './people/person-edit/person-edit.component';

const routes: Routes = [
  { path: "", component: DashboardComponent, children: [
    { path: "", component: HomeComponent },
    { path: "people", component: PeopleListComponent },
    { path: "people/create", component: PersonCreateComponent },
    { path: "people/details/:id", component: PersonDetailsComponent },
    { path: "people/edit/:id", component: PersonEditComponent }
  ]},
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
