<template>
    <div>
        <div class="container-fluid wizard_campaign_container">
            <div class="row">
                <div class="col-md-12 wizard_campaign_col">
                    <ul class="wizard_campaign">
                        <li class="wizard_step_active">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">1</div>
                                <div class="wizard_step_desc">Výběr</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="(nextStepAllowed) ? goToStep('Step2'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">2</div>
                                <div class="wizard_step_desc">Spárování</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="(nextStepAllowed) ? goToStep('Step3'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">3</div>
                                <div class="wizard_step_desc">Zobrazení</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="(nextStepAllowed) ? goToStep('Step4'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">4</div>
                                <div class="wizard_step_desc">Nastavení</div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="container text-center new_campaign_container_wrap">
            <div class="row justify-content-center">
                <div class="col-md-12">
                    <div class="align-items-center pt-5 pb-4" style="display: inline-flex;">
                        <div style="width: 170px;">Vyberte jazyk notifikací:</div>
                        <select v-model="selectedLanguage" style="max-width: 70px;" name="selectedLanguage" v-on:change="validateForm()" v-validate="{required: true}" class="form-control ml-3 mr-5" :class="{ 'is-invalid': errors.has('selectedLanguage') }">
                            <option disabled="" value="none">Vyberte</option>
                            <option v-for="language in languageList" v-bind:value="language">
                                {{(language == "cs")? "CZ" :(language == "sk")? "SK": "EN"}}
                            </option>
                        </select>
                        <div style="width:130px">Vyberte doménu:</div>
                        <select v-model="selectedDomain" style="max-width: 250px;" name="selectedDomain" v-on:change="validateForm()" v-validate="{required: true}" class="form-control ml-3" :class="{ 'is-invalid': errors.has('selectedDomain') }">
                            <option disabled="" value="none">Vyberte</option>
                            <option v-for="domain in DomainList" v-bind:value="domain">
                                {{domain}}
                            </option>
                        </select>

                        <div style="width: 160px;padding-left: 20px;" v-if="userUid != 'none' || adminAccount">Ignorovat doménu:</div>
                        <label class="noselect" v-if="userUid != 'none' || adminAccount">
                            <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                            <button type="button" class="btn btn-toggle" :class="{active: ignoreDomain}" v-on:click="ignoreDomain = !ignoreDomain" v-bind:value="ignoreDomain" data-toggle="button" aria-pressed="true" autocomplete="off">
                                <div class="handle"></div>
                            </button>
                            &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                        </label>
                    </div>
                    <hr />
                    <h3 class="new_campaign_h3_2 py-4 pb-4">Kliknutím na kartu vyberte jednu nebo více typů notifikací</h3>
                    <ul class="new_campaign_product_ul">
                        <li>
                            <div class="new_campaign_product_wrap noselect" v-on:click="SelectMessage('LastEventsOrders')">
                                <label class="select_new_campaign">
                                    <input type="checkbox" value="LastEventsOrders" v-model="SelectedMessages" disabled />
                                    <span class="checkmark"></span>
                                    <span class="infomark fa fa-question-circle"
                                          v-tooltip.top="{ content: 'Zobrazí notifikace o provedených objednávkách' }"></span>
                                </label>
                                <img src="/images/product/orders.svg" class="img-fluid svg_img" title="Poslední události objednávky" alt="Poslední události objednávky" />
                                <div class="product_title">
                                    Poslední události
                                    <div class="product_title_small">(OBJEDNÁVKY)</div>
                                </div>
                            </div>
                            <div class="product_space_button">
                                <button class="btn btn-campaign-primary btn_new" id="orders_button" style="font-size: 1.5rem;">Detailní nastavení</button>
                            </div>
                        </li>
                        <li>
                            <div class="new_campaign_product_wrap noselect" v-on:click="SelectMessage('LastEventsRegistrations')">
                                <label class="select_new_campaign">
                                    <input type="checkbox" value="LastEventsRegistrations" v-model="SelectedMessages" disabled />
                                    <span class="checkmark"></span>
                                    <span class="infomark fa fa-question-circle"
                                          v-tooltip.top="{ content: 'Zobrazí notifikace o registrovaných uživatelích' }"></span>
                                </label>
                                <img src="/images/product/registration.svg" class="img-fluid svg_img" title="Poslední události registrace" alt="Poslední události registrace" />
                                <div class="product_title">
                                    Poslední události
                                    <div class="product_title_small">(REGISTRACE)</div>
                                </div>
                            </div>
                            <div class="product_space_button">
                                <button class="btn btn-campaign-primary btn_new" id="registrations_button" style="font-size: 1.5rem;">Detailní nastavení</button>
                            </div>
                        </li>

                        <li>
                            <div class="new_campaign_product_wrap noselect" v-on:click="SelectMessage('VisitCount')">
                                <label class="select_new_campaign">
                                    <input type="checkbox" value="VisitCount" v-model="SelectedMessages" disabled />
                                    <span class="checkmark"></span>
                                    <span class="infomark fa fa-question-circle"
                                          v-tooltip.top="{ content: 'Zobrazí aktuální počet návštěvníků na stránkách' }"></span>
                                </label>
                                <img src="/images/product/visits.svg" class="img-fluid svg_img" title="Aktuální návštěvníci" alt="Aktuální návštěvníci" />
                                <div class="product_title">
                                    Aktuální návštěvníci
                                </div>
                            </div>
                            <div class="product_space_button">
                                <button class="btn btn-campaign-primary btn_new" id="visits_button" style="font-size: 1.5rem;">Detailní nastavení</button>
                            </div>
                        </li>
                        <li>
                            <div class="new_campaign_product_wrap noselect" v-on:click="SelectMessage('Statistics')">
                                <label class="select_new_campaign">
                                    <input type="checkbox" value="Statistics" v-model="SelectedMessages" disabled />
                                    <span class="checkmark"></span>
                                    <span class="infomark fa fa-question-circle"
                                          v-tooltip.top="{ content: 'Zobrazí souhrny návštěv nebo událostí v čase' }"></span>
                                </label>
                                <img src="/images/product/statistics.svg" class="img-fluid svg_img" title="Souhrnné statistiky" alt="Souhrnné statistiky" />
                                <div class="product_title">
                                    Souhrnné statistiky
                                </div>
                            </div>

                            <div class="product_space_button">
                                <button class="btn btn-campaign-primary btn_new" id="statistics_button" style="font-size: 1.5rem;">Detailní nastavení</button>
                            </div>
                        </li>
                        <li>
                            <div class="new_campaign_product_wrap noselect" v-on:click="SelectMessage('Heureka')">
                                <label class="select_new_campaign">
                                    <input type="checkbox" value="Heureka" v-model="SelectedMessages" disabled />
                                    <span class="checkmark"></span>
                                    <span class="infomark fa fa-question-circle"
                                          v-tooltip.top="{ content: 'Zobrazí recenze a hodnocení z Heureka CZ / SK' }"></span>
                                </label>
                                <img src="/images/product/reviews.svg" class="img-fluid svg_img" title="Recenze a hodnocení HEUREKA" alt="Recenze a hodnocení HEUREKA" />
                                <div class="product_title">
                                    RECENZE A HODNOCENÍ
                                    <div class="product_title_small">(HEUREKA CZ / SK)</div>
                                </div>
                            </div>

                            <div class="product_space_button">
                                <button class="btn btn-campaign-primary btn_new" id="heureka_button" style="font-size: 1.5rem;">Detailní nastavení</button>
                            </div>
                        </li>
                        <li>
                            <div class="new_campaign_product_wrap noselect" v-on:click="SelectMessage('Zbozi')">
                                <label class="select_new_campaign">
                                    <input type="checkbox" value="Zbozi" v-model="SelectedMessages" disabled />
                                    <span class="checkmark"></span>
                                    <span class="infomark fa fa-question-circle"
                                          v-tooltip.top="{ content: 'Zobrazí recenze produktů a/nebo hodnocení obchodu ze Zboží.cz.' }"></span>
                                </label>
                                <img src="/images/product/zbozi.svg" class="img-fluid svg_img" style="width:80px;" title="Recenze a hodnocení ZBOŽÍ" alt="Recenze a hodnocení ZBOŽÍ" />
                                <div class="product_title">
                                    RECENZE A HODNOCENÍ
                                    <div class="product_title_small">(Zboží.cz)</div>
                                </div>
                            </div>

                            <div class="product_space_button">
                                <button class="btn btn-campaign-primary btn_new" id="zbozi_button" style="font-size: 1.5rem;">Detailní nastavení</button>
                            </div>
                        </li>
                        <li>
                            <div class="new_campaign_product_wrap noselect" v-on:click="SelectMessage('OwnAppi')">

                                <label class="select_new_campaign">
                                    <input type="checkbox" value="OwnAppi" v-model="SelectedMessages" disabled />
                                    <span class="checkmark"></span>
                                    <span class="infomark fa fa-question-circle"
                                          v-tooltip.top="{ content: 'Zobrazí na webu vlastní jedinečnou nabídku, událost nebo akci' }"></span>
                                </label>
                                <img src="/images/product/offer.svg" class="img-fluid svg_img" style="width:80px;" title="TOP nabídky" alt="TOP nabídky" />
                                <div class="product_title">
                                    TOP NABÍDKY
                                </div>
                            </div>

                            <div class="product_space_button">
                                <button class="btn btn-campaign-primary btn_new" id="ownAppi_button" style="font-size: 1.5rem;">Detailní nastavení</button>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <span id="ownAppi" v-on:click="checkOwnAppi()"></span>
        <div class="container-fluid new_campaign_container_but">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 d-block justify-content-end text-right">
                        <!--<div class="align-items-center" style="display: inline-flex;margin: 15px 0px 0px 0px;">
                        <div style="width:130px">Vyberte doménu:</div>
                        <select v-model="selectedDomain" style="max-width: 240px;" name="selectedDomain" v-on:change="validateForm()" v-validate="{required: true}" class="form-control ml-3" :class="{ 'is-invalid': errors.has('selectedDomain') }">
                            <option disabled="" value="none">Vyberte</option>
                            <option v-for="domain in DomainList" v-bind:value="domain">
                                {{domain}}
                            </option>
                        </select>
                    </div>-->
                        <button class="btn btn-main-primary btn_new btn_new_campaign" :disabled="!nextStepAllowed" v-on:click="NextStep">Pokračovat&nbsp;&nbsp;&nbsp; <i class="fas fa-chevron-circle-right"></i></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    
 	import Vue from 'vue';
    import VueCookie from 'vue-cookie';
    import VeeValidate from 'vee-validate';
    import VueI18n from 'vue-i18n';

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

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
                ownAppiNotInsert: false,
                ownAppiShowMessage: true,
                adminAccount: false,
                userUid: "none",
                userEmail: null,
                nextStepAllowed: false,
                DomainList: [],
                languageList: this.$store.state.languageList,
                CampaignName: this.$store.state.CampaignName,
                selectedDomain: this.$store.state.selectedDomain,
                ignoreDomain: this.$store.state.ignoreDomain,
                selectedLanguage: this.$store.state.selectedLanguage,
                Component: "",
                SelectedMessages: this.$store.state.SelectedMessages,
                heurekaDisabled: false,
                zboziDisabled: false,
                bothFormsDisabled: false,
                receivedSelections: {
                    event: null
                },
                ownAppi: this.$store.state.OwnAppi

            }
        },
        activated() {
            this.ownAppi = this.$store.state.OwnAppi;
        },
        methods: {
            formatUrlArray(array) {
                var tmpArray = [];
                array.forEach(function (rule, index) {
                    tmpArray.push(rule.split(','));
                });
                return tmpArray;
            },
            setCorrectForm() {
                if (this.CampaignName.length > 0) {
                    const options = { title: 'Info', size: 'sm' }
                    this.$dialogs.alert('Nejdříve vyplňte správně formulář.', options)
                        .then(res => {
                        });
                }
            },
            goToStep(value) {
                this.$store.state.SelectedMessages = this.SelectedMessages;
                this.$store.state.selectedDomain = this.selectedDomain;
                this.$store.state.ignoreDomain = this.ignoreDomain;
                this.$store.state.selectedLanguage = this.selectedLanguage;

                switch (value) {
                    case 'Step4':
                        if (this.$store.state.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step4";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Step3':
                        if (this.$store.state.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step3";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Step2':
                        if (this.$store.state.CampaignName.length > 0) {
                            if (this.SelectedMessages.indexOf('LastEventsOrders') > -1) {
                                this.Component = "app-new-campaign-Step2_obj";
                            } else if (this.SelectedMessages.indexOf('LastEventsRegistrations') > -1) {
                                this.Component = "app-new-campaign-Step2_reg";
                            } else if (this.SelectedMessages.indexOf('VisitCount') > -1) {
                                this.Component = "app-new-campaign-Step2_visit";
                            } else if (this.SelectedMessages.indexOf('Statistics') > -1) {
                                this.Component = "app-new-campaign-Step2_stat";
                            } else if (this.SelectedMessages.indexOf('Heureka') > -1) {
                                this.Component = "app-new-campaign-Step2_rev";
                            } else if (this.SelectedMessages.indexOf('Zbozi') > -1) {
                                this.Component = "app-new-campaign-Step2_zbozi";
                            } else if (this.SelectedMessages.indexOf('OwnAppi') > -1) {
                                this.Component = "app-new-campaign-Step2_ownAppi";
                            }
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Step1':
                        if (this.$store.state.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step1";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                }
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            NextStep() {
                this.$store.state.SelectedMessages = this.SelectedMessages;
                this.$store.state.selectedDomain = this.selectedDomain;
                this.$store.state.ignoreDomain = this.ignoreDomain;
                this.$store.state.selectedLanguage = this.selectedLanguage;


                //změna dynamické komponenty
                if (this.SelectedMessages.indexOf('LastEventsOrders') > -1) {
                    this.Component = "app-new-campaign-Step2_obj";
                } else if (this.SelectedMessages.indexOf('LastEventsRegistrations') > -1) {
                    this.Component = "app-new-campaign-Step2_reg";
                } else if (this.SelectedMessages.indexOf('VisitCount') > -1) {
                    this.Component = "app-new-campaign-Step2_visit";
                } else if (this.SelectedMessages.indexOf('Statistics') > -1) {
                    this.Component = "app-new-campaign-Step2_stat";
                } else if (this.SelectedMessages.indexOf('Heureka') > -1) {
                    this.Component = "app-new-campaign-Step2_rev";
                } else if (this.SelectedMessages.indexOf('Zbozi') > -1) {
                    this.Component = "app-new-campaign-Step2_zbozi";
                } else if (this.SelectedMessages.indexOf('OwnAppi') > -1) {
                    this.Component = "app-new-campaign-Step2_ownAppi";
                }

                this.$emit("changeComponent", this.Component);

            },
            checkOwnAppi() {
                this.ownAppiShowMessage = false;
                var that = this;
                if (that.$store.state.OwnAppi.ownAppiActive.indexOf(true) == -1 && that.SelectedMessages.indexOf("OwnAppi") > -1) {
                    that.SelectMessage("OwnAppi");
                } else if (that.$store.state.OwnAppi.ownAppiActive.indexOf(true) > -1 && that.SelectedMessages.indexOf("OwnAppi") == -1) {
                    that.SelectMessage("OwnAppi");
                }
            },
            SelectMessage(value) {
                //odebere nebo přidá vybrané notifikace do pole
                this.bothFormsDisabled = false;
                this.ownAppiNotInsert = false;

                var that = this;
                if (value == "Heureka") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/get_heurekaapikeys",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                    }).done(function (apiKeys) {
                        if (apiKeys.result === 1) {
                            if (apiKeys.heurekaapikeys != undefined) {
                                if (apiKeys.heurekaapikeys.length == 0) {
                                    let index = that.SelectedMessages.indexOf(value);
                                    that.SelectedMessages.splice(index, 1);
                                    that.showAlert("Nejdříve zadejte Heureka Api Klíč");
                                }
                            }
                        }
                    })

                }

                if (value == "Zbozi") {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/get_zboziapikeys",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                    }).done(function (apiKeys) {
                        if (apiKeys.result === 1) {
                            if (apiKeys.zboziapikeys != undefined) {
                                if (apiKeys.zboziapikeys.length == 0) {
                                    let index = that.SelectedMessages.indexOf(value);
                                    that.SelectedMessages.splice(index, 1);
                                    that.showAlert("Nejdříve zadejte Zboží Api Klíč");
                                }
                            }
                        }
                    })

                }

                if (value == "OwnAppi" && this.SelectedMessages.indexOf(value) == -1 && that.$store.state.OwnAppi.ownAppiActive.indexOf(true) == -1) {
                    that.ownAppiNotInsert = true;
                    if (that.ownAppiShowMessage) {
                        that.showAlert("Nejdříve v Detailním nastavení aktivujte alespoň jednu TOP nabídku a po jejím uložení potvrďte přidání do kampaně.");
                    }
                    that.ownAppiShowMessage = true;
                }
                
                if (this.SelectedMessages.indexOf(value) > -1) {
                    let index = this.SelectedMessages.indexOf(value);
                    this.SelectedMessages.splice(index, 1);
                } else {
                    if ( !that.ownAppiNotInsert && ((value != "Heureka" && value != "Zbozi" && !this.bothFormsDisabled) || (value == "Heureka" && !that.heurekaDisabled) || (value == "Zbozi" && !that.zboziDisabled))) {
                        this.SelectedMessages.push(value);
                    }
                }
            },
            validateForm() {
                this.$store.state.selectedLanguage = this.selectedLanguage;
                var that = this;
                that.nextStepAllowed = (that.SelectedMessages.length > 0 && that.selectedDomain != 'none') ? true : false;
                that.errors.clear();
                that.$validator.validateAll({
                    selectedDomain: that.selectedDomain,
                    selectedLanguage: that.selectedLanguage
                }).then((valid) => {
                    if (that.selectedLanguage == 'none' && that.languageList != []) {
                        that.errors.add({ field: 'selectedLanguage', msg: 'Vyberte jazyk notifikací' });
                        that.nextStepAllowed = false;
                    }
                    if (that.selectedDomain == 'none' && that.DomainList != []) {
                        that.errors.add({ field: 'selectedDomain', msg: 'Vyberte doménu' });
                        that.nextStepAllowed = false;
                    }
                    if (!valid) {
                        that.nextStepAllowed = false;
                    }
                });
            },
        },
        watch: {
            SelectedMessages: function () {
                this.nextStepAllowed = (this.SelectedMessages.length > 0 && this.selectedDomain != 'none') ? true : false;
                if (this.DomainList.length > 0 && this.selectedDomain != 'none' && this.DomainList.indexOf(this.selectedDomain) == -1) {
                    this.selectedDomain = 'none';
                    this.nextStepAllowed = false;
                }
            }
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
                    if (data.isAdmin) {
                        that.adminAccount = true;
                    } else {
                        that.adminAccount = false;
                    }
                } else {
                    that.adminAccount = false;
                }
            });
        },
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            //update load
            if (Vue.cookie.get('EditCampaignID') != 'null' && Vue.cookie.get('EditCampaignID') != undefined) {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/get_campaigns",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                    }).done(function (dataCampaigns) {
                        that.$store.state.AllCampaignsData = dataCampaigns.campaigns;

                        dataCampaigns.campaigns.forEach(function (campaign) {

                            if (campaign.campaignID == Vue.cookie.get('EditCampaignID')) {
                                that.$store.state.CampaignData = campaign;
                                that.SelectedMessages = campaign.SelectedMessages;

                                that.CampaignName = campaign.CampaignName;
                                that.selectedDomain = campaign.selectedDomain;
                                that.$store.state.selectedDomain = campaign.selectedDomain;

                                that.ignoreDomain = campaign.ignoreDomain;
                                that.$store.state.ignoreDomain = campaign.ignoreDomain;

                                that.selectedLanguage = campaign.selectedLanguage;
                                that.$store.state.selectedLanguage = campaign.selectedLanguage;

                                that.$store.state.SelectedMessages = campaign.SelectedMessages.SelectedMessages;

                                that.$store.state.heurekaAPIkey = campaign.heurekaAPIkey;
                                that.$store.state.zboziAPIkey = campaign.zboziAPIkey;
                                that.$store.state.VisitCount.ShowDomainVisitCount = campaign.VisitCount.ShowDomainVisitCount;
                                that.$store.state.Statistics.SelectedStatsVariant = campaign.Statistics.SelectedStatsVariant;
                                that.$store.state.Statistics.selectedStatVisitorsDomain = campaign.Statistics.selectedStatVisitorsDomain;

                                that.$store.state.CaptureRuleObj = (JSON.parse(JSON.stringify(campaign.CaptureRuleObj)) != '') ? JSON.parse(JSON.stringify(campaign.CaptureRuleObj)) : that.$store.state.CaptureRuleObj;
                                that.$store.state.CapturedUrlsObjIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsObjIn)).replace(/""/g, ''));
                                that.$store.state.CapturedUrlsObjOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsObjOut)).replace(/""/g, ''));

                                that.$store.state.CaptureRuleReg = (JSON.parse(JSON.stringify(campaign.CaptureRuleReg)) != '') ? JSON.parse(JSON.stringify(campaign.CaptureRuleReg)) : that.$store.state.CaptureRuleReg;
                                that.$store.state.CapturedUrlsRegIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsRegIn)).replace(/""/g, ''));
                                that.$store.state.CapturedUrlsRegOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsRegOut)).replace(/""/g, ''));

                                that.$store.state.CaptureRuleStat = (JSON.parse(JSON.stringify(campaign.CaptureRuleStat)) != '') ? JSON.parse(JSON.stringify(campaign.CaptureRuleStat)) : that.$store.state.CaptureRuleStat;
                                that.$store.state.CapturedUrlsStatIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsStatIn)).replace(/""/g, ''));
                                that.$store.state.CapturedUrlsStatOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsStatOut)).replace(/""/g, ''));

                                that.$store.state.ShownRule = (JSON.parse(JSON.stringify(campaign.ShownRule)) != '') ? JSON.parse(JSON.stringify(campaign.ShownRule)) : that.$store.state.ShownRule;
                                that.$store.state.ShownUrlsIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.ShownUrlsIn)).replace(/""/g, ''));
                                that.$store.state.ShownUrlsOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.ShownUrlsOut)).replace(/""/g, ''));

                                that.$store.state.OwnAppi = campaign.OwnAppi;
                                that.$store.state.OwnAppiIcons = campaign.OwnAppiIcons;
                                if (that.SelectedMessages.indexOf("OwnAppi") > -1 && that.$store.state.OwnAppi.ownAppiActive.indexOf(true) == -1) {
                                    let index = that.SelectedMessages.indexOf("OwnAppi");
                                    that.SelectedMessages.splice(index, 1);
                                }

                            }
                        });
                        Vue.cookie.set('EditCampaignID', null, 1);
                    });
            } else {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/get_campaigns",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                    }).done(function (dataCampaigns) {
                        that.$store.state.AllCampaignsData = dataCampaigns.campaigns;
                      
                    });
                that.$store.state.CampaignData = [];
            }

            if (JSON.stringify(this.$route.query) != "{}") {
                this.receivedSelections = JSON.parse(JSON.stringify(this.$route.query));
                if (this.receivedSelections.event != null) {
                    if (this.receivedSelections.event == "Heureka") {
                        $.ajax({
                            type: "POST",
                            url: "https://appi.app.cz:444/get_heurekaapikeys",
                            dataType: "json",
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                        }).done(function (apiKeys) {
                            if (apiKeys.result === 1) {
                                if (apiKeys.heurekaapikeys != undefined) {
                                    if (apiKeys.heurekaapikeys.length == 0) {
                                        that.showAlert("Nejdříve zadejte Heureka Api Klíč");
                                    } else {
                                        that.SelectMessage(that.receivedSelections.event);
                                    }
                                }
                            }
                        })
                    } else if (this.receivedSelections.event == "Zbozi") {
                        $.ajax({
                            type: "POST",
                            url: "https://appi.app.cz:444/get_zboziapikeys",
                            dataType: "json",
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                        }).done(function (apiKeys) {
                            if (apiKeys.result === 1) {
                                if (apiKeys.zboziapikeys != undefined) {
                                    if (apiKeys.zboziapikeys.length == 0) {
                                        that.showAlert("Nejdříve zadejte Zboží Api Klíč");
                                    } else {
                                        that.SelectMessage(that.receivedSelections.event);
                                    }
                                }
                            }
                        })
                    }
                    else {
                        this.SelectMessage(this.receivedSelections.event);
                    }
                }
            }

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_domains",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (dataDomains) {
                if (dataDomains.domains != undefined && dataDomains.domains.length > 0) {
                    dataDomains.domains.forEach(function (domain) {
                        if (that.DomainList.indexOf(domain.domain) === -1 && domain.domain != "" && domain.domain.indexOf('file://') == -1 && domain.domain.indexOf('content://') == -1 && domain.domain.indexOf('about:blank') == -1) {
                            that.DomainList.push(domain.domain);
                        }
                    });
                }

              
                if (that.CampaignName == "") {
                    that.selectedDomain = 'none';
                    if (that.DomainList.length == 0) {
                        that.nextStepAllowed = false;
                    } else if (that.DomainList.length == 1) {
                        that.selectedDomain = that.DomainList[0];
                        that.validateForm();
                    }
                    if (that.DomainList.length > 0 && that.selectedDomain != 'none' && that.DomainList.indexOf(that.selectedDomain) == -1) {
                        that.selectedDomain = 'none';
                        that.nextStepAllowed = false;
                    }
                } else {
                    if (that.DomainList.indexOf(that.selectedDomain) == -1) {
                        that.selectedDomain = 'none';
                        that.nextStepAllowed = false;
                    }
                }

             });

		}
    }

   
</script>