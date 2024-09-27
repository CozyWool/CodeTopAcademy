import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SkillsModel} from "./models/skills.model";
import {of} from "rxjs";

@Injectable()
export class SkillsDataService {
  private readonly url: string;

  constructor(private http: HttpClient) {
    this.url = "http://localhost:5202/skills";
  }

  async getItemById(resumeId: number) {
    let response = await fetch(
      `${this.url}/${resumeId}`,
      {
        method: 'get',
      });
    let model = await response.json() as SkillsModel;

    return of(model);
  }
}
