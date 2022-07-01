import { MovieOrderType } from "../../shared/enums/movieOrderType";


export class QueryParams {
    takeCount?: number;
    genres?: Array<string>;
    year?: number;
    orderTypes?: Array<MovieOrderType>;
    pageNumber?: number;
    country?: string;
    title?: string;
    director?: string;
}
