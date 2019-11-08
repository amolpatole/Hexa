import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//Component Barrel
import { HomeComponent, AboutComponent, DetailComponent, 
          AddProductComponent, RegisterComponent, NotFoundComponent } from './components/';
import { ImagePipe } from './pipes/';
import { LoginComponent } from './components/login/login.component';
import { HttpHeaderInterceptor } from './interceptors/http-header.interceptor';
import { HighlightDirective } from './directives/highlight.directive';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ImagePipe,
    DetailComponent,
    AddProductComponent,
    RegisterComponent,
    LoginComponent,
    HighlightDirective,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass:HttpHeaderInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
