<template>

    <div class="visits_content panel_right">
        <div class="row pl-5 pr-5">
            <div class="col-md-12 pb-2 pt-2">
                <button ref="closeBtn" type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="col-md-12">
                <h1 class="panel_right_h1">Aktuální návštěvníci</h1>
            </div>
            <div class="col-md-12 pb-2">
                <p class="under_title">Zobrazí kolik návštěvníků si aktuálně prohlíží specifickou stránku nebo celý web.</p>
            </div>
        </div>
    
        <div class="row">
            <div class="col-md-12">
                <div class="notifikace">
                    <!--<img src="/images/notifikace/visitors.svg" class="notifikace_img" title="Počet návštěv" alt="Počet návštěv" />-->

                    <div class="Appi_bubble shadow noselect">
                        <span>
                            <img src="/images/product/visits.svg" class="svg_img" style="margin-right:10px;" title="Počet návštěv" alt="Počet návštěv" />
                        </span>
                        <span style="vertical-align: top;">
                            <div class="width_100" style="vertical-align: top;">
                                <span class="Appi_bubble_text_bold visit_color">137 {{visitUserText}}</span>
                                <br />{{visitLookingNow}} {{visitPageText}}
                            </div>
                            <div class="width_100" style="vertical-align: top;">
                                <span class="Appi_bubble_check"></span>
                                <span style="color: lightgray;">{{verifyFrom}} </span>
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
            <div class="col-md-12 py-3 form_inline_set">
                <div>
                    Pojmenujte návštěvníky
                    <i style="color:royalblue" class="fa fa-question-circle pointer"
                       v-tooltip.top="{ content: 'Pojmenujte si návštěvníky podle svého = slovo za číslovkou, např.: lidí, skvělých bajkerů, zahrádkářů, marketérů, nadšenců, čumilů :)' }"></i>
                </div>&nbsp;&nbsp;<input type="text" v-model="MessageText" v-bind:placeholder="visitUserText" v-on:input="validateVisit()" v-validate="{max: 15}" name="MessageText" class="form-control form_control_set_width_2" :class="{ 'is-invalid': errors.has('MessageText') }" />
            </div>
            <span v-if="errors.has('MessageText')" class="invalid-feedback" style="display: inline;left: 215px;width: 100%;top: -10px;position: relative;"> {{ errors.first('MessageText') }}</span>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Pravidla zobrazování notifikací
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Zobrazí počet návštěvníků celého webu
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Zapnutím se zobrazí pouze aktuální počet návštěvníků na celém webu. Doporučujeme při nižší návštěvnosti.' }"></i>
                    </div>
                    <div class="noselect">
                        <span class="toogle_desc">NE </span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: ShowDomainVisitCount}" v-on:click="showVisitsForFullDomain()" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                </div>
            </div>
            <div class="col-md-12 py-3 form_inline_set">
                <div>Zobrazí počet návštěvníků od</div>&nbsp;&nbsp;<input type="text" v-model="ShowCountHigherThan" placeholder="20" v-on:input="validateVisit()" v-validate="{numeric:true, min_value:2, max_value: 500}" name="ShowCountHigherThan" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowCountHigherThan') }" />&nbsp;&nbsp;<div>lidí na stránce/na celém webu</div>
            </div>
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Neustálé opakování notifikací
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Vypnutím zastavíte opakované zobrazování této notifikace. Zobrazí se jen jednou.' }"></i>
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
    import vulgarCZ from "../store/vulgarCZ.json";
    import vulgarEN from "../store/vulgarEN.json";
    import vulgarSK from "../store/vulgarSK.json";
    import axios from 'axios';
    
    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

    import Tooltip from 'vue-directive-tooltip';
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

                ShowDomainVisitCount: false,
                ShowCountHigherThan: "",
                CycleShowing: true,
                MessageText: "",
                SaveAllowed: true,
                visitUserText: "návštěvníků",
                visitLookingNow: "si právě prohlíží",
                visitPageText: "tuto stránku",
                verifyFrom:"ověřeno od"
            }
        },
        computed: mapState({
            state: state => state.VisitCount
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
                that.visitUserText = that.translateAppi('visitUserText', that.selectedLanguage);
                that.visitLookingNow = that.translateAppi('visitLookingNow', that.selectedLanguage);
                that.visitPageText = that.translateAppi('pageText', that.selectedLanguage);
                that.verifyFrom = that.translateAppi('verifyFrom', that.selectedLanguage);
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
            validateVisit() {
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

            //	Vue.cookie.set('EditCampaign',CampaignName,1);
            Save() {
                    this.state.ShowDomainVisitCount = this.ShowDomainVisitCount;
                if (this.ShowCountHigherThan) {
                    this.state.ShowCountHigherThan = this.ShowCountHigherThan;
                }
                else {
                    this.state.ShowCountHigherThan = this.$store.getters.VISITCOUNT_ShowCountHigherThan;
                }

                this.state.CycleShowing = this.CycleShowing;

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
                            this.state.MessageTextCz = this.$store.getters.VISITCOUNT_MessageTextCz;
                            break;
                        case "sk":
                            this.state.MessageTextSk = this.$store.getters.VISITCOUNT_MessageTextSk;
                            break;
                        case "en":
                            this.state.MessageTextEn = this.$store.getters.VISITCOUNT_MessageTextEn;
                            break;
                    }
                }
                this.$refs.closeBtn.click();//this.showAlert("Saved");
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            showVisitsForFullDomain() {
                this.ShowDomainVisitCount = !this.ShowDomainVisitCount;
                if (this.ShowDomainVisitCount) {
                    this.pageText = this.translateAppi('webText', this.selectedLanguage);
                } else {
                    this.pageText = this.translateAppi('pageText', this.selectedLanguage);
                }
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
                    this.visitUserText = this.MessageText;
                } else {
                    this.visitUserText = this.translateAppi('visitUserText', this.selectedLanguage);
                }
                this.validateVisit();
            },
            '$store.state.selectedLanguage': function () {
                this.selectedLanguage = this.$store.state.selectedLanguage;
                if (this.MessageText.length > 0) {
                    this.visitUserText = this.MessageText;
                } else {
                    this.visitUserText = this.translateAppi('visitUserText', this.selectedLanguage);
                }
                this.visitLookingNow = this.translateAppi('visitLookingNow', this.selectedLanguage);

                if (this.ShowDomainVisitCount) {
                    this.pageText = this.translateAppi('webText', this.selectedLanguage);
                } else {
                    this.pageText = this.translateAppi('pageText', this.selectedLanguage);
                }
                this.verifyFrom = this.translateAppi('verifyFrom', this.selectedLanguage);
                this.validateVisit();
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

                            that.ShowDomainVisitCount = campaign.VisitCount.ShowDomainVisitCount;

                            if (that.ShowDomainVisitCount) {
                                that.pageText = that.translateAppi('webText', that.selectedLanguage);
                            } else {
                                that.pageText = that.translateAppi('pageText', that.selectedLanguage);
                            }

                            that.ShowCountHigherThan = campaign.VisitCount.ShowCountHigherThan;
                            that.CycleShowing = campaign.VisitCount.CycleShowing;
                            that.MessageText = (campaign.VisitCount.MessageText) ? campaign.VisitCount.MessageText : '';

                            that.$store.state.VisitCount = campaign.VisitCount;
                            switch (that.selectedLanguage) {
                                case "cs":
                                    that.$store.state.VisitCount.MessageTextCz = campaign.VisitCount.MessageText;
                                    break;
                                case "sk":
                                    that.$store.state.VisitCount.MessageTextSk = campaign.VisitCount.MessageText;
                                    break;
                                case "en":
                                    that.$store.state.VisitCount.MessageTextEn = campaign.VisitCount.MessageText;
                                    break;
                            }
                        }
                    })
                })
            }
        }
    }
</script>