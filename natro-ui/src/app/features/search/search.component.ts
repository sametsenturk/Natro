import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddFavoriteRequest } from 'src/app/core/models/favorite/request/addFavoriteRequest';
import { FavoritesService } from 'src/app/core/services/favorites/favorites.service';
import { RdapService } from 'src/app/core/services/rdap/rdap.service';
import { DialogComponent } from 'src/app/shared/dialog/dialog.component';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers: [RdapService, FavoritesService]
})
export class SearchComponent implements OnInit {

  constructor(
    private rdapService: RdapService,
    private favoritesService: FavoritesService,
    private dialog: MatDialog,
  ) { }

  isSearched: boolean = false;
  searchValue: string = "";
  searchResult: string = "";

  ngOnInit(): void {
  }

  search(): void {
    if(this.searchValue !== null && this.searchValue !== undefined && this.searchValue.length < 31)
    {
      this.rdapService.checkDomain(this.searchValue).subscribe(res => {
         if(!res.isSuccess) {
          this.dialog.open(DialogComponent, {
            data: {
              Title: "Error",
              Content: res.errorMessage
            }
          });
         } else {
            this.searchResult = (res.domain + "/" + res.isAvailableToBuy + "/" + res.ownerAdress);
            this.isSearched = true;
         }
      });
    }
  }

  addFavorite(): void {
    let request = new AddFavoriteRequest();
    request.domain = this.searchValue;
    this.favoritesService.addFavorite(request).subscribe(res => {
      if(!res.isSuccess) {
        this.dialog.open(DialogComponent, {
          data: {
            Title: "Error",
            Content: res.errorMessage
          }
        });
       } else {
        this.dialog.open(DialogComponent, {
          data: {
            Title: "Success",
            Content: `The ${this.searchValue} added to favorites successfully.` 
          }
       });
      }
    });
  }

}
