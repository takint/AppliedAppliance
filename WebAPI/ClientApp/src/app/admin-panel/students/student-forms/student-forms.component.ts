import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { StudentFormViewModel, StudentModel } from '../../../common/models/student-model';
import { StudentFormService } from '../student.service';

@Component({
  selector: 'app-student-forms',
  templateUrl: './student-forms.component.html',
  styleUrls: ['./student-forms.component.scss']
})
export class StudentFormsComponent extends FormComponent<StudentFormViewModel> implements OnInit {

  modelName = 'students';
  listUrl = `/admin/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: StudentFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` })
    console.log(this.initData);
  }

  prepareModelForAddMode() {
    this.model = {
      student: {
        id: 0,
        firstName: '',
        lastName: '',
        middleName: '',
        email: '',
        studentCode: '',
        agentId: 0
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('Student information updated!',
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
