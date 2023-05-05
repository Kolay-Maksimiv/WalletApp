import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { TransactionService } from 'src/app/services/transaction.service';
import { CreateTransctionModelComponent } from './create-transction-model/create-transction-model.component';
import { DeleteTransctionModelComponent } from './delete-transction-model/delete-transction-model.component';

export interface TransactionsListModel {
  latestTransactions: TransactionViewModel[];
}

export interface TransactionViewModel {
  id: number;
  name: string;
  description: string;
  senderName: string;
  dateTransaction: string;
  icon: string | undefined;
  sum: string;
}

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss']
})
export class TransactionsComponent {

  displayedColumns: string[] = ['id', 'name', 'description', 'dateTransaction', 'sum', 'senderName', 'icon', 'detailTransaction', 'deleteTransaction'];

  userId = this.route.snapshot.paramMap.get('id');

  transactions$ = this.transactionService.getTrancasctionForUserId(this.userId as string).pipe(map(res => { return res.latestTransactions }));

  constructor(
    private route: ActivatedRoute,
    private transactionService: TransactionService,
    public dialog: MatDialog) {
  }

  openCreateTrasaction() {
    this.dialog.open(CreateTransctionModelComponent, {
      data: {
        userId: this.userId
      }
    });
  }

  openDeleteTransaction() {
    this.dialog.open(DeleteTransctionModelComponent);
  }
}
