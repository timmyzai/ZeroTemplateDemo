import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {AdminSharedModule} from '@app/admin/shared/admin-shared.module';
import {MembersRoutingModule} from './members-routing.module';
import {MembersComponent} from './members.component';
import {CreateOrEditMembersModalComponent} from './create-or-edit-members-modal.component';
import {ViewMembersModalComponent} from './view-members-modal.component';
import {MembersUserLookupTableModalComponent} from './members-user-lookup-table-modal.component';
    					


@NgModule({
    declarations: [
        MembersComponent,
        CreateOrEditMembersModalComponent,
        ViewMembersModalComponent,
        
    					MembersUserLookupTableModalComponent,
    ],
    imports: [AppSharedModule, MembersRoutingModule , AdminSharedModule ],
    
})
export class MembersModule {
}
