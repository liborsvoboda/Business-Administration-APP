<template>
    <div class="container center-block">
        <span class="middle d-block pt-4">
            <img src="/images/logo.png" alt="app.cz" class="img-fluid" style="width:216px;max-width: 216px;" />
        </span>
        <div class="row justify-content-center">
            <form v-on:submit.prevent data-vv-scope="newEmailAccount">
                <input type="hidden" name="email" v-model="email" v-validate="{ required: false, max: 0}" v-on:input="validateFields()" />

                <div class="col-md-12 pt-4 text-center"></div>
                <h1 class="bold" style="text-align: center">Dokončete registraci</h1>
                <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                    <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                        <p style="text-align: center;">Vytvořte si vlastní heslo, kterým se chcete přihlašovat do účtu app.</p>
                    </div>
                </div>
                <div class="col-md-12 pt-4 d-block middle">
                    <div class="col-md-8 d-inline-block float-none middle">
                        <input type="email" placeholder="Zadejte svůj email" readonly="true" v-model="newEmailAccount.Email" v-on:input="validateFields()" v-validate="'required|email'" name="Email" class="form-control py-2" :class="{ 'is-invalid': errors.has('newEmailAccount.Email') }" />
                        <span v-if="errors.has('newEmailAccount.Email')" class="invalid-feedback">{{ errors.first('newEmailAccount.Email') }}</span>
                    </div>
                </div>
                <div class="col-md-12 pt-4 d-block middle">
                    <div class="col-md-8 d-inline-block float-none middle">
                        <input type="password" placeholder="Zadejte své heslo" v-model="newEmailAccount.Password" v-on:input="validateFields()" name="Password" v-validate="{ required: true, min: 6}" class="form-control py-2" :class="{ 'is-invalid': errors.has('newEmailAccount.Password') }" autocomplete="off" />
                        <span v-if="errors.has('newEmailAccount.Password')" class="invalid-feedback">{{ errors.first('Password') }}</span>
                    </div>
                </div>

                <p></p>

                <div class="col-md-12 pt-4 text-center pb-5">
                    <button @click="recaptcha('newEmailAccount')" class="btn btn-outline-secondary btn_new" :disabled="!SaveAllowed">Dokončit registraci</button>
                </div>

                <div id="element_0_0_2" class="element_container text_element_container  element_container_max_width">
                    <div class="in_element_content entry_content ve_content_text  element_text_li element_text_size_medium element_text_style_1 element_text_li">
                        <p style="text-align: center;font-size: 13px;">Kliknutím na „Dokončit registraci“ souhlasíte s <a class="copyright" style="font-size: 13px;" href="https://app.cz/vseobecne-obchodni-podminky/?utm_source=app.app.cz&utm_medium=app-paticka&utm_campaign=app-obchodni-podminky" target="_blank">Všeobecnými obchodními podmínkami</a>.</p>
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
			newEmailAccount:{
				Email : "",
				Password : ""
            },
            SaveAllowed: false,
            registered: false,
            captchaChecked: false,
            email:"",
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
                    if (!this.registered) {
                        this.validateForm(formName, token)
                    } else {
                        this.login(token)
                    }
                    
                })
            },

            validateFields: function () {
                var that = this;
                this.errors.clear();
                this.$validator.validateAll("newEmailAccount").then((valid) => {
                    if (valid) {
                        if (this.newEmailAccount.Password != "" && this.email =="") { this.SaveAllowed = true; }
                        else { this.SaveAllowed = false;}
                    } else {
                        if (this.newEmailAccount.Password.length == 0) {
                            that.errors.add({ field: 'Password', msg: 'Vytvořte si heslo, ať můžete dokončit registraci.' });
                        } else if (this.newEmailAccount.Password.length < 6) {
                            that.errors.add({ field: 'Password', msg: 'Vaše heslo musí mít alespoň 6 znaků.' });
                        }
                        this.SaveAllowed = false;
                    }
                })
            },
		    clearForms(){
			    this.newEmailAccount.Email = null;
			    this.newEmailAccount.Password = null;
		    },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            validateForm(scope, recaptcha) {
                var that = this;
		        this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        if (scope === "newEmailAccount" && this.email == "") {
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/signup",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({ "email": this.newEmailAccount.Email, "password": this.newEmailAccount.Password, "recaptcha": recaptcha, "trial": true })
                            }).done(function (data) {
                                if (data.result === 1) {
                                    that.registered = true;
                                    const options = { title: 'Info', size: 'sm' }
                                    that.$dialogs.alert("Vytvořili jsme vám účet a na e-mail poslali první informace. Teď následujte průvodce na uvítací nástěnce a spusťte první kampaň.", options)
                                        .then(res => {
                                            that.recaptcha();
                                        });
                                } else {
                                    that.registered = false;
                                    if (data.code == "existing-email-error") {
                                        that.showAlert("Účet již existuje.");
                                    } else {
                                        that.showAlert(data.message);
                                    }
                                }
                            });
                        }
                    }
		        });
            },
            login(recaptcha) {
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/login",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ "email": this.newEmailAccount.Email, "password": this.newEmailAccount.Password, "recaptcha": recaptcha })
                }).done(function (data) {
                    if (data.result === 1) {
                        Vue.cookie.set('topVariables', data.topVariables, 1);
                        Vue.cookie.set('logged', true, 1);
                        Vue.cookie.set('session', data.session, 1);
                        window.location.pathname = '/';
                    } else {
                        Vue.cookie.set('topVariables', null, 1);
                        Vue.cookie.set('logged', false, 1);
                    }
                });
            }

	    },
        created() {
            if (JSON.stringify(this.$route.query) != "{}") {
                this.newEmailAccount.Email = this.$route.query.email;
            }
            //this.validateFields();
            //this.$recaptchaLoaded().then(() => {
            //    this.render();
            //})
        }

	}

</script>

<style lang="scss" scoped type="text/css">
</style>
