import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appMissingImage]'
})
export class MissingImageDirective {

  constructor(private elemetRef: ElementRef, private renderer: Renderer2) { }

  @HostListener("error")
  private onError() {
    this.renderer.setAttribute(this.elemetRef.nativeElement, 'src', '../../../../../assets/images/prloaderImg.jpg')
  }
}
