import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Equipment } from './model/equipment.model';
import { Report } from './model/issue-reports.model';
import { environment } from 'src/env/environment';
import { Observable } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TouristNotes } from './model/touristNotes.model';
import { User } from './model/user.model';
import { ApplicationRate } from 'src/app/infrastructure/auth/model/application-rate.model';
import { ReportComment } from './model/report-comments';

@Injectable({
  providedIn: 'root',
})
export class AdministrationService {
  constructor(private http: HttpClient) {}

  getEquipment(): Observable<PagedResults<Equipment>> {
    return this.http.get<PagedResults<Equipment>>(
      environment.apiHost + 'administration/equipment'
    );
  }

  deleteEquipment(id: number): Observable<Equipment> {
    return this.http.delete<Equipment>(
      environment.apiHost + 'administration/equipment/' + id
    );
  }

  addEquipment(equipment: Equipment): Observable<Equipment> {
    return this.http.post<Equipment>(
      environment.apiHost + 'administration/equipment',
      equipment
    );
  }

  updateEquipment(equipment: Equipment): Observable<Equipment> {
    return this.http.put<Equipment>(
      environment.apiHost + 'administration/equipment/' + equipment.id,
      equipment
    );
  }

  getUsers(
    pageSize: number,
    pageIndex: number
  ): Observable<PagedResults<User>> {
    const options = {
      params: new HttpParams()
        .set('pageSize', pageSize.toString())
        .set('page', (pageIndex + 1).toString()),
    };
    return this.http.get<PagedResults<User>>(
      environment.apiHost + 'administration/users',
      options
    );
  }

  getTouristNotes(): Observable<PagedResults<TouristNotes>> {
    return this.http.get<PagedResults<TouristNotes>>(
      environment.apiHost + 'tourism/touristNote'
    );
  }

  deleteTouristNote(id: number): Observable<TouristNotes> {
    return this.http.delete<TouristNotes>(
      environment.apiHost + 'tourism/touristNote/' + id
    );
  }

  addTouristNote(touristNote: TouristNotes): Observable<TouristNotes> {
    return this.http.post<TouristNotes>(
      environment.apiHost + 'tourism/touristNote',
      touristNote
    );
  }

  updateTouristNote(touristNote: TouristNotes): Observable<TouristNotes> {
    return this.http.put<TouristNotes>(
      environment.apiHost + 'tourism/touristNote/' + touristNote.id,
      touristNote
    );
  }
  getIssue(): Observable<PagedResults<Report>> {
    return this.http.get<PagedResults<Report>>(
      'https://localhost:44333/api/administration/report'
    );
  }

  deleteIssue(id: number): Observable<Report> {
    return this.http.delete<Report>(
      environment.apiHost + 'administration/report/' + id
    );
  }

  deleteComment(id: number): Observable<ReportComment> {
    return this.http.delete<ReportComment>(
      environment.apiHost + 'administration/report/' + id + "/1"
    );
  }

  getReportComments(reportId: Number): Observable<PagedResults<ReportComment>> {
    return this.http.get<PagedResults<ReportComment>>(
      environment.apiHost + 'administration/report/' + reportId
    );
  }

  addReportComment(reportComment: ReportComment): Observable<ReportComment> {
    return this.http.post<ReportComment>(
      environment.apiHost + 'administration/report',
      reportComment
    );
  }

  blockUser(id: number): Observable<User> {
    return this.http.put<User>(
      environment.apiHost + 'administration/users/' + id + '/block',
      {}
    );
  }

  createApplicationRate(
    applicationRate: ApplicationRate
  ): Observable<ApplicationRate> {
    return this.http.post<ApplicationRate>(
      environment.apiHost + 'administration/applicationRate',
      applicationRate
    );
  }

  getApplicationRates(
    pageSize: number,
    pageIndex: number
  ): Observable<PagedResults<ApplicationRate>> {
    const options = {
      params: new HttpParams()
        .set('pageSize', pageSize.toString())
        .set('page', (pageIndex + 1).toString()),
    };
    return this.http.get<PagedResults<ApplicationRate>>(
      environment.apiHost + 'administration/applicationRate',
      options
    );
  }
}
