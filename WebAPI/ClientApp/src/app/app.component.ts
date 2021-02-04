import { Component, TemplateRef } from '@angular/core';
import { AppNotificationService } from './common/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Study Porter';
}

@Component({
  selector: 'app-notification',
  template: `
    <ngb-toast
      *ngFor="let toast of toastService.toasts"
      [class]="toast.classname"
      [autohide]="true"
      [animation]="true"
      [delay]="toast.delay || 5000"
      (hide)="toastService.remove(toast)"
    >
      <ng-template [ngIf]="isTemplate(toast)" [ngIfElse]="text">
        <ng-template [ngTemplateOutlet]="toast.textOrTpl"></ng-template>
      </ng-template>

      <ng-template #text>{{ toast.textOrTpl }}</ng-template>
    </ngb-toast>
  `,
  host: { '[class.ngb-toasts]': 'true' },
  styles: [':host.ngb-toasts { bottom: 0; top: initial; opacity:0.85; }']
})
export class ToastsContainer {
  constructor(public toastService: AppNotificationService) { }
  isTemplate(toast) { return toast.textOrTpl instanceof TemplateRef; }
}
