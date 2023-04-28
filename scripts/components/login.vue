<template>
    <div class="container">
        <span class="middle d-block pt-4">
            <img src="/images/logo.png" alt="app.cz" class="img-fluid" style="width:216px;max-width: 216px;" />
        </span>
        <div class="row justify-content-center">
            <form v-on:submit.prevent data-vv-scope="login">
                <input type="hidden" name="email" v-model="email" v-validate="{ required: false, max: 0}" v-on:input="validateFields()" />
                <div class="col-md-12 pt-4 text-center"></div>
                <h1 class="bold" style="text-align: center;">Přihlášení</h1>
                <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                    <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                        <p style="text-align: center;">Vyplňte váš e-mail a heslo zadané při registraci.</p>
                    </div>
                </div>
                <div class="col-md-12 pt-4 d-block middle">
                    <div class="col-md-8 d-inline-block middle float-none">
                        <input type="email" placeholder="Zadejte váš e-mail" v-model="login.Email" v-on:input="validateFields()" name="Email" v-validate="'required|email'" class="form-control py-2" :class="{ 'is-invalid': errors.has('login.Email') }" />
                        <span v-if="errors.has('login.Email')" class="invalid-feedback">{{ errors.first('Email') }}</span>
                    </div>
                </div>

                <div class="col-md-12 pt-4 d-block middle">
                    <div class="col-md-8 d-inline-block middle float-none">
                        <input type="password" placeholder="Zadejte své heslo" v-model="login.Password" v-on:input="validateFields()" name="Password" v-validate="{ required: true, min: 6}" class="form-control py-2" :class="{ 'is-invalid': errors.has('login.Password') }" autocomplete="off" />
                        <span v-if="errors.has('login.Password')" class="invalid-feedback">{{ errors.first('Password') }}</span>
                    </div>
                </div>

                <div class="col-md-12 pt-4 text-center pb-5">
                    <button v-on:click="recaptcha('login')" class="btn btn-outline-secondary btn_new" :disabled="!SaveAllowed">Přihlásit</button>
                </div>
                <div id="element_1_0_3" class="element_container text_element_container ">
                    <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                        <!--<p style="text-align: center;"><a href="/Registration">Nová registrace</a></p>-->
                        <p style="text-align: center;"><a class="mycolor" href="/ResetPassword">Zapomněli jste heslo?</a></p>
                    </div>
                </div>
                <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                    <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                        <p style="text-align: center;"><a class="mycolor" href="https://app.cz/?utm_source=app&utm_medium=link&utm_campaign=prihlaseni" target="_blank">Nemáte účet? Vyzkoušejte 14 dní zdarma.</a></p>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
	import VeeValidate from 'vee-validate';
	import Vue from 'vue';
	import VueI18n from 'vue-i18n';
	import VueCookie from 'vue-cookie';
    import SlimDialog from 'v-slim-dialog';
    import { store } from "./../store/store";
    import { VueReCaptcha } from 'vue-recaptcha-v3';

	import cs from "vee-validate/dist/locale/cs";
	import en from "vee-validate/dist/locale/en";
	
	Vue.use(VueI18n);
	Vue.use(VueCookie);
    Vue.use(SlimDialog);
    Vue.use(VueReCaptcha, {
        siteKey: '6LdQs48UAAAAAPt9Qo0_DTpPRDXQNsRF7vKmZrL3',
        loaderOptions: {
            useRecaptchaNet: true
        }
    });

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
	
	var bcrypt = require('bcrypt-nodejs');

	export default {

	    data() {
		    return {
			    login: {
				    Email : "",
				    Password : ""
			    },
                SaveAllowed: false,
                captchaChecked: false,
                email: "",
                targetMenu: null
		    }
	    },

        methods: {
            //render() {
            //    const recaptchaDiv = document.createElement('div');
            //    document.getElementById("secondRecaptcha").appendChild(recaptchaDiv);
            //    this.widgetId = grecaptcha.render(recaptchaDiv, {
            //        sitekey: "6LdrC5IUAAAAAF1_sp5WMXZJnQd8RKtWTq9pn6UL",
            //        theme: this.theme || "light",
            //        callback: token => {
            //            this.captchaChecked = true;
            //            this.validateFields();
            //            //this.callback(token);
            //            return true;
            //            grecaptcha.reset(this.widgetId);
            //        }
            //    });
            //    this.loaded = true;
            //},
            recaptcha(formName) {
                this.$recaptcha('login').then((token) => {
                    this.validateForm(formName, token)
                })
            },
		    clearForms(){
			    this.login.Email = null;
			    this.login.Password = null;
		    },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            validateFields: function () {
                var that = this;
                this.errors.clear();
                this.$validator.validateAll("login").then((valid) => {
                    if (valid) {
                        //if (this.captchaChecked) {
                        if (this.email == "") {
                            this.SaveAllowed = true;
                        } else { this.SaveAllowed = false; }
                    } else {
                        if (this.login.Email.length == 0) {
                            that.errors.add({ field: 'Email', msg: 'Nejdříve vyplňte e-mail.' });
                        } else if (this.login.Email.length > 0 && !this.ValidateEmail(this.login.Email)) {
                            that.errors.add({ field: 'Email', msg: 'Vložte e-mail ve správném formátu.' });
                        }
                        if (this.login.Password.length == 0) {
                            that.errors.add({ field: 'Password', msg: 'Ještě heslo. Bez toho vás nepřihlásíme.' });
                        } else if (this.login.Password.length < 6) {
                            that.errors.add({ field: 'Password', msg: 'Vyplňte celé heslo, které má minimálně 6 znaků.' });
                        }
                        this.SaveAllowed = false;
                    }
                })
            },
            ValidateEmail(mail){
                if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
                    return (true);
                }
                return (false);
            },  
            validateForm(scope, recaptcha) {
                var that = this;
		        this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        if (scope === "login" && this.email == "") {
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/login",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({ "email": this.login.Email, "password": this.login.Password, "recaptcha": recaptcha })
                            }).done(function (data) {
                                if (data.result === 1) {
                                    Vue.cookie.set('topVariables', data.topVariables, 1);
                                    Vue.cookie.set('logged', true, 1);
                                    Vue.cookie.set('session', data.session, 1);
                                    if (that.targetMenu != null) {
                                        window.location.assign(that.targetMenu);
                                    } else {
                                        window.location.pathname = '/';
                                    }
                                } else {
                                    Vue.cookie.set('topVariables', null, 1);
                                    Vue.cookie.set('session', null, 1);
                                    Vue.cookie.set('logged', false, 1);
                                    if (data.code == "not-exist-user-error") {
                                        that.showAlert("Bohužel, zadaný email neexistuje.");
                                    } else if (data.code == "incorrect-password-error") {
                                        that.showAlert("Bohužel, zadané heslo není správně. Zkuste to znovu nebo si nechte zaslat nové heslo.");
                                    } else if (data.code == "expired-account-error") {
                                        that.showAlert("Bohužel, účet již není aktivní.");
                                    } else {
                                        that.showAlert(data);
                                    }
                                }
                            });
				        }
                    }
		        });
            },
	    },

        beforeCreate() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/auth_status",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (data) {
                if (data.result === 1) {
                    that.authUser = true;
                } else {
                    that.authUser = false;
                }
            });
        },

        created() {
            this.targetMenu = (this.$route.query[0] != undefined) ? this.$route.query[0] : null;

            Vue.cookie.set('EditCampaignID', null, 1);
            this.validateFields();
            //this.$recaptchaLoaded().then(() => {
            //    this.render();
            //})
	    }
	}

</script>

<style lang="scss" scoped type="text/css">
</style>
