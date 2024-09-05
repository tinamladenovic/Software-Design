import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TourPreferencesComponent } from './tour-preferences/tour-preferences.component';
import { TourPreferencesFormComponent } from './tour-preferences-form/tour-preferences-form.component';
import { MaterialModule } from 'src/app/infrastructure/material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { TouristEquipmentComponent } from './tourist-equipment/tourist-equipment.component';
import { TouristclubComponent } from './touristclub/touristclub.component';
import { TouristclubFormComponent } from './touristclub-form/touristclub-form.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { RequestToJoinClubComponent } from './request-to-join-club/request-to-join-club.component';
import { ManageRequestToJoinClubComponent } from './manage-request-to-join-club/manage-request-to-join-club.component';
import { MatTabsModule } from '@angular/material/tabs';
import { TouristclubsOverviewComponent } from './touristclubs-overview/touristclubs-overview.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { TouristclubEditComponent } from './touristclub-edit/touristclub-edit.component';
import { ClubUsersComponent } from './club-users/club-users.component';
import { MatIconModule } from '@angular/material/icon';
import { OwnerViewClubsComponent } from './owner-view-clubs/owner-view-clubs.component';
import { OwnerClubOptionsComponent } from './owner-club-options/owner-club-options.component';
import { AvailableTourPreviewComponent } from './available-tour-preview/available-tour-preview.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { TourReviewComponent } from './available-tour-preview/tour-review/tour-review.component';
import { TourHeaderComponent } from './available-tour-preview/tour-header/tour-header.component';
import { PictureSliderComponent } from './available-tour-preview/picture-slider/picture-slider.component';
import { MatTableModule } from '@angular/material/table';
import { TouristBoughtToursComponent } from './tourist-bought-tours/tourist-bought-tours.component';
import { TourSearchComponent } from './tour-search/tour-search.component';
import { SharedModule } from "../../shared/shared.module";
import { ToursBundlesTouristOverviewComponent } from './tours-bundles-tourist-overview/tours-bundles-tourist-overview.component';
import {MatDividerModule} from '@angular/material/divider';
import { CreateCampaignComponent } from './create-campaign/create-campaign.component';
import { CampaignTourComponent } from './campaign-tour/campaign-tour.component';
import { TouristCampaignsComponent } from './tourist-campaigns/tourist-campaigns.component';
import { SingleCampaignComponent } from './single-campaign/single-campaign.component';
import { AuthorProfileComponent } from './author-profile/author-profile.component';
import { TourAuthorComponent } from './available-tour-preview/tour-author/tour-author.component';
import { TourFilterComponent } from './tour-filter/tour-filter.component';
import { TourPreviewCardComponent } from './available-tour-preview/tour-recommendation/tour-preview-card/tour-preview-card.component';
import { CarouselComponent, CarouselItemDirective, CarouselItemElement } from 'src/app/shared/carousel/carousel.component';
import {MatChipsModule} from '@angular/material/chips';
import { MatTooltipModule } from '@angular/material/tooltip';
import { QuantitySelectorComponent } from './shopping-cart/quantity-selector/quantity-selector.component';
import { TourBundleCartDisplayComponent } from './shopping-cart/tour-bundle-cart-display/tour-bundle-cart-display/tour-bundle-cart-display.component';
import { CheckoutPageComponent } from './checkout-page/checkout-page.component';
import { GooglePayButtonModule } from "@google-pay/button-angular";
import { TourDisplayCheckoutComponent } from './checkout-page/tour-display/tour-display-checkout/tour-display-checkout.component';
import { TourBundleCheckpointDisplayComponent } from './checkout-page/tour-bundle-checkpoint-display/tour-bundle-checkpoint-display/tour-bundle-checkpoint-display.component';
import { TourOverviewPageComponent } from './tour-overview-page/tour-overview-page.component';
import {MatListModule} from '@angular/material/list';
import {MatRadioModule} from '@angular/material/radio';
@NgModule({
  declarations: [
    TourPreferencesComponent,
    TourPreferencesFormComponent,
    TouristclubComponent,
    TouristclubFormComponent,
    TouristEquipmentComponent,
    RequestToJoinClubComponent,
    ManageRequestToJoinClubComponent,
    TouristclubsOverviewComponent,
    TouristclubEditComponent,
    ClubUsersComponent,
    OwnerViewClubsComponent,
    OwnerClubOptionsComponent,
    AvailableTourPreviewComponent,
    ShoppingCartComponent,
    TourReviewComponent,
    TourHeaderComponent,
    PictureSliderComponent,
    TouristBoughtToursComponent,
    TourSearchComponent,
    ToursBundlesTouristOverviewComponent,
    CreateCampaignComponent,
    CampaignTourComponent,
    TouristCampaignsComponent,
    SingleCampaignComponent,
    AuthorProfileComponent,
    TourAuthorComponent,
    TourFilterComponent,
    TourPreviewCardComponent,
    CarouselItemDirective,
    CarouselItemElement,
    QuantitySelectorComponent,
    TourBundleCartDisplayComponent,
    CheckoutPageComponent,
    TourDisplayCheckoutComponent,
    TourBundleCheckpointDisplayComponent,
    TourOverviewPageComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    MatSelectModule,
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTabsModule,
    MatCardModule,
    MatSelectModule,
    MatIconModule,
    MaterialModule,
    MatTableModule,
    SharedModule,
    MatDividerModule,
    MatChipsModule,
    MatTooltipModule,
    GooglePayButtonModule,
    MatListModule,
    MatRadioModule
  ],
  exports: [
    TourPreferencesComponent,
    TourPreferencesFormComponent,
    TouristclubComponent,
    TouristEquipmentComponent,
    RequestToJoinClubComponent,
    ManageRequestToJoinClubComponent,
    MatInputModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    TouristclubComponent,
    TouristclubFormComponent,
    TouristclubsOverviewComponent,
    ClubUsersComponent,
    OwnerViewClubsComponent,
    OwnerClubOptionsComponent,
    CheckoutPageComponent
  ],
})
export class MarketplaceModule {}
