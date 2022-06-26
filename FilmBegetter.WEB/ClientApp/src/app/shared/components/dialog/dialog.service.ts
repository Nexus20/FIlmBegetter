import { ComponentType, Overlay } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { Injectable, Injector } from '@angular/core';

import { DialogRef } from './dialog-ref';
import { DIALOG_DATA } from './dialog-token';

@Injectable()
export class DialogService {

  constructor(private overlay: Overlay, private injector: Injector) { }

  //open a component in the overlay
  public open<T>(component: ComponentType<T>, config?: any) {

    //set global position
    const position = this.overlay
      .position()
      .global()
      .centerHorizontally()
      .centerVertically();

    const overlayRef = this.overlay.create({
      positionStrategy: position,
      hasBackdrop: true,
      panelClass: 'overlay-panel'
    })

    const dialogRef = new DialogRef(overlayRef);

    const injector = Injector.create({
      parent: this.injector,
      providers: [
        { provide: DialogRef, useValue: dialogRef },
        { provide: DIALOG_DATA, useValue: config },
      ]
    })

    const portal = new ComponentPortal(component, null, injector);
    overlayRef.attach(portal);

    return dialogRef;
  }
}
