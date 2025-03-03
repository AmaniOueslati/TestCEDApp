import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { CrudService } from '../../service/crud.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add-intern',
  templateUrl: './add-Intern.component.html',
  styleUrls: ['./add-Intern.component.css']
})
export class AddInternComponent implements OnInit {
  
  InternForm: FormGroup;

  constructor(
    public formBuilder: FormBuilder,
    private router: Router,
    private ngZone: NgZone,
    private crudService: CrudService
  ) {
    this.InternForm = this.formBuilder.group({
      firstName: [''],
      lastName: [''],
      email: [''],
      team: [''],
    });
  }

  ngOnInit() {}

  onSubmit(): any {
    this.crudService.AddIntern(this.InternForm.value).subscribe(
      () => {
        console.log('Data added successfully!');
        this.ngZone.run(() => this.router.navigateByUrl('/interns-list'));
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
