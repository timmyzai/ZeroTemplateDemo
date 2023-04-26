import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { MembersComponent } from './members/members/members.component';
import { ViewMembersModalComponent } from './members/members/view-members-modal.component';
import { CreateOrEditMembersModalComponent } from './members/members/create-or-edit-members-modal.component';
import { MembersUserLookupTableModalComponent } from './members/members/members-user-lookup-table-modal.component';

import { ProductsComponent } from './products/products/products.component';
import { ViewProductsModalComponent } from './products/products/view-products-modal.component';
import { CreateOrEditProductsModalComponent } from './products/products/create-or-edit-products-modal.component';
import { ProductsUserLookupTableModalComponent } from './products/products/products-user-lookup-table-modal.component';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { PaginatorModule } from 'primeng/paginator';
import { EditorModule } from 'primeng/editor';
import { InputMaskModule } from 'primeng/inputmask';import { FileUploadModule } from 'primeng/fileupload';
import { TableModule } from 'primeng/table';

import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { MainRoutingModule } from './main-routing.module';

import { BsDatepickerConfig, BsDaterangepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxBootstrapDatePickerConfigService } from 'assets/ngx-bootstrap/ngx-bootstrap-datepicker-config.service';
import { SubheaderModule } from '@app/shared/common/sub-header/subheader.module';

NgxBootstrapDatePickerConfigService.registerNgxBootstrapDatePickerLocales();

@NgModule({
    imports: [
		FileUploadModule,
		AutoCompleteModule,
		PaginatorModule,
		EditorModule,
		InputMaskModule,		TableModule,

        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        BsDatepickerModule.forRoot(),
        BsDropdownModule.forRoot(),
        PopoverModule.forRoot(),
        SubheaderModule,
    ],
    declarations: [
		MembersComponent,

		ViewMembersModalComponent,
		CreateOrEditMembersModalComponent,
    MembersUserLookupTableModalComponent,
		ProductsComponent,

		ViewProductsModalComponent,
		CreateOrEditProductsModalComponent,
    ProductsUserLookupTableModalComponent,],
    providers: [
        { provide: BsDatepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerConfig },
        { provide: BsDaterangepickerConfig, useFactory: NgxBootstrapDatePickerConfigService.getDaterangepickerConfig },
        { provide: BsLocaleService, useFactory: NgxBootstrapDatePickerConfigService.getDatepickerLocale },
    ],
})
export class MainModule {}
