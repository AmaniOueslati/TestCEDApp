import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AddInternComponent } from './components/add-Intern/add-Intern.component';
import { InternDetailComponent } from './components/Intern-detail/Intern-detail.component';
import { InternsListComponent } from './components/Interns-list/Intern-list.component';
import { IntroPageComponent } from './components/intro-page/intro-page.component';

@NgModule({
  declarations: [
    AppComponent,
    AddInternComponent,
    InternDetailComponent,
    InternsListComponent,
    IntroPageComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
