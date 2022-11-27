import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/interfaces/person';
import { NotificationService } from 'src/app/services/notification.service';
import { PeopleService } from 'src/app/services/people.service';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.css']
})
export class PersonEditComponent implements OnInit {

  formPerson: FormGroup = this.formBuilder.group({
    name: ["", Validators.required],
    phoneNumber: ["", [Validators.required, Validators.pattern("[0-9]{6,12}")]],
    email: ["", [Validators.required, Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
  });

  person!: Person;

  constructor(private personService: PeopleService, private notification: NotificationService,
    private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder){
      const id = Number(this.route.snapshot.paramMap.get('id'));
      if(id > 0) {
        this.getOne(id)
      }
  }

  ngOnInit(): void {
  }

  update(person: Person): void {
    if (!this.formPerson.valid) {
      this.formPerson.markAllAsTouched();
      return;
    }
    person.id = this.person.id;
    this.personService.update(person).subscribe({
      next: (response: any) => {
        this.notification.showSuccess("Person updated successfully");
        this.router.navigate(['/people']);
      }});
  }

  getOne(id: number): void {
    this.personService.getOne(id).subscribe({
      next: (response: any) => {
        this.person = response;
        this.formPerson.patchValue(this.person);
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
