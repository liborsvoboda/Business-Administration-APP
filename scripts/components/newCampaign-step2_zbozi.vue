<template>

    <div>
        <div class="container-fluid wizard_campaign_container">
            <div class="row">
                <div class="col-md-12 wizard_campaign_col">
                    <ul class="wizard_campaign">
                        <li class="list_group_button" v-on:click="(nextStepAllowed2) ? goToStep('Step1'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">1</div>
                                <div class="wizard_step_desc">Výběr</div>
                            </div>
                        </li>
                        <li class="wizard_step_active">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">2</div>
                                <div class="wizard_step_desc">Spárování</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="(nextStepAllowed2) ? goToStep('Step3'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">3</div>
                                <div class="wizard_step_desc">Zobrazení</div>
                            </div>
                        </li>
                        <li class="list_group_button" v-on:click="(nextStepAllowed2) ? goToStep('Step4'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CampaignName.length === 0) }">
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
                <div class="row justify-content-center">
                    <div class="d-inline-flex">
                        <ul class="capturedUrl_campaign col-md-12 justify-content-center align-items-center">
                            <li v-if="SelectedMessages.indexOf('LastEventsOrders') > -1" v-on:click="(nextStepAllowed2) ? goToSelected('LastEventsOrders'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CapturedUrlsObjIn[0].length === 0 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/orders_grey.svg" v-on:click="(nextStepAllowed2) ? goToSelected('LastEventsOrders'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CapturedUrlsObjIn[0].length === 0 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title wizard_step_desc">Poslední objednávky</span>
                                    </div>
                                </span>
                            </li>

                            <li v-if="SelectedMessages.indexOf('LastEventsRegistrations') > -1" v-on:click="(nextStepAllowed2) ? goToSelected('LastEventsRegistrations'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CapturedUrlsRegIn[0].length === 0 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/registration_grey.svg" v-on:click="(nextStepAllowed2) ? goToSelected('LastEventsRegistrations'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CapturedUrlsRegIn[0].length === 0 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title wizard_step_desc">Poslední registrace</span>
                                    </div>
                                </span>
                            </li>

                            <li v-if="SelectedMessages.indexOf('VisitCount') > -1" v-on:click="(nextStepAllowed2) ? goToSelected('VisitCount'): setCorrectForm()" v-bind:class="{ 'cursor_default': (!nextStepAllowed2 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/visits_grey.svg" v-on:click="(nextStepAllowed2) ? goToSelected('VisitCount'): setCorrectForm()" v-bind:class="{ 'cursor_default': (!nextStepAllowed2 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title wizard_step_desc">Aktuální návštěvníci</span>
                                    </div>
                                </span>
                            </li>

                            <li v-if="SelectedMessages.indexOf('Statistics') > -1" v-on:click="(nextStepAllowed2) ? goToSelected('Statistics'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CapturedUrlsStatIn[0].length === 0 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/statistics_grey.svg" v-on:click="(nextStepAllowed2) ? goToSelected('Statistics'): setCorrectForm()" v-bind:class="{ 'cursor_default': (CapturedUrlsStatIn[0].length === 0 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title wizard_step_desc">Souhrnné statistiky</span>
                                    </div>
                                </span>
                            </li>

                            <li v-if="SelectedMessages.indexOf('Heureka') > -1" v-on:click="(nextStepAllowed2) ? goToSelected('Heureka'): setCorrectForm()" v-bind:class="{ 'cursor_default': (heurekaAPIkey === 'none' || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/reviews_grey.svg" v-on:click="(nextStepAllowed2) ? goToSelected('Heureka'): setCorrectForm()" v-bind:class="{ 'cursor_default': (heurekaAPIkey === 'none' || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title wizard_step_desc">Recenze Heuréka</span>
                                    </div>
                                </span>
                            </li>

                            <li v-if="SelectedMessages.indexOf('Zbozi') > -1" class="align-items-center pl-3 pr-3" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/zbozi.svg" class="svg_img_60" style="margin-right:10px;cursor:default;width: 70px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title zbozi_color">Recenze Zboží.cz</span>
                                    </div>
                                </span>
                            </li>

                            <li v-if="SelectedMessages.indexOf('OwnAppi') > -1" v-on:click="(nextStepAllowed2) ? goToSelected('OwnAppi'): setCorrectForm()" v-bind:class="{ 'cursor_default': (ownAppi.ownAppiActive.indexOf(true) == -1 || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/offer_grey.svg" v-on:click="(nextStepAllowed2) ? goToSelected('OwnAppi'): setCorrectForm()" v-bind:class="{ 'cursor_default': (ownAppi.ownAppiActive.indexOf(true) == -1 || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title wizard_step_desc">TOP nabídky</span>
                                    </div>
                                </span>
                            </li>

                        </ul>
                    </div>
                    <div class="col-md-12">
                        <h3 class="new_campaign_h3_2 py-4 pb-4 text-center">Na jakých URL zachytíme data?</h3>
                        <div class="row justify-content-md-center">
                            <div class="col-md-8">
                                <div class="list-group mt-2 shadow-sm">
                                    <div class="list-group-item group_item_red1">
                                        <div class="new_campaign_tile_group_item zbozi_color">Vyberte API klíč pro recenze a hodnocení</div>
                                    </div>

                                    <div class="list-group-item pt-4 pb-4">
                                        <div class="align-items-center " style="display: flex;">
                                            Vyberte ZBOŽÍ API Klíč:
                                            <!--<i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                v-tooltip.top="{ content: 'Automaticky = doplní samo správné znění odkazu včetně http:// nebo https:// k zadané URL.\n\nPřesná shoda = vložte přesnou URL stránky nebo podstránky (ideálně zkopírováním z URL řádku v prohlížeči).\n\nZačíná na = volba umožňuje zadat jen začátek URL a začlení všechny další znaky nebo parametry vypsané v URL (např. strom podstránek) ' }"></i>-->
                                            <select v-model="zboziAPIkey" v-on:change="validateForm()" style="max-width: 240px;" name="zboziAPIkey" v-validate="{required: true}" class="form-control ml-3" :class="{ 'is-invalid': errors.has('zboziAPIkey') }">
                                                <option disabled="" value="none">Vyberte</option>
                                                <option v-for="apikey in apiKeyListZbozi" v-bind:value="apikey.zboziAPIkey">
                                                    {{apikey.Name}}
                                                </option>
                                            </select>
                                        </div>
                                        <span v-if="errors.has('zboziAPIkey')" class="invalid-feedback">{{ errors.first('zboziAPIkey') }}</span>
                                        <!--<br v-if="SelectedMessages.indexOf('Zbozi') > -1" />-->
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
                            <button class="btn btn-main-primary btn_new btn_new_campaign" :disabled="!nextStepAllowed2" v-on:click="NextStep">
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

 	import Vue from 'vue';
	import VueCookie from 'vue-cookie';
    import VeeValidate from 'vee-validate';
	import VueI18n from 'vue-i18n';
	import cs from "vee-validate/dist/locale/cs";
	import en from "vee-validate/dist/locale/en";

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
                adminAccess: false,
                userUid: "none",
                userEmail: null,
				nextStepAllowed2: false,
                Component: "",
                CampaignName: this.$store.state.CampaignName,
                selectedDomain: this.$store.state.selectedDomain,
                selectedLanguage: this.$store.state.selectedLanguage,
                DomainList: [],
                SelectedMessages: [],
                zboziAPIkey: 'none',
                apiKeyListZbozi: [],

                CaptureRuleObj: this.$store.state.CaptureRuleObj,
                CapturedUrlsObjIn: this.$store.state.CapturedUrlsObjIn,
                CapturedUrlsObjOut: this.$store.state.CapturedUrlsObjOut,
                CaptureRuleReg: this.$store.state.CaptureRuleReg,
                CapturedUrlsRegIn: this.$store.state.CapturedUrlsRegIn,
                CapturedUrlsRegOut: this.$store.state.CapturedUrlsRegOut,
                CaptureRuleStat: this.$store.state.CaptureRuleStat,
                CapturedUrlsStatIn: this.$store.state.CapturedUrlsStatIn,
                CapturedUrlsStatOut: this.$store.state.CapturedUrlsStatOut,
                ShownRule: this.$store.state.ShownRule,
                ShownUrlsIn: this.$store.state.ShownUrlsIn,
                ShownUrlsOut: this.$store.state.ShownUrlsOut,
                heurekaAPIkey: this.$store.state.heurekaAPIkey,
                ownAppi: this.$store.state.OwnAppi,

          }
        },
        activated() {
            var that = this;

            if (that.$store.state.CampaignData.campaignID != undefined) {
                if (that.SelectedMessages == "") { that.SelectedMessages = (that.$store.state.SelectedMessages != "") ? that.$store.state.SelectedMessages : that.$store.state.CampaignData.SelectedMessages; }
                if (that.zboziAPIkey == 'none') { that.zboziAPIkey = (that.$store.state.zboziAPIkey != 'none') ? that.$store.state.zboziAPIkey : (that.$store.state.CampaignData.zboziAPIkey != "") ? that.$store.state.CampaignData.zboziAPIkey : 'none'; }
            } else {
                if (that.SelectedMessages == "") { that.SelectedMessages = that.$store.state.SelectedMessages; }
            }

            that.CaptureRuleObj = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleObj));
            that.CapturedUrlsObjIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsObjIn));
            that.CapturedUrlsObjOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsObjOut));
            that.CaptureRuleReg = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleReg));
            that.CapturedUrlsRegIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsRegIn));
            that.CapturedUrlsRegOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsRegOut));
            that.CaptureRuleStat = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleStat));
            that.CapturedUrlsStatIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatIn));
            that.CapturedUrlsStatOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatOut));
            that.ShownRule = JSON.parse(JSON.stringify(that.$store.state.ShownRule));
            that.ShownUrlsIn = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsIn));
            that.ShownUrlsOut = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsOut));
            that.heurekaAPIkey = that.$store.state.heurekaAPIkey;
            that.ownAppi = that.$store.state.OwnAppi;

            that.selectedDomain = that.$store.state.selectedDomain;
            that.selectedLanguage = that.$store.state.selectedLanguage;

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
                this.$store.state.zboziAPIkey = this.zboziAPIkey;

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
            goToSelected(value) {
                this.$store.state.zboziAPIkey = this.zboziAPIkey;

                switch (value) {
                    case 'LastEventsOrders':
                        if (this.CapturedUrlsObjIn[0].length > 0 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_obj";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'LastEventsRegistrations':
                        if (this.CapturedUrlsRegIn[0].length > 0 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_reg";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'VisitCount':
                        if (this.nextStepAllowed2 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_visit";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Statistics':
                        if (this.CapturedUrlsStatIn[0].length > 0 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_stat";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Heureka':
                        if (this.heurekaAPIkey !== 'none' && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_rev";
                            this.$emit("changeComponent", this.Component);
                        }
                        break;
                    case 'Zbozi':
                        if (this.zboziAPIkey !== 'none' && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_zbozi";
                            this.$emit("changeComponent", this.Component);
                            break;
                        }
                    case 'OwnAppi':
                        if (this.ownAppi.ownAppiActive.indexOf(true) > -1 && this.CampaignName.length > 0) {
                            this.Component = "app-new-campaign-Step2_ownAppi";
                            this.$emit("changeComponent", this.Component);
                            break;
                        }
                }

            },
            NextStep() {
                //uloží vybrané URL do globální state
                this.$store.state.zboziAPIkey = this.zboziAPIkey;

				//změna dynamické komponenty
                if (this.SelectedMessages.indexOf('OwnAppi') > -1) {
                    this.Component = "app-new-campaign-Step2_ownAppi";
                } else {
                    this.Component = "app-new-campaign-Step3";
                }
                this.$emit("changeComponent", this.Component);
            },
			
            PreviousStep() {
                //uloží vybrané URL do globální state
                this.$store.state.zboziAPIkey = this.zboziAPIkey;

				//změna dynamické komponenty
                if (this.SelectedMessages.indexOf('Heureka') > -1) {
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
            validateForm() {
                this.nextStepAllowed2 = true;
                this.errors.clear();

                this.$validator.validateAll({
                    zboziAPIkey: this.zboziAPIkey 
				}).then((valid) => {
                    if (valid) {
                        var that = this;

                        if (that.zboziAPIkey == 'none' && that.SelectedMessages.indexOf("Zbozi") > -1) {
                            that.errors.add({ field: 'zboziAPIkey', msg: 'Vyberte API klíč' });
                            that.nextStepAllowed2 = false;
                        }

                    } else {
                        if (this.zboziAPIkey == 'none' && this.SelectedMessages.indexOf("Zbozi") > -1) {
                            this.errors.add({ field: 'zboziAPIkey', msg: 'Vyberte API klíč' });
                            this.nextStepAllowed2 = false;
                        }

                        this.nextStepAllowed2 = false;
                    }
				
			    });
            },
		},
        watch: {
        },
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_zboziapikeys",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    if (apiKeys.zboziapikeys != undefined) {
                        apiKeys.zboziapikeys.forEach(function (apikey) {
                            that.apiKeyListZbozi.push(apikey);
                        })
                    }
                }
            });
		}
    }
</script>