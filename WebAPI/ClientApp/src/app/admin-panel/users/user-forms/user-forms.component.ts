import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { AppUtil } from '../../../common/app.util';
import { FormComponent } from '../../../common/base.component';
import { DropdownModel } from '../../../common/models/dropdown-model';
import { UserViewModel } from '../../../common/models/user-model';
import { UserFormService } from '../users.service';

@Component({
  selector: 'app-user-forms',
  templateUrl: './user-forms.component.html',
  styleUrls: ['./user-forms.component.scss']
})
export class UserFormsComponent extends FormComponent<UserViewModel> implements OnInit {

  modelName = 'Users';
  listUrl = `/admin/${this.modelName}`;
  formUrl = `${this.listUrl}/details/`;

  roleDropdownItems: Array<DropdownModel>;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: UserFormService,
    protected notiService: AppNotificationService) {
    super(route, router, service, notiService);
  }


  onInitDataLoaded(data) {
    super.onInitDataLoaded(data);
    this.roleDropdownItems = data[0];
  }

  prepareModel() {
    this.initData = [
      { sourceUrl: `${AppUtil.apiHost}Common/RoleDropdown` }
    ];

    super.prepareModel();
  }

  prepareModelForViewOrEditMode() {
    this.initData.push({ sourceUrl: `${this.service.apiUrl}/${this.modelId}` });
  }

  prepareModelForAddMode() {
    this.model = {
      user: {
        id: '',
        userName: '',
        email: '',
        emailConfirmed: false,
        phoneNumber: '',
        phoneNumberConfirmed: false,
        password: '',
        passwordConfirmed: '',
        accessFailedCount: 0,
        lockoutEnabled: false,
        twoFactorEnabled: false
      }
    }
  }

  onSubmitSuccess() {
    this.notiService.show('User updated!',
      { classname: AppUtil.toastSuccessClass })
  }

  /* ==== VALIDATION ==== */
  validationRules = {
    userName: {
      required: 'User name is required'
    },
    email: {
      required: 'User email is required',
      email: 'This is not an email format'
    }
  };

}
