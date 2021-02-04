import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { ProgramCategoryModel } from '../../../common/models/program-category-model';
import { ProgramCategoryListService } from '../program-category.service';

@Component({
  selector: 'app-program-category-list',
  templateUrl: './program-category-list.component.html',
  styleUrls: ['./program-category-list.component.scss']
})

export class ProgramCategoryListComponent extends ListComponent<ProgramCategoryModel> implements OnInit {

  constructor(protected route: ActivatedRoute,
    public service: ProgramCategoryListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }

  //ngOnInit(): void {
  //}

}
