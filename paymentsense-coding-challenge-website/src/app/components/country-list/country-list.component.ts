import { Component, OnInit } from '@angular/core';
import { PageEvent } from "@angular/material";

import { CountryListItemModel } from '../../models/country-list-item.model';
import { PagedResponse } from '../../models/paged-response';

import { CountryListService } from "../../services/country-list/country-list.service";

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent implements OnInit {
  public totalItemsCount: number = 0;
  public pageIndex: number = 0;
  public pageSize: number = 10;
  public pageSizeOptions: number[] = [5, 10, 25, 100];
  public items: Array<CountryListItemModel>;

  constructor(private countryListService: CountryListService) { }

  ngOnInit() {
    this.initData(this.pageIndex, this.pageSize);
  }

  private initData(pageIndex: number, pageSize: number) {
    this.countryListService.Get(pageIndex + 1, pageSize)
      .subscribe(pagedResponse => {
        this.pageIndex = pagedResponse.pageIndex - 1;
        this.pageSize = pagedResponse.pageSize;
        this.totalItemsCount = pagedResponse.totalCount;
        this.items = pagedResponse.items;
      });
  }

  public paginatorEvent(event: PageEvent) {
    this.initData(event.pageIndex, event.pageSize);
  }



}
