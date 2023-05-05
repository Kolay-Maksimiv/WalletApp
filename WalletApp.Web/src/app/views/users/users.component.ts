import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { TransactionService } from 'src/app/services/transaction.service';
import { UserService } from 'src/app/services/user.service';


export interface UserBaseModels {
  id: string;
  firstName: string;
  lastName: string;
}

export interface BlocsModel {
  cardBalance: number;
  available: number;
  noPaymentDue: number;
  dailyPoints: number;
}

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent {
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'transaction'];

  dataSource$ = this.userService.getListOfUsers();

  blocs$ = this.transactionService.getBlocs();

  constructor(private userService: UserService, private transactionService: TransactionService) { }

}
