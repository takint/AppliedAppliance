import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { CampusFormViewModel } from '../../../common/models/campus-model';
import { CampusFormService } from '../campus.service';

@Component({
  selector: 'app-campus-forms',
  templateUrl: './campus-forms.component.html',
  styleUrls: ['./campus-forms.component.scss']
})
export class CampusFormsComponent extends FormComponent<CampusFormViewModel> implements OnInit {

  modelName = 'campuses';
  listUrl = `/admin/schools/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: CampusFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
    console.log(this.initData);
  }

  prepareModelForAddMode() {
    this.model = {
      campus: {
        id: 0,
        campusName: '',
        address: '',
        city: '',
        province: '',
        postalCode: '',
        phone: '',
        ext: '',
        processingFee: 0,
        schoolId: 0,
        brandId: 0,
        submissionCode: 0,
        leadCampusId: 0,
        hasLeadIntegration: false
      }
    }
  }
  onSubmitSuccess() {
    this.notiService.show('Campus information updated!',
      { classname: AppUtil.toastSuccessClass })
  }

  /* === VALIDATION ===*/
  validationRules = {
    campusName: {
      required: 'Campus name is required'
    },
    schoolId: {
      required: 'Shool Id is required'
    },
    processingFee: {
      required: 'Processing fee is required'
    }
  };
}
