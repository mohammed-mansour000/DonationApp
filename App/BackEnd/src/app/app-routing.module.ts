import { LoginComponent } from './pages/login/login.component';
import { MenuComponent } from './pages/menu/menu.component';
import { DonationComponent } from './pages/donation/donation/donation.component';
import { UserComponent } from './pages/user/user/user.component';
import { CategoryComponent } from './pages/category/category/category.component';
import { ItemComponent } from './pages/item/item/item.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: "items", component: ItemComponent},
  {path: "categories", component: CategoryComponent},
  {path: "users", component: UserComponent},
  {path: "donations", component: DonationComponent},
  {path: "login", component: LoginComponent},
  {path: "menu", component: MenuComponent},
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
