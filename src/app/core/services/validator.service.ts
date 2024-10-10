import { Injectable } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';

@Injectable()
export class ValidatorService {
    constructor() {

    }
    isControlValid(control: AbstractControl): boolean {
        return control.valid && (control.dirty || control.touched);
    }

    isControlInvalid(control: AbstractControl): boolean {
        return control.invalid && (control.dirty || control.touched);
    }

    controlHasError(validation: string, control: AbstractControl | null): boolean {

        return control ? control.hasError(validation) && (control.dirty || control.touched) : false;
    }

    isControlTouched(control: AbstractControl): boolean {
        return control.dirty || control.touched;
    }

    mustMatch(controlName: string, matchingControlName: string) {
        return (formGroup: FormGroup) => {
            const control = formGroup.controls[controlName];
            const matchingControl = formGroup.controls[matchingControlName];

            if (matchingControl.errors && !matchingControl.errors['mustMatch']) {
                // return if another validator has already found an error on the matchingControl
                return;
            }

            // set error on matchingControl if validation fails
            if (control.value && control.value !== matchingControl.value) {
                matchingControl.setErrors({ mustMatch: true });
            } else {
                matchingControl.setErrors(null);
            }
        }
    }

    getControl(control: AbstractControl, path: string) {
        return control.get(path);
    }

    setFocusInvalid() {
        //this.notificationService.validator();
        const formInvalid = document.querySelector('form.ng-invalid');
        if (formInvalid) {
            const input = formInvalid.querySelector('.ng-invalid');
            if (input) {
                if (input.tagName.toLowerCase() == 'ng-select') {
                    const filterSelect = input.querySelector('.ng-input input');
                    (<HTMLElement>filterSelect)?.focus()
                }
                (<HTMLElement>input).focus()
            }
        }
    }
}