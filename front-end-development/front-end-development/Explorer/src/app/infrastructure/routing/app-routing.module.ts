import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/feature-modules/layout/home/home.component';
import { LoginComponent } from '../auth/login/login.component';
import { ResetPasswordComponent } from '../auth/reset-password/reset-password..component';
import { EquipmentComponent } from 'src/app/feature-modules/administration/equipment/equipment.component';
import { AuthGuard } from '../auth/auth.guard';
import { RegistrationComponent } from '../auth/registration/registration.component';
import { TourPreferencesComponent } from 'src/app/feature-modules/marketplace/tour-preferences/tour-preferences.component';
import { TourRatingComponent } from 'src/app/feature-modules/tour-execution/tour-rating/tour-rating.component';
import { TouristEquipmentComponent } from 'src/app/feature-modules/marketplace/tourist-equipment/tourist-equipment.component';
import { RequestToJoinClubComponent } from 'src/app/feature-modules/marketplace/request-to-join-club/request-to-join-club.component';
import { ManageRequestToJoinClubComponent } from 'src/app/feature-modules/marketplace/manage-request-to-join-club/manage-request-to-join-club.component';
import { OwnerViewClubsComponent } from 'src/app/feature-modules/marketplace/owner-view-clubs/owner-view-clubs.component';
import { OwnerClubOptionsComponent } from 'src/app/feature-modules/marketplace/owner-club-options/owner-club-options.component';
import { TouristNotesComponent } from 'src/app/feature-modules/administration/tourist-notes/tourist-notes.component';
import { IssueReportsComponent } from 'src/app/feature-modules/administration/issue-reports/issue-reports.component';
import { ReportFormComponent } from 'src/app/feature-modules/tour-execution/report-form/report-form.component';
import { DestinationComponent } from 'src/app/feature-modules/tour-authoring/destination/destination.component';
import { CheckpointAddComponent } from 'src/app/feature-modules/tour-authoring/checkpoint-add/checkpoint-add.component';
import { TouristclubComponent } from 'src/app/feature-modules/marketplace/touristclub/touristclub.component';
import { TouristclubFormComponent } from 'src/app/feature-modules/marketplace/touristclub-form/touristclub-form.component';
import { TouristclubsOverviewComponent } from 'src/app/feature-modules/marketplace/touristclubs-overview/touristclubs-overview.component';
import { CommentComponent } from 'src/app/feature-modules/blog/comments/comment/comment.component';
import { CommentCrudComponent } from 'src/app/feature-modules/blog/comments/comment-crud/comment-crud.component';
import { BlogFormComponent } from 'src/app/feature-modules/blog/blog-form/blog-form.component';
import { CreateTourComponent } from 'src/app/feature-modules/tour-authoring/create-tour/create-tour.component';
import { TourSearchComponent } from 'src/app/feature-modules/marketplace/tour-search/tour-search.component';
import { UserProfileComponent } from 'src/app/feature-modules/layout/user-profile/user-profile.component';
import { ReviewTourComponent } from 'src/app/feature-modules/tour-authoring/review-tour/review-tour.component';
import { ApplicationRateFormComponent } from 'src/app/feature-modules/administration/application-rates/application-rate-form/application-rate-form.component';
import { ApplicationRatesTableComponent } from 'src/app/feature-modules/administration/application-rates/application-rates-table/application-rates-table.component';
import { TourCheckpointsDisplayComponent } from 'src/app/feature-modules/tour-authoring/tour-checkpoints-display/tour-checkpoints-display.component';
import { PublishTourComponent } from 'src/app/feature-modules/tour-authoring/publish-tour/publish-tour.component';
import { AuthorToursDisplayComponent } from 'src/app/feature-modules/tour-authoring/author-tours-display/author-tours-display.component';
import { AvailableTourPreviewComponent } from 'src/app/feature-modules/marketplace/available-tour-preview/available-tour-preview.component';
import { ShoppingCartComponent } from 'src/app/feature-modules/marketplace/shopping-cart/shopping-cart.component';
import { TouristBoughtToursComponent } from 'src/app/feature-modules/marketplace/tourist-bought-tours/tourist-bought-tours.component';
import { PositionSimulatorComponent } from 'src/app/feature-modules/tour-execution/position-simulator/position-simulator.component';
import { ReportCommentsComponent } from 'src/app/feature-modules/administration/report-comments/report-comments.component';
import { AdminGuard } from '../auth/admin.guard';
import { ErrorPageComponent } from 'src/app/shared/error-page/error-page.component';
import { BlogListComponent } from 'src/app/feature-modules/blog/blog-list/blog-list.component';
import { AuthorGuard } from '../auth/author.guard';
import { BlogPageComponent } from 'src/app/feature-modules/blog/blog-page/blog-page.component';
import { UpdateUserProfileComponent } from 'src/app/feature-modules/layout/user-profile/update-user-profile/update-user-profile.component';
import { TouristGuard } from '../auth/tourist.guard';
import { TourSaleComponent } from 'src/app/feature-modules/tour-authoring/tour-sale/tour-sale.component';
import { TourBundlesOverviewComponent } from 'src/app/feature-modules/tour-authoring/tour-bundles-overview/tour-bundles-overview.component';
import { ToursBundlesTouristOverviewComponent } from 'src/app/feature-modules/marketplace/tours-bundles-tourist-overview/tours-bundles-tourist-overview.component';
import { CreateCampaignComponent } from 'src/app/feature-modules/marketplace/create-campaign/create-campaign.component';
import { TouristCampaignsComponent } from 'src/app/feature-modules/marketplace/tourist-campaigns/tourist-campaigns.component';
import { EncounterComponent } from 'src/app/feature-modules/encounters/encounter/encounter.component';
import { EncountersExecutionComponent } from 'src/app/feature-modules/encounters/encounters-execution/encounters-execution.component';
import { UmComponent } from 'src/app/feature-modules/administration/um/um.component';
import { AuthorProfileComponent } from 'src/app/feature-modules/marketplace/author-profile/author-profile.component';
import { TourCreationComponent } from 'src/app/feature-modules/tour-tourist/tour-creation/tour-creation.component';
import { CreateCouponComponent } from 'src/app/feature-modules/tour-authoring/create-coupon/create-coupon.component';
import { TourFilterComponent } from 'src/app/feature-modules/marketplace/tour-filter/tour-filter.component';
import { ToursComponent } from 'src/app/feature-modules/tour-tourist/tours/tours.component';
import { SingleTourStatisticComponent } from 'src/app/feature-modules/tour-authoring/tour-statistic/single-tour-statistic/single-tour-statistic.component';
import { UserLocationComponent } from '../auth/user-location/user-location.component';
import { CheckoutPageComponent } from 'src/app/feature-modules/marketplace/checkout-page/checkout-page.component';
import { TourExecutionLeaderboardsComponent } from 'src/app/feature-modules/tour-execution/tour-execution-leaderboards/tour-execution-leaderboards.component';
import { TourOverviewPageComponent } from 'src/app/feature-modules/marketplace/tour-overview-page/tour-overview-page.component';


