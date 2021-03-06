﻿module app.admin {
    "use strict";

    export namespace vidoviorganizacii {
        export class VnesuvanjeController extends base.ControllerBase {

            public vidOrganizacija: app.model.organizational.VidOrganizacija = new app.model.organizational.VidOrganizacija();
            public novZapis: boolean;
            public izmena: boolean;

            static $inject = [
                app.InjectionIds.vidOrganizacijaService,
                "$scope",
                "$state",
                "$stateParams"
            ];

            constructor(private vidOrganizacijaService: app.services.organizational.IVidOrganizacijaService,
                $scope: ng.IScope,
                private $state: ng.ui.IStateService,
                private $stateParams: ng.ui.IStateParamsService) {

                super();

                let vm: VnesuvanjeController = this;
                let vidOrganizacijaid: number = 0;
                if (vm.$stateParams["id"] != null) {
                    vidOrganizacijaid = parseInt(this.$stateParams["id"], 10);
                    if (vidOrganizacijaid !== 0) {
                        vm.vidOrganizacijaService.zemi(vidOrganizacijaid)
                            .then((result: app.model.organizational.VidOrganizacija): void => {
                                vm.vidOrganizacija = result;
                                $scope.$apply();
                            });
                    }
                }
                vm.novZapis = vidOrganizacijaid === 0;
                vm.izmena = !vm.novZapis;
            }

            public zapishi(): void {
                if (this.novZapis) {
                    this.vidOrganizacijaService.nov(this.vidOrganizacija)
                        .then((result: app.model.organizational.VidOrganizacija): void => {
                            this.$state.go("admin.vidoviorganizacii");
                        });
                } else {
                    this.vidOrganizacijaService.izmeni(this.vidOrganizacija)
                        .then((result: app.model.organizational.VidOrganizacija): void => {
                            this.$state.go("admin.vidoviorganizacii");
                        });
                }
            }
            public otkazhiSe(): void {
                this.$state.go("admin.vidoviorganizacii");
            }
        }
        angular.module("app.admin")
            .controller(app.InjectionIds.admin_vidoviOrganizacii_vnesuvanjeController, VnesuvanjeController);
    }
}