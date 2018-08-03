export interface RaceSummary {
  status: string;
  stake: number;
  horses: Horse[];
}

export interface Horse {
  id: number;
  name: string;
  betcount: number;
  payout: number;
}
