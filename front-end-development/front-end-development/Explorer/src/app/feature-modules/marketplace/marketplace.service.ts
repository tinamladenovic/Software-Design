import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TourPreferences } from './model/tour-preferences.model';
import { environment } from 'src/env/environment';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TouristEquipment } from './model/touristEquipment.model';
import { Equipment } from '../administration/model/equipment.model';
import {
  AvailableTour,
  BundleItem,
  OrderItem,
  ShoppingCart,
} from './model/available-tour-model';
import TourBundle from '../tour-authoring/model/tour-bundle';
import { PaymentRecord } from './model/payment-record';
import { Order } from './model/order.model';
import { CompositeTour } from './model/composite-tour.model';
import { TouristWallet } from '../layout/model/userProfile.model';
import { Tour } from '../tour-authoring/model/tour.model';
import { Checkpoint } from '../tour-authoring/model/checkpoint.model';

@Injectable({
  providedIn: 'root',
})
export class MarketplaceService {
  constructor(private http: HttpClient) {}


  getTours(): Observable<PagedResults <Tour>> {
    
    return this.http.get<PagedResults<Tour>>('https://localhost:44333/api/tour');
  }

  getTour(tourId: number): Observable<any> {
    return this.http.get<AvailableTour>(
      environment.apiHost + `tour/singletour/${tourId}`
    );
  }

  wallet$ = new BehaviorSubject<TouristWallet>({
    id: -1,
    userId: -1,
    adventureCoins: 0,
  });


  getTourPreferences(): Observable<PagedResults<TourPreferences>> {
    return this.http.get<PagedResults<TourPreferences>>(
      'https://localhost:44333/api/tourist/tourpreferences'
    );
  }

  deleteTourPreferences(id: number): Observable<TourPreferences> {
    return this.http.delete<TourPreferences>(
      environment.apiHost + 'tourist/tourpreferences/' + id
    );
  }

  addTourPreferences(
    tourpreferences: TourPreferences
  ): Observable<TourPreferences> {
    return this.http.post<TourPreferences>(
      environment.apiHost + 'tourist/tourpreferences',
      tourpreferences
    );
  }

  updateTourPreferences(
    tourpreferences: TourPreferences
  ): Observable<TourPreferences> {
    return this.http.put<TourPreferences>(
      environment.apiHost + 'tourist/tourpreferences/' + tourpreferences.id,
      tourpreferences
    );
  }

  getTouristEquipment(
    userId: number
  ): Observable<PagedResults<TouristEquipment>> {
    return this.http.get<PagedResults<TouristEquipment>>(
      environment.apiHost + 'tourism/touristEquipment/' + userId
    );
  }

  getEquipment(): Observable<PagedResults<Equipment>> {
    return this.http.get<PagedResults<Equipment>>(
      environment.apiHost + 'tourism/equipmentForTourist'
    );
  }

  deleteEquipment(id: number): Observable<TouristEquipment> {
    return this.http.delete<TouristEquipment>(
      environment.apiHost + 'tourism/touristEquipment/' + id
    );
  }

  addTouristEquipment(
    touristEquipment: TouristEquipment
  ): Observable<TouristEquipment> {
    return this.http.post<TouristEquipment>(
      environment.apiHost + 'tourism/touristEquipment',
      touristEquipment
    );
  }

  updateEquipment(
    touristEquipment: TouristEquipment
  ): Observable<TouristEquipment> {
    return this.http.put<TouristEquipment>(
      environment.apiHost + 'tourism/touristEquipment' + touristEquipment.id,
      touristEquipment
    );
  }

  addToCart(orderItem: OrderItem, userId: number): Observable<any> {
    return this.http.put<OrderItem>(
      'https://localhost:44333/api/shoppingCart/addTour/' + userId,
      orderItem
    );
  }

  addBundleToCart(bundleItem: TourBundle, userId: number): Observable<any> {
    return this.http.put<OrderItem>(
      'https://localhost:44333/api/shoppingCart/addTourBundle/' + userId,
      bundleItem
    );
  }

  removeFromCart(cartId: number, tourId: number): Observable<ShoppingCart> {
    return this.http.delete<ShoppingCart>(
      `https://localhost:44333/api/shoppingCart/removeTour/${cartId}?tourId=${tourId}`
    );
  }

