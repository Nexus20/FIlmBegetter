import { ICustomSelectItem, ICustomSelect } from '../../models/custom-select.interface';
import { FormControl, NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { Component, Input, OnInit, Output, ViewChild, EventEmitter, HostBinding, forwardRef } from '@angular/core';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DropdownComponent),
      multi: true
    }
  ]
})
export class DropdownComponent implements OnInit, ControlValueAccessor {

  @Input() selectContent!: ICustomSelect;

  onChange: any = () => { }
  onTouch: any = () => { }
  private currentValue!: ICustomSelectItem;


  set value(value: ICustomSelectItem) {
    if (value) {
      this.onChange(value);
      this.onTouch(value);
    }
  }

  constructor() { }

  ngOnInit(): void {
  }


  public writeValue(value: ICustomSelectItem) {
    this.value = value;
  }

  public registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  public registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }
}
