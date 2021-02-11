import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { DropdownModel } from '../../../common/models/dropdown-model';
import { SchoolDocumentFormViewModel } from '../../../common/models/school-document-model';
import { SchoolDocumentFormService } from '../school-document.service';

@Component({
  selector: 'app-school-document-forms',
  templateUrl: './school-document-forms.component.html',
  styleUrls: ['./school-document-forms.component.scss']
})
export class SchoolDocumentFormsComponent extends FormComponent<SchoolDocumentFormViewModel> implements OnInit {

  modelName = 'school-documents';
  listUrl = `/admin/schools/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  documentTypeListDropDownItems: Array<DropdownModel>;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: SchoolDocumentFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  onInitDataLoaded(data) {
    super.onInitDataLoaded(data);
    this.documentTypeListDropDownItems = data[0];
  }

  prepareModel() {
    this.initData = [
      { sourceUrl: `${AppUtil.apiHost}Common/DocumentTypeListDropDown` }
    ];

    super.prepareModel();
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
  }

  prepareModelForAddMode() {
    this.model = {
      schoolDocument: {
        id: 0,
        schoolId: 0,
        documentId: 0,
        document: {
          name: '',
          group: '',
        },     
        type: '',
        isRequired: false,
        description: '',
        preTemplate: ''
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('School Document information updated!',
      { classname: AppUtil.toastSuccessClass })
  }

  /* === VALIDATION ===*/
  validationRules = {
    schoolId: {
      required: 'Shool Id is required'
    },
    documentId: {
      required: 'Document Id is required'
    },
    isRequired: {
      required: 'Is required'
    }
  };

}
