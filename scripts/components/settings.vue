<template>
    <div class="container" v-show="authUser=='true'">
        <div class="row justify-content-center">
            <div class="col-lg-11 col-xl-9">
                <h2 class="py-3 pt-5 pb-4 text-center">Váš účet</h2>

                <div class="list-group mt-2">
                    <form @submit.prevent="validateForm('StepChangeEmail')" data-vv-scope="StepChangeEmail">
                        <h2 class="list-group-item group_item_blue bold py-3">
                            PŘIHLAŠOVACÍ ÚDAJE
                        </h2>

                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-12 py-2">
                                    <input type="email" :readonly="(1== 1) ? true : false" placeholder="Contact Email" v-on:input="validateEmail()" v-model="StepChangeEmail.Email" v-validate="'required|email'" name="Email" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepChangeEmail.Email') }" />
                                    <span v-if="errors.has('StepChangeEmail.Email')" class="invalid-feedback">{{ errors.first('StepChangeEmail.Email') }}</span>
                                </div>
                            </div>
                        </div>
                    </form>

                    <form @submit.prevent="validateForm('StepChangePassword')" data-vv-scope="StepChangePassword">
                        <div class="list-group-item">
                            <div class="row">
                                <div class="col-md-6 py-2">
                                    <input type="password" placeholder="Nové Heslo" v-on:input="validatePassword()" v-model="StepChangePassword.Password" name="Password" v-validate="{ required: false, min: 6}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepChangePassword.Password') }" autocomplete="off" />
                                    <span v-if="errors.has('StepChangePassword.Password')" class="invalid-feedback">{{ errors.first('StepChangePassword.Password') }}</span>
                                </div>
                                <div class="col-md-6 text-right py-2">
                                    <button class="btn btn-outline-secondary btn_new" :disabled="userUid != 'none' || !SavePasswordAllowed">Uložit nové heslo</button>
                                </div>
                            </div>
                        </div>
                    </form>

                    <div class="list-group-item">
                        <div class="row">
                            <div class="col-md-6 py-2">
                                <input type="text" :readonly="(1== 1) ? true : false" placeholder="Api Klíč" v-model="apiKey" name="apiKey" class="form-control py-2"  />
                            </div>
                            <div class="col-md-6 text-right py-2">
                                <button class="btn btn-outline-secondary btn_new" :disabled="userUid != 'none'" v-on:click="generateApi()">Generovat Nový api klíč</button>
                            </div>
                        </div>
                    </div>

                    <p>
                        <form @submit.prevent="validateForm('StepProfil')" data-vv-scope="StepProfil">
                            <div class="list-group-item group_item_blue bold ">
                                KONTAKTNÍ ÚDAJE
                            </div>
                            <div class="list-group-item">
                                <div class="row">
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="Jméno" v-model="StepProfil.Name" name="Name" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Name') }" />
                                        <span v-if="errors.has('StepProfil.Name')" class="invalid-feedback">{{ errors.first('StepProfil.Name') }}</span>
                                    </div>
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="Příjmení" v-model="StepProfil.Surname" name="Surname" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Surname') }" />
                                        <span v-if="errors.has('StepProfil.Surname')" class="invalid-feedback">{{ errors.first('StepProfil.Surname') }}</span>
                                    </div>
                                </div>
                            </div>
                            <div class="list-group-item">
                                <div class="row">
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="Telefonní číslo" v-model="StepProfil.Telephone" name="Telephone" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Telephone') }" />
                                        <span v-if="errors.has('StepProfil.Telephone')" class="invalid-feedback">{{ errors.first('StepProfil.Telephone') }}</span>
                                    </div>
                                    <div class="col-md-6 py-2">

                                    </div>
                                </div>
                            </div>
                            <div class="list-group-item">
                                <div class="row">
                                    <div class="col-md-12 py-2 group_item_green bold">
                                        ÚDAJE O FIRMĚ
                                    </div>
                                </div>
                            </div>

                            <div class="list-group-item">
                                <div class="row">
                                    <div class="col-md-6 py-2">
                                        <input type="text" v-bind:placeholder="$t('companyName')" v-model="StepProfil.Company" class="form-control py-2" />
                                    </div>
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="Ulice a č.p." v-model="StepProfil.StreetACP" name="StreetACP" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.StreetACP') }" />
                                        <span v-if="errors.has('StepProfil.StreetACP')" class="invalid-feedback">{{ errors.first('StepProfil.StreetACP') }}</span>
                                    </div>
                                </div>
                            </div>

                            <div class="list-group-item">
                                <div class="row">
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="Město" v-model="StepProfil.City" name="City" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.City') }" />
                                        <span v-if="errors.has('StepProfil.City')" class="invalid-feedback">{{ errors.first('StepProfil.City') }}</span>
                                    </div>
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="PSČ" v-model="StepProfil.PostCode" name="PostCode" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.PostCode') }" />
                                        <span v-if="errors.has('StepProfil.PostCode')" class="invalid-feedback">{{ errors.first('StepProfil.PostCode') }}</span>
                                    </div>
                                </div>
                            </div>

                            <div class="list-group-item">
                                <div class="row">
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="IČO" v-model="StepProfil.Ico" name="Ico" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Ico') }" />
                                        <span v-if="errors.has('StepProfil.Ico')" class="invalid-feedback">{{ errors.first('StepProfil.Ico') }}</span>
                                    </div>
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="DIČ" v-model="StepProfil.Dic" name="Dic" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Dic') }" />
                                        <span v-if="errors.has('StepProfil.Dic')" class="invalid-feedback">{{ errors.first('StepProfil.Dic') }}</span>
                                    </div>
                                </div>
                            </div>

                            <div class="list-group-item py-4">
                                <!--<a href="#" class="btn btn-primary btn_new w-25">Uložit</a>-->
                                <button class="btn btn-outline-secondary btn_new">Uložit</button>
                            </div>
                        </form>
                    </p>
                </div>


                <br />
                <div class="list-group mt-2 shadow-sm">
                    <div class="list-group-item group_item_blue bold d-flex flex-row justify-content-between " style="display: inline-flex;">
                        <span style="padding-top: inherit;">VÁŠ TARIF</span>
                        <!--<div class="d-flex flex-row justify-content-between align-items-center">-->
                        <div class="right">
                            <a href="/BusinessPlanSelection" class="btn btn-outline-secondary" style="padding-right: 3px;" :class="{disabled: userUid != 'none'}">
                                <span class="fas fa-pencil-alt"> </span>
                            </a>
                            <!--</div>-->
                        </div>
                    </div>

                    <div class="list-group-item">
                        <div class="d-flex flex-row justify-content-between align-items-center">
                            <div>
                                {{CreditVariant}} {{CreditVariantText}}
                            </div>
                            <div>
                                {{Price}} Kč / {{invoicePeriod}}
                            </div>
                        </div>
                    </div>
                    <div class="list-group-item">
                        Vaše předplatné končí {{new Date(NextPayDate).toLocaleDateString('cs-CZ').replace(/\s+/g, '')}}
                    </div>
                    <div class="list-group-item">
                        Doplňující informace: {{Note}}
                    </div>
                </div>

                <p style="height:40px;"></p>
            </div>
        </div>
    </div>
