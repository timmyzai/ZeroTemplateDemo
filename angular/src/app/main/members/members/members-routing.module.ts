import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MembersComponent} from './members.component';



const routes: Routes = [
    {
        path: '',
        component: MembersComponent,
        pathMatch: 'full'
    },
    
    
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MembersRoutingModule {
}
