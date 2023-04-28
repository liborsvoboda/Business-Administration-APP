<template>
    <div class="container" v-show="authUser=='true' && adminAccount">
        <div v-show="!loadingFinished" class="loading">Loading&#8230;</div>
        <div class="row justify-content-center">

            <div class="col-lg-11 col-xl-9">

                <div class="d-flex flex-row justify-content-between align-items-center my-3">
                    <div class="d-flex">
                        <input type="text" class="form-control py-2" placeholder="Napište co chcete hledat" v-model="fn_FilteredList" />
                    </div>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" style="padding-right: 3px;" title="Načti" alt="Načti" v-on:click="loadClient(fn_FilteredList);">
                        <span class="fas fa-spinner"></span>
                    </a>&nbsp;&nbsp;&nbsp;&nbsp;

                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="Nová Kampaň" alt="Nová Kampaň" v-on:click="fn_runRoute('NewCampaign');">
                        <span class="fa fa-plus"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="Kampaně" alt="Kampaně" v-on:click="fn_runRoute('Campaigns');">
                        <span class="far fa-paper-plane"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="Nový A/B test" alt="Nový A/B test" v-on:click="fn_runRoute('NewAbTest');">
                        <span class="fa fa-plus"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="A/B testy" alt="A/B testy" v-on:click="fn_runRoute('AbTesting');">
                        <span class="fas fa-chart-pie"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="Instalace Pixelu" alt="Instalace Pixelu" v-on:click="fn_runRoute('PixelInstallation');">
                        <span class="far fa-file-code"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="Heureka" alt="Heureka" v-on:click="fn_runRoute('HeurekaApi');">
                        <span class="fas fa-key"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="Zboží" alt="Zboží" v-on:click="fn_runRoute('ZboziApi');">
                        <span class="fas fa-key"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: !keySelected}" style="padding-right: 3px;" title="Váš Účet" alt="Váš Účet" v-on:click="fn_runRoute('Settings');">
                        <span class="fas fa-cogs"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: (!keySelected || adminGroupId !== 999)}" style="padding-right: 3px;" title="Fakturace" alt="Fakturace" v-on:click="fn_runRoute('AdminCredits');">
                        <span class="fas fa-shopping-basket"></span>
                    </a>
                    <span class="fa"></span>
                    <a class="btn btn-outline-secondary" :class="{disabled: (!keySelected || adminGroupId !== 999)}" style="padding-right: 3px;" title="DB Nástroje" alt="DB Nástroje" v-on:click="fn_runRoute('AdminScripts');">
                        <span class="fa fa-database"></span>
                    </a>
                </div>

                <div class="d-flex flex-row justify-content-between align-items-center my-3">
                    <div>
                        <input type="text" :readonly="(1== 1) ? true : false" class="form-control py-2" placeholder="Vybraný klíč" v-model="selectedKey" />
                    </div>
                    <div>
                        <a class="btn btn-outline-secondary btn_new_campaign" :class="{disabled: !keySelected}" v-on:click="fn_setUserKey();">
                            <span class="fa"></span> Zrušit výběr
                        </a>
                        <a class="btn btn-outline-secondary btn_new_campaign" :class="{disabled: (keySelected || !fn_FilteredList || adminGroupId===999 || !fn_checkValidEmail(fn_FilteredList.toLowerCase()) )}" v-on:click="fn_setAdminGroup();">
                            <span class="fa"></span> Přidat Klienta
                        </a>
                        <a class="btn btn-outline-secondary btn_new_campaign" v-on:click="fn_runRoute('AdminNDictionary');" :class="{disabled: (adminGroupId !== 999)}" >
                            <span class="fa"></span> Notif.Slovník
                        </a>
                    </div>
                </div>

                <div class="list-group shadow-sm">
                    <p class="list-group-item group_item_blue bold width_100">Seznam registrovaných klientů</p>
                    <div v-for="customer,index in filteredList" v-if="(customer.RegEmail.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) >
                        -1
                        || customer.Name.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1
                        || customer.Surname.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1
                        || customer.uuid.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1
                        || customer.StreetACP.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1
                        || customer.City.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1
                        || customer.Company.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1
                        )" v-on:click="fn_setUserKey(customer.uuid,customer.RegEmail);" class="list-group-item d-flex justify-content-between align-items-center list-group-item-action pointer">
                        <span class="width_100">
                            <div class="descipt text-left" style="line-height: 1.5em;">
                                <i style="color:royalblue;opacity:1;background-color: #edf6e2;" class="fa fa-question-circle pointer"
                                   v-tooltip.bottom.end.click="{html: 'profile_' + index}"></i>

                                <strong>EMAIL:</strong> {{customer.RegEmail}} | <strong>JMÉNO:</strong> {{customer.Name}} {{customer.Surname}} | <strong>FIRMA:</strong> {{customer.Company}}
                                <div><strong>TARIF:</strong> {{customer.PaymentVersion}} - {{translateValue(customer.InvoicePeriod)}} | <strong>KREDITY:</strong> {{customer.CreditCounts}}/{{customer.CreditVariant}} | <strong>SKUPINA:</strong> {{customer.groupId}}<!-- | <strong></strong>PIXEL: {{translateValue(pixelExistList.indexOf(customer.uuid) >-1)}}--> | <strong>HEURÉKA:</strong> {{translateValue(customer.StepHeurekaFinished)}} | <strong>ZBOŽÍ:</strong> {{translateValue(customer.stepZbozifinished)}} </div>
                                <div v-bind:id="'profile_' + index" class="descipt_url text-left" style="background-color:transparent;">{{customer}}</div>

                            </div>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
     
