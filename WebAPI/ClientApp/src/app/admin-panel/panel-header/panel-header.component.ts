import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../common/auth.service';
import { NavigationDropDownItems } from '../../shared-components/navigation-dropdown/navigation-dropdown.component';

@Component({
  selector: 'app-panel-header',
  templateUrl: './panel-header.component.html',
  styleUrls: ['./panel-header.component.scss']
})
export class PanelHeaderComponent implements OnInit {

  navDropDownTitle: string = 'admin@admin.com';

  navDropDownList: Array<NavigationDropDownItems> = [
    { title: 'Profile', url: '/authentication/profile', icon: 'far fa-user mr-2' },
    { title: 'Settings', url: 'admin/settings', icon: 'fas fa-wrench mr-2' },
    { title: 'Logout', url: '/authentication/logout', icon: 'fa-sign-out mr-2' }
  ];

  constructor(private authService: AuthService) {
    this.authService.getUser().subscribe(user => {
      this.navDropDownTitle = user.name;
    });
  }

  ngOnInit() { }

}
