import {
  Component,
  Input,
  OnChanges,
  Output,
  EventEmitter,
} from '@angular/core';
import { Blog } from '../model/blog.model';
import { BlogService } from '../blog.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';
import { Rating } from '../model/rating.model';
import { Router } from '@angular/router';

@Component({
  selector: 'xp-blog-form',
  templateUrl: './blog-form.component.html',
  styleUrls: ['./blog-form.component.css'],
})
export class BlogFormComponent implements OnChanges {
  @Output() blogUpdated = new EventEmitter<null>();
  @Input() blog: Blog;
  selectedImages: FileList;
  markdownText: string;
  blogName: string;
  blogCreated: boolean = false;
  selectedFile: any;
  selectedFileNames: string = "No image selected";
  images: string[];

  constructor(private service: BlogService, private authSevice: AuthService, private router: Router) {}

  ngOnChanges(): void {
    this.blogForm.reset();
  }

  onFileChange(event: any) {
    if(this.selectedFileNames == 'No image selected'){
      this.selectedFileNames = '';
    }
    const inputElement = event.target as HTMLInputElement;
    this.selectedFile = event.target.files[0] ?? null;
    if(inputElement.files?.[0]?.name){
      this.selectedFileNames = inputElement.files?.[0]?.name;
    }
    this.selectedImages = event.target.files;
    this.images.push(this.selectedFileNames)
  }

  blogForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    images: new FormControl(''),
  });

  addBlog(): void {
    console.log('Logged user: ', this.authSevice.user$);
    let imagesNames = [];
    this.markdownText = this.blogForm.value.description || '';
    this.blogName = this.blogForm.value.name || '';

    for (let i = 0; i < this.selectedImages?.length; i++) {
      imagesNames.push(this.selectedImages[i].name);
    }
    console.log(imagesNames);

    const blog: Blog = {
      name: this.blogForm.value.name || '',
      description: this.blogForm.value.description || '',
      dateCreated: new Date(),
      images: this.images,
      status: 1,
      authorId: this.authSevice.user$.value.id,
      author: this.authSevice.user$.value.username,
      comments: new Array<Comment>(),
      ratings: new Array<Rating>(),
      rating: 0,
    };
    console.log(blog);
    this.service.addBlog(blog).subscribe({
      next: () => {
        this.blogUpdated.emit();
        this.blogCreated = true;

        this.blogForm.setValue({
          name: '',
          description: '',
          images: '',
        });

        this.router.navigate(['/blog'])


      },
    });
  }
}
