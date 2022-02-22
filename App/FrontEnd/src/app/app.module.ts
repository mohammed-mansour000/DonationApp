import { MaterialModule } from './Material/material.module';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DonateNowComponent } from './pages/donate-now/donate-now.component';
import { CategoriesComponent } from './pages/categories/categories.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';
import { ItemsComponent } from './pages/item/items/items.component';
import { ShowItemComponent } from './pages/item/show-item/show-item.component';
import { MyDonationsComponent } from './pages/donation/my-donations/my-donations.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { HeaderComponent } from './pages/header/header.component';

import { MapComponent } from './pages/map/map/map.component';

import { MatCarouselModule } from '@ngmodule/material-carousel';
import { AddDonationComponent } from './pages/donation/add-donation/add-donation.component';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    DonateNowComponent,
    CategoriesComponent,
    ProfileComponent,
    LoginComponent,
    SignupComponent,
    ItemsComponent,
    ShowItemComponent,
    MyDonationsComponent,
    HeaderComponent,
    AddDonationComponent,
    MapComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SlickCarouselModule,
    MatCarouselModule.forRoot(),
    ToastrModule.forRoot()

  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]

})
export class AppModule { }
