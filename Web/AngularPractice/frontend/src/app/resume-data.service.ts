import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {ResumeModel} from "./models/resume.model";
import {of} from "rxjs";

@Injectable()
export class ResumeDataService {
  private readonly url: string;

  constructor(private http: HttpClient) {
    this.url = "http://localhost:5202/resume";
  }

  async getItemById(id: number) {
    let response = await fetch(
      `${this.url}/${id}`,
      {
        method: 'get',
      });
    let model = await response.json() as ResumeModel;

    return of(model);
  }
}
