import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { DocumentFormViewModel } from '../../../common/models/document-model';
import { DocumentFormService } from '../document.service';

@Component({
  selector: 'app-document-forms',
  templateUrl: './document-forms.component.html',
  styleUrls: ['./document-forms.component.scss']
})
export class DocumentFormsComponent extends FormComponent<DocumentFormViewModel> implements OnInit {

  modelName = 'documents';
  listUrl = `/admin/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: DocumentFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
    console.log(this.initData);
  }

  prepareModelForAddMode() {
    this.model = {
      document: {
        id: 0,
        name: '',
        type: '',
        group: ''
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('Document information updated!',
      { classname: AppUtil.toastSuccessClass })
  }

  /* === VALIDATION ===*/
  validationRules = {
    name: {
      required: 'Document name is required'
    },
    type: {
      required: 'Document type is required'
    },
    group: {
      required: 'Document group is required'
    }
  };

}
