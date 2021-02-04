import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgentListComponent } from './agent-list/agent-list.component';
import { RouterModule } from '@angular/router';
import { AgentFormService, AgentListService } from './agent.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbdSortableHeader } from '../../common/sortable.directive';
import { AgentFormsComponent } from './agent-forms/agent-forms.component';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';


const ADMIN_PANEL_AGENT_ROUTE = [
  { path: '', component: AgentListComponent, pathMatch: 'full' },
  { path: 'details/:id/:mode', component: AgentFormsComponent },
];


@NgModule({

  declarations: [
    AgentListComponent,
    AgentFormsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_AGENT_ROUTE)
  ],
  providers: [
    AgentListService,
    AgentFormService
  ]
})
export class AgentsModule { }
