import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {ProfessionalExperienceModel} from "./models/professional-experience.model";
import {of} from "rxjs";

@Injectable()
export class ProfessionalExperienceDataService {
  private readonly url: string;

  constructor(private http: HttpClient) {
    this.url = "http://localhost:5202/professional-experience";
  }

  async getItemById(resumeId: number) {
    let response = await fetch(
      `${this.url}/${resumeId}`,
      {
        method: 'get',
      });
    let model = await response.json() as ProfessionalExperienceModel;

    return of(model);
  }
}
