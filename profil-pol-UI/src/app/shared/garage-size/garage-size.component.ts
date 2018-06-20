import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-garage-size',
  templateUrl: './garage-size.component.html',
  styleUrls: ['./garage-size.component.scss']
})
export class GarageSizeComponent implements OnInit {

  @Input() sizes: string[];
  @Output() select = new EventEmitter<string>();
  constructor() { }

  ngOnInit() {
    this.select.emit(this.sizes[0]);
  }

  onSelect(event) {
    this.select.emit(event.target.value);
  }

}
