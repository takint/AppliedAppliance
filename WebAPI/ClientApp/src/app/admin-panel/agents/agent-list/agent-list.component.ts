import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ListComponent } from '../../../common/base.component';
import { AgentModel } from '../../../common/models/agent-models';
import { AgentListService } from '../agent.service';

@Component({
  selector: 'app-agent-list',
  templateUrl: './agent-list.component.html',
  styleUrls: ['./agent-list.component.scss']
})

export class AgentListComponent extends ListComponent<AgentModel> implements OnInit {

  constructor(protected route: ActivatedRoute,
    public service: AgentListService) {
    super(route, service);
  }
}