  removeBundleFromCart(cartId: number, bundleId: number): Observable<ShoppingCart> {
    return this.http.delete<ShoppingCart>(
      `https://localhost:44333/api/shoppingCart/removeTourBundle/${cartId}?bundleId=${bundleId}`
    );
  }

  getCart(userId: number): Observable<ShoppingCart> {
    return this.http.get<ShoppingCart>(
      'https://localhost:44333/api/shoppingCart/' + userId
    );
  }

  createOrder(tourIds: number[], userId: number): Observable<ShoppingCart> {
    return this.http.post<ShoppingCart>(
      environment.apiHost + 'order/' + userId,
      tourIds
    );
  }

  getTourBundles(): Observable<PagedResults<TourBundle>> {
    return this.http.get<PagedResults<TourBundle>>(
      environment.apiHost + 'tourist/tourBundle'
    );
  }

  getBundlesForTour(tourId : number): Observable<PagedResults<TourBundle>> {
    return this.http.get<PagedResults<TourBundle>>(
      environment.apiHost + `tourist/tourBundle/${tourId}`
    );
  }

  buyBundle(bundleId: number, amount: number): Observable<PaymentRecord> {
    return this.http.post<PaymentRecord>(
      environment.apiHost + `tourist/tourBundle/purchase/${bundleId}`,
      amount
    );
  }

  getTouristOrders(userId: number): Observable<PagedResults<Order>> {
    return this.http.get<PagedResults<Order>>(
      environment.apiHost + 'order/orders/' + userId
    );
  }

  createCompositeTour(compositeTour: CompositeTour): Observable<CompositeTour> {
    return this.http.post<CompositeTour>(
      environment.apiHost + 'compositetour',
      compositeTour
    );
  }

  getTouristsCompositeToursTours(
    touristId: number
  ): Observable<PagedResults<CompositeTour>> {
    const params = new HttpParams().set('touristId', touristId);
    return this.http.get<PagedResults<CompositeTour>>(
      environment.apiHost + 'compositetour/touristscompositetours',
      { params }
    );
  }
  getWallet(userId: number): Observable<TouristWallet> {
    return this.http
      .get<TouristWallet>('https://localhost:44333/api/wallet/' + userId)
      .pipe(
        tap((result) => {
          this.wallet$.next(result);
        })
      );
  }

  addCoinsToUser(userId: number, coins: number): Observable<TouristWallet> {
    return this.http
      .put<TouristWallet>(
        'https://localhost:44333/api/wallet/addCoins/' + userId,
        coins
      )
      .pipe(
        tap((result) => {
          this.wallet$.next({
            ...this.wallet$.value,
            adventureCoins: this.wallet$.value.adventureCoins + coins,
          });
        })
      );
  }

  removeCoinsFromUser(coins: number): void {
    this.wallet$.next({
      ...this.wallet$.value,
      adventureCoins: this.wallet$.value.adventureCoins - coins,
    });
  }

  getPublishedAuthorTours(authorId: number): Observable<PagedResults<Tour>> {
    const params = new HttpParams().set('authorId', authorId);
    return this.http.get<PagedResults<Tour>>(
      environment.apiHost + 'tour/publishedauthortours',
      { params }
    );
  }

  addDiscount({couponCode}: { couponCode: string }): Observable<boolean> {
    const params = new HttpParams().set('couponHash', couponCode);
    return this.http.post<boolean>(
      environment.apiHost + 'shoppingCart/addDiscount', null, {params}
    );
  }

  getRecommendedTours() : Observable<PagedResults<Tour>> {
    return this.http.get<PagedResults<Tour>>(
      environment.apiHost + 'recommendation'
    );
  }

  getRecommendedActiveTours() : Observable<PagedResults<Tour>> {
    return this.http.get<PagedResults<Tour>>(
      environment.apiHost + 'recommendation/activeTours'
    );
  }

  getCheckpoints(tourId : number) : Observable<PagedResults<Checkpoint>> {
    return this.http.get<PagedResults<Checkpoint>>(
      environment.apiHost + `tour/getCheckpoints/${tourId}`
    );
  } 

}
