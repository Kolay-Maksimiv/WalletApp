import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-transction-model',
  templateUrl: './delete-transction-model.component.html',
  styleUrls: ['./delete-transction-model.component.scss']
})
export class DeleteTransctionModelComponent {

  constructor(public dialogRef: MatDialogRef<DeleteTransctionModelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { isDelete: boolean }) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
