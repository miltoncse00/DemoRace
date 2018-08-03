import { Component, OnInit } from '@angular/core'
import { DemoService } from '../shared/demoService';
import { RaceSummary } from '../shared/raceSummary.model';

@Component({
  selector: 'race-summary',
  templateUrl: './raceSummary.component.html'
})


export class RaceSummaryComponent implements OnInit{

  private raceSummaries: RaceSummary[];
  ngOnInit(): void {
    this.demoService.RaceSummary().subscribe(
      (data) => {
        this.raceSummaries = data;
      }
    )
  }
  constructor(private demoService: DemoService) { }


}
