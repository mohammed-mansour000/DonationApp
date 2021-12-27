import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CategoryComponent } from './pages/category/category/category.component';
import { DonationComponent } from './pages/donation/donation/donation.component';
import { ItemComponent } from './pages/item/item/item.component';
import { UserComponent } from './pages/user/user/user.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MenuComponent } from './pages/menu/menu.component';
import { LoginComponent } from './pages/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './Material/material.module';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { MapsComponent } from './maps/maps.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    DonationComponent,
    ItemComponent,
    UserComponent,
    MenuComponent,
    LoginComponent,
    MapsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    SlickCarouselModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
