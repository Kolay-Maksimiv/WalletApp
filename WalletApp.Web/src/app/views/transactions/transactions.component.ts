import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { TransactionService } from 'src/app/services/transaction.service';
import { CreateTransctionModelComponent } from './create-transction-model/create-transction-model.component';
import { DeleteTransctionModelComponent } from './delete-transction-model/delete-transction-model.component';
import { DetailTransctionModelComponent } from './detail-transction-model/detail-transction-model.component';

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
    const dialogRef =  this.dialog.open(CreateTransctionModelComponent, {
      data: {
        userId: this.userId
      }
    });
   dialogRef.afterClosed().subscribe(res=> {
      if (res) {
        this.transactionService.create(res).pipe().subscribe(() => {
          this.transactions$ = this.transactions$.pipe(map(transactions => [...transactions, res]));
        });
      }
    });
  }

  opneDetailTransaction(id: number) {
    this.dialog.open(DetailTransctionModelComponent, {
      data : {
        id: id
      }
    });
  }

  openDeleteTransaction(id: number) {
    const dialogRef =  this.dialog.open(DeleteTransctionModelComponent, {
      data : {
        isDelete: true
      }
    });
    dialogRef.afterClosed().subscribe(res => {
      if(res) {
        this.transactionService.deleteTranscation(id).subscribe(() => {
          this.transactions$ = this.transactions$.pipe(map(transactions => transactions.filter(t => t.id !== id)));
        });
      }
    })
  }
}
