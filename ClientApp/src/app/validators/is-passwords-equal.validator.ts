import { FormGroup } from '@angular/forms';

export function IsPasswordsEqual() {
    return (formGroup: FormGroup) => {
        const passwordControl = formGroup.controls["password"];
        const confirmPasswordControl = formGroup.controls["confirmPassword"];
        
        if (passwordControl.value != confirmPasswordControl.value){
            confirmPasswordControl.setErrors({ isPasswordsEqual: true });
        }
    }
}