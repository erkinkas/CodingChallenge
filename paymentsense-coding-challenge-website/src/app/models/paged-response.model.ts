export class PagedResponse<T> {
  pageIndex: number;
  pageSize: number;
  totalCount: number;
  totalPageCount: number;
  items: Array<T>;
}
