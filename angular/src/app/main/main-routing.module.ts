﻿import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MembersComponent } from './members/members/members.component';
import { ProductsComponent } from './products/products/products.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'members/members', component: MembersComponent, data: { permission: 'Pages.Members' }  },
                    { path: 'products/products', component: ProductsComponent, data: { permission: 'Pages.Products' }  },
                    {
                        path: 'dashboard',
                        loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
                        data: { permission: 'Pages.Tenant.Dashboard' },
                    },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class MainRoutingModule {}
