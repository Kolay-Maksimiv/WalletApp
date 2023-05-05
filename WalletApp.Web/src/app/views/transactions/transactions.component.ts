import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { TransactionService } from 'src/app/services/transaction.service';

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

  displayedColumns: string[] = ['id', 'name', 'description', 'dateTransaction', 'sum', 'senderName', 'icon', 'deleteTransaction'];

  userId = this.route.snapshot.paramMap.get('id');

  transactions$ =  this.transactionService.getTrancasctionForUserId(this.userId as string).pipe(map(res => {return res.latestTransactions }));

  constructor(private route: ActivatedRoute, private transactionService: TransactionService) { 
   }
}
