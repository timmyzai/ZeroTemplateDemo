import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {AdminSharedModule} from '@app/admin/shared/admin-shared.module';
import {ProductsRoutingModule} from './products-routing.module';
import {ProductsComponent} from './products.component';
import {CreateOrEditProductsModalComponent} from './create-or-edit-products-modal.component';
import {ViewProductsModalComponent} from './view-products-modal.component';
import {ProductsUserLookupTableModalComponent} from './products-user-lookup-table-modal.component';
    					


@NgModule({
    declarations: [
        ProductsComponent,
        CreateOrEditProductsModalComponent,
        ViewProductsModalComponent,
        
    					ProductsUserLookupTableModalComponent,
    ],
    imports: [AppSharedModule, ProductsRoutingModule , AdminSharedModule ],
    
})
export class ProductsModule {
}
