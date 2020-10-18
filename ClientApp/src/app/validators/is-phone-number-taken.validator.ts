import { FormGroup } from '@angular/forms';
import { Service, IsPhoneNumberTakenQuery } from '../api/api.client.generated';

export function IsPhoneNumberTaken(service: Service, userId: string) {
    return (formGroup: FormGroup) => {
        const control = formGroup.controls["phoneNumber"];

        let phoneIsTaken = new IsPhoneNumberTakenQuery();
        phoneIsTaken.phoneNumber = control.value;
        phoneIsTaken.userId = userId;

        service.isPhoneNumberTaken(phoneIsTaken).subscribe(result => {
          if (result){
              control.setErrors({ phoneIsTaken: true });
          }
        });
    }
}