import { Component } from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import {ResumeComponent} from "./resume/resume.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ResumeComponent, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngularPractice';
}
