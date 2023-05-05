import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-transction-model',
  templateUrl: './create-transction-model.component.html',
  styleUrls: ['./create-transction-model.component.scss']
})
export class CreateTransctionModelComponent implements OnInit {

  types: any[] = [
    {value: 0, viewValue: 'Payment'},
    {value: 1, viewValue: 'Credit'},
  ];

  fg: FormGroup = new FormGroup({
    name:  new FormControl('', [Validators.required]),
    description:  new FormControl('', [Validators.required]),
    senderName :  new FormControl('', [Validators.required]),
    ownerId :  new FormControl('', [Validators.required]),
    sum :  new FormControl('', [Validators.required]),
    typeTransaction :  new FormControl('', [Validators.required])
  });

  constructor(public dialogRef: MatDialogRef<CreateTransctionModelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { userId: string, fg : FormGroup }) {}

  ngOnInit(): void {
    this.fg.get("ownerId")?.patchValue(this.data.userId);
    this.data.fg = this.fg;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
