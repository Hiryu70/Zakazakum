import { FormGroup } from '@angular/forms';
import { Service, IsPhoneNumberIsTakenQuery } from '../api/api.client.generated';

export function PhoneIsTaken(service: Service, userId: string) {
    return (formGroup: FormGroup) => {
        const control = formGroup.controls["phoneNumber"];

        let phoneIsTaken = new IsPhoneNumberIsTakenQuery();
        phoneIsTaken.phoneNumber = control.value;
        phoneIsTaken.userId = userId;

        service.phoneIsTaken(phoneIsTaken).subscribe(result => {
          if (result){
              control.setErrors({ phoneIsTaken: true });
          }
        });
    }
}