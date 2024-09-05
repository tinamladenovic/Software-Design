import { Component, Input, OnInit } from '@angular/core';
import { Checkpoint } from 'src/app/feature-modules/tour-authoring/model/checkpoint.model';

@Component({
  selector: 'xp-picture-slider',
  templateUrl: './picture-slider.component.html',
  styleUrls: ['./picture-slider.component.css'],
})
export class PictureSliderComponent implements OnInit {
  ngOnInit(): void {
    if (this.checkpoints.length == 0) {
      this.images.push(this.default_image);
    } else {
      for (let i = 0; i < this.checkpoints.length; i++) {
        this.images.push(this.checkpoints[i].pictureURL);
      }
    }
  }

  @Input() checkpoints: Checkpoint[];
  @Input() imageSize: string = '100';
  @Input() imageSize2: string;
  images: string[] = [];
  default_image: string = 'assets/images/No-Image.svg.png';
  currentImageIndex = 0;

  prevImage() {
    this.currentImageIndex =
      (this.currentImageIndex - 1 + this.images.length) % this.images.length;
  }

  nextImage() {
    this.currentImageIndex = (this.currentImageIndex + 1) % this.images.length;
  }
}
