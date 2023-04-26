import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { ProductsServiceProxy, CreateOrEditProductsDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

             import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { ProductsUserLookupTableModalComponent } from './products-user-lookup-table-modal.component';

@Component({
    selector: 'createOrEditProductsModal',
    templateUrl: './create-or-edit-products-modal.component.html'
})
export class CreateOrEditProductsModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('productsUserLookupTableModal', { static: true }) productsUserLookupTableModal: ProductsUserLookupTableModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    products: CreateOrEditProductsDto = new CreateOrEditProductsDto();

    userName = '';


    constructor(
        injector: Injector,
        private _productsServiceProxy: ProductsServiceProxy,
             private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }
    
    show(productsId?: string): void {
    

        if (!productsId) {
            this.products = new CreateOrEditProductsDto();
            this.products.id = productsId;
            this.userName = '';

            this.active = true;
            this.modal.show();
        } else {
            this._productsServiceProxy.getProductsForEdit(productsId).subscribe(result => {
                this.products = result.products;

                this.userName = result.userName;

                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._productsServiceProxy.createOrEdit(this.products)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }

    openSelectUserModal() {
        this.productsUserLookupTableModal.id = this.products.userId;
        this.productsUserLookupTableModal.displayName = this.userName;
        this.productsUserLookupTableModal.show();
    }


    setUserIdNull() {
        this.products.userId = null;
        this.userName = '';
    }


    getNewUserId() {
        this.products.userId = this.productsUserLookupTableModal.id;
        this.userName = this.productsUserLookupTableModal.displayName;
    }


    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
