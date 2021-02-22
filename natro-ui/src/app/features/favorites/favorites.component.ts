import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserFavoriteEntity } from 'src/app/core/models/entities/userFavoriteEntity';
import { FavoritesService } from 'src/app/core/services/favorites/favorites.service';
import { DialogComponent } from 'src/app/shared/dialog/dialog.component';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css'],
  providers: [FavoritesService]
})
export class FavoritesComponent implements OnInit {

  constructor(
    private favoritesService: FavoritesService,
    private dialog: MatDialog,
  ) { }

  displayedColumns: string[] = ['domain', 'isAvailableToBuy', 'delete'];
  dataSource: UserFavoriteEntity[];

  ngOnInit(): void {
    this.getFavorites();
  }

  getFavorites() {
    this.favoritesService.getList().subscribe(res => {
      if(!res.isSuccess) {
        this.dialog.open(DialogComponent, {
          data: {
            Title: "Error",
            Content: res.errorMessage
          }
        });
      } else {
        this.dataSource = res.favorites;
      }
    })
  }

  deleteFavorite(id: number) {
    this.favoritesService.deleteFavorite(id).subscribe(res => {
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
            Content: "Favorite deleted successfully."
          }
        });
        this.dataSource = this.dataSource.filter(x => x.id !== id);
      }
    })
  }

}
