import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  
  constructor(public snackBar: MatSnackBar) { }

  showSuccess(message: string): void {
    this.snackBar.open(message, '✅', {
      horizontalPosition: "center",
      verticalPosition: "top",
      });
  }

  showError(message: string): void {
    this.snackBar.open(message, 'X', {
      horizontalPosition: "center",
      verticalPosition: "top",
    });
  }

  getMessage(control: AbstractControl<any,any> | null, field: string): string {
    let message = "";
    if (field == "phoneNumber"){
      field = "phone"
    }
    if (control?.hasError("required")) {
      message = `${field} is required`;	
    }
    if (control?.hasError("pattern")) {
      message= `${field} is not valid`;
    }
    return message.charAt(0).toUpperCase() + message.slice(1);
  }
}
