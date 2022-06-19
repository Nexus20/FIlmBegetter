import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'crop'
})
export class CropPipe implements PipeTransform {

    transform(value: string, limit: number): unknown {
        return value.length >= limit ? value.substr(0, limit) + '...' : value;
    }

}
