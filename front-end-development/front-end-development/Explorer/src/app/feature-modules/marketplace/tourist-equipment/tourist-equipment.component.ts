import { Component, OnInit } from '@angular/core';
import { TouristEquipment } from '../model/touristEquipment.model';
import { MarketplaceService } from '../marketplace.service';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Equipment } from '../../administration/model/equipment.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Component({
  selector: 'xp-tourist-equipment',
  templateUrl: './tourist-equipment.component.html',
  styleUrls: ['./tourist-equipment.component.css']
})
export class TouristEquipmentComponent implements OnInit { 
  touristEquipment: TouristEquipment[] = [];
  allEquipment: Equipment[] = [];
  userId: any;
  
  constructor(private service: MarketplaceService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.userId = this.authService.user$.getValue().id;
    this.getTouristEquipment();
    this.getEquipment();
  }

  getEquipment(): void{
    this.service.getEquipment().subscribe({
      next: (result: PagedResults<Equipment>) => {
        this.allEquipment = result.results;
      },
      error: () => {
      }
    })
  }

  getTouristEquipment(): void {
    this.service.getTouristEquipment(this.userId).subscribe({
      next: (result: PagedResults<TouristEquipment>) => {
        this.touristEquipment = result.results;
      },
      error: () => {
      }
    })
  }
  
  getEquipmentName(equipmentId: number): string {
    const equipment = this.allEquipment.find(equipment => equipment.id === equipmentId);
    if (equipment) {
      return equipment.name;
    }
    return 'Equipment not found';
  }
  
  getEquipmentDescription(equipmentId: number): string {
    const equipment = this.allEquipment.find(equipment => equipment.id === equipmentId);
    if (equipment) {
      return equipment.description; 
    }
    return 'Equipment not found';
  }
  
  
  deleteEquipment(id: number): void {
    this.service.deleteEquipment(id).subscribe({
      next: () => {
        this.getTouristEquipment();
      },
    })
 }

  onAddClicked(eqId: number): void {
    const existingEquipment = this.touristEquipment.find((eq) => eq.equipmentId === eqId);

    if (existingEquipment) {
      console.log('Equipment with the same ID already exists:', existingEquipment);
      return;
    }
    const newTouristEquipment: TouristEquipment = {
      touristId: this.userId,
      equipmentId: eqId,
    };

    this.service.addTouristEquipment(newTouristEquipment).subscribe(
        (response: TouristEquipment) => {
            console.log('Tourist equipment created successfully with id:', response.id);
            this.getTouristEquipment();
        },
        (error: any) => {
            console.error('Error creating tourist equipment:', error);
        },
        () => {
            console.log('Create request completed');
        }
    );
  }
}
