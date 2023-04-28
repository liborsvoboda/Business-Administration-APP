<template>
    <div class="statistics_content panel_right">
        <div class="row pl-5 pr-5">
            <div class="col-md-12 pb-2 pt-2">
                <button ref="closeBtn" type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="col-md-12">
                <h1 class="panel_right_h1">Souhrnné statistiky</h1>
            </div>
            <div class="col-md-12 pb-2">
                <p class="under_title">Zobrazí celkový počet registrací, objednávek, návštěvníků nebo zobrazení stránek za určité časové období.</p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Vyberte jeden ze souhrnů k zobrazení:
                </div>
            </div>
        </div>

        <div class="col-md-12 pl-5 py-3 form_inline_set">
            <div>Vyberte variantu</div>&nbsp;&nbsp;
            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                <label class="btn btn btn-outline-primary mycolor" :class="{active: SelectedStatsVariant == 'registration'}" v-on:click="SelectedStatsVariant = 'registration'">
                    <input type="radio" name="options" autocomplete="off" :checked="SelectedStatsVariant == 'Registration'"> Registrace
                </label>
                <label class="btn btn btn-outline-primary mycolor" :class="{active: SelectedStatsVariant == 'order'}" v-on:click="SelectedStatsVariant = 'order'">
                    <input type="radio" name="options" autocomplete="off" :checked="SelectedStatsVariant == 'order'"> Objednávky
                </label>
                <label class="btn btn btn-outline-primary mycolor" :class="{active: SelectedStatsVariant == 'visitor' || SelectedStatsVariant == ''}" v-on:click="SelectedStatsVariant = 'visitor'">
                    <input type="radio" name="options" autocomplete="off" :checked="SelectedStatsVariant == 'visitor' || SelectedStatsVariant == ''"> Návštěvníci
                </label>
                <label class="btn btn btn-outline-primary mycolor" :class="{active: SelectedStatsVariant == 'pages'}" v-on:click="SelectedStatsVariant = 'pages'">
                    <input type="radio" name="options" autocomplete="off" :checked="SelectedStatsVariant == 'pages'"> Stránky
                </label>
            </div>
        </div>

        <span v-if="SelectedStatsVariant == 'registration'">
            <div class="row" style="display: block;">
                <div class="col-md-12">
                    <div class="notifikace">
                        <!--<img src="/images/notifikace/registrations.png" class="notifikace_img" title="Poslední události – REGISTRACE" alt="Poslední události – REGISTRACE" />-->
                        <div class="Appi_bubble shadow noselect">
                            <span>
                                <img src="/images/product/statistics.svg" class="svg_img" style="margin-right:10px;" title="Souhrnné statistiky - REGISTRACE" alt="Souhrnné statistiky - REGISTRACE" />
                            </span>
                            <span style="vertical-align: top;">
                                <div class="width_100" style="vertical-align: top;">
                                    <span class="stat_bold">268 lidí</span>
                                    {{userText}} <span><br />{{statLastOf}} {{DateType}}</span>
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
        </span>

        <span v-if="SelectedStatsVariant == 'order'">
            <div class="row" style="display: block;">
                <div class="col-md-12">
                    <div class="notifikace">
                        <!--<img src="/images/notifikace/orders.png" class="notifikace_img" title="Poslední události – OBJEDNÁVKY" alt="Poslední události – OBJEDNÁVKY" />-->
                        <div class="Appi_bubble shadow noselect">
                            <span>
                                <img src="/images/product/statistics.svg" class="svg_img" style="margin-right:10px;" title="Souhrnné statistiky - OBJEDNÁVKY" alt="Souhrnné statistiky - OBJEDNÁVKY" />
                            </span>
                            <span style="vertical-align: top;">
                                <div class="width_100" style="vertical-align: top;">
                                    <span class="stat_bold">87 {{userText}}</span>
                                    {{statBoughtFromUs}} <span><br />{{statLastOf}} {{DateType}}</span>
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
        </span>

        <span v-if="SelectedStatsVariant == 'visitor'">
            <div class="row" style="display: block;">
                <div class="col-md-12">
                    <div class="notifikace">
                        <!--<img src="/images/notifikace/visitors.svg" class="notifikace_img" title="Počet návštěv" alt="Počet návštěv" />-->

                        <div class="Appi_bubble shadow noselect">
                            <span>
                                <img src="/images/product/statistics.svg" class="svg_img" style="margin-right:10px;" title="Souhrnné statistiky - NÁVŠTĚVY" alt="Souhrnné statistiky - NÁVŠTĚVY" />
                            </span>
                            <span style="vertical-align: top;">
                                <div class="width_100" style="vertical-align: top;">
                                    <span class="stat_bold">725 {{userText}}</span>
                                    {{statVisited}} {{pageText}} <span><br />{{statLastOf}} {{DateType}}</span>
                                </div>
                                <div class="width_100" style="vertical-align: top;">
                                    <span class="Appi_bubble_check"></span>
                                    <span style="color: lightgray;">{{verifyFrom}} </span>
                                    <span class="Appi_bubble_text">app</span>
                                </div>
                            </span>
                        </div>
                        <img src="/images/product/liveview.png" class="img-fluid" style="filter: grayscale(100%);position: relative;min-width: 210px;" />
                    </div>
                </div>
            </div>
        </span>

        <span v-if="SelectedStatsVariant == 'pages'">
            <div class="row" style="display: block;">
                <div class="col-md-12">
                    <div class="notifikace">
                        <!--<img src="/images/notifikace/visitors.svg" class="notifikace_img" title="Počet návštěv" alt="Počet návštěv" />-->

                        <div class="Appi_bubble shadow noselect">
                            <span>
                                <img src="/images/product/statistics.svg" class="svg_img" style="margin-right:10px;" title="Souhrnné statistiky - NÁVŠTĚVY" alt="Souhrnné statistiky - NÁVŠTĚVY" />
                            </span>
                            <span style="vertical-align: top;">
                                <div class="width_100" style="vertical-align: top;" v-if="!ShowStatsDomainVisitCount">
                                    <span class="stat_bold">725× </span>
                                    {{statThisPageShown}} <span><br />{{statLastOf}} {{DateType}}</span>
                                </div>
                                <div class="width_100" style="vertical-align: top;" v-if="ShowStatsDomainVisitCount">
                                    <span class="stat_bold">725× </span>
                                    {{statThisWebShown}} <span><br />{{statLastOf}} {{DateType}}</span>
                                </div>
                                <div class="width_100" style="vertical-align: top;">
                                    <span class="Appi_bubble_check"></span>
                                    <span style="color: lightgray;">{{verifyFrom}} </span>
                                    <span class="Appi_bubble_text">app</span>
                                </div>
                            </span>
                        </div>
                        <img src="/images/product/liveview.png" class="img-fluid" style="filter: grayscale(100%);position: relative;min-width: 210px;" />
                    </div>
                </div>
            </div>
        </span>

        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3">
                <div style="font-size:30px">DETAILNÍ NASTAVENÍ</div>
            </div>
        </div>

        <div class="row" v-if="SelectedStatsVariant != 'pages'">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Text v notifikaci
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5" v-if="SelectedStatsVariant != 'pages'">
            <div class="col-md-12 py-3 form_inline_set">
                <div>
                    <span v-if="SelectedStatsVariant != 'registration'">
                        Pojmenujte návštěvníky
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Pojmenujte si návštěvníky podle svého = slovo za číslovkou, např.: lidí, skvělých bajkerů, zahrádkářů, marketérů, nadšenců, čumilů :)' }"></i>
                    </span>

                    <span v-if="SelectedStatsVariant == 'registration'">Popis akce při registraci </span>

                </div>&nbsp;&nbsp;

                <input v-if="SelectedStatsVariant != 'registration'" type="text" v-model="MessageText" v-bind:placeholder="userText" v-on:input="validateStatistics()" v-validate="{max: 15}" name="MessageText" class="form-control form_control_set_width_2" :class="{ 'is-invalid': errors.has('MessageText') }" />
                <input v-if="SelectedStatsVariant == 'registration'" type="text" v-model="MessageText" v-bind:placeholder="userText" v-on:input="validateStatistics()" v-validate="{max: 31}" name="MessageText" class="form-control form_control_set_width_3" :class="{ 'is-invalid': errors.has('MessageText') }" />

            </div>
            <span v-if="errors.has('MessageText')" class="invalid-feedback" style="display: inline;left: 215px;width: 100%;top: -10px;position: relative;"> {{ errors.first('MessageText') }}</span>
        </div>


        <!--<div class="row pl-5 pr-5">
        <div class="col-md-12 py-3">
            <input type="text" v-model="MessageText" placeholder="lidí" v-on:input="validateStatistics()" v-validate="{max: 15}" name="MessageText" class="form-control" :class="{ 'is-invalid': errors.has('MessageText') }" />
            <span v-if="errors.has('MessageText')" class="invalid-feedback">{{ errors.first('MessageText') }}</span>
        </div>
    </div>-->

        <div class="row">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Pravidla zobrazování notifikací
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3 form_inline_set">
                <div v-if="SelectedStatsVariant == 'registration'">Zobrazí registrace za posledních </div>
                <div v-if="SelectedStatsVariant == 'order'">Zobrazí objednávky za posledních </div>
                <div v-if="SelectedStatsVariant == 'visitor'">Zobrazí návštěvníky za posledních </div>
                <div v-if="SelectedStatsVariant == 'pages'">Ukáže zobrazené stránky za posledních </div>&nbsp;&nbsp;
                <div class="btn-group btn-group-toggle" data-toggle="buttons">
                    <label class="btn btn btn-outline-primary mycolor " :class="{active: ShowStatsFromLastDays == 1}" v-on:click="ShowStatsFromLastDays = 1">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowStatsFromLastDays == 1"> 24 hod.
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: (ShowStatsFromLastDays == 7 || ShowStatsFromLastDays == '')}" v-on:click="ShowStatsFromLastDays = 7">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowStatsFromLastDays == 7 || ShowStatsFromLastDays == '' "> 7 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowStatsFromLastDays == 30}" v-on:click="ShowStatsFromLastDays = 30">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowStatsFromLastDays == 30"> 30 dní
                    </label>
                </div>
            </div>


            <div class="col-md-12 py-3 form_inline_set">
                <div v-if="SelectedStatsVariant == 'registration'">Zobrazí počet registrací pokud je vyšší než </div>
                <div v-if="SelectedStatsVariant == 'order'">Zobrazí počet objednávek pokud je vyšší než </div>
                <div v-if="SelectedStatsVariant == 'visitor'">Zobrazí se pokud je počet návštěvníků vyšší než </div>
                <div v-if="SelectedStatsVariant == 'pages'">Ukáže se pokud je počet zobrazených stránek vyšší než </div>&nbsp;&nbsp;
                <input type="text" v-model="ShowCountHigherThan" v-bind:placeholder="$t(SelectedStatsVariant == 'registration')?5:$t(SelectedStatsVariant == 'order')?10:$t(SelectedStatsVariant == 'visitor')?50:5" v-on:input="validateStatistics()" v-validate="{numeric:true, min_value:5, max_value: 500000}" name="ShowCountHigherThan" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowCountHigherThan') }" />
            </div>
            <div class="col-md-12 py-3" v-if="SelectedStatsVariant == 'visitor'">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Zobrazí počet návštěvníků celého webu
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Zapnutím se zobrazí pouze souhrnný počet návštěvníků celého webu nikoliv jednotlivých stránek ve vybraném časovém období.' }"></i>
                    </div>
                    <div class="noselect">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: ShowStatsDomainVisitCount}" v-on:click="showStatVisitsForFullDomain()" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                </div>
            </div>
            <div class="col-md-12 py-3" v-if="SelectedStatsVariant == 'pages'">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Ukáže počet zobrazení stránek celého webu
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Zapnutím se zobrazí pouze souhrn všech zobrazených stránek celého webu nikoliv jednotlivých stránek ve vybraném časovém období.' }"></i>
                    </div>
                    <div class="noselect">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: ShowStatsDomainVisitCount}" v-on:click="showStatVisitsForFullDomain()" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                </div>
            </div>
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Neustálé opakování notifikací
                        <i v-if="SelectedStatsVariant == 'registration'" style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Vypnutím zastavíte opakované zobrazování souhrnu registrací. Zobrazí se jen jednou.' }"></i>
                        <i v-if="SelectedStatsVariant == 'order'" style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Vypnutím zastavíte opakované zobrazování souhrnu objednávek. Zobrazí se jen jednou.' }"></i>
                        <i v-if="SelectedStatsVariant == 'visitor'" style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Vypnutím zastavíte opakované zobrazování souhrnu návštěv. Zobrazí se jen jednou.' }"></i>
                        <i v-if="SelectedStatsVariant == 'pages'" style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Vypnutím zastavíte opakované zobrazování souhrnu zobrazených stránek. Notifikace se ukáže jen jednou.' }"></i>
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
                note: [null, null, null],
                selectedLanguage: this.$store.state.selectedLanguage,

                ShowStatsDomainVisitCount: true,
                SelectedStatsVariant: "visitor",
                ShowStatsFromLastDays: "",
                ShowCountHigherThan: "",
                CycleShowing: true,
                MessageText: "",
                SaveAllowed: true,
                userText: "lidí",
                pageText: "tento web",
                oldType: "visitor",
                DateType: this.$store.getters.STATISTICS_ShowStatsFromLastDays + " dní",
                statLastOf: "za posledních",
                verifyFrom: "ověřeno od",
                statBoughtFromUs: "si u nás nakoupilo",
                statVisited: "navštívilo",
                statThisWebShown: "byl zobrazen tento web",
                statThisPageShown:"byla zobrazena tato stránka"
           }
        },
        computed: mapState({
            state: state => state.Statistics
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
                that.userText = that.translateAppi('statUserText', that.selectedLanguage);
                that.pageText = that.translateAppi('webText', that.selectedLanguage);
                that.DateType = that.$store.getters.STATISTICS_ShowStatsFromLastDays + " " + that.translateAppi('statDays', that.selectedLanguage);
                that.statLastOf = that.translateAppi('statLastOf', that.selectedLanguage);
                that.verifyFrom = that.translateAppi('verifyFrom', that.selectedLanguage);
                that.statBoughtFromUs = that.translateAppi('statBoughtFromUs', that.selectedLanguage);
                that.statVisited = that.translateAppi('statVisited', that.selectedLanguage);
                that.statThisWebShown = that.translateAppi('statThisWebShown', that.selectedLanguage);
                that.statThisPageShown = that.translateAppi('statThisPageShown', that.selectedLanguage);
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
            validateStatistics() {
                var that = this;
                this.$validator.validateAll().then((valid) => {
                    if (valid) {
                        that.errors.clear();
                        that.SaveAllowed = true;
                        //if (that.MessageText != null) {
                        //    if (!that.checkVulgar('MessageText', that.MessageText, that.selectedLanguage)) {
                        //        that.SaveAllowed = false;
                        //    }
                        //}

                    } else { this.SaveAllowed = false; }
                });
                switch (that.SelectedStatsVariant) {
                    case "registration":
                        that.note[0] = that.MessageText;
                        break;
                    case "order":
                        that.note[1] = that.MessageText;
                        break;
                    case "visitor":
                        that.note[2] = that.MessageText;
                        break;
                    default:
                        break;
                }
            },
            Save() {
                if (this.SelectedStatsVariant) {
                    this.state.SelectedStatsVariant = this.SelectedStatsVariant;
                }
                else {
                    this.state.SelectedStatsVariant = this.$store.getters.STATISTICS_SelectedStatsVariant;
                }

                if (this.ShowStatsFromLastDays) {
                    this.state.ShowStatsFromLastDays = this.ShowStatsFromLastDays;
                }
                else {
                    this.state.ShowStatsFromLastDays = this.$store.getters.STATISTICS_ShowStatsFromLastDays;
                }
                this.state.ShowStatsDomainVisitCount = (this.SelectedStatsVariant == 'visitor' || this.SelectedStatsVariant == 'pages') ? this.ShowStatsDomainVisitCount : false;

                if (this.ShowCountHigherThan) {
                    this.state.ShowCountHigherThan = this.ShowCountHigherThan;
                }
                else {
                    this.state.ShowCountHigherThan = this.$store.getters.STATISTICS_ShowCountHigherThan;
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
                            this.state.MessageTextCz = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                            break;
                        case "sk":
                            this.state.MessageTextSk = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                            break;
                        case "en":
                            this.state.MessageTextEn = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                            break;
                    }
                }
                this.$refs.closeBtn.click();//this.showAlert("Saved");
            },
			showAlert(val) {
				const options = {title: 'Info', size: 'sm'}
				this.$dialogs.alert(val, options)
					.then(res => {
				});
			},
            showStatVisitsForFullDomain() {
                this.ShowStatsDomainVisitCount = !this.ShowStatsDomainVisitCount;
                if (this.ShowStatsDomainVisitCount) {
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
            '$store.state.selectedLanguage': function () {
                this.selectedLanguage = this.$store.state.selectedLanguage;
                if (this.MessageText != null) {
                    if (this.MessageText.length > 0) {
                        this.userText = this.MessageText;
                    } else {
                        this.userText = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                    }
                } else {
                    this.userText = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                }
                if (this.ShowStatsDomainVisitCount) {
                    this.pageText = this.translateAppi('webText', this.selectedLanguage);
                } else {
                    this.pageText = this.translateAppi('pageText', this.selectedLanguage);
                }
                if (this.ShowStatsFromLastDays != "") {
                    if (this.ShowStatsFromLastDays == 1) { this.DateType = this.translateAppi('statDayInHours', this.selectedLanguage); } else { this.DateType = this.ShowStatsFromLastDays + " " + this.translateAppi('statDays', this.selectedLanguage); }
                } else {
                    this.DateType = this.$store.getters.STATISTICS_ShowStatsFromLastDays + " " + this.translateAppi('statDays', this.selectedLanguage);
                }

                this.statLastOf = this.translateAppi('statLastOf', this.selectedLanguage);
                this.verifyFrom = this.translateAppi('verifyFrom', this.selectedLanguage);
                this.statBoughtFromUs = this.translateAppi('statBoughtFromUs', this.selectedLanguage);
                this.statVisited = this.translateAppi('statVisited', this.selectedLanguage);
                this.statThisWebShown = this.translateAppi('statThisWebShown', this.selectedLanguage);
                this.statThisPageShown = this.translateAppi('statThisPageShown', this.selectedLanguage);
                this.validateStatistics();
            },
            MessageText() {
                if (this.MessageText != null) {
                    if (this.MessageText.length > 0) {
                        this.userText = this.MessageText;
                    } else {
                        this.userText = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                    }
                } else {
                    this.userText = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                }
                this.validateStatistics();
            },
            SelectedStatsVariant() {
                switch (this.SelectedStatsVariant) {
                    case "registration":
                        this.MessageText = this.note[0];
                        break;
                    case "order":
                        this.MessageText = this.note[1];
                        break;
                    case "visitor":
                        this.MessageText = this.note[2];
                        break;
                    default:
                        break;
                }

                if (this.SelectedStatsVariant != this.oldType) {
                    this.oldType = this.SelectedStatsVariant;
                  
                    if (this.SelectedStatsVariant =="visitor") {
                        this.ShowStatsDomainVisitCount = true;
                    }
                    else {
                        this.ShowStatsDomainVisitCount = false;
                    }
                    if (this.ShowStatsDomainVisitCount) {
                        this.pageText = this.translateAppi('webText', this.selectedLanguage);
                    } else {
                        this.pageText = this.translateAppi('pageText', this.selectedLanguage);
                    }
                    this.userText = (this.SelectedStatsVariant == "registration") ? this.translateAppi('statRegNews', this.selectedLanguage) : this.translateAppi('statUserText', this.selectedLanguage);
                }
                this.validateStatistics();
            },
            ShowStatsFromLastDays(){
                if (this.ShowStatsFromLastDays != "") {
                    if (this.ShowStatsFromLastDays == 1) { this.DateType = this.translateAppi('statDayInHours', this.selectedLanguage); } else { this.DateType = this.ShowStatsFromLastDays + " " + this.translateAppi('statDays', this.selectedLanguage);}
                } else {
                    this.DateType = this.$store.getters.STATISTICS_ShowStatsFromLastDays + " " + this.translateAppi('statDays', this.selectedLanguage);
                }
                this.validateStatistics();
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
                            that.oldType = campaign.Statistics.SelectedStatsVariant;
                            that.SelectedStatsVariant = campaign.Statistics.SelectedStatsVariant;
                            that.ShowStatsFromLastDays = campaign.Statistics.ShowStatsFromLastDays;
                            that.ShowStatsDomainVisitCount = campaign.Statistics.ShowStatsDomainVisitCount;

                            if (that.ShowStatsDomainVisitCount) {
                                that.pageText = that.translateAppi('webText', that.selectedLanguage);
                            } else {
                                that.pageText = that.translateAppi('pageText', that.selectedLanguage);
                            }
                            that.ShowCountHigherThan = campaign.Statistics.ShowCountHigherThan;
                            that.CycleShowing = campaign.Statistics.CycleShowing;
                            that.MessageText = campaign.Statistics.MessageText;

                            that.$store.state.Statistics = campaign.Statistics;
                            switch (that.selectedLanguage) {
                                case "cs":
                                    that.$store.state.Statistics.MessageTextCz = campaign.Statistics.MessageText;
                                    break;
                                case "sk":
                                    that.$store.state.Statistics.MessageTextSk = campaign.Statistics.MessageText;
                                    break;
                                case "en":
                                    that.$store.state.Statistics.MessageTextEn = campaign.Statistics.MessageText;
                                    break;
                            }
                        }
                    })
                })
            }
		}
    }
</script>