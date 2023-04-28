<template>
    <div class="container">
        <span class="middle d-block pt-4">
            <img src="/images/logo.png" alt="app.cz" class="img-fluid" style="width:216px;max-width: 216px;" />
        </span>
        <span v-show="Verification.uid ==null">
            <div class="row justify-content-center">
                <form v-on:submit.prevent data-vv-scope="ResetPassword">
                    <input type="hidden" name="email" v-model="email" v-validate="{ required: false, max: 0}" v-on:input="validateFields()" />
                    <div class="col-md-12 pt-4 text-center"></div>
                    <h1 class="bold" style="text-align: center;">Zapomněli jste heslo?</h1>
                    <h3 style="text-align: center;">To se občas stává :)</h3>
                    <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                        <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                            <p style="text-align: center;">Vyplňte svou e-mailovou adresu a my vám pošleme další instrukce k obnovení hesla.</p>
                        </div>
                    </div>

                    <div class="col-md-12 pt-4">
                        <input type="email" placeholder="Zadejte váš registrační e-mail" v-model="ResetPassword.Email" v-on:input="validateFields()" v-validate="'required|email'" name="Email" class="form-control py-2" :class="{ 'is-invalid': errors.has('ResetPassword.Email') }" />
                        <span v-if="errors.has('ResetPassword.Email')" class="invalid-feedback">{{ errors.first('ResetPassword.Email') }}</span>
                    </div>

                    <!--<div class="col-md-12 pt-4">
                    <div id="secondRecaptcha" style="text-align: -webkit-center;"></div>
                </div>-->

                    <div class="col-md-12 pt-4 text-center pb-5">
                        <button v-on:click="recaptcha('ResetPassword')" class="btn btn-outline-secondary btn_new" :disabled="!SaveAllowed">Poslat nové heslo</button>
                    </div>

                    <div id="element_1_0_3" class="element_container text_element_container ">
                        <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                            <p style="text-align: center;"><a class="mycolor" href="/Login">Přihlásit</a></p>
                            <!--<p style="text-align: center;"><a href="/Registration">Nová registrace</a></p>-->
                        </div>
                    </div>

                    <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                        <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                            <!--<p style="text-align: center;">Nemáte účet? Vyzkoušejte 14 dní zdarma.</p>-->
                        </div>
                    </div>
                </form>
            </div>
        </span>
        <span v-show="Verification.uid !=null">
            <div class="row justify-content-center">
                <form v-on:submit.prevent data-vv-scope="NewPassword">
                    <input type="hidden" name="email" v-model="email" v-validate="{ required: false, max: 0}" v-on:input="validateFields()" />
                    <div class="col-md-12 pt-4 text-center pb-5"></div>
                    <h1 style="text-align: center;">Zadejte nové heslo</h1>
                    <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                        <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                            <p style="text-align: center;">Vyplňte nové heslo, kterým se chcete přihlašovat do účtu na app.cz</p>
                        </div>
                    </div>
                    <div class="col-md-12 py-2 ">
                        <input type="password" placeholder="Nové Heslo" v-on:input="validatePassword()" v-model="NewPassword.Password1" name="Password1" v-validate="{ required: false, min: 6}" class="form-control py-2" :class="{ 'is-invalid': errors.has('NewPassword.Password1') }" autocomplete="off" />
                        <span v-if="errors.has('NewPassword.Password1')" class="invalid-feedback">{{ errors.first('NewPassword.Password1') }}</span>
                    </div>

                    <div class="col-md-12 py-2">
                        <input type="password" placeholder="Opakuj Heslo" v-on:input="validatePassword()" v-model="NewPassword.Password2" name="Password2" v-validate="{ required: false, min: 6}" class="form-control py-2" :class="{ 'is-invalid': errors.has('NewPassword.Password2') }" autocomplete="off" />
                        <span v-if="errors.has('NewPassword.Password2')" class="invalid-feedback">{{ errors.first('NewPassword.Password2') }}</span>
                    </div>

                    <!--<div class="col-md-12 pt-4">
                    <div id="thirdRecaptcha" style="text-align: -webkit-center;"></div>
                </div>-->

                    <div class="col-md-12 pt-4 text-center pb-5">
                        <button v-on:click="recaptcha('NewPassword')" class="btn btn-outline-secondary btn_new" :disabled="!SavePasswordAllowed">Potvrdit nové heslo</button>
                    </div>

                    <div id="element_1_0_3" class="element_container text_element_container ">
                        <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                            <p style="text-align: center;"><a class="mycolor" href="/ResetPassword">Znovu Odeslat novou žádost na email</a></p>
                            <p style="text-align: center;"><a class="mycolor" href="/Login">Přihlásit</a></p>
                            <!--<p style="text-align: center;"><a class="mycolor" href="/Registration">Nová registrace</a></p>-->
                        </div>
                    </div>
                    <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                        <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                            <p style="text-align: center;">Nemáte účet? Vyzkoušejte 14 dní zdarma.</p>
                        </div>
                    </div>
                </form>
            </div>
        </span>
    </div>
