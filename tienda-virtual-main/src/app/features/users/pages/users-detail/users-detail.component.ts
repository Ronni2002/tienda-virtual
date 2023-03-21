import { ActivatedRoute } from '@angular/router';
import { MockService } from './../../../../shared/services/mock/mock.service';
import { Component } from '@angular/core';
import { tap } from 'rxjs';

@Component({
  selector: 'app-users-detail',
  templateUrl: './users-detail.component.html',
  styleUrls: ['./users-detail.component.scss'],
})
export class UsersDetailComponent {
  user: any = {
    email: '',
    name: '',
    lastName: '',
    avatar: '',
  };

  constructor(
    private mockService: MockService,
    private activatedRoute: ActivatedRoute
  ) {
    this.activatedRoute.params.subscribe(({ id }) => this.getUserById(id));
  }

  private getUserById(id: string) {
    this.mockService
      .getById(id)
      .pipe(tap(({ data }) => ((this.user = data), console.log(data))))
      .subscribe();
  }
}
