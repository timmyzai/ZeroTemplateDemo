import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetProductsForViewDto, ProductsDto , ProductType} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewProductsModal',
    templateUrl: './view-products-modal.component.html'
})
export class ViewProductsModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetProductsForViewDto;
    productType = ProductType;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetProductsForViewDto();
        this.item.products = new ProductsDto();
    }

    show(item: GetProductsForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
