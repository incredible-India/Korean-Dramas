import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './Component/home/home.component';

const routes: Routes = [

  {path: '' , component:HomeComponent}
  ,{path : "user",loadChildren:()=>import('./Modules/users/users.module').then(mod=>mod.UsersModule)}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
