import { AfterViewChecked, Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppNotificationService, LoginFormService } from '../common/app.service';
import { LoginViewModel } from '../common/models/user-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements AfterViewChecked, OnInit {

  loginForm: NgForm;
  @ViewChild('loginForm') currentForm: NgForm;
  public isFormLoaded: boolean = false;
  public model: LoginViewModel;

  constructor(public service: LoginFormService,
    protected router: Router,
    protected route: ActivatedRoute,
    protected notiService: AppNotificationService) {

  }

  onSubmit() {
    let errorMessage = null;

    if (this.loginForm.invalid) {
      errorMessage = 'mandatoryFieldsValidation';
    }

    return errorMessage;
  }

  ngOnInit() {
    this.model = {
      email: '',
      password: '',
      rememberMe: false
    };
    this.isFormLoaded = true;
  }

  /* ==== VALIDATION ==== */
  formErrors = {};
  validationRules = {
    email: {
      required: 'Email is required',
      email: 'This is not an email format'
    },
    password: {
      required: 'Password is required'
    }
  };

  ngAfterViewChecked() {
    this.formChanged();
  }

  formChanged() {
    if (this.currentForm === this.loginForm) { return; }
    this.loginForm = this.currentForm;
    if (this.loginForm) {
      this.loginForm.valueChanges
        .subscribe(data => this.onValueChanged(data));
    }
  }

  onValueChanged(data?: any) {
    this.validateAllFields(true);
  }

  validateAllFields(checkDirty: boolean) {
    if (!this.loginForm) { return; }
    const form = this.loginForm.form;

    for (const field in this.validationRules) {
      this.formErrors[field] = '';
      const control = form.get(field);

      if (control && (control.dirty || !checkDirty) && !control.valid) {
        const messages = this.validationRules[field];
        for (const key in control.errors) {
          this.formErrors[field] += messages[key] + ' ';
        }
        control.markAsDirty();
      }
    }
  }
}
