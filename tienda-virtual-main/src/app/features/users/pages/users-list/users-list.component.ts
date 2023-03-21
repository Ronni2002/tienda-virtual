import { Component, ElementRef, ViewChild } from '@angular/core';
import { Product } from 'src/app/shared/models/product.model';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss'],
})
export class UsersListComponent {
  listOfData = [
    {
      id: 7,
      email: 'michael.lawson@reqres.in',
      name: 'Michael',
      username: 'Lawson',
      avatar: 'https://reqres.in/img/faces/7-image.jpg',
    },
    {
      id: 8,
      email: 'lindsay.ferguson@reqres.in',
      name: 'Lindsay',
      username: 'Ferguson',
      avatar: 'https://reqres.in/img/faces/8-image.jpg',
    },
    {
      id: 9,
      email: 'tobias.funke@reqres.in',
      name: 'Tobias',
      username: 'Funke',
      avatar: 'https://reqres.in/img/faces/9-image.jpg',
    },
    {
      id: 10,
      email: 'byron.fields@reqres.in',
      name: 'Byron',
      username: 'Fields',
      avatar: 'https://reqres.in/img/faces/10-image.jpg',
    },
    {
      id: 11,
      email: 'george.edwards@reqres.in',
      name: 'George',
      username: 'Edwards',
      avatar: 'https://reqres.in/img/faces/11-image.jpg',
    },
    {
      id: 12,
      email: 'rachel.howell@reqres.in',
      name: 'Rachel',
      username: 'Howell',
      avatar: 'https://reqres.in/img/faces/12-image.jpg',
    },
  ];
  @ViewChild('search') searchValue!: ElementRef;

  constructor() {}

}