</template>
<script>
    import VeeValidate from 'vee-validate';
    import Vue from 'vue';
    import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';
    import SlimDialog from 'v-slim-dialog';
    import { VueReCaptcha } from 'vue-recaptcha-v3';
   
    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";
    //import VueGrecaptcha from 'vue-grecaptcha';

    Vue.use(VueI18n);
    Vue.use(VueCookie);
    Vue.use(SlimDialog);
    Vue.use(VueReCaptcha, {
        siteKey: '6LdQs48UAAAAAPt9Qo0_DTpPRDXQNsRF7vKmZrL3',
        loaderOptions: {
            useRecaptchaNet: true
        },

    });

    //Vue.use(VueGrecaptcha, {
    //    sitekey: '6LdrC5IUAAAAAF1_sp5WMXZJnQd8RKtWTq9pn6UL',
    //    theme: 'light'
    //})

    const locale = Vue.cookie.get('locale') || 'cs';
    const i18n = new VueI18n({
        locale: locale
    });

    Vue.use(VeeValidate, {
        i18n,
        dictionary: {
            cs, en
        }
    });

    export default {
        data() {

            return {
                ResetPassword: {
                    Email: ""
                },
                authUser: null,

                Verification: {
                    email: null,
                    uid: null
                },
                NewPassword: {
                    Password1: "",
                    Password2: ""
                },
                SavePasswordAllowed: false,
                SaveAllowed: false,
                captchaChecked: false,
                email:""

            }
        },

        methods: {
           
            // render() {
            //    const recaptchaDiv = document.createElement('div');
            //    document.getElementById("secondRecaptcha").appendChild(recaptchaDiv);
           
            //    this.widgetId = grecaptcha.render(recaptchaDiv, {
            //        sitekey: "6LdrC5IUAAAAAF1_sp5WMXZJnQd8RKtWTq9pn6UL",
            //        theme: this.theme || "light",
            //        callback: token => {
            //            this.captchaChecked = true;
            //            this.validateFields();
            //              //this.callback(token);
            //            return true;
            //            grecaptcha.reset(this.widgetId);
            //        }
            //    });
            //    this.loaded = true;
            //},
            //render1() {
            //    const recaptchaDiv = document.createElement('div');
            //    document.getElementById("thirdRecaptcha").appendChild(recaptchaDiv);

            //    this.widgetId = grecaptcha.render(recaptchaDiv, {
            //        sitekey: "6LdrC5IUAAAAAF1_sp5WMXZJnQd8RKtWTq9pn6UL",
            //        theme: this.theme || "light",
            //        callback: token => {
            //            this.captchaChecked = true;
            //            this.validatePassword();
            //            //this.callback(token);
            //            return true;
            //            grecaptcha.reset(this.widgetId);
            //        }
            //    });
            //    this.loaded = true;
            //},
            recaptcha(formName) {
                this.$recaptcha('login').then((token) => {
                    if (formName != "") {
                        this.validateForm(formName, token);
                    }
                });
            },
            validateFields: function () {
                this.$validator.validateAll("ResetPassword").then((valid) => {
                    if (valid) {
                        if (this.email=="") {
                            this.SaveAllowed = true;
                        } else { this.SaveAllowed = false; }
                        
                    } else { this.SaveAllowed = false; }
                })
            },
            showAlert(val) {
                var that = this;
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            validateForm(scope, recaptcha) {
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        var that = this;
                        if (scope === "ResetPassword" && this.email == "") {
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/reset_password",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({ "email": this.ResetPassword.Email, "recaptcha": recaptcha })
                            }).done(function (data) {
                                if (data.result === 1) {
                                    const options = { title: 'Info', size: 'sm' }
                                    that.$dialogs.alert('Žádost s odkazem pro obnovu hesla byla zaslána na váš email.', options)
                                        .then(res => {
                                            that.goToIndexPage();
                                        });
                                } else {
                                    that.showAlert("Emailová adresa neexistuje. Zadejte váš registrační email.");
                                }
                            });
                        }

                        if (scope === "NewPassword" && this.email == "") {
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/new_password",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({ "email": this.Verification.email, "confirmation": this.Verification.uid, "password": this.NewPassword.Password1, "recaptcha": recaptcha })
                            }).done(function (data) {
                                if (data.result === 1) {
                                    const options = { title: 'Info', size: 'sm' }
                                    that.$dialogs.alert('Heslo bylo úspěšně změněno. Nyní se můžete přihlásit.', options)
                                        .then(res => {
                                            that.goToIndexPage();
                                        });
                                } else {
                                    that.showAlert(error.message);
                                }
                            })
                        }
                    }
                });
            },
            validatePassword: function () {
                this.$validator.validateAll("NewPassword").then((valid) => {
                    if (valid) {
                        this.SavePasswordAllowed = (this.NewPassword.Password1 == this.NewPassword.Password2 && this.email == "") ? true : false;
                    } else { this.SavePasswordAllowed = false; }
                })
            },

            goToIndexPage() {
                window.location.pathname = '/';
            },

            checkVerification(recaptcha) {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/new_password",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ "email": that.Verification.email, "confirmation": that.Verification.uid, "recaptcha": recaptcha })
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
                        this.$recaptcha.reset();
                    }
                })
            }
        },
        
        created() {
            var that = this;
            if (JSON.stringify(this.$route.query) != "{}") {
                this.Verification = JSON.parse(JSON.stringify(this.$route.query));
                this.$recaptchaLoaded().then(() => {
                    this.$recaptcha('login').then((token) => {
                        that.checkVerification(token);
                //        that.render1();
                    })
                })
            } else {
                //this.$recaptchaLoaded().then(() => {
                //    this.render();
                //})
            }

           
        }
    }

</script>
<style lang="scss" scoped type="text/css">

</style>
