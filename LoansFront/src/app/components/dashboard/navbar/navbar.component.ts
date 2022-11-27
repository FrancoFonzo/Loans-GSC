import { Component, OnInit } from '@angular/core';
import { Menu } from 'src/app/interfaces/menu';
import { AuthService } from 'src/app/services/auth.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  menu: Menu[] = [];
  isLoggedIn: boolean = false;
  
  constructor(private menuService: MenuService, private auth: AuthService) {
    this.isLoggedIn = this.auth.isLoggedIn();
  }

  ngOnInit(): void {
    this.loadMenu();
   }

  loadMenu(): void {
    this.menuService.getMenu().subscribe((data) => {
      this.menu = data;
    });
  }

  logout(): void {
    this.auth.logout();
  }

}
