<template>

    <div class="registrations_content panel_right">
        <div class="row pl-5 pr-5">
            <div class="col-md-12 pb-2 pt-2">
                <button ref="closeBtn" type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="col-md-12">
                <h1 class="panel_right_h1">Poslední události – REGISTRACE</h1>
            </div>
            <div class="col-md-12 pb-2">
                <p class="under_title">
                    Zobrazí notifikace o kontaktech registrovaných z různých formulářů na webu, např. webinář, stažení e-booku, zasílání newsletteru atd.
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="notifikace">
                    <!--<img src="/images/notifikace/orders.png" class="notifikace_img" title="Poslední události – REGISTRACE" alt="Poslední události – REGISTRACE" />-->
                    <div class="Appi_bubble shadow noselect">
                        <span>
                            <img src="/images/product/registration.svg" class="svg_img" style="margin-right:10px;" title="Poslední události – REGISTRACE" alt="Poslední události – REGISTRACE" />
                        </span>
                        <span style="vertical-align: top;">
                            <div class="width_100" style="vertical-align: top;">
                                <span class="bold">{{regTextHeader}}</span>
                                <br />{{regUserText}}
                            </div>
                            <div class="width_100" style="vertical-align: top;">
                                <span style="color: lightgray;">{{timeInfo}} </span>
                                <img src="/images/product/star.png" class="flag_img" />
                                <span>{{by}}</span>
                                <span class="Appi_bubble_text">app</span>
                            </div>
                        </span>
                    </div>
                    <img src="/images/product/liveview.png" style="filter: grayscale(100%);position: relative;min-width: 210px;" />
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3">
                <div style="font-size:30px">DETAILNÍ NASTAVENÍ</div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Text v notifikaci
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3">
                <input type="text" v-model="MessageText" v-bind:placeholder="regUserText" v-on:input="validateRegistrations()" v-validate="{max: 35}" name="MessageText" class="form-control" :class="{ 'is-invalid': errors.has('MessageText') }" />
                <span v-if="errors.has('MessageText')" class="invalid-feedback">{{ errors.first('MessageText') }}</span>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Pravidla zobrazování notifikací
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3 form_inline_set">
                <div>Zobrazí maximálně posledních</div>&nbsp;&nbsp;<input type="text" v-model="ShowMaxLastReg" placeholder="20" v-on:input="validateRegistrations()" v-validate="{numeric:true, min_value:2, max_value: 500}" name="ShowMaxLastReg" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowMaxLastReg') }" />&nbsp;&nbsp;<div>registrovaných e-mailů</div>
            </div>
            <div class="col-md-12 py-3 form_inline_set">
                <div>
                    Zobrazí registrace jen za posledních
                    <i style="color:royalblue" class="fa fa-question-circle pointer"
                       v-tooltip.top="{ content: 'Doporučujeme nastavit 7 dní a méně, podle množství registrací. Maximum je 30 dní.' }"></i>
                </div>&nbsp;&nbsp;<input type="text" v-model="ShowRegFromLastDays" placeholder="7" v-on:input="validateRegistrations()" v-validate="{numeric:true, min_value:1, max_value: 30}" name="ShowRegFromLastDays" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowRegFromLastDays') }" />&nbsp;&nbsp;<div>dní</div>
            </div>
            <div class="col-md-12 py-3 form_inline_set">
                <div>
                    Zobrazí notifikaci pouze pokud je minimálně
                    <i style="color:royalblue" class="fa fa-question-circle pointer"
                       v-tooltip.top="{ content: 'Dokud není potřebný počet zde zadaných registrací, notifikace se nezobrazuje.' }"></i>
                </div>&nbsp;&nbsp;<input type="text" v-model="ShowWhenExistMinReg" placeholder="5" v-on:input="validateRegistrations()" v-validate="{numeric:true, min_value:1, max_value: 500}" name="ShowWhenExistMinReg" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowWhenExistMinReg') }" />&nbsp;&nbsp;<div>registrací</div>
            </div>
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Zobrazí nerozpoznaná jména jako „Návštěvník“
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Registrace, u kterých nebylo rozpoznáno jméno, budou zobrazeny slovem „Návštěvník“. Vypnutím funkce nebudou bezejmenné notifikace zobrazeny.' }"></i>
                    </div>
                    <div class="noselect">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: ShowAnonymEmails}" v-model="ShowAnonymEmails" v-on:click="ShowAnonymEmails = !ShowAnonymEmails" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                </div>
            </div>
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>Zobrazí návštěvníkům jejich vlastní registrace</div>
                    <div class="noselect">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: ShowOwnReg}" v-model="ShowOwnReg" v-on:click="ShowOwnReg = !ShowOwnReg" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                </div>
            </div>
            <!--<div class="col-md-12 py-3">
            <div class="d-flex flex-row justify-content-between align-items-center">
                <div>Zobraz všechny konverze jako anonymní</div>
                <div>
                    <span class="toogle_desc">OFF</span>
                    <button type="button" class="btn btn-toggle" data-toggle="button" aria-pressed="false" autocomplete="off">
                        <div class="handle"></div>
                    </button>
                    <span class="toogle_desc">ON</span>
                </div>
            </div>
        </div>-->
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Neustálé opakování notifikací
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Když máte např. 5 registrací, po páté se začnou zobrazovat znovu od první. Vypnutím zastavíte opakování smyčky registrací.' }"></i>
                    </div>
                    <div class="noselect">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: CycleShowing}" v-on:click="CycleShowing = !CycleShowing" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5 pb-5">
            <div class="col-md-12 border-top pt-3">
                <button class="btn btn-outline-secondary btn_new" :disabled="!SaveAllowed" v-on:click="Save">Uložit</button>
            </div>
        </div>
    </div>

