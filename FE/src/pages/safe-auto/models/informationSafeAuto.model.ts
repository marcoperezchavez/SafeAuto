export class InformationSafeAuto {
    id: number;
    name: string;
    startTrip: string;
    endTrip: string;
    miles: number;
  }

  export class InformationSafeAutoShow extends  InformationSafeAuto {
    totalMiles: number;
    milesPerHour: number;
  }