import {Injectable} from "@angular/core";

@Injectable()
export class LogService {

  write(logMessage: string) {
    console.log(logMessage);
  }
}
