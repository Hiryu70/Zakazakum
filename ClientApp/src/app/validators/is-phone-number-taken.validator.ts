import { FormGroup } from '@angular/forms';
import { Service, IsPhoneNumberTakenQuery } from '../api/api.client.generated';

export function IsPhoneNumberTaken(service: Service, userId: string) {
    return (formGroup: FormGroup) => {
        const control = formGroup.controls["phoneNumber"];

        let isPhoneNumberTaken = new IsPhoneNumberTakenQuery();
        isPhoneNumberTaken.phoneNumber = control.value;
        isPhoneNumberTaken.userId = userId;

        service.isPhoneNumberTaken(isPhoneNumberTaken).subscribe(result => {
          if (result){
              control.setErrors({ isPhoneNumberTaken: true });
          }
        });
    }
}