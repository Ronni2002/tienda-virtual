import { NzDividerModule } from 'ng-zorro-antd/divider';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzRateModule } from 'ng-zorro-antd/rate';
import { NzSegmentedModule } from 'ng-zorro-antd/segmented';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NzCardModule,
    NzTableModule,
    NzButtonModule,
    NzFormModule,
    NzAvatarModule,
    FormsModule,
    ReactiveFormsModule,
    NzInputModule,
    NzSelectModule,
    NzCollapseModule,
    NzImageModule,
    NzDescriptionsModule,
    NzRadioModule,
    NzTagModule,
    NzBadgeModule,
    NzRateModule,
    NzDividerModule,
    NzSegmentedModule
  ],
  exports:[
    NzCardModule,
    NzTableModule,
    NzButtonModule,
    NzFormModule,
    NzAvatarModule,
    NzIconModule,
    FormsModule,
    ReactiveFormsModule,
    NzInputModule,
    NzSelectModule,
    NzCollapseModule,
    NzImageModule,
    NzDescriptionsModule,
    NzRadioModule,
    NzTagModule,
    NzBadgeModule,
    NzRateModule,
    NzDividerModule,
    NzSegmentedModule

  ]
})
export class SharedModule { }
