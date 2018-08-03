import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DemoService } from './shared/demoService';
import { RaceSummaryComponent} from './raceSummary/raceSummary.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RaceSummaryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: RaceSummaryComponent, pathMatch: 'full' },
      { path: 'race-summary', component: RaceSummaryComponent }
    ])
  ],
  providers: [DemoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
