import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { MembersServiceProxy, CreateOrEditMembersDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

             import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { MembersUserLookupTableModalComponent } from './members-user-lookup-table-modal.component';

@Component({
    selector: 'createOrEditMembersModal',
    templateUrl: './create-or-edit-members-modal.component.html'
})
export class CreateOrEditMembersModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('membersUserLookupTableModal', { static: true }) membersUserLookupTableModal: MembersUserLookupTableModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    members: CreateOrEditMembersDto = new CreateOrEditMembersDto();

    userName = '';


    constructor(
        injector: Injector,
        private _membersServiceProxy: MembersServiceProxy,
             private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }
    
    show(membersId?: string): void {
    

        if (!membersId) {
            this.members = new CreateOrEditMembersDto();
            this.members.id = membersId;
            this.userName = '';

            this.active = true;
            this.modal.show();
        } else {
            this._membersServiceProxy.getMembersForEdit(membersId).subscribe(result => {
                this.members = result.members;

                this.userName = result.userName;

                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._membersServiceProxy.createOrEdit(this.members)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }

    openSelectUserModal() {
        this.membersUserLookupTableModal.id = this.members.userId;
        this.membersUserLookupTableModal.displayName = this.userName;
        this.membersUserLookupTableModal.show();
    }


    setUserIdNull() {
        this.members.userId = null;
        this.userName = '';
    }


    getNewUserId() {
        this.members.userId = this.membersUserLookupTableModal.id;
        this.userName = this.membersUserLookupTableModal.displayName;
    }


    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
