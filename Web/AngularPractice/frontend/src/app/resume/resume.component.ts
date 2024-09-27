import {Component, OnInit} from '@angular/core';
import {ResumeModel} from "../models/resume.model";
import {ActivatedRoute} from "@angular/router";
import {ResumeDataService} from "../resume-data.service";
import {switchMap} from "rxjs";
import {NgIf} from "@angular/common";
import {SkillsComponent} from "../skills/skills.component";
import {ProfessionalExperienceComponent} from "../professional-experience/professional-experience.component";

@Component({
  selector: 'app-resume',
  standalone: true,
  imports: [
    NgIf,
    SkillsComponent,
    ProfessionalExperienceComponent
  ],
  providers: [ResumeDataService],
  templateUrl: './resume.component.html',
  styleUrl: './resume.component.css'
})
export class ResumeComponent implements OnInit {
  isLoaded: boolean = false;
  model: ResumeModel
  constructor( private activateRoute: ActivatedRoute, private resumeDataService: ResumeDataService) {
  }

  async getItem(id: number) {
    this.isLoaded = false;

    (await this.resumeDataService.getItemById(id)).subscribe({
      next: response => {
        this.model = response;
        this.isLoaded = true;
      },
      error: error => console.error(error)
    });

  }

  ngOnInit(): void {
    this.activateRoute.paramMap
      .pipe(switchMap(p => p.getAll('id')))
      .subscribe(async id => {
        await this.getItem(Number(id));
      });
  }

}
