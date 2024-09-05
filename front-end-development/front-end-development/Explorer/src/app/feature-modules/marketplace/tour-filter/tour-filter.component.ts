import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { MarketplaceService } from '../marketplace.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Tour } from '../../tour-authoring/model/tour.model';
import { Registration } from 'src/app/infrastructure/auth/model/registration.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { User } from '../../administration/model/user.model';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AdministrationService } from '../../administration/administration.service';
import { People } from '../model/person.model';
import { TourExecutionService } from '../../tour-execution/tour-execution.service';
import { TourRating } from '../../tour-execution/model/tour-rating.model';


@Component({
  selector: 'xp-tour-filter',
  templateUrl: './tour-filter.component.html',
  styleUrls: ['./tour-filter.component.css']
})
export class TourFilterComponent implements OnInit{
  users: User[] = [];
  tourFilter: Tour[] = [];
  filteredTours: Tour[] = [];
  authorFilter: string = '';
  difficultyFilter: string = '';
  travelMethodFilter: string = '';
  tourNames:People[]=[];
  tourRatings:TourRating[]=[];
 
  
  constructor(private service: MarketplaceService, private authService: AuthService,private tourExecService:TourExecutionService) { }

  async ngOnInit(): Promise<void> {

    await this.getTours();
    this.getTourRating()
  }

  async getTours(): Promise<void> {
    this.service.getTours().subscribe({
      next: (result: PagedResults<Tour>) => {
        this.tourFilter = result.results;
        this.filteredTours = result.results
        this.applyFilters(); // Apply filters after fetching the tours
        for (let i = 0; i < this.tourFilter.length; i++) {
          const tour = this.tourFilter[i];
          this.getNameById(tour.authorId)
        }
      },
      error: () => {
        // Handle error
      }
    });
  }

  getTourRating(){
    this.tourExecService.getTourRating().subscribe((data:PagedResults<TourRating>)=>{
      this.tourRatings = data.results
    })
  }
  searchByName(listForFilter:Tour[]){
    if (this.authorFilter == '') {
      this.filteredTours = listForFilter
    }
    else {
      let searchList:Tour[] = []
      for (let j = 0; j < this.tourNames.length; j++) {
        const tourName = this.tourNames[j];
        if (tourName.name.toLocaleLowerCase().includes(this.authorFilter.toLowerCase())) {
          for (let i = 0; i < listForFilter.length; i++) {
            const tour = listForFilter[i];
            if (tourName.userId == tour.authorId) {
              if (!searchList.includes(tour)) {
                searchList.push(tour)
              }
            }
          }
        }
      }
      this.filteredTours = searchList;
    }
  }

  calculateRating(id: number): number {
    let filteredList: TourRating[] = this.tourRatings.filter((tourRating: TourRating) => {
      return tourRating.tourId === id;
    });
  
    if (filteredList.length === 0) {
      return 0;
    } else {
      var sum = 0;
      for (var i = 0; i < filteredList.length; i++) {
        sum += filteredList[i].rating;
      }
  
      var averageRating = sum / filteredList.length;
  
      // Round to one decimal place
      return parseFloat(averageRating.toFixed(1));
    }
  }
  

  applyFilters(): void {
    this.filteredTours = this.tourFilter.filter(tour => {
      let difficultyCondition = !this.difficultyFilter || tour.difficult.toString() === this.difficultyFilter.toString();
      let travelMethodCondition = !this.travelMethodFilter || tour.travelTimeAndMethod.some(method => method.travelMethod.toString() === this.travelMethodFilter);
      return difficultyCondition && travelMethodCondition;
    });
    this.searchByName(this.filteredTours);
  }

  sortToursByRating(highestFirst: boolean): void {
    if (highestFirst) {
      this.filteredTours = this.filteredTours.sort((a, b) => {
        return this.calculateRating(b.id) - this.calculateRating(a.id);
      });
    } else {
      this.filteredTours = this.filteredTours.sort((a, b) => {
        return this.calculateRating(a.id) - this.calculateRating(b.id);
      });
    }
  }
  
  

  getNameById(id: number){
    this.authService.getNameById(id).subscribe((data:People)=>{
      this.tourNames.push(data)
    })
  }

  calculateName(authorId:number){
    for (let i = 0; i < this.tourNames.length; i++) {
      const tourName = this.tourNames[i];
      if (tourName.userId == authorId) {
        return tourName.name
      }
    }
    return 'Not Found'
  }
  
  resetFilters(): void {
    this.authorFilter = ''; 
    this.difficultyFilter = ''; 
    this.travelMethodFilter = ''; 
    
  
    this.applyFilters(); 
  }
  
  mapDifficulty(difficulty: number): string {
    switch (difficulty) {
      case 0:
        return 'Easy';
      case 1:
        return 'Medium';
      case 2:
        return 'Hard';
      default:
        return 'Unknown';
    }
  }
  mapTravelMethod(method: number): string {
    switch (method) {
      case 0:
        return 'Car';
      case 1:
        return 'Bicycle';
      case 2:
        return 'Walking';
      default:
        return 'Unknown Method';
    }
  }
  
  

  }
  
  

