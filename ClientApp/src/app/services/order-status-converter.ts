export class OrderStatusConverter {
    public statuses: { [id: string] : string; } = {};

    constructor() { 
        this.fillStatuses();
    }

    fillStatuses(){
        this.statuses["Open"] = "Открыт";
        this.statuses["Closed"] = "Прием закрыт";
        this.statuses["Delivered"] = "Доставлен";
        this.statuses["Finished"] = "Все оплатили";
        this.statuses["Cancelled"] = "Отменен";
      }

      public convert(status){
          return this.statuses[status];
      }
}