const routes: Routes = [

  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'add-checkpoint/:id', component: CheckpointAddComponent },
  { path: 'tour-preferences', component: TourPreferencesComponent, canActivate: [TouristGuard] }, //.
  { path: 'rate-tour', component: TourRatingComponent }, //.
  { path: 'manage-notes', component: TouristNotesComponent }, //.
  { path: 'club-overview/:id', component: TouristclubComponent },
  { path: 'create-club', component: TouristclubFormComponent },
  { path: 'clubs-overview', component: TouristclubsOverviewComponent },
  { path: 'blog/:id/newComment', component: CommentCrudComponent },
  { path: 'search-tours', component: TourSearchComponent }, //.
  { path: 'error-page', component: ErrorPageComponent }, //.
  { path: 'available-tours', component: AvailableTourPreviewComponent }, //.
  { path: 'shopping-cart', component: ShoppingCartComponent }, //.
  { path: 'purchased-tours', component: TouristBoughtToursComponent }, //.
  { path: 'tour-filter', component: TourFilterComponent }, //.

  // Admin
  { path: 'admin/equipment', component: EquipmentComponent, canActivate: [AdminGuard], }, //.
  { path: 'admin/manage-users', component: UmComponent, canActivate: [AdminGuard], }, //.
  { path: 'admin/encounters-overview', component: EncounterComponent, canActivate: [AdminGuard] },
  // Auth
  { path: 'join-club-request', component: RequestToJoinClubComponent, canActivate: [AuthGuard] }, //.
  { path: 'blog', component: BlogListComponent, canActivate: [AuthGuard] }, //.
  { path: 'blog/:id', component: BlogPageComponent, canActivate: [AuthGuard] },
  { path: 'review-tour', component: ReviewTourComponent, canActivate: [AuthGuard] }, //.
  { path: 'application-rate/create', component: ApplicationRateFormComponent, canActivate: [AuthGuard] }, //.
  { path: 'application-rates', component: ApplicationRatesTableComponent, canActivate: [AuthGuard] }, //.
  { path: 'single-tour-statistic/:id', component: SingleTourStatisticComponent, canActivate: [AuthGuard] },
  { path: 'user-location', component: UserLocationComponent, canActivate: [AuthGuard] },
  { path: 'tourist-leaderboards', component: TourExecutionLeaderboardsComponent, canActivate: [AuthGuard] },
  // Tourist

  { path: 'profile', component: UserProfileComponent, canActivate: [TouristGuard] }, //.
  { path: 'update-profile', component: UpdateUserProfileComponent, canActivate: [TouristGuard], }, //.
  { path: 'position-simulator/:tourId', component: PositionSimulatorComponent, canActivate: [TouristGuard] }, //.
  { path: 'position-simulator/:tourId/:isComposite', component: PositionSimulatorComponent, canActivate: [TouristGuard] }, //.
  { path: 'tourist/tourist-equipment', component: TouristEquipmentComponent, canActivate: [TouristGuard] }, // 
  { path: 'tourist/bundles', component: ToursBundlesTouristOverviewComponent, canActivate: [TouristGuard] }, // 
  { path: 'tourist/create-campaign', component: CreateCampaignComponent, canActivate: [TouristGuard] }, //. 
  { path: 'tourist/tourist-campaigns', component: TouristCampaignsComponent, canActivate: [TouristGuard] }, // 
  { path: 'encounters-execution', component: EncountersExecutionComponent, canActivate: [TouristGuard] },
  { path: 'tourist/create-tour', component: TourCreationComponent, canActivate: [TouristGuard] }, //.
  { path: 'tour-overview/:tourId', component: TourOverviewPageComponent },

  { path: 'tourist/club-requests-manager', component: ManageRequestToJoinClubComponent, canActivate: [TouristGuard] }, //.
  { path: 'tourist/tours', component: ToursComponent, canActivate: [TouristGuard] }, //.
  { path: 'checkout-page', component: CheckoutPageComponent, canActivate: [TouristGuard] }, //.

  // Author
  { path: 'author/profile', component: AuthorProfileComponent, canActivate: [AuthorGuard] }, //.

  { path: 'author/create-blog', component: BlogFormComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/create-new-tour', component: CreateTourComponent, canActivate: [AuthorGuard], }, //.
  { path: 'author/create-coupon', component: CreateCouponComponent, canActivate: [AuthorGuard] },
  { path: 'author/tour-checkpoints', component: TourCheckpointsDisplayComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/tours', component: AuthorToursDisplayComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/tour-review', component: ReviewTourComponent, canActivate: [AuthorGuard], }, //.
  { path: 'author/publish-tour', component: PublishTourComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/bundles', component: TourBundlesOverviewComponent, canActivate: [AuthorGuard] }, //. 
  { path: 'author/clubs-overview', component: OwnerViewClubsComponent, canActivate: [AuthorGuard] }, //.

  { path: 'author/club-options/:clubId', component: OwnerClubOptionsComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/issues', component: IssueReportsComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/submit-report', component: ReportFormComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/report/:id/comments', component: ReportCommentsComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/destinations', component: DestinationComponent, canActivate: [AuthorGuard] }, //.
  { path: 'author/tour-sale', component: TourSaleComponent, canActivate: [AuthorGuard] },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }



