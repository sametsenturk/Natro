import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']  
})
export class SearchComponent implements OnInit {

  constructor() { }

  isSearched: boolean = false;
  searchValue: string = "";

  ngOnInit(): void {
  }

  search(): void {
    console.log(this.searchValue);
  }

  addFavorite(): void {
    
  }

}
