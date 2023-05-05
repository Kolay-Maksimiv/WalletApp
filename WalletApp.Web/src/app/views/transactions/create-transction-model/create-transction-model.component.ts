import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-create-transction-model',
  templateUrl: './create-transction-model.component.html',
  styleUrls: ['./create-transction-model.component.scss']
})
export class CreateTransctionModelComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: { userId: string}) {}
}
