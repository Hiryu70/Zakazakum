export class OrderStatusConverter {
    public statuses: { [id: string] : string; } = {};

    constructor() { 
        this.fillStatuses();
    }

    fillStatuses(){
        this.statuses[0] = "Открыт";
        this.statuses[1] = "Прием закрыт";
        this.statuses[2] = "Доставлен";
        this.statuses[3] = "Все оплатили";
        this.statuses[4] = "Отменен";
      }

      public convert(status){
          return this.statuses[status];
      }
}
