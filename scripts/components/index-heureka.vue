<template>
    <div class="heureka_key_content panel_right">
        <form @submit.prevent="validateFormHeureka('StepHeureka')" data-vv-scope="StepHeureka">
            <div class="row pl-5 pr-5">
                <div class="col-md-12 pb-4 pt-3">
                    <button ref="closeBtn" type="button" class="close" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="col-md-12 text-center pt-2 pb-2">
                    <h1 class="panel_right_h2">Vložte API klíč Heuréka</h1>
                </div>
                <div class="col-md-12 py-2 text-center">
                    <p class="under_title">Pro zobrazování recenzí a hodnocení zákazníků stačí jen vložit Tajný klíč (alfanumerický kód), který získáte v administraci vašeho účtu na heureka</p>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="Název webu" v-on:input="validateFormHeureka('StepHeureka')" v-model="StepHeureka.apiKeyName" name="apiKeyName" v-validate="{required: true, min: 1, max: 50}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepHeureka.apiKeyName') }" />
                    <span v-if="errors.has('StepHeureka.apiKeyName')" class="invalid-feedback">{{ errors.first('StepHeureka.apiKeyName') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <select v-model="StepHeureka.country" style="height: calc(3rem + 6px);" v-on:change="validateFormHeureka('StepHeureka')" name="country" v-validate="{required: true}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepHeureka.country') }">
                        <option disabled="" value="none">Vyberte zemi</option>
                        <option value="CZ">CZ</option>
                        <option value="SK">SK</option>
                    </select>
                </div>


                <div class="col-md-9 py-2">
                    <input type="text" placeholder="API klíč" v-on:input="validateFormHeureka('StepHeureka')" v-model="StepHeureka.apiKey" name="apiKey" v-validate="{ required: true, min: 32, max: 32}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepHeureka.apiKey') }" />
                    <span v-if="errors.has('StepHeureka.apiKey')" class="invalid-feedback">{{ errors.first('StepHeureka.apiKey') }}</span>
                </div>
                <div class="col-md-0 pt-2 ">
                    <span class="fas fa-exclamation-circle alert_pixel" v-if="!heurekaKeyValid && heurekaKeyChecked" style="font-size:33px" title="Zadaný klíč není funkční" alt="Zadaný klíč není funkční"></span>
                    <span class="fas fa-check-circle alert_campaign" v-else-if="heurekaKeyValid && heurekaKeyChecked" style="font-size:33px" title="Zadaný klíč je funkční" alt="Zadaný klíč je funkční"></span>
                </div>
                <div class="col-md-2 pt-2 ">
                    <button class="btn btn-outline-secondary mr-2" style="padding: .5rem 1.5rem;" :disabled="!nextStepAllowedHeureka" v-on:click="checkIfHeurekaKeyIsValid(StepHeureka.apiKey,StepHeureka.country)">Ověřit klíč</button>
                </div>
                <!--<div class="col-md-12 py-3 pixel_sending text-center">
        <input type="text" placeholder="Název webu" v-on:input="validateForm('StepHeureka')" v-model="StepHeureka.apiKeyName" name="apiKeyName" v-validate="{required: true, min: 1, max: 255}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepHeureka.apiKeyName') }" />
        <span v-if="errors.has('StepHeureka.apiKeyName')" class="invalid-feedback">{{ errors.first('StepHeureka.apiKeyName') }}</span>
    </div>-->

                <div class="col-md-12 pt-4 text-center pb-5">
                    <button class="btn btn-main-primary btn_new mr-2" style=" margin-bottom: 10px;padding: .5rem 1.5rem;" v-on:click="SaveHeureka" :disabled="!nextStepAllowedHeureka || !heurekaKeyValid">Uložit</button>
                    <button class="btn btn-outline-secondary" style=" margin-bottom: 10px;padding: .5rem 1.5rem;" v-on:click="SaveStepHeureka" :disabled="StepHeureka.Finished">Nemám Heuréku</button>
                    <!--<a class="btn btn-outline-secondary" style=" margin-bottom: 10px;" href="https://napoveda.app.cz/navody/2-heureka-api-klic/?utm_source=app.app.cz&utm_medium=zaciname-heureka&utam_campaign=zaciname-heureka" target="_blank">Přečíst nápovědu</a>-->
                </div>
                <br />
                <br />
                <p style="padding-left: 40px;">
                    Rychlá nápověda
                    <i style="padding-left:8px;" class="fa fa-question-circle pointer mycolor"
                       v-tooltip.top="{ content: '1. Otevřete v účtu heureka. Administraci e-shopu\n2. Vyhledejte v menu záložku Ověřeno zákazníky\n3. Zkopírujte Tajný klíč a vložte ho do pole API klíč' }"></i>
                    <br />
                    Pro kompletní návod <a class="mycolor" href="https://napoveda.app.cz/navody/2-heureka-api-klic/?utm_source=app.app.cz&utm_medium=zaciname-heureka&utm_campaign=zaciname-heureka" target="_blank">navštivte centrum nápovědy</a>.
                </p>
                <!--<div class="width_100 under_title bold" style="padding-left: 40px;">Rychlá nápověda:</div>
    <div style="padding-left: 40px;">1. Otevřete v účtu heureka.cz Administraci e-shopu</div>
    <div style="padding-left: 40px;">2. Vyhledejte v menu záložku Ověřeno zákazníky</div>
    <div style="padding-left: 40px;">3. Zkopírujte Tajný klíč a vložte ho do pole API klíč</div>-->
            </div>
        </form>

        <hr style="border-width: 1px;border-style: inset;margin:30px;">

        <form @submit.prevent="validateFormZbozi('StepZbozi')" data-vv-scope="StepZbozi">
            <div class="row pl-5 pr-5">
                <div class="col-md-12 text-center pt-2 pb-2">
                    <h1 class="panel_right_h2">Vložte API klíč Zboží.cz</h1>
                </div>
                <div class="col-md-12 py-2 text-center">
                    <p class="under_title">Pro zobrazování recenzí a hodnocení zákazníků stačí jen vložit API klíč (alfanumerický kód), který získáte v administraci vašeho účtu na zboží.cz</p>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="Název webu" v-on:input="validateFormZbozi('StepZbozi')" v-model="StepZbozi.apiKeyName" name="apiKeyName" v-validate="{required: true, min: 1, max: 50}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepZbozi.apiKeyName') }" />
                    <span v-if="errors.has('StepZbozi.apiKeyName')" class="invalid-feedback">{{ errors.first('StepZbozi.apiKeyName') }}</span>
                </div>
                <div class="col-md-6 py-2">
                    <input type="text" placeholder="ID provozovny" v-on:input="validateFormZbozi('StepZbozi')" v-model="StepZbozi.idProvozovny" name="idProvozovny" v-validate="{ required: true, min: 1, max: 24}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepZbozi.idProvozovny') }" />
                    <span v-if="errors.has('StepZbozi.idProvozovny')" class="invalid-feedback">{{ errors.first('StepZbozi.idProvozovny') }}</span>
                </div>

                <div class="col-md-9 py-2">
                    <input type="text" placeholder="API klíč" v-on:input="validateFormZbozi('StepZbozi')" v-model="StepZbozi.apiKey" name="apiKey" v-validate="{ required: true, min: 30, max: 64}" class="form-control py-2" :class="{ 'is-invalid': errors.has('StepZbozi.apiKey') }" />
                    <span v-if="errors.has('StepZbozi.apiKey')" class="invalid-feedback">{{ errors.first('StepZbozi.apiKey') }}</span>
                </div>
                <div class="col-md-0 pt-2">
                    <span class="fas fa-exclamation-circle alert_pixel" v-if="!zboziKeyValid && zboziKeyChecked" style="font-size:33px" title="Zadaný klíč není funkční" alt="Zadaný klíč není funkční"></span>
                    <span class="fas fa-check-circle alert_campaign" v-else-if="zboziKeyValid && zboziKeyChecked" style="font-size:33px" title="Zadaný klíč je funkční" alt="Zadaný klíč je funkční"></span>
                </div>
                <div class="col-md-2 pt-2 text-right">
                    <button class="btn btn-outline-secondary mr-2" style="padding: .5rem 1.5rem;" :disabled="!nextStepAllowedZbozi" v-on:click="checkIfZboziKeyIsValid(StepZbozi.idProvozovny,StepZbozi.apiKey)">Ověřit klíč</button>
                </div>

                <div class="col-md-12 pt-4 text-center pb-5">
                    <button class="btn btn-main-primary btn_new mr-2" style="margin-bottom: 10px;padding: .5rem 1.5rem;" v-on:click="SaveZbozi" :disabled="!nextStepAllowedZbozi || !zboziKeyValid">Uložit</button>
                    <button class="btn btn-outline-secondary" style="margin-bottom: 10px;padding: .5rem 1.5rem;" v-on:click="SaveStepZbozi" :disabled="StepZbozi.Finished">Nemám Zboží.cz</button>
                    <!--<a class="btn btn-outline-secondary" style="margin-bottom: 10px;" href="https://napoveda.app.cz/navody/2-zbozi-api-klic/?utm_source=app.app.cz&utm_medium=zaciname-zbozi&utm_campaign=zaciname-zbozi" target="_blank">Přečíst nápovědu</a>-->
                </div>
                <br /><br />
                <p style="padding-left: 40px;">
                    Rychlá nápověda
                    <i style="padding-left:8px;" class="fa fa-question-circle pointer mycolor"
                       v-tooltip.top="{ content: '1. V administraci Zboží.cz otevřete záložku Provozovna.\n2. Zkopírujte ID vybraného e-shopu a vložte do pole ID provozovny.\n3. V záložce Správa API vygenerujte nový API klíč a vložte do pole API klíč.' }"></i>
                    <br />
                    Pro kompletní návod <a class="mycolor" href="https://napoveda.app.cz/navody/2-zbozi-api-klic/?utm_source=app.app.cz&utm_medium=zaciname-zbozi&utm_campaign=zaciname-zbozi" target="_blank">navštivte centrum nápovědy</a>.
                </p>
                <!--<div class="width_100 under_title bold" style="padding-left: 40px;">Rychlá nápověda:</div>
    <div style="padding-left: 40px;">1. Otevřete v účtu zboží.cz Administraci e-shopu</div>
    <div style="padding-left: 40px;">2. Vyhledejte v menu záložku Ověřeno zákazníky</div>
    <div style="padding-left: 40px;">3. Zkopírujte Tajný klíč a vložte ho do pole API klíč</div>-->
            </div>
        </form>
        <p style="padding-bottom:14px"></p>
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
                StepHeureka: {
                    Finished: false,
                    apiKey: "",
                    apiKeyName: "",
                    country: "none",
                    isvalid: false
                },
                StepZbozi: {
                    Finished: false,
                    apiKey: "",
                    apiKeyName: "",
                    idProvozovny: "",
                    isvalid: false
                },
                nextStepAllowedHeureka: false,
                nextStepAllowedZbozi: false,
                apiKeyListHeureka: [],
                apiKeyListZbozi: [],
                userUid: "none",
                heurekaKeyValid: false,
                zboziKeyValid: false,
                heurekaKeyChecked: false,
                zboziKeyChecked: false,
            }
        },
        methods: {

            validateFormHeureka(scope) {
                var that = this;
                this.errors.clear();
                var inputHeureka = (that.StepHeureka.apiKey.length == 32) ? that.StepHeureka.apiKey : null;
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        this.nextStepAllowedHeureka = true;
                      
                        that.apiKeyListHeureka.forEach(function (apiKeyItem) {
                            if (apiKeyItem.Name.toLowerCase() == that.StepHeureka.apiKeyName.toLowerCase()) {
                                that.errors.add({ field: 'StepHeureka.apiKeyName', msg: 'Název webu: ' + that.StepHeureka.apiKeyName + ' je již zadán.' });
                                that.nextStepAllowedHeureka = false;
                            }
                            if (apiKeyItem.heurekaAPIkey == inputHeureka) {
                                that.errors.add({ field: 'StepHeureka.apiKey', msg: 'Klíč: ' + that.StepHeureka.apiKey + ' je již zadán.' });
                                that.nextStepAllowedHeureka = false;
                            }
                        })

                        if (that.StepHeureka.country == 'none') {
                            that.errors.add({ field: 'StepHeureka.country', msg: 'Vyberte zemi, ze které klíč pochází.' });
                            that.nextStepAllowed = false;
                        }

                    } else {
                        that.errors.clear();
                        that.heurekaKeyValid = false;

                        if (that.StepHeureka.apiKeyName.length == 0) {
                            that.errors.add({ field: 'StepHeureka.apiKeyName', msg: 'Pojmenujte si API klíč – třeba podle URL webu.' });
                        }

                        if (that.StepHeureka.apiKey.length != 32) {
                            that.errors.add({ field: 'StepHeureka.apiKey', msg: 'Opravdu je to Tajný klíč? Klíč obsahuje minimálně 32 znaků.' });
                        }

                        that.apiKeyListHeureka.forEach(function (apiKeyItem) {
                            if (apiKeyItem.Name.toLowerCase() == that.StepHeureka.apiKeyName.toLowerCase()) {
                                that.errors.add({ field: 'StepHeureka.apiKeyName', msg: 'Název webu: ' + that.StepHeureka.apiKeyName + ' je již zadán.' });
                                that.nextStepAllowedHeureka = false;
                            }
                            if (apiKeyItem.heurekaAPIkey == inputHeureka) {
                                that.errors.add({ field: 'StepHeureka.apiKey', msg: 'Klíč: ' + that.StepHeureka.apiKey + ' je již zadán.' });
                                that.nextStepAllowedHeureka = false;
                            }
                        })

                        if (that.StepHeureka.country == 'none') {
                            that.errors.add({ field: 'StepHeureka.country', msg: 'Vyberte zemi, ze které klíč pochází.' });
                        }

                        that.nextStepAllowedHeureka = false;
                    }
                })
            },
            validateFormZbozi(scope) {
                var that = this;
                this.errors.clear();
                var inputZbozi = (that.StepZbozi.apiKey.length == 64) ? that.StepZbozi.apiKey : null;
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        this.nextStepAllowedZbozi = true;
                        that.zboziKeyValid = false; 

                        if (that.StepZbozi.apiKeyName.length == 0) {
                            that.errors.add({ field: 'StepZbozi.apiKeyName', msg: 'Pojmenujte si API klíč – třeba podle URL webu.' });
                        }
                        if (that.StepZbozi.idProvozovny.length == 0) {
                            that.errors.add({ field: 'StepZbozi.idProvozovny', msg: 'Vložte číselný kód ID Provozovny.' });
                        }

                        if (that.StepZbozi.apiKey.length < 30 || that.StepZbozi.apiKey.length > 64) {
                            that.errors.add({ field: 'StepZbozi.apiKey', msg: 'Vložte správný API klíč a poté ověřte.' });
                        }

                        that.apiKeyListZbozi.forEach(function (apiKeyItem) {
                            if (apiKeyItem.Name.toLowerCase() == that.StepZbozi.apiKeyName.toLowerCase()) {
                                that.errors.add({ field: 'StepZbozi.apiKeyName', msg: 'Název webu: ' + that.StepZbozi.apiKeyName + ' je již zadán.' });
                                that.nextStepAllowedZbozi = false;
                            }
                            if (apiKeyItem.zboziAPIkey == inputZbozi) {
                                that.errors.add({ field: 'StepZbozi.apiKey', msg: 'Klíč: ' + that.StepZbozi.apiKey + ' je již zadán.' });
                                that.nextStepAllowedZbozi = false;
                            }
                        })
                    } else {
                        that.apiKeyListZbozi.forEach(function (apiKeyItem) {
                            if (apiKeyItem.Name.toLowerCase() == that.StepZbozi.apiKeyName.toLowerCase()) {
                                that.errors.add({ field: 'StepZbozi.apiKeyName', msg: 'Název webu: ' + that.StepZbozi.apiKeyName + ' je již zadán.' });
                                that.nextStepAllowedZbozi = false;
                            }
                            if (apiKeyItem.zboziAPIkey == inputZbozi) {
                                that.errors.add({ field: 'StepZbozi.apiKey', msg: 'Klíč: ' + that.StepZbozi.apiKey + ' je již zadán.' });
                                that.nextStepAllowedZbozi = false;
                            }
                        })
                        that.nextStepAllowedZbozi = false;
                    }
                })
            },
            checkIfHeurekaKeyIsValid(heurekaAPIkey, country) {
                this.heurekaKeyChecked = true;
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/checkapikeyheureka",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), heurekaAPIkey: heurekaAPIkey, country: country, uuid: that.userUid })
                }).done(function (data) {
                    if (data.result === 1) {
                        //data.message is array
                        that.heurekaKeyValid = true;
                    } else {
                        that.heurekaKeyValid = false;
                    }
                });
            },
            checkIfZboziKeyIsValid(idProvozovny, apiKey) {
                this.zboziKeyChecked = true;
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/checkapikeyzbozi",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), idprovozovny: idProvozovny, zboziapikey: apiKey, uuid: that.userUid })
                }).done(function (data) {
                    if (data.result === 1) {
                        //data.message is array
                        that.zboziKeyValid = true;
                    } else {
                        that.zboziKeyValid = false;
                    }
                });
            },
            SaveHeureka() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/insert_heurekaapikeys",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), heurekaapikey: that.StepHeureka.apiKey, name: that.StepHeureka.apiKeyName, country: that.StepHeureka.country, isvalid: that.heurekaKeyValid })
                }).done(function (updateHeureka) {
                    if (updateHeureka.result == 1) {
                        that.StepHeureka.Finished = true;
                        that.$emit("changesFinished", that.StepHeureka.Finished);
                        that.$refs.closeBtn.click();/*this.showAlert("Saved");*/
                        window.location.pathname = '/';
                    }

                })
            },
            SaveStepHeureka() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/update_user_heureka",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), Finished: true, uuid: that.userUid })
                }).done(function (updateHeureka) {
                    if (updateHeureka.result == 1) {
                        that.StepHeureka.Finished = true;
                        that.$emit("changesFinished", that.StepHeureka.Finished);
                        that.$refs.closeBtn.click();/*this.showAlert("Saved");*/
                        window.location.pathname = '/';
                    }
                })
            },
            SaveZbozi() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/insert_zboziapikeys",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), idprovozovny: that.StepZbozi.idProvozovny, zboziapikey: that.StepZbozi.apiKey, name: that.StepZbozi.apiKeyName, isvalid: that.zboziKeyValid })
                }).done(function (updateZbozi) {
                    if (updateZbozi.result == 1) {
                        that.StepZbozi.Finished = true;
                        that.$emit("changesFinished", that.StepZbozi.Finished);
                        that.$refs.closeBtn.click();/*this.showAlert("Saved");*/
                        window.location.pathname = '/';
                    }

                })
            },
            SaveStepZbozi() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/update_user_zbozi",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), Finished: true, uuid: that.userUid })
                }).done(function (updateZbozi) {
                    if (updateZbozi.result == 1) {
                        that.StepZbozi.Finished = true;
                        that.$emit("changesFinished", that.StepZbozi.Finished);
                        that.$refs.closeBtn.click();/*this.showAlert("Saved");*/
                        window.location.pathname = '/';
                    }
                })
            },
			showAlert(val) {
			    const options = {title: 'Info', size: 'sm'}
			    this.$dialogs.alert(val, options)
					.then(res => {
				});
			},
        },
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_heurekaapikeys",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    if (apiKeys.heurekaapikeys != undefined) {
                        apiKeys.heurekaapikeys.forEach(function (apikey) {
                            that.apiKeyListHeureka.push(apikey);
                        })
                    }
                }
            })
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_user_heureka",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    that.StepHeureka.Finished = apiKeys.Finished;
                    that.$emit("changesFinished", apiKeys.Finished);
                }
            })
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_zboziapikeys",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    if (apiKeys.zboziapikeys != undefined) {
                        apiKeys.zboziapikeys.forEach(function (apikey) {
                            that.apiKeyListZbozi.push(apikey);
                        })
                    }
                }
            })
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_user_zbozi",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    that.StepZbozi.Finished = apiKeys.Finished;
                    if (!that.StepHeureka.Finished) {that.$emit("changesFinished", apiKeys.Finished);}
                }
            })
        }
    }
</script>