import { Component, OnInit } from '@angular/core';
import { TourAuthoringService } from '../tour-authoring.service';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import TourBundle from '../model/tour-bundle';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'xp-tour-bundles-overview',
  templateUrl: './tour-bundles-overview.component.html',
  styleUrls: ['./tour-bundles-overview.component.css']
})
export class TourBundlesOverviewComponent implements OnInit{

  bundles: TourBundle[] = [];
  displayedColumns: string[] = ['name', 'price', 'status', 'publish', 'archieve'];
  constructor(
    private service: TourAuthoringService,
    private toastr: ToastrService
  ){}
  
  ngOnInit(): void {
    this.service.getAuthorBundles().subscribe({
      next: (result: PagedResults<TourBundle>) => {
        this.bundles = result.results;
        console.log(this.bundles);
      },
      error: (err: any) => {
        console.error('Error fetching bundles:', err);
      }
    });
  }

  publishTour(id : number) : void {
    this.service.publishBundle(id).subscribe({
      next: (result: TourBundle) =>{
        this.toastr.success("You successfully published bundle " + result.name);
        this.fetchUpdatedData();
      },
      error: (err: any) => {
        this.toastr.warning("There must be at least 2 published tours to publish bundle!");
      }
    })
  }

  archieveTour(bundle: TourBundle) : void {
    this.service.archieveBundle(bundle.id).subscribe({
      next: (result: TourBundle) =>{
        this.toastr.info("You successfully archived bundle " + result.name);
        this.fetchUpdatedData();
      },
      error: (err: any) => {
        this.toastr.warning("error", err);
      }
    })
  }

  canPublish(id : number) : boolean {
    const tourBundle = this.bundles.find(bundle => bundle.id === id);

    if (tourBundle) {
      const publishedToursCount = tourBundle.tours.filter(tour => tour.status == 1).length;
      return publishedToursCount >= 2;
    }

    return false;
  }
  
  private fetchUpdatedData(): void {
    this.service.getAuthorBundles().subscribe({
      next: (result: PagedResults<TourBundle>) => {
        this.bundles = result.results;
      },
      error: (err: any) => {
        console.error('Error fetching bundles:', err);
      }
    });
  }
}
