import { OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";

export class BaseComponent implements OnDestroy {
    private suscriptions: Subscription [] = [];

    ngOnDestroy(): void {
        this.suscriptions.forEach(x => x.unsubscribe());
    }

    unsubscribeOnDestroy(suscription: Subscription) {
        this.suscriptions.push(suscription);
    }

}