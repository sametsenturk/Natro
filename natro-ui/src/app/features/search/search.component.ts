import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddFavoriteRequest } from 'src/app/core/models/favorite/request/addFavoriteRequest';
import { CheckDomainResponse } from 'src/app/core/models/rdap/response/checkDomainResponse';
import { FavoritesService } from 'src/app/core/services/favorites/favorites.service';
import { RdapService } from 'src/app/core/services/rdap/rdap.service';
import { DialogComponent } from 'src/app/shared/dialog/dialog.component';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers: [RdapService, FavoritesService, DatePipe]
})
export class SearchComponent implements OnInit {

  constructor(
    private rdapService: RdapService,
    private favoritesService: FavoritesService,
    private dialog: MatDialog,
    private datePipe: DatePipe
  ) { }

  isSearched: boolean = false;
  searchValue: string = "";
  searchResult: string = "";
  response: CheckDomainResponse;

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
            this.searchResult = "";
            this.searchResult += `Domain: ${res.domain} \n`;
            this.searchResult += `Is Available To Buy: ${res.isAvailableToBuy ? "Yes" : "No"} \n`;
            this.searchResult += `Name Server 1: ${res.nameserver1} \n`;
            this.searchResult += `Name Server 2: ${res.nameserver2} \n`;
            this.searchResult += `Last Change: ${this.datePipe.transform(res.lastChange, 'medium')} \n`;
            this.searchResult += `Expire Date: ${this.datePipe.transform(res.expireDate, 'medium')}`;
            this.isSearched = true;
            this.response = res;
         }
      });
    }
  }

  addFavorite(): void {
    let request = new AddFavoriteRequest();
    request.domain = this.searchValue;
    request.expireDate = this.response.expireDate;
    request.isAvailableToBuy = this.response.isAvailableToBuy;
    request.lastChange = this.response.lastChange;
    request.nameserver1 = this.response.nameserver1;
    request.nameserver2 = this.response.nameserver2;
    
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
