import { RoutingHistoryService } from './shared/services/routing-history.service';
import { Component } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

declare var $: any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    $('button').click(function() {
      alert('kliknales przycisk');
    });
  }

  constructor(private routingHistoryService: RoutingHistoryService) {
    routingHistoryService.loadRouting();
  }
}
