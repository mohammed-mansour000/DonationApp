import { LoginComponent } from './pages/login/login.component';
import { MenuComponent } from './pages/menu/menu.component';
import { DonationComponent } from './pages/donation/donation/donation.component';
import { UserComponent } from './pages/user/user/user.component';
import { CategoryComponent } from './pages/category/category/category.component';
import { ItemComponent } from './pages/item/item/item.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {path: "items", component: ItemComponent},
  {path: "categories", component: CategoryComponent},
  {path: "users", component: UserComponent},
  {path: "donations", component: DonationComponent},
  {path: "menu", component: MenuComponent, canActivate: [AuthGuard]},
  {path: "login", component: LoginComponent},
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
