import { Component, OnInit, AfterViewInit } from '@angular/core';

@Component({
  selector: 'thestylesgurugram-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit, AfterViewInit {
  public constructor() {}

  public ngOnInit(): void {}

  public ngAfterViewInit(): void {
    this.loadScript();
  }

  public loadScript() {
    const body = <HTMLDivElement>document.body;
    const slickscript = document.createElement('script');
    slickscript.innerHTML = '';
    slickscript.src = '../../assets/js/slick.js';
    slickscript.async = false;
    slickscript.defer = true;
    body.appendChild(slickscript);
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = '../../assets/js/script.js';
    script.async = false;
    script.defer = true;
    body.appendChild(script);
  }
}
