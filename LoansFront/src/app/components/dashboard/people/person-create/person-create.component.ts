import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Person } from 'src/app/interfaces/person';
import { NotificationService } from 'src/app/services/notification.service';
import { PeopleService } from 'src/app/services/people.service';

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.css']
})
export class PersonCreateComponent implements OnInit {

  formPerson: FormGroup = this.formBuilder.group({
    name: ["", Validators.required],
    phoneNumber: ["", [Validators.required, Validators.pattern("[0-9]{6,12}")]],
    email: ["", [Validators.required, Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
  });

  constructor(private personService: PeopleService, private router: Router,
     private formBuilder: FormBuilder, private notification: NotificationService) { }

  ngOnInit(): void {
  }

  create(person: Person): void {
    if (!this.formPerson.valid) {
      this.formPerson.markAllAsTouched();
      return;
    }
    this.personService.create(person).subscribe({
      next: (response: any) => {
        this.notification.showSuccess("Person created successfully");
        this.router.navigate(['/people']);
      }});
  }

  isValid(field: string): boolean | undefined {
    return !(this.formPerson.get(field)?.invalid &&
      this.formPerson.get(field)?.touched);
  }

  getMessage(field: string): string {
    const control = this.formPerson.get(field);
    return this.notification.getMessage(control, field);
  }
}
