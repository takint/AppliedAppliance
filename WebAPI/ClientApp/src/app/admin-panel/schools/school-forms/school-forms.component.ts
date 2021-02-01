import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { SchoolFormViewModel } from '../../../common/models/school-model';
import { SchoolFormService } from '../school.service';

@Component({
  selector: 'app-school-forms',
  templateUrl: './school-forms.component.html',
  styleUrls: ['./school-forms.component.scss']
})
export class SchoolFormsComponent extends FormComponent<SchoolFormViewModel> implements OnInit {

  modelName = 'Schools';
  listUrl = `/Admin/${this.modelName}`;
  formUrl = `${this.listUrl}/Details/`;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: SchoolFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
  }

  prepareModelForAddMode() {
    this.model = {
      school: {
        id: 0,
        schoolName: '',
        email: '',
        countryCode: '',
        applicationFee: 0,
        hasLeadIntegration: false,
        ieltSlisten: 0,
        ieltSread: 0,
        ieltSwrite: 0,
        ieltSspeak: 0,
        pgwp: ''
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('Shools information updated!',
      { classname: AppUtil.toastSuccessClass })
  }

  /* ==== VALIDATION ==== */
  validationRules = {
    schoolName: {
      required: 'Shool name is required'
    },
    email: {
      required: 'Shool email is required',
      email: 'This is not an email format'
    }
  };
}
