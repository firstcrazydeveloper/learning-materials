import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'simaira-customer-app-select-language',
  template: `
    <select #langSelect (change)="translate.use(langSelect.value)">
      <option
        *ngFor="let lang of translate.getLangs()"
        [value]="lang"
        [attr.selected]="lang === translate.currentLang ? '' : null"
        >{{ lang }}</option
      >
    </select>
  `,
  styles: [],
})
export class SelectLanguageComponent implements OnInit {
  public constructor(public translate: TranslateService) {}

  public ngOnInit(): void {}
}
