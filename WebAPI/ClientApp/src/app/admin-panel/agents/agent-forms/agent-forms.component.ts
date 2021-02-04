import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { AgentFormViewModel, AgentModel } from '../../../common/models/agent-model';
import { AgentFormService } from '../agent.service';

@Component({
  selector: 'app-agent-forms',
  templateUrl: './agent-forms.component.html',
  styleUrls: ['./agent-forms.component.scss']
})
export class AgentFormsComponent extends FormComponent<AgentFormViewModel> implements OnInit {

  modelName = 'agents';
  listUrl = `/admin/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: AgentFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
    console.log(this.initData);
  }

  prepareModelForAddMode() {
    this.model = {
      agent: {
        id: 0,
        firstName: '',
        lastName: '',
        email: '',
        phone: '',
        companyName: '',
        mainSourceStudent: '',
        approved: false,
        manager: 0
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('Agent information updated!',
      { classname: AppUtil.toastSuccessClass })
  }

  /* === VALIDATION === */
  validationRules = {
    firstName: {
      required: 'FirstName is required'
    },
    lastName: {
      required: 'LastName is required'
    },
    email: {
      required: 'Email is required',
      email: 'Please enter valid email'
    }
  };

  ngOnInit(): void {
  }

}
