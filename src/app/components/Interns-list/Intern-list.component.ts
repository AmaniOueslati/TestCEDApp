import { Component, OnInit } from '@angular/core';
import { CrudService } from '../../service/crud.service';

@Component({
  selector: 'app-Interns-list',
  templateUrl: './Intern-list.component.html',
  styleUrls: ['./Intern-list.component.css'],
})
export class InternsListComponent implements OnInit {
  Interns: any = [];

  constructor(private crudService: CrudService) {}

  ngOnInit(): void {
    this.crudService.GetInterns().subscribe((res: any) => {
      console.log(res);
      this.Interns = res;
    });
  }

  delete(id: any, i: any) {
    console.log(id);
    if (window.confirm('Do you want to go ahead?')) {
      this.crudService.deleteIntern(id).subscribe(() => {
        this.Interns.splice(i, 1);
      });
    }
  }
}
