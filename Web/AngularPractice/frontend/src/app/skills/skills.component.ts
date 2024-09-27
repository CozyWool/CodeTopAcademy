import {Component, OnInit} from '@angular/core';
import {ResumeModel} from "../models/resume.model";
import {ActivatedRoute} from "@angular/router";
import {switchMap} from "rxjs";
import {SkillsDataService} from "../skills-data.service";
import {SkillsModel} from "../models/skills.model";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [
    NgIf
  ],
  providers:[SkillsDataService],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.css'
})
export class SkillsComponent implements OnInit {
  isLoaded: boolean = false;
  model: SkillsModel
  constructor( private activateRoute: ActivatedRoute, private skillsDataService: SkillsDataService) {
  }

  async getItem(id: number) {
    this.isLoaded = false;

    (await this.skillsDataService.getItemById(id)).subscribe({
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
