import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { SimairaCustomerAppSharedModule } from '@simaira/simaira-customer-app/shared';

@NgModule({
  imports: [CommonModule, SimairaCustomerAppSharedModule, BrowserModule, HttpClientModule],
})
export class SimairaCustomerAppHomeModule {}