</template>
<script>
    import Vue from 'vue';
    import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';
    import SlimDialog from 'v-slim-dialog';
    import NProgress from 'nprogress';
    //import NProgress from 'nprogress';

    Vue.use(SlimDialog);
    Vue.use(VueI18n);
    Vue.use(VueCookie);

    export default {
        data() {
            return {
                creditsList:[],
                CustomerKeyList: [],
                filteredList: [],
                clientList: [],
                pixelExistList: [],
                fn_FilteredList: "",
                authUser: Vue.cookie.get('logged') || false,
                adminUuid: null,
                adminGroupId: null,
                adminAccount: false,
                //loadingFinished: false,
                keySelected: false,
                selectedKey:""
            } 
        },
        methods: {
            loadClient(filter) {
                this.loadingFinished = false;
                NProgress.start();
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_users",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.adminUuid, filter: (filter.length > 0) ? filter: 'allData' })
                }).done(function (data) {
                    if (data.result === 1) {
                        if (that.adminGroupId === 999) {
                            that.filteredList = data.users;
                            that.clientList = data.users;
                        }
                        else {
                            that.clientList = data.users;
                            that.filteredList = data.users.filter(function (item) { return item.groupId === that.adminGroupId; });
                        }
                    }
                });
                NProgress.done();
                that.loadingFinished = true;
            },
            translateValue(value) {
                var result = "";

                if (value == undefined) {
                    result = "NE";
                }
                else {
                    switch (value.toString()) {
                        case "false":
                            result = "NE";
                            break;
                        case "true":
                            result = "ANO";
                            break;
                        case "month":
                            result = "měsíc";
                            break;
                        case "year":
                            result = "rok";
                            break;
                        default:
                            result = "";
                    }
                }
                return result;
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            fn_checkValidEmail(value) {
                if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(value)) {
                    return (true)
                }
                return (false)
            },
            fn_setUserKey(key, email) {
                if (key === undefined) {
                    this.$store.state.AdminModule.adminUserKey = null;
                    this.$store.state.AdminModule.adminUserEmail = null;
                    this.selectedKey = null;
                    this.keySelected = false;
                }
                else {
                    this.$store.state.AdminModule.adminUserKey = key;
                    this.$store.state.AdminModule.adminUserEmail = email;
                    this.selectedKey = key;
                    this.keySelected = true;
                }
            },
            fn_runRoute(route) {
                if (this.$store.state.AdminModule.adminUserKey !== null) {
                    this.$router.push({ path: '/' + route });
                }
            },
            fn_setAdminGroup() {
                var that = this;
                if (this.clientList.filter(function (item) { return item.email === that.fn_FilteredList; }).length === 0) {
                    that.showAlert("Emailová adresa neexistuje.");
                } else {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/update_groupid",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), email: this.fn_FilteredList, groupId: this.adminGroupId })
                    }).done(function (data) {
                        if (data.result === 1) {
                            that.showAlert("Klient byl přiřazen. Pro zobrazení znovu načtěte přehled klientů.");
                        } else {
                            that.showAlert("Klienta se nepodařilo přiřadit.");
                        }
                    });
                }
            }
        },

        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/auth_status",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (data) {
                if (data.result === 1) {
                    if (data.isAdmin) {
                        that.adminUuid = data.uuid;
                        that.adminGroupId = data.groupId;
                        that.adminAccount = true;
                    } else {
                        that.adminUuid = null;
                        that.adminGroupId = null;
                        that.adminAccount = false;
                        window.location.pathname = '/';
                    }
                } else {
                    that.adminUuid = null;
                    that.adminGroupId = null;
                    that.adminAccount = false;
                    window.location.pathname = '/';
                }
            });
        },

        watch: {
        },

        created() {
         
            //var that = this;
            //$.ajax({
            //    type: "POST",
            //    url: "https://appi.app.cz:444/get_users",
            //    dataType: "json",
            //    contentType: 'application/json; charset=utf-8',
            //    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.adminUuid })
            //}).done(function (data) {
            //    if (data.result === 1) {
            //        if (that.adminGroupId === 999) {
            //            that.filteredList = data.users;
            //            that.clientList = data.users;
            //        }
            //        else {
            //            that.clientList = data.users;
            //            that.filteredList = data.users.filter(function (item) { return item.groupId === that.adminGroupId; });
            //        }
            //    } 
            //});
            this.loadingFinished = true;
        }
    }

</script>
