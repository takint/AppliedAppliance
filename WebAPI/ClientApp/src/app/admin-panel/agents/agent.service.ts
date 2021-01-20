import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { AgentModel } from '../../common/models/agent-models';

@Injectable({
  providedIn: 'root'
})
export class AgentListService extends ListService<AgentModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}agents`);
  }
}
