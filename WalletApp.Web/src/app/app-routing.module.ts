import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './views/users/users.component';
import { UserCreateComponent } from './views/users/user-create/user-create.component';
import { TransactionsComponent } from './views/transactions/transactions.component';

const routes: Routes = [
  {
    path: '',
    component: UsersComponent,
  },
  {
    path: 'user-create',
    component: UserCreateComponent
  },
  {
    path: '',
    children: [{
      path: ':id/transactions',
      component: TransactionsComponent
    }]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
