import { Directive, ElementRef, Renderer2, Input, HostListener } from '@angular/core';

@Directive({
  selector: '[highlight]'
})
export class HighlightDirective {
  @Input("inputColor") color: string;
  constructor(private ele:ElementRef, private renderer:Renderer2) {
   }

   ngOnInit(){
    this.renderer.setStyle(this.ele.nativeElement, "background-color", this.color);
   }

   @HostListener("mouseenter")
    applyColor(){
      this.renderer.setStyle(this.ele.nativeElement, "color", "White");
    }

    @HostListener("mouseleave")
    removeColor(){
      this.renderer.removeStyle(this.ele.nativeElement, "color");
    }
}
