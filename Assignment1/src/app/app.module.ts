import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomeComponent, AddEventComponent } from './components';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { EditEventComponent } from './components/edit-event/edit-event.component';
import { HttpHeaderInterceptorService } from './interceptors/http-header-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddEventComponent,
    EditEventComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass:HttpHeaderInterceptorService, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
