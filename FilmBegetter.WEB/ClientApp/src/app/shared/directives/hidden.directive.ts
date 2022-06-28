import { Directive, ElementRef, Renderer2, OnInit } from '@angular/core';

@Directive({
  selector: '[appHidden]'
})
export class HiddenDirective implements OnInit {

  constructor(private elementRef: ElementRef, private renderer: Renderer2) { }

  public ngOnInit(): void {
    console.log(this.elementRef.nativeElement);

    // this.renderer.setStyle(this.elementRef.nativeElement, 'display', 'none');
  }
}
