import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-navigation-dropdown',
  templateUrl: './navigation-dropdown.component.html',
  styleUrls: ['./navigation-dropdown.component.scss']
})
export class NavigationDropdownComponent {

  @Input() navDropDownHeader: string;
  @Input() navDropDownItems: Array<NavigationDropDownItems>;

  constructor() { }

}

export interface NavigationDropDownItems {
  title: string,
  url: string,
  icon: string
}
