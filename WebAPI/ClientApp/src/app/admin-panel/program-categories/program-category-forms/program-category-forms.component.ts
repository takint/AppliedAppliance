import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { ProgramCategoryFormViewModel } from '../../../common/models/program-category-model';
import { ProgramCategoryFormService } from '../program-category.service';

@Component({
  selector: 'app-program-category-forms',
  templateUrl: './program-category-forms.component.html',
  styleUrls: ['./program-category-forms.component.scss']
})
export class ProgramCategoryFormsComponent extends FormComponent<ProgramCategoryFormViewModel> implements OnInit {

  modelName = 'program-categories';
  listUrl = `/admin/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: ProgramCategoryFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  ngOnInit(): void {
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
  }

  prepareModelForAddMode() {
    this.model = {
      programCategory: {
        id: 0,
        name: '',
        description: ''
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('Program Category information updated!',
      { classname: AppUtil.toastSuccessClass })
  }

/* === VALIDATION === */
  validationRules = {
    name: {
      required: 'Program Category name is required'
    }
  };

}
