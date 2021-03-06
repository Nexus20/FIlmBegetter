import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { AbstractControl, ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { IInput } from '../../models/input.interface';
import { MovieService } from "../../../core/services/movie.service";


export const INPUT_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => InputComponent),
  multi: true
};

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
  providers: [INPUT_VALUE_ACCESSOR],

})
export class InputComponent implements OnInit, ControlValueAccessor {

  private componentParameters!: IInput;
  private onChange: any;
  private onTouched: any;
  public value: any;

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.value = '';
  }

  @Input() control?: AbstractControl;
  @Input() set inputParameters(value: IInput) {
    this.componentParameters = value;
  }
  @Input() error?: string;
  @Input() type: 'email' | 'password' | 'date' | 'file' | 'text' = 'text';

  get inputParameters(): IInput {
    return this.componentParameters;
  }

  change(event: any): void {
    this.onChange(event.target.value);
    this.onTouched(event.target.value);
  }

  writeValue(value: any): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  changeDate(event: any): void {
    const value = (event.target.value as Date).getTime();
    this.onChange(value);
    this.onTouched(value);
  }

  changeRate(event: any): void {
    const value = Number(event.target.value);
    this.onChange(value);
    this.onTouched(value);
  }
}
