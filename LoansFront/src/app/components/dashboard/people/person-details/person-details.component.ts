import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/interfaces/person';
import { NotificationService } from 'src/app/services/notification.service';
import { PeopleService } from 'src/app/services/people.service';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.css']
})
export class PersonDetailsComponent implements OnInit {

  person!: Person;

  constructor(private personService: PeopleService, private notification: NotificationService,
    private route: ActivatedRoute, private router: Router){
      const id = Number(this.route.snapshot.paramMap.get('id'));
      if(id > 0) {
        this.getOne(id)
      }
  }

  ngOnInit(): void {
  }


  getOne(id: number): void {
    this.personService.getOne(id).subscribe({
      next: (response: any) => {
        this.person = response;
      }});
  }
}
