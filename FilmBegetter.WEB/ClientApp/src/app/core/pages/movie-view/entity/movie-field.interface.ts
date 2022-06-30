import { EMovieFieldType } from './movie-field.enum';
export interface ImovieField {
  label: string,
  type: EMovieFieldType,
  value: string | number | Date | string[]
}