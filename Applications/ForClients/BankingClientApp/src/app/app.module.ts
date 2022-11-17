import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TemplateViewIndexComponent } from './views/template-view-index/template-view-index.component';
import { TemplateViewProfileComponent } from './views/template-view-profile/template-view-profile.component';
import { TemplateViewLoginComponent } from './views/template-view-login/template-view-login.component';
import { SharedComponentsModule } from './shared-components/shared-components.module';
import { LoginViewComponent } from './views/login-view/login-view.component';
import { AccountsViewComponent } from './views/accounts-view/accounts-view.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptorService } from './services/security/jwt-interceptor.service';
import { ShareViewsModule } from './views/share-views/share-views.module';

@NgModule({
  declarations: [
    AppComponent,
    TemplateViewIndexComponent,
    TemplateViewProfileComponent,
    TemplateViewLoginComponent,
    LoginViewComponent,
    AccountsViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    SharedComponentsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ShareViewsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: JwtInterceptorService,
    multi: true
  }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
