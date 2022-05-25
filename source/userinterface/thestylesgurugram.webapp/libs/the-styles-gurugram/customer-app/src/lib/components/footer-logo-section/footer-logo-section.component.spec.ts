import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FooterLogoSectionComponent } from './footer-logo-section.component';

describe('FooterLogoSectionComponent', () => {
  let component: FooterLogoSectionComponent;
  let fixture: ComponentFixture<FooterLogoSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FooterLogoSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FooterLogoSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
