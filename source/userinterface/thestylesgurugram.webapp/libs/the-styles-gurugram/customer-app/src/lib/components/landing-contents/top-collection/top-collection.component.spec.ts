import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopCollectionComponent } from './top-collection.component';

describe('TopCollectionComponent', () => {
  let component: TopCollectionComponent;
  let fixture: ComponentFixture<TopCollectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopCollectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
