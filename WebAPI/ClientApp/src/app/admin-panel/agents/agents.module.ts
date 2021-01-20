import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgentListComponent } from './agent-list/agent-list.component';
import { RouterModule } from '@angular/router';
import { AgentListService } from './agent.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbdSortableHeader } from '../../common/sortable.directive';


const ADMIN_PANEL_AGENT_ROUTE = [
  { path: '', component: AgentListComponent, pathMatch: 'full' },
  //{ path: 'details/{id}', component: SchoolFormsComponent },
];


@NgModule({

  declarations: [
    AgentListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forChild(ADMIN_PANEL_AGENT_ROUTE)
  ],
  providers: [
    AgentListService
  ]
})
export class AgentsModule { }
