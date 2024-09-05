import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'xp-quantity-selector',
  templateUrl: './quantity-selector.component.html',
  styleUrls: ['./quantity-selector.component.css'],
})
export class QuantitySelectorComponent implements OnInit {
  @Input() value: number;
  @Output() valueChanged = new EventEmitter<number>();

  ngOnInit(): void {
    if (!this.value) {
      this.value = 1;
    }
  }

  increase() {
    this.value += 1;
    this.valueChanged.emit(this.value);
  }

  decrease() {
    if (this.value > 1) {
      this.value -= 1;
      this.valueChanged.emit(this.value);
    }
  }
}
