<template>
    <div class="container" v-show="authUser=='true'">
        <form @submit.prevent="validateForm('StepHeureka')" data-vv-scope="StepHeureka">
            <div class="row justify-content-center">

                <div class="col-lg-11 pb-3 col-xl-9" v-if="apiKeysInserted">

                    <div class="d-flex flex-row justify-content-between align-items-center my-3">
                        <div>
                            <!--<input type="text" class="form-control py-2" placeholder="Napište co chcete hledat" v-model="fn_FilteredList" />-->
                        </div>
                    </div>

                    <div class="list-group shadow-sm">
                        <p class="list-group-item group_item_blue bold width_100">Vložené klíče</p>
                        <div v-for="apiKey,index in apiKeyList" v-if="apiKey.Name.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1" class="list-group-item d-flex justify-content-between align-items-center list-group-item-action ">
                            <span class="width_100">
                                <span class="fas fa-exclamation-circle alert_pixel" v-if="!apiKey.isvalid" title="Zadaný klíč není validní nebo nebyl ověřen" alt="Zadaný klíč není funkční nebo nebyl ověřen"></span>
                                <span class="fas fa-check-circle alert_campaign" v-else-if="apiKey.isvalid" title="Zadaný klíč je funkční" alt="Zadaný klíč je funkční"></span>
                                <span class="margin-desc" style="margin-left: 0px;"><strong>{{apiKey.Name}}</strong></span>
                                <span class="margin-desc"><strong>{{apiKey.country}}</strong></span>
                                <span class="margin-desc">{{apiKey.heurekaAPIkey}}</span>
                                <div style="color:#666666">
                                    <span class="fas fa-exclamation-circle alert_pixel" style="visibility:hidden"></span>
                                    <span class="font-size-small">
                                        Poslední aktualizace: {{new Date(apiKey.lastCheck).toLocaleDateString("cs-CZ").replace(/\s+/g, '') + ' v ' + new Date(apiKey.lastCheck).toLocaleTimeString("cs-CZ") + ' | Počet recenzí k zobrazení: '+ apiKey.count + ' | Aktuální skóre: '+ Math.trunc(((100/5) * apiKey.lastScore))+'%'}}
                                        <i v-if="Math.trunc(((100/5) * apiKey.lastScore)) < 85" style="color:#dc3545; opacity:1;font-size:14px" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{class: 'v-tooltip_small', content: 'Jakmile průměrné hodnocení e-shopu za posledních 90 dní klesne pod 80 %,\nzastavíme zobrazování notifikací Recenze a hodnocení Heuréka.\nAktualizace dat probíhá každých 6 hodin.' }"></i>
                                    </span>
                                </div>
                            </span>

                            <span class="fa"></span>
                            <a class="btn btn-outline-secondary_red" style="padding-right: 3px;" title="Smazat" alt="Smazat" :class="{disabled: checkUsedApiKey(apiKey.heurekaAPIkey)}" v-on:click="deleteApikey(apiKey.Name,apiKey.heurekaAPIkey,index)">
                                <span class="fa fa-trash"></span>
                            </a>

                            <span class="fa"></span>
                            <a class="btn btn-outline-secondary_blue" style="padding-right: 3px;" title="Použito v kampaních" alt="Použito v kampaních" v-tooltip.bottom.end.click="{html: apiKey.id }">
                                <i class="fa fa-question-circle info">
                                    <div v-bind:id=apiKey.id class="descipt_url text-left" style="left:-120px;">
                                        <div class="width_100 text-left">Použito v kampaních:<div v-for="campaign in campaignList" v-if="campaign.heurekaAPIkey == apiKey.heurekaAPIkey" class="width_100 descipt text-left py-0">
                                            <span class="fa label_url text-right" style="vertical-align: middle;opacity: 1;">{{campaign.CampaignName}}</span>
                                            </div>
                                        </div>
                                    </div>
                                </i>
                            </a>
                        </div>
                    </div>

                </div>

                <div class="col-lg-11 pt-4 col-xl-9">
                    <div class="list-group mt-2 ">
                        <div class="list-group-item text-center shadow-sm">
                            <h2 class="pt-3">
                                Přidat Heureka API klíč
                            </h2>
                            <p>
                                Následujte instrukce níže nebo <a class="mycolor" href="https://napoveda.app.cz/navody/2-heureka-api-klic/?utm_source=app.app.cz&utm_medium=menu&utm_campaign=menu-heureka" target="_blank">navštivte centrum nápovědy</a>.
                            </p>
                        </div>
                        <div class="list-group-item p-5" style="background-color:#EDF6E2;">
                            <div class="row">
                                <div class="col-md-6 py-2">
                                    <input type="text" placeholder="Název webu" v-on:input="validateForm('StepHeureka')" v-model="StepHeureka.apiKeyName" name="apiKeyName" v-validate="{required: true, min: 1, max: 50}" class="form-control py-2" :class="{ 'is-invalid': errors.has('apiKeyName') }" />
                                    <span v-if="errors.has('apiKeyName')" class="invalid-feedback">{{ errors.first('apiKeyName') }}</span>
                                </div>
                                <div class="col-md-6 py-2">
                                    <select v-model="StepHeureka.country" style="height: calc(3rem + 6px);" v-on:change="validateForm('StepHeureka')" name="country" v-validate="{required: true}" class="form-control py-2" :class="{ 'is-invalid': errors.has('country') }">
                                        <option disabled="" value="none">Vyberte zemi</option>
                                        <option value="CZ">CZ</option>
                                        <option value="SK">SK</option>
                                    </select>
                                </div>
                                <div class="col-md-9 py-2">
                                    <input type="text" placeholder="API klíč" v-on:input="validateForm('StepHeureka')" v-model="StepHeureka.apiKey" name="apiKey" v-validate="{required: true, min: 32, max: 32}" class="form-control py-2" :class="{ 'is-invalid': errors.has('apiKey') }" />
                                    <span v-if="errors.has('apiKey')" class="invalid-feedback">{{ errors.first('apiKey') }}</span>
                                </div>
                                <div class="col-md-0 pt-2 ">
                                    <span class="fas fa-exclamation-circle alert_pixel" v-if="!keyValid && keyChecked" style="font-size:33px" title="Zadaný klíč není funkční" alt="Zadaný klíč není funkční"></span>
                                    <span class="fas fa-check-circle alert_campaign" v-else-if="keyValid && keyChecked" style="font-size:33px" title="Zadaný klíč je funkční" alt="Zadaný klíč je funkční"></span>
                                </div>
                                <div class="col-md-2 pt-2 ">
                                    <button class="btn btn-outline-secondary mr-2" style="padding: .5rem 1.5rem;" :disabled="!nextStepAllowed" v-on:click="checkIfKeyIsValid(StepHeureka.apiKey,StepHeureka.country)">Ověřit klíč</button>
                                </div>
                            </div>
                        </div>

                        <div class="list-group-item pb-4 pt-4 text-center">
                            <button class="btn btn-main-primary btn_new mr-2" style="padding: .5rem 1.5rem;" v-on:click="Save" :disabled="!nextStepAllowed || !keyValid">Uložit</button>
                            <button class="btn btn-outline-secondary mr-2" style="padding: .5rem 1.5rem;" v-on:click="SaveStep" :disabled="StepHeureka.Finished">Nemám Heuréku</button>
                        </div>
                    </div>
                    <br />
                    <div class="list-group mt-2 ">
                        <div class="list-group-item pl-5 pr-5">
                            <p class="bold" style="padding-top: 15px;">1. Otevřete Administraci e-shopu</p>
                            <p>Přihlaste se do svého Heureka účtu a v horním menu vyberte záložku Administrace e-shopu a kliknutím jí otevřete.</p>
                        </div>
                        <div class="list-group-item pl-5 pr-5">
                            <p class="bold" style="padding-top: 10px;">2. Záložka Ověřeno zákazníky</p>
                            <p>V levém menu vyhledejte odkaz Ověřeno zákazníky a kliknutím otevřete.</p>
                        </div>
                        <div class="list-group-item pl-5 pr-5">
                            <p class="bold" style="padding-top: 10px;">3. Zkopírujte Tajný klíč a vložte do app.cz</p>
                            <p>
                                V případě, že máte na Heureka.cz dostatek hodnocení a splňujete podmínky pro získání a udržení certifikátu Ověřeno zákazníky,<strong> níže na stránce je zobrazený Tajný klíč</strong>. Zkopírujte a vložte ho do pole v horní části této stránky.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </form>
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
            cs, en
        }
    });

    export default {
        data() {
            return {
                userUid: "none",
                userEmail: null,
                apiKeyList: [],
                countries:['none','CZ','SK'],
                apiKeysInserted: false,
                StepHeureka: {
                    Finished: false,
                    apiKey: "",
                    apiKeyName: "",
                    country: "none",
                    isvalid: false
                },
                authUser: Vue.cookie.get('logged') || false,
                fn_FilteredList: "",
                nextStepAllowed: false,
                campaignList: [],

                keyChecked: false,
                keyValid: false,
                recordList: []
            }
        },
        methods: {
            checkUsedApiKey(heurekaAPIkey) {
                var result = false;
                this.campaignList.forEach(function (entry) {
                    if (entry.heurekaAPIkey == heurekaAPIkey) {
                        result = true;
                    }
                })
                return result;
            },
            checkIfKeyIsValid(heurekaAPIkey, country) {
                this.keyChecked = true;
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/checkapikeyheureka",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), heurekaAPIkey: heurekaAPIkey, country: country, uuid: that.userUid })
                }).done(function (data) {
                    if (data.result === 1) {
                        data.message.forEach(function (record) {
                            that.recordList.push(record);
                        })
                        //data.message is array
                        that.keyValid = true;
                    } else {
                        that.recordList = [];
                        that.keyValid = false;
                    }
                });
            },
            deleteApikey(Name, heurekaAPIkey, index) {
                var that = this;
                const options = { title: 'Smazání API klíče', cancelLabel: 'Ne', size: 'sm' }
                this.$dialogs.confirm('Chcete opravdu smazat Api klíč: ' + Name, options)
                .then(res => {
                    if (res.ok) {
                        $.ajax({
                            type: "POST",
                            url: "https://appi.app.cz:444/delete_apikeyheureka",
                            dataType: "json",
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify({ session: Vue.cookie.get('session'), heurekaAPIkey: heurekaAPIkey, uuid: that.userUid })
                        }).done(function (data) {
                            if (data.result === 1) {
                                that.apiKeyList.splice(index, 1);
                            }
                        });
                    }
                });
            },	
            validateForm(scope) {
                var that = this;
                that.errors.clear();
                var inputHeureka = (that.StepHeureka.apiKey.length == 32) ? that.StepHeureka.apiKey : null;
                this.$validator.validateAll(scope).then((valid) => {
                    if (valid) {
                        this.nextStepAllowed = true;
                      
                        that.apiKeyList.forEach(function (apiKeyItem) {
                            if (apiKeyItem.Name.toLowerCase() == that.StepHeureka.apiKeyName.toLowerCase()) {
                                that.errors.add({ field: 'apiKeyName', msg: 'Název webu: ' + that.StepHeureka.apiKeyName + ' je již zadán.' });
                                that.nextStepAllowed = false;
                            }
                            if (apiKeyItem.heurekaAPIkey == inputHeureka) {
                                that.errors.add({ field: 'apiKey', msg: 'Klíč: ' + that.StepHeureka.apiKey + ' je již zadán.' });
                                that.nextStepAllowed = false;
                            }
                        })
                   
                        if (that.StepHeureka.country == 'none') {
                            that.errors.add({ field: 'country', msg: 'Vyberte zemi, ze které klíč pochází.' });
                            that.nextStepAllowed = false;
                        }
                      
                    } else {
                        that.errors.clear();
                        that.keyValid = false;

                        if (that.StepHeureka.apiKeyName.length == 0) {
                            that.errors.add({ field: 'apiKeyName', msg: 'Pojmenujte si API klíč – třeba podle URL webu.' });
                        }

                        if (that.StepHeureka.apiKey.length != 32) {
                            that.errors.add({ field: 'apiKey', msg: 'Opravdu je to Tajný klíč? Klíč obsahuje minimálně 32 znaků.' });
                        }

                        that.apiKeyList.forEach(function (apiKeyItem) {
                            if (apiKeyItem.Name.toLowerCase() == that.StepHeureka.apiKeyName.toLowerCase()) {
                                that.errors.add({ field: 'apiKeyName', msg: 'Název webu: ' + that.StepHeureka.apiKeyName + ' je již zadán.' });
                            }
                            if (apiKeyItem.heurekaAPIkey == inputHeureka) {
                                that.errors.add({ field: 'apiKey', msg: 'Klíč: ' + that.StepHeureka.apiKey + ' je již zadán.' });
                            }
                        })

                        if (that.StepHeureka.country == 'none') {
                            that.errors.add({ field: 'country', msg: 'Vyberte zemi, ze které klíč pochází.' });
                        }
 
                        that.nextStepAllowed = false;
                    }
                })
            },
            Save() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/insert_heurekaapikeys",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), heurekaapikey: that.StepHeureka.apiKey, name: that.StepHeureka.apiKeyName, uuid: that.userUid, country: that.StepHeureka.country, isvalid: that.keyValid })
                }).done(function (updateHeureka) {
                    if (updateHeureka.result == 1) {
                        that.StepHeureka.Finished = true;
                        that.showAlert("Api klíč byl uložen.");
                    }
                })
            },
            SaveStep() {
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
                        that.showAlert("Krok heuréka byl dokončen.");
                    }
                })
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                        window.location.pathname = '/HeurekaApi';
                    });
            },
        },

        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
        },

        created() {
            Vue.cookie.set('EditCampaignID', null, 1);
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_heurekaapikeys",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    if (apiKeys.heurekaapikeys != undefined) {
                        apiKeys.heurekaapikeys.forEach(function (apikey) {
                            that.apiKeysInserted = true;
                            that.apiKeyList.push(apikey);
                        });
                    }

                } else {
                    that.apiKeysInserted = false;
                }
            })

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_campaigns",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (dataCampaigns) {
                if (dataCampaigns.campaigns != undefined) {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        that.campaignList.push(campaign);

                    })
                }
            });

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_user_heureka",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    that.StepHeureka.Finished = apiKeys.Finished;
                }
            })
        }
    }
</script>
  