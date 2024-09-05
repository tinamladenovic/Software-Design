import { Component, OnInit } from '@angular/core';
import { MarketplaceService } from '../marketplace.service';
import TourBundle from '../../tour-authoring/model/tour-bundle';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { PaymentRecord } from '../model/payment-record';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from 'src/app/shared/confirmation-dialog/confirmation-dialog.component';
import { BundleItem } from '../model/available-tour-model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from 'src/app/infrastructure/auth/model/user.model';

@Component({
  selector: 'xp-tours-bundles-tourist-overview',
  templateUrl: './tours-bundles-tourist-overview.component.html',
  styleUrls: ['./tours-bundles-tourist-overview.component.css']
})
export class ToursBundlesTouristOverviewComponent implements OnInit{
  bundles: TourBundle[];
  user: User;
  constructor(private service: MarketplaceService,
    private toastr: ToastrService,
    private dialog: MatDialog,
    private authService: AuthService,
    ){}

  ngOnInit(): void {
    this.service.getTourBundles().subscribe({
      next: (result: PagedResults<TourBundle>) => {
        this.bundles = result.results;
        console.log(this.bundles);
      }
    })
    this.authService.user$.subscribe((user) => {
      this.user = user;
    });
  }

  buyBundle(bundle: TourBundle) : void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent,{
      data:{    
        message: "Please confirm purchase."
      }
    });
    dialogRef.afterClosed().subscribe((result: boolean | undefined) => {
      if(result == true){
        this.service.buyBundle(bundle.id, bundle.price).subscribe({
          next: () => {
            this.toastr.success("You purchased bundle successfully.")
          },
          error: () => {
            this.toastr.warning('Failed to create tourBundle.', 'Warning');
          }
        });
      }else{
        this.toastr.info("You successfully cancelled purchase.");
      }
    });
  }

  addToCart(bundle: TourBundle) : void {
    this.service.addBundleToCart(bundle, this.user.id).subscribe({
      next: (result: BundleItem) => {
        this.toastr.success("Bundle added to cart.")
      },
      error: (err: any) => {
        this.toastr.warning('Bundle already in cart.', 'Warning');
      },
    })
  }
}
