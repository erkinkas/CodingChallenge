import { Component, OnInit, OnDestroy } from '@angular/core';
import { PageEvent } from "@angular/material";

import { Subscription } from 'rxjs';

import { CountryListItemModel } from '../../models/';

import { CountryListService } from "../../services/";

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent implements OnInit, OnDestroy {
  public totalItemsCount: number = 0;
  public pageIndex: number = 0;
  public pageSize: number = 10;
  public pageSizeOptions: number[] = [5, 10, 25, 100];
  public items: Array<CountryListItemModel>;

  private subscriptions: Array<Subscription> = [];

  constructor(private countryListService: CountryListService) { }

  ngOnInit() {
    this.initData(this.pageIndex, this.pageSize);
  }

  private initData(pageIndex: number, pageSize: number) {
    this.subscriptions.push(
      this.countryListService.Get(pageIndex + 1, pageSize) // +1 and -1 due to backend page index starts from 1
        .subscribe(pagedResponse => {
          if (pagedResponse) {
            this.pageIndex = pagedResponse.pageIndex - 1;
            this.pageSize = pagedResponse.pageSize;
            this.totalItemsCount = pagedResponse.totalCount;
            this.items = pagedResponse.items;
          }
        })
    );
  }

  public paginatorEvent(event: PageEvent) {
    this.initData(event.pageIndex, event.pageSize);
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

}
