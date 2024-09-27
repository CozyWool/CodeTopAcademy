import {Component, OnInit} from '@angular/core';
import {NgIf} from "@angular/common";
import {ActivatedRoute} from "@angular/router";
import {switchMap} from "rxjs";
import {ProfessionalExperienceModel} from "../models/professional-experience.model";
import {ProfessionalExperienceDataService} from "../professional-experience-data.service";

@Component({
  selector: 'app-professional-experience',
  standalone: true,
  imports: [NgIf],
  providers: [ProfessionalExperienceDataService],
  templateUrl: './professional-experience.component.html',
  styleUrl: './professional-experience.component.css'
})
export class ProfessionalExperienceComponent implements OnInit {
  isLoaded: boolean = false;
  model: ProfessionalExperienceModel;

  constructor(private activateRoute: ActivatedRoute, private professionalExperienceDataService: ProfessionalExperienceDataService) {
  }

  async getItem(id: number) {
    this.isLoaded = false;

    (await this.professionalExperienceDataService.getItemById(id)).subscribe({
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

