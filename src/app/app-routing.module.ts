import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InternsListComponent } from './components/Interns-list/Intern-list.component';
import { AddInternComponent } from './components/add-Intern/add-Intern.component';
import { InternDetailComponent } from './components/Intern-detail/Intern-detail.component';
import { IntroPageComponent } from './components/intro-page/intro-page.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'intro' },
  { path: 'intro', component: IntroPageComponent },
  { path: 'Intern-list', component: InternsListComponent },
  { path: 'add-Intern', component: AddInternComponent },
  { path: 'edit-Intern/:id', component: InternDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
