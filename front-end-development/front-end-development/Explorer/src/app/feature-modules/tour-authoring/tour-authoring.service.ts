import { Destination } from './model/destination.model';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from 'src/env/environment';
import { TextWrapper } from 'src/app/shared/model/text-wrapper.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Tour } from './model/tour.model';
import { TransferPublish } from './model/transfer-publish.model';
import { Equipment } from '../administration/model/equipment.model';
import { TourReview } from './model/tour.review.model';
import { AvailableTour } from '../marketplace/model/available-tour-model';
import { TourSale } from './model/tour-sale.model';
import { TourSaleConnection } from './model/tour-sale-connection.model';
import TourBundle from './model/tour-bundle';
import { Checkpoint } from './model/checkpoint.model';

@Injectable({
  providedIn: 'root',
})
export class TourAuthoringService {
  constructor(private http: HttpClient) {}

  getAuthorTours(authorId: number): Observable<PagedResults<Tour>> {
    const params = new HttpParams().set('authorId', authorId);
    return this.http.get<PagedResults<Tour>>(
      environment.apiHost + 'tour/authortours',
      { params }
    );
  }

  getPublishedAuthorTours(authorId: number): Observable<PagedResults<Tour>> {
    const params = new HttpParams().set('authorId', authorId);
    return this.http.get<PagedResults<Tour>>(
      environment.apiHost + 'tour/publishedauthortours',
      { params }
    );
  }

  addTour(tour: Tour): Observable<Tour> {
    return this.http.post<Tour>(environment.apiHost + 'tour', tour);
  }

  updateTour(tour: Tour): Observable<Tour> {
    return this.http.put<Tour>(environment.apiHost + 'tour/updatetour', tour);
  }

  getTourById(id: number): Observable<Tour> {
    const params = new HttpParams().set('tourId', id);
    return this.http.get<Tour>(environment.apiHost + 'tour/singletour', {
      params,
    });
  }

  getEquipmentForTour(
    tourId: number,
    page: number,
    pageSize: number
  ): Observable<PagedResults<Equipment>> {
    const params = new HttpParams()
      .set('tourId', tourId.toString()) // Use 'tourId' for the parameter name
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());

    const url = `${environment.apiHost}author/equipment/tourequipment`;

    return this.http.get<PagedResults<Equipment>>(url, { params });
  }

  deleteEquipment(id: number): Observable<Equipment> {
    return this.http.delete<Equipment>(
      environment.apiHost + 'author/equipment/' + id
    );
  }

  addEquipment(equipment: Equipment): Observable<Equipment> {
    //console.log("Ulaz u servis")
    //console.log(equipment)
    //const url = `${environment.apiHost}author/equipment`;
    //console.log(url);
    return this.http.post<Equipment>(
      environment.apiHost + 'author/equipment',
      equipment
    );
  }

  addTourReview(tourReview: TourReview): Observable<TourReview> {
    return this.http.post<TourReview>(
      environment.apiHost + 'tourist/tourReview',
      tourReview
    );
  }

  getAuthorTourReviews(authorId: number): Observable<PagedResults<TourReview>> {
    const params = new HttpParams().set('authorId', authorId);
    return this.http.get<PagedResults<TourReview>>(
      environment.apiHost + 'tourist/tourReview'
    );
  }

  publishTour(tourId: number): Observable<Tour> {
    return this.http.put<Tour>(
      environment.apiHost + 'tour/publishTour',
      tourId
    );
  }

  archiveTour(tourId: number): Observable<Tour> {
    return this.http.put<Tour>(
      environment.apiHost + 'tour/archiveTour',
      tourId
    );
  }

  getAllEquipments(): Observable<PagedResults<Equipment>> {
    return this.http.get<PagedResults<Equipment>>(
      environment.apiHost + 'author/equipment'
    );
  }

  getAllAvailableTours(
    page: number,
    pageSize: number,
    userId: number
  ): Observable<PagedResults<AvailableTour>> {
    const params = new HttpParams()
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<PagedResults<AvailableTour>>(
      environment.apiHost + 'tour/shopping/' + userId.toString(),
      { params }
    );
  }

  getTouristTours(userId: number): Observable<PagedResults<AvailableTour>> {
    return this.http.get<PagedResults<AvailableTour>>(
      environment.apiHost + 'tour/touristTours/' + userId
    );
  }

  getAllTours(): Observable<PagedResults<Tour>> {
    return this.http.get<PagedResults<Tour>>(environment.apiHost + 'tour');
  }

  getAllToursForAuthor(userId: number): Observable<PagedResults<Tour>> {
    return this.http.get<PagedResults<Tour>>(
      environment.apiHost + 'tour/authortours'
    );
  }

  addTourSale(tourSale: TourSale): Observable<TourSale> {
    return this.http.post<TourSale>(
      environment.apiHost + 'author/sale',
      tourSale
    );
  }

  deleteSale(saleId: number) {
    return this.http.delete<TourSale>(
      environment.apiHost + 'author/sale' + saleId
    );
  }

  addTourToSale(
    tourSaleConnection: TourSaleConnection
  ): Observable<TourSaleConnection> {
    return this.http.post<TourSaleConnection>(
      environment.apiHost + 'author/tourSaleConnection',
      tourSaleConnection
    );
  }

  createTourBundle(tourBundle: TourBundle): Observable<TourBundle> {
    return this.http.post<TourBundle>(
      environment.apiHost + 'author/tourBundle',
      tourBundle
    );
  }

  getAuthorBundles(): Observable<PagedResults<TourBundle>> {
    return this.http.get<PagedResults<TourBundle>>(
      environment.apiHost + 'author/tourBundle'
    );
  }

  publishBundle(id: number): Observable<TourBundle> {
    return this.http.patch<TourBundle>(
      environment.apiHost + 'author/tourBundle/publish/' + id,
      id
    );
  }

  getSuggestedTours(checkpoints: Checkpoint[]): Observable<PagedResults<Tour>> {
    const ids = checkpoints.map((c) => c.id);
    let params = new HttpParams();
    ids.forEach((id) => {
      params = params.append('ids', id!.toString());
    });
    return this.http.get<PagedResults<Tour>>(
      environment.apiHost + 'tour/suggestedTours',
      { params }
    );
  }

  archieveBundle(id: number): Observable<TourBundle> {
    return this.http.patch<TourBundle>(
      environment.apiHost + 'author/tourBundle/archieve/' + id,
      id
    );
  }

  addToFavorite(tourId: number, userId: number): Observable<AvailableTour> {
    return this.http.post<AvailableTour>(
      environment.apiHost + 'tour/' + tourId + '/favorite/',
      null
    );
  }

  removeFromFavorite(
    tourId: number,
    userId: number
  ): Observable<AvailableTour> {
    return this.http.delete<AvailableTour>(
      environment.apiHost + 'tour/' + tourId + '/favorite/'
    );
  }
}
