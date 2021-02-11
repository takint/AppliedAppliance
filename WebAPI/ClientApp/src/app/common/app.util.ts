import { DefaultUrlSerializer, UrlTree } from '@angular/router';
import { environment } from '../../environments/environment';

export class AppUtil {
  public static apiHost: string = environment.apiEnpoint;

  public static toastSuccessClass: string = 'bg-success text-light';
  public static toastErrorClass: string = 'bg-danger text-light';

  public static isNullOrEmpty(input): boolean {
    // Null or empty
    if (input === null || input === undefined || input === '') {
      return true;
    }

    // Array empty
    if (typeof input.length === 'number' && typeof input !== 'function') {
      return !input.length;
    }

    // Blank string like '   '
    if (typeof input === 'string' && input.match(/\S/) === null) {
      return true;
    }

    return false;
  }
}

export function parseResponse(response, isObject: boolean = false) {
  // For the first time the response is object itself
  if (typeof response === "object") {
    return response;
  }

  let jsonResponse;
  try {
    jsonResponse = isObject ? response : <any>response.json();

    for (let item in jsonResponse) {
      if (jsonResponse[item] !== null) {
        if (typeof jsonResponse[item] === "object") {
          parseResponse(jsonResponse[item], true);
        }
      }
    }
  } catch (ex) {
    throw ex;
  }

  return jsonResponse;
}

export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
  parse(url: string): UrlTree {
    // Optional Step: Do some stuff with the url if needed.
    if (url.includes('authentication')) {
      return super.parse(url);
    }

    return super.parse(url.toLowerCase());
  }
}
