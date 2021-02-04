import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { AgentFormViewModel, AgentModel } from '../../common/models/agent-model';

@Injectable({
  providedIn: 'root'
})

export class AgentListService extends ListService<AgentModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}agents`);
  }
}

@Injectable({
  providedIn: 'root'
})

export class AgentFormService extends AppService<AgentFormViewModel>{
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}agents`);
  }
}
