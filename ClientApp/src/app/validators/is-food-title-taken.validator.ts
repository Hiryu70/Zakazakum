import { FormGroup } from '@angular/forms';
import { Service, IsFoodTitleTakenQuery } from '../api/api.client.generated';

export function IsFoodTitleTaken(service: Service, restaurantId: string, foodId: string) {
    return (formGroup: FormGroup) => {
        const control = formGroup.controls["title"];

        let isFoodTitleTaken = new IsFoodTitleTakenQuery();
        isFoodTitleTaken.title = control.value;
        isFoodTitleTaken.restaurantId = restaurantId;
        isFoodTitleTaken.foodId = foodId;

        service.isFoodTitleTaken(isFoodTitleTaken).subscribe(result => {
          if (result){
              control.setErrors({ isFoodTitleTaken: true });
          }
        });
    }
}