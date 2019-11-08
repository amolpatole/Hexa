import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ReverseNumOrTextPipe } from './pipes/reverse-num-or-text.pipe';
import { AvailablityPipe } from './pipes/availablity.pipe';

@NgModule({
  declarations: [ // Components, pipes and directives
    AppComponent, HomeComponent, AboutComponent, ReverseNumOrTextPipe, AvailablityPipe
  ],
  imports: [ // Any imported modules (custom / built-in)
    BrowserModule,
    AppRoutingModule
  ],
  providers: [ // Service

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
