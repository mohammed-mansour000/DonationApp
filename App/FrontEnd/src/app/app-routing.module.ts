import { AddDonationComponent } from './pages/donation/add-donation/add-donation.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { LoginComponent } from './pages/login/login.component';
import { ItemsComponent } from './pages/item/items/items.component';
import { DonateNowComponent } from './pages/donate-now/donate-now.component';
import { CategoriesComponent } from './pages/categories/categories.component';
import { SignupComponent } from './pages/signup/signup.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MyDonationsComponent } from './pages/donation/my-donations/my-donations.component';

const routes: Routes = [
  {path: "", component: DonateNowComponent},
  {path: "categories", component: CategoriesComponent},
  {path: "items/:cat_id", component: ItemsComponent},
  {path: "signup", component: SignupComponent},
  {path: "login", component: LoginComponent},
  {path: "profile", component: ProfileComponent},
  {path: "items/add-donation/:item_id", component: AddDonationComponent},

  {path: "myDonation", component: MyDonationsComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
