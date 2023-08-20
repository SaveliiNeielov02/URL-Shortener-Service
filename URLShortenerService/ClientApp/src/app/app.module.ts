import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ShortURLsTableComponent } from './short-urls-table/short-urls-table.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './auth-service/auth-service';
import { ViewComponent } from './view/view.component';
import { CodeBlockComponent } from './about/code-block/code-block.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutComponent,
    ShortURLsTableComponent,
    LoginComponent,
    CodeBlockComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent }, //about
      { path: 'short-urls-table', component: ShortURLsTableComponent },
      { path: 'login', component: LoginComponent },
      { path: 'view/:shortUrl', component: ViewComponent },
    ])
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
