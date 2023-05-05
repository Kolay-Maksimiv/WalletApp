import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UsersComponent } from './views/users/users.component';
import { UserCreateComponent } from './views/users/user-create/user-create.component';
import { UserDelailComponent } from './views/users/user-delail/user-delail.component';
import { TransactionsComponent } from './views/transactions/transactions.component';
import { CreateTransctionModelComponent } from './views/transactions/create-transction-model/create-transction-model.component';
import { DeleteTransctionModelComponent } from './views/transactions/delete-transction-model/delete-transction-model.component';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserCreateComponent,
    UserDelailComponent,
    TransactionsComponent,
    CreateTransctionModelComponent,
    DeleteTransctionModelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
