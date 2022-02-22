import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { menumodel } from 'src/app/models/menumodel';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  entries: menumodel[] = [];
  constructor(private router: Router) { }

  MenuHandler(m: menumodel)
  {
    const NavArray = [];
    NavArray.push(m.route);
    this.router.navigate(NavArray);
  }

  ngOnInit() {
    let m = new menumodel();
    m.fa_icon = 'fa fa-users';
    m.title = 'Users';
    m.route = 'users';
    this.entries.push(m);

    m = new menumodel();
    m.fa_icon = 'fas fa-donate';
    m.title = 'Donation';
    m.route = 'donations';
    this.entries.push(m);
 
    m = new menumodel();
    m.fa_icon = 'fas fa-list-alt';
    m.title = 'Category';
    m.route = 'categories';
    this.entries.push(m);

    m = new menumodel();
    m.fa_icon = 'fas fa-tshirt';
    m.title = 'Item';
    m.route = 'items';
    this.entries.push(m);
  }

}
