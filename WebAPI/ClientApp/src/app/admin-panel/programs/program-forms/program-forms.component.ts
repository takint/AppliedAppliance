import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { ProgramFormViewModel } from '../../../common/models/program-model';
import { ProgramFormService } from '../program.service';

@Component({
  selector: 'app-program-forms',
  templateUrl: './program-forms.component.html',
  styleUrls: ['./program-forms.component.scss']
})
export class ProgramFormsComponent extends FormComponent<ProgramFormViewModel> implements OnInit {

  modelName = 'programs';
  listUrl = `/admin/schools/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: ProgramFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
  }

  prepareModelForAddMode() {
    this.model = {
      program: {
        id: 0,
        schoolId: 0,
        programCategoryId: 0,
        brandId: 0,
        leadProgramId: 0,
        eaTemplateId: 0,
        additionalDocumentId: 0,
        programName: '',
        programLevel: 0,
        startDate: new Date(),
        programLength: 0,
        hasLeadIntegration: false
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('Program information updated!',
      { classname: AppUtil.toastSuccessClass })
  }

  /* === VALIDATION ===*/
  validationRules = {
    schoolId: {
      required: 'Shool Id is required'
    },
    programName: {
      required: 'Program name is required'
    },
    programCategoryId: {
      required: 'Program Category is required'
    }
  };

}
