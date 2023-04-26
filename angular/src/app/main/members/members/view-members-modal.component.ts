import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetMembersForViewDto, MembersDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewMembersModal',
    templateUrl: './view-members-modal.component.html'
})
export class ViewMembersModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetMembersForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetMembersForViewDto();
        this.item.members = new MembersDto();
    }

    show(item: GetMembersForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
