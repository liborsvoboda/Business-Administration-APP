<template>
    <div>
        <div class="container-fluid wizard_campaign_container">
            <div class="row">
                <div class="col-md-12 wizard_campaign_col">
                    <ul class="wizard_campaign">
                        <li class="list_group_button" v-on:click="(nextStepAllowed3) ? goToStep('Step1'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">1</div>
                                <div class="wizard_step_desc">Výběr</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="(nextStepAllowed3) ? goToStep('Step2'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">2</div>
                                <div class="wizard_step_desc">Spárování</div>
                            </div>
                        </li>
                        <li class="wizard_step_active">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">3</div>
                                <div class="wizard_step_desc">Zobrazení</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="(nextStepAllowed3) ? goToStep('Step4'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">4</div>
                                <div class="wizard_step_desc">Nastavení</div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <form @submit.prevent="validateForm()">
            <div class="container new_campaign_container_wrap">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="new_campaign_h3_2 py-4 pb-4 text-center">Kde zobrazíme tuto kampaň?</h3>

                        <div class="row justify-content-md-center">
                            <div class="col-md-8">
                                <div class="list-group mt-2 shadow-sm">
                                    <div class="list-group-item group_item_blue">
                                        <div class="new_campaign_tile_group_item visit_color d-flex align-items-center">
                                            <span class="width_100">Na jakých URL chcete zobrazovat tuto kampaň?</span>
                                            <span class="right d-flex align-items-center">
                                                <button class="btn btn-outline-secondary_visit fas fa-copy visit_color copyPaste" style="padding: 0.2rem 0.5rem;" v-on:click="copyToClipboard" title="Zkopírovat pravidla z této stránky" alt="Zkopírovat pravidla z této stránky"> </button>
                                                <button class="btn btn-outline-secondary_visit fas fa-paste visit_color copyPaste" style="padding: 0.2rem 0.5rem;" v-on:click="pasteFromClipboard" title="Vložit zkopírovaná pravidla" alt="Vložit zkopírovaná pravidla" :disabled="!pasteEnable"> </button>
                                            </span>
                                        </div>
                                    </div>

                                    <div class="list-group-item" v-for="rule,index in ShownRule">
                                        <p v-if="index == 0">
                                            Do pole „Zahrnout“ vložte celou nebo částečnou URL, kde chcete notifikace zobrazovat.
                                            <br />Každou URL potvrďte tlačítkem *Enter*.
                                        </p>

                                        <div class="align-items-center pb-4 pt-3" style="display: flex;">
                                            <span class="d-flex width_100 align-items-center">
                                                <span class="width_70px">URL </span>
                                                <select v-model="ShownRule[index]" style="max-width: 240px;" v-on:change="validateForm()" v-bind:name="ShownRule[index]" v-validate="{required: true}" class="form-control" v-bind:class="{ 'is-invalid': errors.has('ShownRule['+index+']') }">
                                                    <option disabled="" value="none">Vyberte</option>
                                                    <option value="startWith" :hidden="ShownRule.indexOf('startWith') > -1 && ShownRule.indexOf('startWith') != index">Začíná na</option>
                                                    <option value="exactmatch" :hidden="ShownRule.indexOf('exactmatch') > -1 && ShownRule.indexOf('exactmatch') != index">Shoduje se</option>
                                                    <option value="contains" :hidden="ShownRule.indexOf('contains') > -1 && ShownRule.indexOf('contains') != index">Obsahuje</option>
                                                </select>
                                                <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                                   v-tooltip.top="{ content: 'Začíná na = zadejte jen začátek URL a začleňte tím všechny další znaky nebo parametry vypsané v URL (např. strom podstránek).\n\nShoduje se = vložte přesnou URL stránky nebo podstránky (ideálně zkopírováním z URL řádku v prohlížeči).\n\nObsahuje = vložte slovo nebo řetězec obsažený v URL (např. kosik, lcd-televizory).' }"></i>
                                            </span>
                                            <span class="right d-flex align-items-center" style="font-family: inherit;font-weight: 500;line-height: 1.2;color: inherit;" v-if="index > 0">
                                                <span class="fas fa-trash visit_color btn btn-outline-secondary_remove copyPaste" style="cursor:pointer" title="odstranit" alt="odstranit" v-on:click="removeRule(index)"> </span>
                                            </span>
                                        </div>

                                        <div class="d-flex">
                                            <span class="width_70px">Zahrnout </span>
                                            <tags-input :selectedRule="ShownRule[index]" v-bind:element-id="'tagsShownUrlsIn'+index" v-on:input="validateForm()" v-bind:ref="'tagsShownUrlsIn'+index" v-model="ShownUrlsIn[index]" :allow-duplicates="false" placeholder="" v-bind:name="ShownUrlsIn[index]" v-validate="{ required: false,url:require_protocol}" class="form-control" v-bind:class="{ 'is-invalid': errors.has('ShownUrlsIn['+index+']') }" style="display: inline-table;table-layout: fixed;width: calc(100% - 70px);"></tags-input>
                                        </div>

                                        <div class="d-flex">
                                            <span class="width_70px">Vyloučit </span>
                                            <tags-input :selectedRule="ShownRule[index]" v-bind:element-id="'tagsShownUrlsOut'+index" v-on:input="validateForm()" v-bind:ref="'tagsShownUrlsOut'+index" v-model="ShownUrlsOut[index]" :allow-duplicates="false" placeholder="" v-bind:name="ShownUrlsOut[index]" v-validate="{ required: false,url:require_protocol}" class="form-control" v-bind:class="{ 'is-invalid': errors.has('ShownUrlsOut['+index+']') }" style="display: inline-table;table-layout: fixed;width: calc(100% - 70px);"></tags-input>
                                        </div>
                                        <span v-if="errors.has('ShownUrlsIn['+index+']') || errors.has('ShownUrlsOut['+index+']') " class="d-flex invalid-feedback pl_70px">{{ errors.first('ShownUrlsIn['+index+']') }} {{ errors.first('ShownUrlsOut['+index+']') }}</span>
                                        <!--<span style="padding-top: 10px;display: block;padding-bottom: 10px;overflow-wrap: break-word;">{{ShownUrlsIn[rule]}}</span>-->


                                        <div style="padding-top: 10px;color: #D3D5D7;font-size: 13px;">
                                            <label class="width_70px"></label>
                                            <i style="color:#7dc542; opacity:1;" class="fa fa-question-circle pointer"
                                               v-tooltip.top="{ content: 'URL má správně nainstalovaný kód Pixelu a zachytává data.' }"></i>
                                            Aktivní URL
                                            &nbsp;&nbsp;
                                            <i style="color:#ed6b27; opacity:1;" class="fa fa-question-circle pointer"
                                               v-tooltip.top="{ content: 'URL může mít správně nainstalovaný kód Pixelu, ale nebyla aktivována. Proveďte první návštěvu. Pokud URL zůstává stále oranžová, zkontrolujte si nastavení webu.' }"></i>
                                            Nenavštívená URL
                                            &nbsp;&nbsp;
                                            <i style="color:#dc3545; opacity:1;" class="fa fa-question-circle pointer"
                                               v-tooltip.top="{ content: 'Konkrétní chyba je zobrazena pod polem pro zadávání URL.' }"></i>
                                            Chybná URL
                                        </div>
                                    </div>

                                    <div class="list-group-item pt-4 pb-4">
                                        <button class="btn btn-outline-secondary" v-on:click="addRule" :disabled="(!nextStepAllowed3 || ShownRule.length ==3)"><i class="fas fa-plus"></i>Přidat pravidlo</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
        <div class="container-bottom-buttons new_campaign_container_but">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 d-flex justify-content-between p-0">
                        <div class="justify-content-start">
                            <button class="btn btn-outline-secondary btn_new_campaign" v-on:click="PreviousStep">
                                <i class="fas fa-chevron-circle-left"></i>&nbsp;&nbsp;&nbsp; Zpět
                            </button>
                        </div>
                        <div class="d-flex justify-content-center" style="display: inline-flex;">
                            <div class="d-inline-block pt-1 text-center">
                                Vybraná doména:
                                <i style="color:royalblue; opacity:1;" class="fa fa-question-circle pointer pl-2"
                                   v-tooltip.top="{ content: 'Pro změnu domény u celé kampaně se vraťte do kroku 1.' }"></i>
                                <input type="text" v-bind:alt="selectedDomain" v-bind:title="selectedDomain" v-model="selectedDomain" disabled="disabled" style="max-width: 240px;" name="selectedDomain" class="form-control" />
                            </div>
                        </div>
                        <div class="justify-content-end">
                            <button class="btn btn-main-primary btn_new btn_new_campaign" :disabled="!nextStepAllowed3" v-on:click="NextStep">
                                Pokračovat&nbsp;&nbsp;&nbsp; <i class="fas fa-chevron-circle-right"></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

    import TagsInput from "../plugin/VoerroTagsInputOrig.vue";
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';
    import VeeValidate from 'vee-validate';
    import VueI18n from 'vue-i18n';

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";
    import { isNullOrUndefined } from "util";

    Vue.use(VueI18n);
    Vue.use(VueCookie);

    const parseDomain = require("parse-domain");
    const parseUrl = require("parse-url");
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
    components: {
        "tags-input": TagsInput,
    },
    data() {
        return {
            adminAccess: false,
            userUid: 'none',
            userEmail: null,
            nextStepAllowed3: false,
            Component: '',
            CampaignName: this.$store.state.CampaignName,
            selectedDomain: this.$store.state.selectedDomain,
            selectedLanguage: this.$store.state.selectedLanguage,
            DomainList: [],
            SelectedMessages: [],
            ShownRule: this.$store.state.ShownRule,
            ShownUrlsIn: this.$store.state.ShownUrlsIn,
            ShownUrlsOut: this.$store.state.ShownUrlsOut,
            validatingEnabled: true,
            pasteEnable: (this.$store.state.clipBoardRules.length > 0) ? true : false,
          
        }
    },
    activated() {
        var that = this;
      
        if (that.$store.state.CampaignData.campaignID != undefined) {
            if (that.SelectedMessages == '') { that.SelectedMessages = (that.$store.state.SelectedMessages != '') ? that.$store.state.SelectedMessages : that.$store.state.CampaignData.SelectedMessages; }
            that.ShownRule = (that.$store.state.ShownRule[0] != 'none') ? JSON.parse(JSON.stringify(that.$store.state.ShownRule)) : JSON.parse(JSON.stringify(that.$store.state.CampaignData.ShownRule));
            that.ShownUrlsIn = (that.$store.state.ShownRule[0] != 'none') ? JSON.parse(JSON.stringify(that.$store.state.ShownUrlsIn)) : JSON.parse(JSON.stringify(that.$store.state.CampaignData.ShownUrlsIn).replace(/""/g, '[]'));
            that.ShownUrlsOut = (that.$store.state.ShownRule[0] != 'none') ? JSON.parse(JSON.stringify(that.$store.state.ShownUrlsOut)) : JSON.parse(JSON.stringify(that.$store.state.CampaignData.ShownUrlsOut).replace(/""/g, '[]'));

            that.validateForm();
        } else {
            if(that.SelectedMessages == '') { that.SelectedMessages = that.$store.state.SelectedMessages; }
            that.ShownRule = JSON.parse(JSON.stringify(that.$store.state.ShownRule));
            that.ShownUrlsIn = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsIn));
            that.ShownUrlsOut = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsOut));
        }

        that.selectedDomain = that.$store.state.selectedDomain;
        that.selectedLanguage = that.$store.state.selectedLanguage;
        that.ignoreDomain = that.$store.state.ignoreDomain;

        that.pasteEnable = (that.$store.state.clipBoardRules.length > 0) ? true : false;

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
        });

        that.validateForm();
    },
    methods: {
        setCorrectForm() {
            if (this.CampaignName.length > 0) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert('Nejdříve vyplňte správně formulář.', options)
                    .then(res => {
                    });
            }
        },
        goToStep(value) {
            this.$store.state.ShownRule = JSON.parse(JSON.stringify(this.ShownRule));
            this.$store.state.ShownUrlsIn = JSON.parse(JSON.stringify(this.ShownUrlsIn));
            this.$store.state.ShownUrlsOut = JSON.parse(JSON.stringify(this.ShownUrlsOut));

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
        copyToClipboard() {
            this.$store.state.clipBoardRules = JSON.parse(JSON.stringify(this.ShownRule));
            this.$store.state.clipBoardUrlsIn = JSON.parse(JSON.stringify(this.ShownUrlsIn));
            this.$store.state.clipBoardUrlsOut = JSON.parse(JSON.stringify(this.ShownUrlsOut));
            this.pasteEnable = (this.$store.state.clipBoardRules.length > 0) ? true : false;
            const options = { title: 'Info', size: 'sm' }
            this.$dialogs.alert('Všechna pravidla jste zkopírovali do dočasné schránky.', options)
                .then(res => {
                });
        },
        pasteFromClipboard() {
            const options = { title: 'Info', size: 'sm', cancelLabel: 'Ne' }
            this.$dialogs.confirm('Chcete opravdu vložit pravidla z dočasné schránky ? Přepíší se již zadané URL adresy na této stránce.', options)
                .then(res => {
                    if (res.ok) {
                        this.validatingEnabled = false;
                        this.ShownRule = JSON.parse(JSON.stringify(this.$store.state.clipBoardRules));
                        this.ShownUrlsIn = JSON.parse(JSON.stringify(this.$store.state.clipBoardUrlsIn));
                        this.ShownUrlsOut = JSON.parse(JSON.stringify(this.$store.state.clipBoardUrlsOut));
                        this.validatingEnabled = true;
                        this.validateForm();             
                    }
                });
        },
        addRule() {
            this.validatingEnabled = false;
            this.ShownRule.push('none');
            this.ShownUrlsIn.push([]);
            this.ShownUrlsOut.push([]);
            this.validatingEnabled = true;
            this.validateForm();
        
        },
        removeRule(value) {
            this.validatingEnabled = false;
            this.ShownRule.splice(value, 1);
            this.ShownUrlsIn.splice(value, 1);
            this.ShownUrlsOut.splice(value, 1);
            this.validatingEnabled = true;
            this.validateForm();
        },

        NextStep() {
            //uloží vybrané URL do globální state
            this.$store.state.ShownRule = JSON.parse(JSON.stringify(this.ShownRule));
            this.$store.state.ShownUrlsIn = JSON.parse(JSON.stringify(this.ShownUrlsIn));
            this.$store.state.ShownUrlsOut = JSON.parse(JSON.stringify(this.ShownUrlsOut));

            //zmina dynamické komponenty
            this.Component = "app-new-campaign-Step4";
            this.$emit("changeComponent", this.Component);
        },
        PreviousStep() {
            //uloží vybrané URL do globální state
            this.$store.state.ShownRule = JSON.parse(JSON.stringify(this.ShownRule));
            this.$store.state.ShownUrlsIn = JSON.parse(JSON.stringify(this.ShownUrlsIn));
            this.$store.state.ShownUrlsOut = JSON.parse(JSON.stringify(this.ShownUrlsOut));


            //změna dynamické komponenty
            if(this.SelectedMessages.indexOf('OwnAppi') > -1) {
                this.Component = "app-new-campaign-Step2_ownAppi";
            } else if (this.SelectedMessages.indexOf('Zbozi') > -1) {
                this.Component = "app-new-campaign-Step2_zbozi";
            } else if (this.SelectedMessages.indexOf('Heureka') > -1) {
                this.Component = "app-new-campaign-Step2_rev";
            } else if (this.SelectedMessages.indexOf('Statistics') > -1) {
                this.Component = "app-new-campaign-Step2_stat";
            } else if (this.SelectedMessages.indexOf('VisitCount') > -1) {
                this.Component = "app-new-campaign-Step2_visit";
            } else if (this.SelectedMessages.indexOf('LastEventsRegistrations') > -1) {
                this.Component = "app-new-campaign-Step2_reg";
            } else if (this.SelectedMessages.indexOf('LastEventsOrders') > -1) {
                this.Component = "app-new-campaign-Step2_obj";
            } else {
                this.Component = "app-new-campaign-Step1";
            }
            this.$emit("changeComponent", this.Component);
        },
        validUrl(valUrl) {
            if (parseUrl(valUrl, true).protocol != "http" && parseUrl(valUrl, true).protocol != "https") {
                return false;
            }

            if (parseDomain(valUrl) == null) {
                return false;
            }

            return true;
        },
        validateForm() {
            this.nextStepAllowed3 = true;
            this.errors.clear();
            var that = this;

            this.$validator.validateAll({
                ShownRule: that.ShownRule,
                ShownUrlsIn: that.ShownUrlsIn
            }).then((valid) => {
                if (that.validatingEnabled) {
                    if (valid) {
                        that.ShownRule.forEach(function (rule, index) {
                            if (rule == 'none') {
                                that.errors.add({ field: 'ShownRule[' + index + ']', msg: 'Vyberte variantu' });
                                that.nextStepAllowed3 = false;
                            }
                        });

                        //check minimum 1 url in next rules
                        that.ShownUrlsIn.forEach(function (ruleUrlsIn, index) {
                            var checkInsertedMinimumUrl = [];
                            if (index > 0) {
                                if (ruleUrlsIn.length > 0) {
                                    ruleUrlsIn.forEach(function (urlAddressIn) {
                                        if (checkInsertedMinimumUrl.indexOf(urlAddressIn) == -1 && urlAddressIn != '') { checkInsertedMinimumUrl.push(urlAddressIn); }
                                    });
                                }

                                if (that.ShownUrlsOut[index].length > 0) {
                                    that.ShownUrlsOut[index].forEach(function (urlAddressOut) {
                                        if (checkInsertedMinimumUrl.indexOf(urlAddressOut) == -1 && urlAddressOut != '') { checkInsertedMinimumUrl.push(urlAddressOut); }
                                    });
                                }

                                if (checkInsertedMinimumUrl.length == 0) {
                                    that.errors.add({ field: 'ShownUrlsIn[' + index + ']', msg: 'Musí být zadána minimálně 1 URL.' });
                                    that.errors.add({ field: 'ShownUrlsOut[' + index + ']', msg: ' ' });
                                    that.nextStepAllowed3 = false;
                                }
                            }
                        });

                        //check minimum 1 url in first rule
                        if (that.ShownUrlsIn[0].length == 0) {
                            that.errors.add({ field: 'ShownUrlsIn[0]', msg: 'Není zadaná žádná zahrnutá URL.' });
                            that.nextStepAllowed3 = false;
                        }

                        //check valid url format !validUrl(urlAddressOut)
                        that.ShownUrlsIn.forEach(function (ruleUrlsIn, index) {
                            if (ruleUrlsIn.length > 0) {
                                ruleUrlsIn.forEach(function (urlAddressIn) {
                                    if (urlAddressIn != '' && !that.validUrl(urlAddressIn) && that.ShownRule[index] != 'contains') {
                                        that.errors.add({ field: 'ShownUrlsIn[' + index + ']', msg: 'URL adresa nemá správný formát.' });
                                        that.nextStepAllowed3 = false;
                                    }
                                });
                            }

                            if (that.ShownUrlsOut[index].length > 0) {
                                that.ShownUrlsOut[index].forEach(function (urlAddressOut) {
                                    if (urlAddressOut != '' && !that.validUrl(urlAddressOut) && that.ShownRule[index] != 'contains') {
                                        that.errors.add({ field: 'ShownUrlsOut[' + index + ']', msg: 'URL adresa nemá správný formát.' });
                                        that.nextStepAllowed3 = false;
                                    }
                                });
                            }
                        });

                        //check if only 1 domain inserted
                        //Shown
                        var ruleUrlsList = [];
                        that.ShownUrlsIn.forEach(function (ruleUrlsIn, index) {
                            if (ruleUrlsIn.length > 0) {
                                ruleUrlsIn.forEach(function (entry) {
                                    var urlAddressIn = parseDomain(entry);
                                    if (urlAddressIn != null) {
                                        if (ruleUrlsList.indexOf(urlAddressIn.domain + '.' + urlAddressIn.tld) == -1 && urlAddressIn.domain != '' && that.ShownRule[index] != 'contains') { ruleUrlsList.push(urlAddressIn.domain + '.' + urlAddressIn.tld); }
                                        if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                            if ((
                                                   (urlAddressIn.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressIn.subdomain + '.' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                || (urlAddressIn.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                || urlAddressIn.domain + '.' + urlAddressIn.tld != ruleUrlsList[0]) && that.ShownRule[index] != 'contains') {
                                                that.errors.add({ field: 'ShownUrlsIn[' + index + ']', msg: 'V Kampani může být nastavena jen jedna doména: ' + that.selectedDomain });
                                                that.nextStepAllowed3 = false;
                                            }
                                        }
                                    }
                                });
                            }

                            if (that.ShownUrlsOut[index].length > 0) {
                                that.ShownUrlsOut[index].forEach(function (entry) {
                                    var urlAddressOut = parseDomain(entry);
                                    if (urlAddressOut != null) {
                                        if (ruleUrlsList.indexOf(urlAddressOut.domain + '.' + urlAddressOut.tld) == -1 && urlAddressOut.domain != '' && that.ShownRule[index] != 'contains') { ruleUrlsList.push(urlAddressOut.domain + '.' + urlAddressOut.tld); }
                                        if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                            if ((
                                                   (urlAddressOut.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressOut.subdomain + '.' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                || (urlAddressOut.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                || urlAddressOut.domain + '.' + urlAddressOut.tld != ruleUrlsList[0]) && that.ShownRule[index] != 'contains') {
                                                that.errors.add({ field: 'ShownUrlsOut[' + index + ']', msg: 'V Kampani může být nastavena jen jedna doména: ' + that.selectedDomain });
                                                that.nextStepAllowed3 = false;
                                            }
                                        }
                                    }
                                });
                            }
                        });

                    } else {
                        //console.log("not valid");
                        that.nextStepAllowed3 = false;
                    }
                }
            });

        },
    },
    watch: {

    },
    created() {
        this.userUid = this.$store.state.AdminModule.adminUserKey;
    }

    }
</script>