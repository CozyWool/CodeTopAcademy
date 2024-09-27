import {Routes} from '@angular/router';
import {ResumeComponent} from "./resume/resume.component";

export const routes: Routes = [
  {path: 'resume/:id', component: ResumeComponent},
];
