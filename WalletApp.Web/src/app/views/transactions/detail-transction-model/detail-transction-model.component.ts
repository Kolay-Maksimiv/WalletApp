import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TransactionService } from 'src/app/services/transaction.service';

@Component({
  selector: 'app-detail-transction-model',
  templateUrl: './detail-transction-model.component.html',
  styleUrls: ['./detail-transction-model.component.scss']
})
export class DetailTransctionModelComponent {
  constructor(public dialogRef: MatDialogRef<DetailTransctionModelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { id: number,},
    private transactionService: TransactionService,) {}

    transaction$ = this.transactionService.getById(this.data.id);
}