</template>

<script>
    import { mapState } from 'vuex';
 	import Vue from 'vue';
	import VueCookie from 'vue-cookie';
	import SlimDialog from 'v-slim-dialog';
    import VeeValidate from 'vee-validate';
    import VueI18n from 'vue-i18n';
    import axios from 'axios';

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

    import Tooltip from 'vue-directive-tooltip';
    import vulgarCZ from "../store/vulgarCZ.json";
    import vulgarEN from "../store/vulgarEN.json";
    import vulgarSK from "../store/vulgarSK.json";

    Vue.use(Tooltip); 

    Vue.use(SlimDialog);
    Vue.use(VueCookie);
    Vue.use(VueI18n);

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
                adminAccess: false,
                userUid: "none",
                userEmail: null,
                selectedLanguage: this.$store.state.selectedLanguage,
                dictionaryList: [],

                MessageText: "",
                ShowMaxLastReg: "",
                ShowRegFromLastDays: "",
                ShowWhenExistMinReg: "",
                ShowAnonymEmails: true,
                ShowOwnReg: "",
                CycleShowing: true,
                SaveAllowed: true,
                regUserText: "se přihlásil/a k odběru novinek",
                regTextHeader: "Martin z České Třebové",
                by: 'od',
                timeInfo: 'před 5 minutami'
            }
        },
        computed: mapState({
            state: state => state.LastEventsRegistrations
        }),
        mounted() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getNDictionary",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({
                    session: Vue.cookie.get('session'),
                    using: 'app',
                })
            }).done(function (data) {
                that.dictionaryList = data.nDictionary;
                that.regUserText = that.translateAppi('regUserText', that.selectedLanguage);
                that.regTextHeader = that.translateAppi('regTextHeader', that.selectedLanguage);
                that.by = that.translateAppi('by', that.selectedLanguage);
                that.timeInfo = that.translateAppi('timeInfo', that.selectedLanguage);
            });
        },
        methods: {
            translateAppi(word, language) {
                try {
                    return this.dictionaryList.filter(function (s, i) {
                        return (s["systemName"] == word);
                    })[0][language];
                } catch (err) {
                    return null;
                }
            },
            checkVulgar(fieldName, text, language) {
                this.selectedLanguage = this.$store.state.selectedLanguage;
                let res = true;
                var that = this;
                switch (language) {
                    case "cs":
                        vulgarCZ.forEach(function (child) {
                            if (text.includes(child + " ")) {
                                that.errors.add({ field: fieldName, msg: 'Pardon, ale pod tohle se teda nepodepíšem' });
                                res = false;
                            }
                        });
                        break;
                    case "sk":
                        vulgarSK.forEach(function (child) {
                            if (text.includes(child + " ")) {
                                that.errors.add({ field: fieldName, msg: 'Pardon, ale pod tohle se teda nepodepíšem' });
                                res = false;
                            }
                        });
                        break;
                    case "en":
                        vulgarEN.forEach(function (child) {
                            if (text.includes(child + " ")) {
                                that.errors.add({ field: fieldName, msg: 'Pardon, ale pod tohle se teda nepodepíšem' });
                                res = false;
                            }
                        });
                        break;
                }
                return res;
            },
            validateRegistrations() {
                var that = this;
                this.$validator.validateAll().then((valid) => {
                    if (valid) {
                        this.errors.clear();
                        this.SaveAllowed = true;
                        if (that.MessageText != null) {
                            if (!that.checkVulgar('MessageText', that.MessageText, that.selectedLanguage)) {
                                that.SaveAllowed = false;
                            }
                        }
                      
                    } else { this.SaveAllowed = false; }
                })
            },
            Save() {
                if (this.MessageText) {
                    switch (this.selectedLanguage) {
                        case "cs":
                            this.state.MessageTextCz = this.MessageText;
                            break;
                        case "sk":
                            this.state.MessageTextSk = this.MessageText;
                            break;
                        case "en":
                            this.state.MessageTextEn = this.MessageText;
                            break;
                    }
                }
                else {
                    switch (this.selectedLanguage) {
                        case "cs":
                            this.state.MessageTextCz = this.$store.getters.LASTEVENTSREGISTRATIONS_MessageTextCz;
                            break;
                        case "sk":
                            this.state.MessageTextSk = this.$store.getters.LASTEVENTSREGISTRATIONS_MessageTextSk;
                            break;
                        case "en":
                            this.state.MessageTextEn = this.$store.getters.LASTEVENTSREGISTRATIONS_MessageTextEn;
                            break;
                    }
                }

                if (this.ShowMaxLastReg) {
                    this.state.ShowMaxLastReg = this.ShowMaxLastReg;
                }
                else {
                    this.state.ShowMaxLastReg = this.$store.getters.LASTEVENTSREGISTRATIONS_ShowMaxLastReg;
                }

                if (this.ShowRegFromLastDays) {
                    this.state.ShowRegFromLastDays = this.ShowRegFromLastDays;
                }
                else {
                    this.state.ShowRegFromLastDays = this.$store.getters.LASTEVENTSREGISTRATIONS_ShowRegFromLastDays;
                }

                if (this.ShowWhenExistMinReg) {
                    this.state.ShowWhenExistMinReg = this.ShowWhenExistMinReg;
                }
                else {
                    this.state.ShowWhenExistMinReg = this.$store.getters.LASTEVENTSREGISTRATIONS_ShowWhenExistMinReg;
                }

                    this.state.ShowAnonymEmails = this.ShowAnonymEmails;


                if (this.ShowOwnReg) {
                    this.state.ShowOwnReg = this.ShowOwnReg;
                }
                else {
                    this.state.ShowOwnReg = this.$store.getters.LASTEVENTSREGISTRATIONS_ShowOwnReg;
                }

                    this.state.CycleShowing = this.CycleShowing;

                this.$refs.closeBtn.click();//this.showAlert("Saved");
            },
			showAlert(val) {
				const options = {title: 'Info', size: 'sm'}
				this.$dialogs.alert(val, options)
					.then(res => {
				});
            },
            GetCampaignData() {
                return new Promise((resolve, reject) => {
                    return axios.post('https://appi.app.cz:444/get_campaigns', {
                        session: Vue.cookie.get('session'),
                        uuid: this.userUid
                    }).then((dataCampaigns) => {
                        resolve(dataCampaigns.data);
                    }).catch((error) => {
                        //console.log(error);
                        reject(error)
                    })
                });
            }
        },
        watch: {
            MessageText() {
                if (this.MessageText.length > 0) {
                    this.regUserText = this.MessageText;
                } else {
                    this.regUserText = this.translateAppi('regUserText', this.selectedLanguage);
                }
                this.validateRegistrations();
            },
            '$store.state.selectedLanguage': function () {
                this.selectedLanguage = this.$store.state.selectedLanguage;
                if (this.MessageText.length > 0) {
                    this.regUserText = this.MessageText;
                } else {
                    this.regUserText = this.translateAppi('regUserText', this.selectedLanguage);
                }
                this.regTextHeader = this.translateAppi('regTextHeader', this.selectedLanguage);
                this.by = this.translateAppi('by', this.selectedLanguage);
                this.timeInfo = this.translateAppi('timeInfo', this.selectedLanguage);
                this.validateRegistrations();
            }
        },
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            if (Vue.cookie.get('EditCampaignID') != 'null' && Vue.cookie.get('EditCampaignID') != undefined) {
                var selectedCampaignID = Vue.cookie.get('EditCampaignID');
                this.GetCampaignData().then(dataCampaigns => {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        if (campaign.campaignID == selectedCampaignID) {
                            that.MessageText = (campaign.LastEventsRegistrations.MessageText) ? campaign.LastEventsRegistrations.MessageText : '';
                            that.ShowMaxLastReg = campaign.LastEventsRegistrations.ShowMaxLastReg;
                            that.ShowRegFromLastDays = campaign.LastEventsRegistrations.ShowRegFromLastDays;
                            that.ShowWhenExistMinReg = campaign.LastEventsRegistrations.ShowWhenExistMinReg;
                            that.ShowAnonymEmails = campaign.LastEventsRegistrations.ShowAnonymEmails;
                            that.ShowOwnReg = campaign.LastEventsRegistrations.ShowOwnReg;
                            that.CycleShowing = campaign.LastEventsRegistrations.CycleShowing;

                            that.$store.state.LastEventsRegistrations = campaign.LastEventsRegistrations;
                            switch (that.selectedLanguage) {
                                case "cs":
                                    that.$store.state.LastEventsRegistrations.MessageTextCz = campaign.LastEventsRegistrations.MessageText;
                                    break;
                                case "sk":
                                    that.$store.state.LastEventsRegistrations.MessageTextSk = campaign.LastEventsRegistrations.MessageText;
                                    break;
                                case "en":
                                    that.$store.state.LastEventsRegistrations.MessageTextEn = campaign.LastEventsRegistrations.MessageText;
                                    break;
                            }
                        }
                    })
                })
            }
		}
    }
</script>