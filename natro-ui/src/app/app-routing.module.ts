import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FavoritesComponent } from './features/favorites/favorites.component';
import { LoginComponent } from './features/login/login.component';
import { ProfileComponent } from './features/profile/profile.component';
import { SearchComponent } from './features/search/search.component';


const routes: Routes = [
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "search",
    component: SearchComponent
  },
  {
    path: "favorites",
    component: FavoritesComponent
  },
  {
    path: "profile",
    component: ProfileComponent
  },
  { path: "**", redirectTo: "/search" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
