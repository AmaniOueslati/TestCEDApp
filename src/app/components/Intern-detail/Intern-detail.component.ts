import { Component, OnInit, NgZone } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CrudService } from '../../service/crud.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-Intern-detail',
  templateUrl: './Intern-detail.component.html',
  styleUrls: ['./Intern-detail.component.scss'],
})
export class InternDetailComponent implements OnInit {
  getId: any;
  updateForm: FormGroup;

  constructor(
    public formBuilder: FormBuilder,
    private router: Router,
    private ngZone: NgZone,
    private activatedRoute: ActivatedRoute,
    private crudService: CrudService
  ) {
    this.getId = this.activatedRoute.snapshot.paramMap.get('id');

    this.crudService.GetIntern(this.getId).subscribe((res: { [x: string]: any; }) => {
      this.updateForm.setValue({
        firstName: res['firstName'],
        lastName: res['lastName'],
        email: res['email'],
        team: res['team'],
      });
    });

    this.updateForm = this.formBuilder.group({
      firstName: [''],
      lastName: [''],
      email: [''],
    });
  }

  ngOnInit() {}

  onUpdate(): any {
    this.crudService.updateIntern(this.getId, this.updateForm.value).subscribe(
      () => {
        console.log('Data updated successfully!');
        this.ngZone.run(() => this.router.navigateByUrl('/Intern-list'));
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
