import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Person } from '../../../../interfaces/person';
import { PeopleService } from '../../../../services/people.service';

@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.component.html',
  styleUrls: ['./people-list.component.css']
})
export class PeopleListComponent implements OnInit, AfterViewInit {

  displayedColumns: string[] = ['id', 'name', 'phone', 'email', 'actions'];
  dataSource: MatTableDataSource<Person> = new MatTableDataSource();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(private peopleService: PeopleService, private router: Router) {
    this.loadPeople();
  }

  ngOnInit(): void {
  }
  
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  loadPeople() {
    this.peopleService.getAll().subscribe(resp => {
      this.dataSource = new MatTableDataSource(resp);
    });  
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  delete(person: Person) {
    if(confirm("Are you sure you want to delete " + person.name + "?")){
      this.peopleService.delete(person.id).subscribe(resp => {
        this.loadPeople();
      });
    }
  }
}
