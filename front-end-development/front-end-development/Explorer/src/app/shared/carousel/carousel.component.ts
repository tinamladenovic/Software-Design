import { Input, ViewChild, Component, AfterViewInit, Directive, ContentChildren, ViewChildren, QueryList, TemplateRef, ElementRef } from '@angular/core';
import { AnimationFactory, animate, style, AnimationBuilder } from '@angular/animations';

@Directive({
  selector: '[carouselItem]'
})
export class CarouselItemDirective {
  constructor( public tpl : TemplateRef<any> ) { }
}

@Directive({
  selector: '.carousel-item'
})
export class CarouselItemElement {
  constructor( public element : ElementRef<any> ){ }
}

@Component({
  selector: 'xp-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements AfterViewInit {

  @ContentChildren( CarouselItemDirective ) items : QueryList<CarouselItemDirective>;
  @ViewChildren( CarouselItemElement, { read: ElementRef } ) private itemsElements : QueryList<ElementRef>;
  @ViewChild('carousel') private carousel : ElementRef;
  // @Input() timing = '250ms ease-in';
  @Input() showControls = true;
  private itemWidth : number;
  public offset = 0;
  public currentSlide = 0;
  // public carouselWrapperStyle = {};

  constructor( public _builder : AnimationBuilder ) { }

  ngAfterViewInit() {
    // this.itemWidth = this.itemsElements.first.nativeElement.getBoundingClientRect().width;
    this.itemWidth = 100;
  }

  change( state: string ) {
    if( this.currentSlide + 1 === this.items.length ) return;
    if( state == 'next' ){
      this.currentSlide = ( this.currentSlide + 1 ) % this.items.length;
    } else {
      this.currentSlide = ( ( this.currentSlide - 1 ) + this.items.length ) % this.items.length;
    }
    this.offset = this.currentSlide * this.itemWidth;
    const myAnimation : AnimationFactory = this._builder.build([
       animate( '250ms ease-in', style({ transform: `translateX(-${ this.offset }px)` }))
    ]);
    const player = myAnimation.create( this.carousel.nativeElement );
    player.play();
  }
}
