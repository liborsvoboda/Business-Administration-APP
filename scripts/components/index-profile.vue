<template>
    <div class="finish_profil_content panel_right">
        <form @submit.prevent="validateForm('StepChangeEmail')" data-vv-scope="StepChangeEmail">
            <div class="row pl-5 pr-5">
                <div class="col-md-12 pb-4 pt-3">
                    <button ref="closeBtn" type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <!--<div class="col-md-12 text-center pt-2 pb-2">
                    <span class="fas fa-smile smile"></span>
                </div>-->
                <div class="col-md-12 text-center pt-2 pb-2">
                    <h1 class="panel_right_h2 py-3">Dokončete váš profil</h1>
                </div>
                <div class="col-md-12 py-2">
                    <input type="email" :readonly="(1== 1) ? true : false" placeholder="Contact Email" v-on:input="validateEmail()" v-model="StepChangeEmail.Email" v-validate="'required|email'" name="Email" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepChangeEmail.Email') }" />
                    <span v-if="errors.has('StepChangeEmail.Email')" class="invalid-feedback">{{ errors.first('StepChangeEmail.Email') }}</span>
                </div>
                <!--<div class="col-md-6 py-2 text-right"">
                <button class="btn btn-primary btn_new" :disabled="!SaveEmailAllowed" >Uložit nový email</button>
            </div>-->
            </div>
        </form>

        <form @submit.prevent="validateForm('StepChangePassword')" data-vv-scope="StepChangePassword">
            <div class="row pl-5 pr-5">
                <div class="col-md-6 py-2">
                    <input type="password" placeholder="Nové Heslo" v-on:input="validatePassword()" v-model="StepChangePassword.Password" name="Password" v-validate="{ required: false, min: 6}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepChangePassword.Password') }" autocomplete="off" />
                    <span v-if="errors.has('StepChangePassword.Password')" class="invalid-feedback">{{ errors.first('StepChangePassword.Password') }}</span>
                </div>
                <div class="col-md-6 py-2 text-right">
                    <button class="btn btn-outline-secondary btn_new" :disabled="!SavePasswordAllowed">Uložit nové heslo</button>
                </div>

            </div>
        </form>

        <form @submit.prevent="validateForm('StepProfil')" data-vv-scope="StepProfil">
            <div class="row pl-5 pr-5">
                <div class="col-md-12 text-center pt-2 pb-2">

                    <br /><br />
                    <h1 class="panel_right_h2_2">KONTAKTNÍ ÚDAJE</h1>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="Jméno" v-model="StepProfil.Name" name="Name" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Name') }" />
                    <span v-if="errors.has('StepProfil.Name')" class="invalid-feedback">{{ errors.first('StepProfil.Name') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="Příjmení" v-model="StepProfil.Surname" name="Surname" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Surname') }" />
                    <span v-if="errors.has('StepProfil.Surname')" class="invalid-feedback">{{ errors.first('StepProfil.Surname') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="Telefonní číslo" v-model="StepProfil.Telephone" name="Telephone" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Telephone') }" />
                    <span v-if="errors.has('StepProfil.Telephone')" class="invalid-feedback">{{ errors.first('StepProfil.Telephone') }}</span>
                </div>
                <div class="col-md-6 py-2">

                </div>

                <div class="col-md-12 text-center pt-2 pb-2">

                    <br /><br />
                    <h1 class="panel_right_h2_2">ÚDAJE O FIRMĚ </h1>
                </div>

                <div class="col-md-6 py-2">
                    <!--v-bind:placeholder="$t('companyName')"-->
                    <input type="text" placeholder="Název Firmy" v-model="StepProfil.Company" class="form-control py-2" />
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="Ulice a č.p." v-model="StepProfil.StreetACP" name="StreetACP" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.StreetACP') }" />
                    <span v-if="errors.has('StepProfil.StreetACP')" class="invalid-feedback">{{ errors.first('StepProfil.StreetACP') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="Město" v-model="StepProfil.City" name="City" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.City') }" />
                    <span v-if="errors.has('StepProfil.City')" class="invalid-feedback">{{ errors.first('StepProfil.City') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="PSČ" v-model="StepProfil.PostCode" name="PostCode" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.PostCode') }" />
                    <span v-if="errors.has('StepProfil.PostCode')" class="invalid-feedback">{{ errors.first('StepProfil.PostCode') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="IČO" v-model="StepProfil.Ico" name="Ico" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Ico') }" />
                    <span v-if="errors.has('StepProfil.Ico')" class="invalid-feedback">{{ errors.first('StepProfil.Ico') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="DIČ" v-model="StepProfil.Dic" name="Dic" v-validate="{ required: false}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepProfil.Dic') }" />
                    <span v-if="errors.has('StepProfil.Dic')" class="invalid-feedback">{{ errors.first('StepProfil.Dic') }}</span>
                </div>
                <div class="col-md-12 pt-4 text-center pb-5">
                    <button class="btn btn-outline-secondary btn_new">Uložit</button>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
	import VueI18n from 'vue-i18n';
	import VueCookie from 'vue-cookie';

	import cs from "vee-validate/dist/locale/cs";
	import en from "vee-validate/dist/locale/en";

	import VeeValidate from 'vee-validate';
	import Vue from 'vue';
	import SlimDialog from 'v-slim-dialog';
    import VueResource from 'vue-resource';

	Vue.use(SlimDialog);
	Vue.use(VueI18n);
	Vue.use(VueCookie);
    Vue.use(VueResource);

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
				profileUser : [],
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
                SavePasswordAllowed: false,
                SaveEmailAllowed: false,
                userUid: "none",
            }
        },
        methods: {
            validateForm(scope) {
                var that = this;
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        if (scope === "StepProfil") {
                            ///update_profile
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
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/update_profile",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify(dataProfile)                               
                            }).done(function (data) {
                                if (data.result === 1) {
                                    that.$emit("changesFinished", true);
                                    that.$refs.closeBtn.click();
                                }
                            });
                        }

                        //if (scope === "StepChangeEmail" && this.SaveEmailAllowed) {
                        //    if (this.StepChangeEmail.Email.length > 0 && this.StepChangeEmail.Email != this.StepChangeEmail.oldEmail) {
                        //        this.profileUser.updateEmail(this.StepChangeEmail.Email)
                        //            .then(() => {
                        //                that.StepChangeEmail.oldEmail = that.StepChangeEmail.Email;
                        //                that.validateEmail();
                        //                that.$refs.closeBtn.click();
                        //                that.showAlert("Emailová adresa byla změněna");
                        //            })
                        //            .catch(error => { that.$refs.closeBtn.click();that.showAlert(error.message); });
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
                                    if (data.result === 1) {
                                        that.$refs.closeBtn.click();
                                        that.StepChangePassword.Password = "";
                                        that.showAlert("Heslo bylo změněno.");
                                    }
                                });
                            } else { this.showAlert("Heslo je prázdné"); };
                        }
                    }
				});
			},
			showAlert(val) {
				const options = {title: 'Info', size: 'sm'}
				this.$dialogs.alert(val, options)
					.then(res => {
				});
            },
            validateEmail: function () {
                this.$validator.validateAll("StepChangeEmail").then((valid) => {
                    if (valid) {
                        this.SaveEmailAllowed = (this.StepChangeEmail.Email.length > 0 && this.StepChangeEmail.Email != this.StepChangeEmail.oldEmail) ? true : false;
                    } else { this.SaveEmailAllowed = false;}
                })
            },
            validatePassword: function () {
                this.$validator.validateAll("StepChangePassword").then((valid) => {
                    if (valid) {
                        this.SavePasswordAllowed=(this.StepChangePassword.Password.length > 5) ? true : false;
                    } else { this.SavePasswordAllowed = false; }
                })
            },
        },
        created() {
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
                    that.StepProfil.Finished = dataProfile.Finished;

                    that.$emit("changesFinished", that.StepProfil.Finished);
                }
            });
        }
    }
</script>