</template>

<script>
    import VeeValidate from 'vee-validate';
	import Vue from 'vue';
	import SlimDialog from 'v-slim-dialog';
	import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';

	import cs from "vee-validate/dist/locale/cs";
	import en from "vee-validate/dist/locale/en";

	Vue.use(SlimDialog);
	Vue.use(VueI18n);
	Vue.use(VueCookie);

	const locale = Vue.cookie.get('locale') || 'cs';
	const i18n = new VueI18n({
	  locale: locale
	});

	Vue.use(VeeValidate, {
	  i18n,
	  dictionary: {
		cs,en
	  }
	});
	
    export default {
        data() {
            return {
                StepProfil: {
                    Name: "",
                    Surname: "",
                    Company: "",
                    Telephone: "",
                    Ico: "",
                    Dic: "",
                    StreetACP: "",
                    City: "",
                    PostCode: "",
                    Finished: false
                },
                StepChangeEmail: {
                    Email: "",
                    oldEmail: ""
                },
                StepChangePassword: {
                    Password: ""
                },
                apiKey: null,
                SavePasswordAllowed: false,
                SaveEmailAllowed: false,
                DaysToPay: 0,
                CreditVariant: "",
                CreditVariantText: "",
                trial: "",
                Price: 0,
                invoicePeriod: "",
                NextPayDate: null,
                userUid: "none",
                userEmail: null,
                authUser: Vue.cookie.get('logged') || false,
                Note:""
            };
        },
        methods: {
            date_diff_indays(date2, date1) {
                var dt1 = date1;
                var dt2 = date2;
                return Math.floor((Date.UTC(dt2.getFullYear(), dt2.getMonth(), dt2.getDate()) - Date.UTC(dt1.getFullYear(), dt1.getMonth(), dt1.getDate())) / (1000 * 60 * 60 * 24));
            },
            validateForm(scope) {
                var that = this;
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        if (scope === "StepProfil") {
                            //update_profile
                            var dataProfile = {
                                session: Vue.cookie.get('session'),
                                Name: (this.StepProfil.Name) ? this.StepProfil.Name : "",
                                Surname: (this.StepProfil.Surname) ? this.StepProfil.Surname : "",
                                Company: (this.StepProfil.Company) ? this.StepProfil.Company : "",
                                Telephone: (this.StepProfil.Telephone) ? this.StepProfil.Telephone : "",
                                Ico: (this.StepProfil.Ico) ? this.StepProfil.Ico : "",
                                Dic: (this.StepProfil.Dic) ? this.StepProfil.Dic : "",
                                StreetACP: (this.StepProfil.StreetACP) ? this.StepProfil.StreetACP : "",
                                City: (this.StepProfil.City) ? this.StepProfil.City : "",
                                PostCode: (this.StepProfil.PostCode) ? this.StepProfil.PostCode : "",
                                Finished: true
                            }
                            if (that.userUid != "none") {
                                dataProfile.uuid = that.userUid;

                                $.ajax({
                                    type: "POST",
                                    url: "https://appi.app.cz:444/update_user_profile",
                                    dataType: "json",
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify(dataProfile)
                                }).done(function (data) {
                                    if (data.result === 1) {
                                        that.showAlert("Profil byl uložen.");
                                    }
                                });
                            } else {
                                $.ajax({
                                    type: "POST",
                                    url: "https://appi.app.cz:444/update_profile",
                                    dataType: "json",
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify(dataProfile)
                                }).done(function (data) {
                                    if (data.result === 1) {
                                        that.showAlert("Profil byl uložen.");
                                    }
                                });
                            }
                        }

                        //if (scope === "StepChangeEmail" && this.SaveEmailAllowed) {
                        //    if (this.StepChangeEmail.Email.length > 0 && this.StepChangeEmail.Email != this.StepChangeEmail.oldEmail) {
                        //        this.authUser.updateEmail(this.StepChangeEmail.Email)
                        //            .then(() => {
                        //                that.StepChangeEmail.oldEmail = that.StepChangeEmail.Email;
                        //                that.validateEmail();
                        //                that.showAlert("Emailová adresa byla změněna");
                        //            })
                        //            .catch(error => { that.showAlert(error.message); });
                        //    } else { this.showAlert("Emailová adresa nebyla změněna"); }
                        //}

                        if (scope === "StepChangePassword" && this.SavePasswordAllowed) {
                            if (this.StepChangePassword.Password.length > 0) {
                                $.ajax({
                                    type: "POST",
                                    url: "https://appi.app.cz:444/update_profile",
                                    dataType: "json",
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify({ session: Vue.cookie.get('session'), password: this.StepChangePassword.Password })
                                }).done(function (data) {
                                    if (data.result === 0) {
                                        if (data.code == "not-exist-user-error") {
                                            that.showAlert("Bohužel, zadaný email neexistuje.");
                                        }
                                        else if (data.code == "confirmation-error") {
                                            that.showAlert("Bohužel, požadavek již není platný.");
                                        }
                                        else if (data.code == "email-error") {
                                            that.showAlert("Nepodařilo se odeslat email. Prosím zkuste to znovu.");
                                        }
                                        else {
                                            that.showAlert(data.message);
                                        }
                                    } else {
                                        that.StepChangePassword.Password = "";
                                        that.showAlert("Heslo bylo změněno.");
                                    }
                                });
                            } else { this.showAlert("Heslo je prázdné"); };
                        }
                    }
                });
            },
            generateApi() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/generateApi",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: (that.userUid != "none") ? that.userUid : null })
                }).done(function (data) {
                    if (data.result === 0) {
                        that.showAlert("Nepodařilo se vygenerovat nový api klíč. Prosím zkuste to znovu.");
                    } else {
                        that.apiKey = data.apiKey;
                        that.showAlert("Byl Vygenerován nový api klíč.");
                    }
                });
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            validateEmail: function () {
                this.$validator.validateAll("StepChangeEmail").then((valid) => {
                    if (valid) {
                        this.SaveEmailAllowed = (this.StepChangeEmail.Email.length > 0 && this.StepChangeEmail.Email != this.StepChangeEmail.oldEmail) ? true : false;
                    } else { this.SaveEmailAllowed = false; }
                })
            },
            validatePassword: function () {
                this.$validator.validateAll("StepChangePassword").then((valid) => {
                    if (valid) {
                        this.SavePasswordAllowed = (this.StepChangePassword.Password.length > 5) ? true : false;
                    } else { this.SavePasswordAllowed = false; }
                })
            },

        },

        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            if (that.userUid != "none") {
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/user_credits",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (dataCredit) {
                    if (dataCredit.result === 1) {
                        that.NextPayDate = dataCredit.NextPayDate;
                        if (that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date()) >= 0) {
                            that.DaysToPay = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());
                        } else {
                            that.DaysToPay = -1;
                        }

                        that.Price = dataCredit.Price;

                        switch (dataCredit.PaymentVersion) {
                            case "Trial":
                                that.CreditVariant = "Zkušební verze";
                                that.trial = "zdarma ";
                                break;
                            default:
                                that.CreditVariant = dataCredit.PaymentVersion;
                                that.trial = dataCredit.PaymentVersion;
                        }

                        switch (that.DaysToPay) {
                            case 0:
                                that.DaysToPay = "končí dnes";
                                break;
                            case -1:
                                that.DaysToPay = " skončilo. Zůstaňte notifikovaní a objednejte si placený tarif";
                                break;
                            case 1:
                                that.DaysToPay = "končí za " + that.DaysToPay + " den";
                                break;
                            case 2: case 3: case 4:
                                that.DaysToPay = "končí za " + that.DaysToPay + " dny";
                                break;
                            default:
                                that.DaysToPay = "končí za " + that.DaysToPay + " dní";
                        }

                        switch (dataCredit.InvoicePeriod) {
                            case "month":
                                that.invoicePeriod = "měs.";
                                that.CreditVariantText = " – měsíční tarif";
                                break;
                            case "year":
                                that.invoicePeriod = "rok";
                                that.CreditVariantText = " – roční tarif";
                                break;
                            default:
                                that.invoicePeriod = "";
                        }
                    }
                });
            } else {
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/credits",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session') })
                }).done(function (dataCredit) {
                    if (dataCredit.result === 1) {
                        that.NextPayDate = dataCredit.NextPayDate;
                         if (that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date()) >= 0) {
                            that.DaysToPay = that.date_diff_indays(new Date(dataCredit.NextPayDate), new Date());
                        } else {
                            that.DaysToPay = -1;
                        }

                        that.Price = dataCredit.Price;

                        switch (dataCredit.PaymentVersion) {
                            case "Trial":
                                that.CreditVariant = "Zkušební verze";
                                that.trial = "zdarma ";
                                break;
                            default:
                                that.CreditVariant = dataCredit.PaymentVersion;
                                that.trial = dataCredit.PaymentVersion;
                        }

                        switch (that.DaysToPay) {
                            case 0:
                                that.DaysToPay = "končí dnes";
                                break;
                            case -1:
                                that.DaysToPay = " skončilo. Zůstaňte notifikovaní a objednejte si placený tarif";
                                break;
                            case 1:
                                that.DaysToPay = "končí za " + that.DaysToPay + " den";
                                break;
                            case 2: case 3: case 4:
                                that.DaysToPay = "končí za " + that.DaysToPay + " dny";
                                break;
                            default:
                                that.DaysToPay = "končí za " + that.DaysToPay + " dní";
                        }

                        switch (dataCredit.InvoicePeriod) {
                            case "month":
                                that.invoicePeriod = "měs.";
                                that.CreditVariantText = " – měsíční tarif";
                                break;
                            case "year":
                                that.invoicePeriod = "rok";
                                that.CreditVariantText = " – roční tarif";
                                break;
                            default:
                                that.invoicePeriod = "";
                        }
                    }
                });


            }
        },

        created() {
            Vue.cookie.set('EditCampaignID', null, 1);
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_user_profile",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (dataProfile) {
                if (dataProfile.result === 1) {
                    that.StepChangeEmail.Email = dataProfile.RegEmail;
                    that.StepChangeEmail.oldEmail = dataProfile.RegEmail;
                    that.StepChangePassword.Password = "";

                    that.StepProfil.Name = dataProfile.Name;
                    that.StepProfil.Surname = dataProfile.Surname;
                    that.StepProfil.Company = dataProfile.Company;
                    that.StepProfil.Telephone = dataProfile.Telephone;
                    that.StepProfil.Ico = dataProfile.Ico;
                    that.StepProfil.Dic = dataProfile.Dic;
                    that.StepProfil.StreetACP = dataProfile.StreetACP;
                    that.StepProfil.City = dataProfile.City;
                    that.StepProfil.PostCode = dataProfile.PostCode;
                    that.StepProfil.Finished = dataProfile.StepProfileFinished;
                    that.apiKey = dataProfile.apiKey;
                    that.Note = dataProfile.note;

                    that.$emit("changesFinished", that.StepProfil.Finished);
                }
            })
        }
    }
</script>

<style lang="scss" scoped type="text/css">
</style>