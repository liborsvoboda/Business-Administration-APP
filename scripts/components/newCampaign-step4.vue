<template>

    <div>

        <div class="container-fluid wizard_campaign_container">
            <div class="row">
                <div class="col-md-12 wizard_campaign_col">
                    <ul class="wizard_campaign">
                        <li class="list_group_button" v-on:click="(nextStepAllowed4) ? goToStep('Step1'): setCorrectForm()" v-bind:class="{ 'cursor_default': (selectedCampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">1</div>
                                <div class="wizard_step_desc">Výběr</div>
                            </div>
                        </li>

                        <li class="list_group_button" v-on:click="(nextStepAllowed4) ? goToStep('Step2'): setCorrectForm()" v-bind:class="{ 'cursor_default': (selectedCampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">2</div>
                                <div class="wizard_step_desc">Spárování</div>
                            </div>
                        </li>

                        <li class="list_group_button" v-on:click="(nextStepAllowed4) ? goToStep('Step3'): setCorrectForm()" v-bind:class="{ 'cursor_default': (selectedCampaignName.length === 0) }">
                            <div class="d-flex justify-content-center align-items-center">
                                <div class="wizard_step_number d-flex align-items-center justify-content-center">3</div>
                                <div class="wizard_step_desc">Zobrazení</div>
                            </div>
                        </li>

                        <li class="wizard_step_active">
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
				<div class="row justify-content-md-center">
                    <div class="col-md-8">
                        <h3 class="new_campaign_h3_2 py-4 pb-4 text-center">Dokončete nastavení kampaně</h3>
                        <!--<p>Pokud jste připraveni spustit kampaň rovnou klikněte na tlačítko uložit.</p>-->
                        <div class="list-group mt-2 shadow-sm">
                            <div class="list-group-item group_item_blue">
                                <div class="new_campaign_tile_group_item">Pojmenujte si kampaň</div>
                            </div>
                            <div class="list-group-item">
                                <input type="text" placeholder="Název kampaně" v-on:input="validateForm()" v-model="CampaignName" name="CampaignName" v-validate="{ required: true,min: 3,max: 25}" class="form-control" :class="{ 'is-invalid': errors.has('CampaignName') }" />
                                <span v-if="errors.has('CampaignName')" class="invalid-feedback">{{ errors.first('CampaignName') }}</span>
                                <p class="descipt">
                                    Pokud nechcete měnit další nastavení, můžete spustit kampaň kliknutím na tlačítko uložit.
                                </p>
                            </div>
                        </div>
                        <p style="padding-top: 10px;"></p>
                        <div class="list-group mt-2 shadow-sm">
                            <div class="list-group-item group_item_blue d-inline-flex flex-row justify-content-between">
                                <span class="col-md-6 p-0">Pravidla zobrazování notifikací</span>
                                <span class="col-md-3 desc_hw">POČÍTAČ&nbsp;&nbsp;&nbsp;</span>
                                <span class="col-md-3 desc_hw">MOBIL&nbsp;&nbsp;&nbsp;</span>
                            </div>

                            <div class="list-group-item">
                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-3 p-0">
                                    <span class="col-md-6 p-0">Skryje notifikace</span>
                                    <span class="col-md-3 noselect desc_hw" style="top:0px;">
                                        <span class="toogle_desc">NE</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: HiddenAppiOnComputer}" v-on:click="HiddenAppiOnComputer = !HiddenAppiOnComputer" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">ANO&nbsp;&nbsp;&nbsp;</span>
                                    </span>
                                    <span class="col-md-3 noselect desc_hw" style="top:0px;">
                                        <span class="toogle_desc">NE</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: HiddenAppiOnMobile}" v-on:click="HiddenAppiOnMobile = !HiddenAppiOnMobile" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">ANO&nbsp;&nbsp;&nbsp;</span>
                                    </span>
                                </div>

                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-3 p-0">
                                    <span class="col-md-6 p-0">Pozice zobrazení notifikací na střed</span>
                                    <span class="col-md-3 noselect desc_hw" style="top:0px;">
                                        <span class="toogle_desc">NE</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: AppiPositionCenter}" :disabled="HiddenAppiOnComputer" v-on:click="AppiPositionCenter = !AppiPositionCenter" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">ANO&nbsp;&nbsp;&nbsp;</span>
                                    </span>

                                    <span class="col-md-3 noselect desc_hw" style="top:0px;">
                                        <span class="toogle_desc">NE</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: AppiPositionOnMobileCenter}" :disabled="HiddenAppiOnMobile" v-on:click="AppiPositionOnMobileCenter = !AppiPositionOnMobileCenter" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">ANO&nbsp;&nbsp;&nbsp;</span>
                                    </span>
                                </div>

                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-3 p-0">
                                    <span class="col-md-6 p-0">Pozice zobrazení notifikací</span>
                                    <span class="col-md-3 noselect desc_hw" style="top:0px;padding-right: 2px;">
                                        <span class="toogle_desc">DOLE</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: ShowUpOnComputer}" :disabled="HiddenAppiOnComputer" v-on:click="ShowUpOnComputer = !ShowUpOnComputer" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">NAHOŘE</span>
                                    </span>
                                    <span class="col-md-3 noselect desc_hw" style="top:0px;padding-right: 2px;">
                                        <span class="toogle_desc">DOLE</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: ShowUpOnMobile}" :disabled="HiddenAppiOnMobile" v-on:click="ShowUpOnMobile = !ShowUpOnMobile" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">NAHOŘE</span>
                                    </span>
                                </div>

                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-3 p-0">
                                    <span class="col-md-6 p-0">Pozice zobrazení notifikací</span>
                                    <span class="col-md-3 noselect desc_hw" style="top: 0px;padding-left: 6px;text-align: left;">
                                        <span class="toogle_desc">VLEVO</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: AppiPosition == 'right'}" :disabled="AppiPositionCenter || HiddenAppiOnComputer" @click="AppiPosition == 'left' ?AppiPosition= 'right' :AppiPosition= 'left'" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">VPRAVO</span>
                                    </span>
                                    <span class="col-md-3 noselect desc_hw" style="top:0px;padding-left: 7px;text-align: left;">
                                        <span class="toogle_desc">VLEVO</span>&nbsp;
                                        <button type="button" class="btn btn-toggle" :class="{active: AppiPositionOnMobile == 'right'}" :disabled="AppiPositionOnMobileCenter || HiddenAppiOnMobile" @click="AppiPositionOnMobile == 'left' ?AppiPositionOnMobile= 'right' :AppiPositionOnMobile= 'left'" data-toggle="button" aria-pressed="false" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span class="toogle_desc">VPRAVO</span>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <p style="padding-top: 10px;"></p>
                        <div class="list-group mt-2 shadow-sm">
                            <div class="list-group-item group_item_blue d-inline-flex flex-row justify-content-between">
                                <span class="col-md-7 p-0">Časování a prodlevy notifikací</span>
                                <span class="col-md-3 desc_hw" style="text-align:left">POČÍTAČ</span>
                                <span class="col-md-3 desc_hw" style="text-align:left">MOBIL</span>
                            </div>

                            <div class="list-group-item">
                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-3 p-0">
                                    <span class="col-md-7 p-0">
                                        Za jak dlouho se zobrazí první notifikace?
                                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Horní hranice je 20 minut (1200 vteřin). Do pole vyplňujete vteřiny, např. pokud chcete odložit zobrazení o 5 minut, vyplníte hodnotu 300 (tj. 5×60 vteřin).' }"></i>
                                    </span>
                                    <span class="col-md-3 noselect desc_timer">
                                        <input type="text" placeholder="2" v-model="PcDelayBeforeFirstAppi" :disabled="HiddenAppiOnComputer" v-on:input="validateForm()" v-validate="{required: false,numeric:true, min_value:1, max_value: 1200}" name="PcDelayBeforeFirstAppi" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('PcDelayBeforeFirstAppi') }" />
                                        <label class="desc_timer" style="padding-top: 5px">&nbsp;&nbsp;vteřin</label>
                                    </span>
                                    <span class="col-md-3 noselect desc_timer">
                                        <input type="text" placeholder="4" v-model="MobDelayBeforeFirstAppi" :disabled="HiddenAppiOnMobile" v-on:input="validateForm()" v-validate="{required: false,numeric:true, min_value:1, max_value: 1200}" name="MobDelayBeforeFirstAppi" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('MobDelayBeforeFirstAppi') }" />
                                        <label class="desc_timer" style="padding-top: 5px">&nbsp;&nbsp;vteřin</label>
                                    </span>
                                </div>
                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-3 p-0">
                                    <span class="col-md-7 p-0">
                                        Doba zobrazení každé notifikace je
                                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Horní hranice zobrazení každé notifikace jsou 2 minuty (120 vteřin). ' }"></i>
                                    </span>
                                    <span class="col-md-3 noselect desc_timer">
                                        <input type="text" placeholder="7" v-model="PcAppiShowTime" :disabled="HiddenAppiOnComputer" v-on:input="validateForm()" v-validate="{required: false,numeric:true, min_value:1, max_value: 120}" name="PcAppiShowTime" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('PcAppiShowTime') }" />
                                        <label class="desc_timer" style="padding-top: 5px">&nbsp;&nbsp;vteřin</label>
                                    </span>
                                    <span class="col-md-3 noselect desc_timer">
                                        <input type="text" placeholder="5" v-model="MobAppiShowTime" :disabled="HiddenAppiOnMobile" v-on:input="validateForm()" v-validate="{required: false,numeric:true, min_value:1, max_value: 120}" name="MobAppiShowTime" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('MobAppiShowTime') }" />
                                        <label class="desc_timer" style="padding-top: 5px">&nbsp;&nbsp;vteřin</label>
                                    </span>
                                </div>
                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-3 p-0">
                                    <span class="col-md-7 p-0">
                                        Prodleva mezi jednotlivými notifikacemi
                                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Horní hranice zobrazení každé notifikace jsou 2 minuty (120 vteřin).' }"></i>
                                    </span>
                                    <span class="col-md-3 noselect desc_timer">
                                        <input type="text" placeholder="5" v-model="PcDelayBetweenAppi" :disabled="HiddenAppiOnComputer" v-on:input="validateForm()" v-validate="{required: false,numeric:true, min_value:1, max_value: 120}" name="PcDelayBetweenAppi" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('PcDelayBetweenAppi') }" />
                                        <label class="desc_timer" style="padding-top: 5px">&nbsp;&nbsp;vteřin</label>
                                    </span>
                                    <span class="col-md-3 noselect desc_timer">
                                        <input type="text" placeholder="15" v-model="MobDelayBetweenAppi" :disabled="HiddenAppiOnMobile" v-on:input="validateForm()" v-validate="{required: false,numeric:true, min_value:1, max_value: 120}" name="MobDelayBetweenAppi" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('MobDelayBetweenAppi') }" />
                                        <label class="desc_timer" style="padding-top: 5px">&nbsp;&nbsp;vteřin</label>
                                    </span>
                                </div>
                                <div class="d-inline-flex flex-row col-md-12 justify-content-between align-items-center pt-5 mt-3 pb-4 p-0">
                                    <span class="col-md-7 p-0">
                                        Zpomalení notifikací
                                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Nejnižší hodnota znamená nejvyšší rychlost zobrazení notifikace. ' }"></i>
                                    </span>
                                    <span class="col-md-3 noselect p-0 pr-5 ">
                                        <vue-slider v-model="PcSpeedAppi" :min="1" :max="10" v-on:change=""
                                                    :process="false" :order="true" drag-on-click="false"
                                                    :marks="zoomMarks" :labelStyle="{cursor:'pointer'}" 
                                                    :tooltipStyle ="{backgroundColor:'#7dc542',borderColor:'#7dc542'}"
                                                    :dot-options="dotOptions1" />
                                    </span>
                                    <span class="col-md-2 noselect p-0 pl-0">
                                        <vue-slider v-model="MobSpeedAppi" :min="1" :max="10" v-on:change=""
                                                    :process="false" :order="true" drag-on-click="false"
                                                    :marks="zoomMarksMob" :labelStyle="{cursor:'pointer'}"
                                                    :tooltipStyle ="{backgroundColor:'#7dc542',borderColor:'#7dc542'}"
                                                    :dot-options="dotOptions1" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
				</div>
			</div>

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
                                <button class="btn btn-main-primary btn_new btn_new_campaign" :disabled="!nextStepAllowed4 || !nextStepAllowedCheck" v-on:click="Save">Uložit</button>
                            </div>
                        </div>
					</div>
				</div>
			</div>
		</form>
    </div>

</template>

<script>

    //import { mapState } from 'vuex';
 	import Vue from 'vue';
	import VueCookie from 'vue-cookie';
	import SlimDialog from 'v-slim-dialog';
    import VeeValidate from 'vee-validate';
    import VueI18n from 'vue-i18n';

    import VueSlider from 'vue-slider-component';
    import 'vue-slider-component/dist-css/vue-slider-component.css';

	import cs from "vee-validate/dist/locale/cs";
	import en from "vee-validate/dist/locale/en";

	Vue.use(SlimDialog);
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
		cs,en
	  }
	});
	
    export default {
        components: {
            "vue-slider": VueSlider,
        },
        data() {
            return {
                //horizontalMarks: { '1': '-', '5': 'Optimum', '10': '+' }, horizontalDotLabel: '{value}',
                zoomMarks: { '1': '-', '5': { label: '', style: { width: '10px', height: '10px', cursor: 'pointer', display: 'block', backgroundColor: '#7dc542', transform: 'translate(-2px, -2px)' } }, '10': '+' },
                zoomMarksMob: { '1': '-', '7': { label: '', style: { width: '10px', height: '10px', cursor: 'pointer', display: 'block', backgroundColor: '#7dc542', transform: 'translate(-2px, -2px)' } }, '10': '+' },
                dotOptions1: [{ disabled: false, tooltip: 'always', labelStyle : { backgroundColor: '#7dc542'}}],


                adminAccess: false,
                userUid: "none",
                userEmail: null,

                nextStepAllowed4: false,
                Component: "",

                CampaignKey: "",
                selectedCampaignName: this.$store.state.CampaignName,//"",
                CampaignName: this.$store.state.CampaignName,//"",
                selectedDomain: this.$store.state.selectedDomain,
                ignoreDomain: this.$store.state.ignoreDomain,
                selectedLanguage: this.$store.state.selectedLanguage,

                DomainList: [],
                ActiveCampaign: false,

                HiddenAppiOnMobile: false,
                HiddenAppiOnComputer: false,
                ShowUpOnComputer: "",
                ShowUpOnMobile: "",
                PcSpeedAppi: 5,
                MobSpeedAppi: 7,

                AppiPosition: this.$store.getters.CAMPAIGNADAPTATION_AppiPosition,
                AppiPositionOnMobile: this.$store.getters.CAMPAIGNADAPTATION_AppiPositionOnMobile,
                AppiPositionCenter: false,
                AppiPositionOnMobileCenter: false,
                PcDelayBeforeFirstAppi: null,
                PcAppiShowTime: null,
                PcDelayBetweenAppi: null,
                MobDelayBeforeFirstAppi: null,
                MobAppiShowTime: null,
                MobDelayBetweenAppi: null,
                SelectedMessages: [],
                nextStepAllowedCheck: true,

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
                zboziAPIkey: this.$store.state.zboziAPIkey,

            }
        },
        activated() {
            var that = this;
            if (that.$store.state.CampaignData.campaignID != undefined) {
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
                    that.zboziAPIkey = that.$store.state.zboziAPIkey;
                    that.selectedDomain = that.$store.state.selectedDomain;
                    that.ignoreDomain = that.$store.state.ignoreDomain;
                    that.selectedLanguage = that.$store.state.selectedLanguage;

                    that.checkCampaignCorrection();
                });
            }
        },
    
        deactivated() {
        },
        methods: {
            OvnAppiRecolor() {
                var that = this;
                if (this.$store.state.OwnAppiIcons != undefined) {
                    this.$store.state.OwnAppiIcons.forEach((icon, index) => {
                        switch (index) {
                            case 0:
                                that.$store.state.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.$store.state.OwnAppi.Iconcolor1); break;
                            case 1:
                                that.$store.state.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.$store.state.OwnAppi.Iconcolor2); break;
                            case 2:
                                that.$store.state.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.$store.state.OwnAppi.Iconcolor3); break;
                            case 3:
                                that.$store.state.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.$store.state.OwnAppi.Iconcolor4); break;
                            case 4:
                                that.$store.state.OwnAppiIcons[index] = icon.replace(icon.substr(icon.indexOf('fill') + 6, 7).toString(), that.$store.state.OwnAppi.Iconcolor5); break;
                            default:
                                break;
                        }
                    });
                } else {
                    that.$store.state.OwnAppiIcons = this.$store.getters.OWNAppi_OwnAppiIcons;
                }
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
            setCorrectForm() {
                if (this.CampaignName.length > 0) {
                    const options = { title: 'Info', size: 'sm' }
                    this.$dialogs.alert('Nejdříve vyplňte správně formulář.', options)
                        .then(res => {
                        });
                }
            },
            goToStep(value) {

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
            validateForm() {
				this.$validator.validateAll({
                    CampaignName: this.CampaignName,
                    PcDelayBeforeFirstAppi: this.PcDelayBeforeFirstAppi,
                    PcAppiShowTime: this.PcAppiShowTime,
                    PcDelayBetweenAppi: this.PcDelayBetweenAppi,
                    MobDelayBeforeFirstAppi: this.MobDelayBeforeFirstAppi,
                    MobAppiShowTime: this.MobAppiShowTime,
                    MobDelayBetweenAppi: this.MobDelayBetweenAppi
                }).then((valid) => {
                    if (valid) {
                       
                        var that = this;
                        that.errors.clear();
                        if (that.$store.state.CampaignData.campaignID != undefined) {
                            that.nextStepAllowed4 = true;

                            if (that.CampaignName.length < 3) {
                                that.errors.add({ field: 'CampaignName', msg: 'Pole CampaignName musí obsahovat alespoň 3 znaků.' });
                                that.nextStepAllowed4 = false;
                            }
                           //check correct CampaignKey

                            this.$store.state.AllCampaignsData.forEach(function (checkAllCampaigns) {
                                if (checkAllCampaigns.CampaignName.toLowerCase() == that.CampaignName.toLowerCase() && checkAllCampaigns.campaignID != that.$store.state.CampaignData.campaignID) {
                                    that.errors.add({ field: 'CampaignName', msg: 'Název Kampaně již existuje' });
                                    that.nextStepAllowed4 = false;
                                };
                            })

                            if (that.PcDelayBeforeFirstAppi == null || that.MobDelayBeforeFirstAppi == null) { 
                                that.nextStepAllowed4 = false;
                            }
                            if (that.PcAppiShowTime == null || that.MobAppiShowTime == null) {
                                that.nextStepAllowed4 = false;
                            }
                            if (that.PcDelayBetweenAppi == null || that.MobDelayBetweenAppi == null) {
                                that.nextStepAllowed4 = false;
                            }
                        
						}
                        else
                        {
                            that.nextStepAllowed4 = true;

                            if (that.CampaignName.length < 3) {
                                that.errors.add({ field: 'CampaignName', msg: 'Pole CampaignName musí obsahovat alespoň 3 znaků.' });
                                that.nextStepAllowed4 = false;
                            }

							//check Campaign name
                            this.$store.state.AllCampaignsData.forEach(function (checkAllCampaigns) {
                                if (checkAllCampaigns.CampaignName.toLowerCase() == that.CampaignName.toLowerCase()) {
                                    that.errors.add({ field: 'CampaignName', msg: 'Název Kampaně již existuje' });
                                    that.nextStepAllowed4 = false;
                                };
                            })
						}
                    } else {
                        this.nextStepAllowed4 = false;
                    }

                });
			},
		
            PreviousStep() {
                //změna dynamické komponenty
                this.Component = "app-new-campaign-Step3";
                this.$emit("changeComponent", this.Component);
                //this.OvnAppiRecolor();
                //console.log(this.$store.state.OwnAppiIcons);
            },

            Save() {
                this.OvnAppiRecolor();

                if (this.HiddenAppiOnMobile) {
                    this.$store.state.CampaignAdaptation.HiddenAppiOnMobile = this.HiddenAppiOnMobile;
                }
                else {
                    this.$store.state.CampaignAdaptation.HiddenAppiOnMobile = this.$store.getters.CAMPAIGNADAPTATION_HiddenAppiOnMobile;
                }

                if (this.HiddenAppiOnComputer) {
                    this.$store.state.CampaignAdaptation.HiddenAppiOnComputer = this.HiddenAppiOnComputer;
                }
                else {
                    this.$store.state.CampaignAdaptation.HiddenAppiOnComputer = this.$store.getters.CAMPAIGNADAPTATION_HiddenAppiOnComputer;
                }

                if (this.ShowUpOnMobile) {
                    this.$store.state.CampaignAdaptation.ShowUpOnMobile = this.ShowUpOnMobile;
                }
                else {
                    this.$store.state.CampaignAdaptation.ShowUpOnMobile = this.$store.getters.CAMPAIGNADAPTATION_ShowUpOnMobile;
                }

                if (this.ShowUpOnComputer) {
                    this.$store.state.CampaignAdaptation.ShowUpOnComputer = this.ShowUpOnComputer;
                }
                else {
                    this.$store.state.CampaignAdaptation.ShowUpOnComputer = this.$store.getters.CAMPAIGNADAPTATION_ShowUpOnComputer;
                }

                if (this.AppiPosition) {
                    this.$store.state.CampaignAdaptation.AppiPosition = this.AppiPosition;
                }
                else {
                    this.$store.state.CampaignAdaptation.AppiPosition = this.$store.getters.CAMPAIGNADAPTATION_AppiPosition;
                }

                if (this.AppiPositionOnMobile) {
                    this.$store.state.CampaignAdaptation.AppiPositionOnMobile = this.AppiPositionOnMobile;
                }
                else {
                    this.$store.state.CampaignAdaptation.AppiPositionOnMobile = this.$store.getters.CAMPAIGNADAPTATION_AppiPositionOnMobile;
                }

                if (this.AppiPositionCenter) {
                    this.$store.state.CampaignAdaptation.AppiPositionCenter = this.AppiPositionCenter;
                }
                else {
                    this.$store.state.CampaignAdaptation.AppiPositionCenter = this.$store.getters.CAMPAIGNADAPTATION_AppiPositionCenter;
                }

                if (this.AppiPositionOnMobileCenter) {
                    this.$store.state.CampaignAdaptation.AppiPositionOnMobileCenter = this.AppiPositionOnMobileCenter;
                }
                else {
                    this.$store.state.CampaignAdaptation.AppiPositionOnMobileCenter = this.$store.getters.CAMPAIGNADAPTATION_AppiPositionOnMobileCenter;
                }

                
                if (this.PcDelayBeforeFirstAppi) {
                    this.$store.state.CampaignAdaptation.PcDelayBeforeFirstAppi = parseInt(this.PcDelayBeforeFirstAppi);
                }
                else {
                    this.$store.state.CampaignAdaptation.PcDelayBeforeFirstAppi = parseInt(this.$store.getters.CAMPAIGNADAPTATION_PcDelayBeforeFirstAppi);
                }
                if (this.PcAppiShowTime) {
                    this.$store.state.CampaignAdaptation.PcAppiShowTime = parseInt(this.PcAppiShowTime);
                }
                else {
                    this.$store.state.CampaignAdaptation.PcAppiShowTime = parseInt(this.$store.getters.CAMPAIGNADAPTATION_PcAppiShowTime);
                }
                if (this.PcDelayBetweenAppi) {
                    this.$store.state.CampaignAdaptation.PcDelayBetweenAppi = parseInt(this.PcDelayBetweenAppi);
                }
                else {
                    this.$store.state.CampaignAdaptation.PcDelayBetweenAppi = parseInt(this.$store.getters.CAMPAIGNADAPTATION_PcDelayBetweenAppi);
                }
                if (this.PcSpeedAppi) {
                    this.$store.state.CampaignAdaptation.PcSpeedAppi = parseInt(this.PcSpeedAppi);
                }
                else {
                    this.$store.state.CampaignAdaptation.PcSpeedAppi = parseInt(this.$store.getters.CAMPAIGNADAPTATION_PcSpeedAppi);
                }

                if (this.MobDelayBeforeFirstAppi) {
                    this.$store.state.CampaignAdaptation.MobDelayBeforeFirstAppi = parseInt(this.MobDelayBeforeFirstAppi);
                }
                else {
                    this.$store.state.CampaignAdaptation.MobDelayBeforeFirstAppi = parseInt(this.$store.getters.CAMPAIGNADAPTATION_MobDelayBeforeFirstAppi);
                }
                if (this.MobAppiShowTime) {
                    this.$store.state.CampaignAdaptation.MobAppiShowTime = parseInt(this.MobAppiShowTime);
                }
                else {
                    this.$store.state.CampaignAdaptation.MobAppiShowTime = parseInt(this.$store.getters.CAMPAIGNADAPTATION_MobAppiShowTime);
                }
                if (this.MobDelayBetweenAppi) {
                    this.$store.state.CampaignAdaptation.MobDelayBetweenAppi = parseInt(this.MobDelayBetweenAppi);
                }
                else {
                    this.$store.state.CampaignAdaptation.MobDelayBetweenAppi = parseInt(this.$store.getters.CAMPAIGNADAPTATION_MobDelayBetweenAppi);
                }
                if (this.MobSpeedAppi) {
                    this.$store.state.CampaignAdaptation.MobSpeedAppi = parseInt(this.MobSpeedAppi);
                }
                else {
                    this.$store.state.CampaignAdaptation.MobSpeedAppi = parseInt(this.$store.getters.CAMPAIGNADAPTATION_MobSpeedAppi);
                }

                if (this.$store.state.CampaignData.campaignID == undefined && this.CampaignName != "") { //insert new campaign
                    var that = this;
                    var campaignData = {
                        session: Vue.cookie.get('session'),
                        CampaignName: this.CampaignName,
                        selectedDomain: this.$store.state.selectedDomain,
                        ignoreDomain: this.$store.state.ignoreDomain,
                        selectedLanguage: that.$store.state.selectedLanguage,
                        ActiveCampaign: false,
                        SelectedMessages: this.$store.state.SelectedMessages,
                        CaptureRuleObj: (this.$store.state.CaptureRuleObj[0] == 'none') ? [] : this.$store.state.CaptureRuleObj,
                        CapturedUrlsObjIn: this.$store.state.CapturedUrlsObjIn,
                        CapturedUrlsObjOut: this.$store.state.CapturedUrlsObjOut,
                        CaptureRuleReg: (this.$store.state.CaptureRuleReg[0] == 'none') ?[]: this.$store.state.CaptureRuleReg,
                        CapturedUrlsRegIn: this.$store.state.CapturedUrlsRegIn,
                        CapturedUrlsRegOut: this.$store.state.CapturedUrlsRegOut,
                        CaptureRuleStat: (this.$store.state.CaptureRuleStat[0] == 'none') ? [] : this.$store.state.CaptureRuleStat,
                        CapturedUrlsStatIn: this.$store.state.CapturedUrlsStatIn,
                        CapturedUrlsStatOut: this.$store.state.CapturedUrlsStatOut,
                        ShownRule: (this.$store.state.ShownRule[0] == 'none') ? [] : this.$store.state.ShownRule,
                        ShownUrlsIn: this.$store.state.ShownUrlsIn,
                        ShownUrlsOut: this.$store.state.ShownUrlsOut,
                        heurekaAPIkey: (this.$store.state.heurekaAPIkey == 'none') ? null : this.$store.state.heurekaAPIkey,
                        zboziAPIkey: (this.$store.state.zboziAPIkey == 'none') ? null : this.$store.state.zboziAPIkey,
                        OwnAppiIcons: this.$store.state.OwnAppiIcons,

                        CampaignAdaptation: {
                            HiddenAppiOnMobile: this.$store.state.CampaignAdaptation.HiddenAppiOnMobile,
                            ShowUpOnMobile: this.$store.state.CampaignAdaptation.ShowUpOnMobile,
                            HiddenAppiOnComputer: this.$store.state.CampaignAdaptation.HiddenAppiOnComputer,
                            ShowUpOnComputer: this.$store.state.CampaignAdaptation.ShowUpOnComputer,
                            AppiPosition: this.$store.state.CampaignAdaptation.AppiPosition,
                            AppiPositionOnMobile: this.$store.state.CampaignAdaptation.AppiPositionOnMobile,
                            AppiPositionCenter: this.$store.state.CampaignAdaptation.AppiPositionCenter,
                            AppiPositionOnMobileCenter: this.$store.state.CampaignAdaptation.AppiPositionOnMobileCenter,
                            PcDelayBeforeFirstAppi: parseInt(this.$store.state.CampaignAdaptation.PcDelayBeforeFirstAppi),
                            PcAppiShowTime: parseInt(this.$store.state.CampaignAdaptation.PcAppiShowTime),
                            PcDelayBetweenAppi: parseInt(this.$store.state.CampaignAdaptation.PcDelayBetweenAppi),
                            MobDelayBeforeFirstAppi: parseInt(this.$store.state.CampaignAdaptation.MobDelayBeforeFirstAppi),
                            MobAppiShowTime: parseInt(this.$store.state.CampaignAdaptation.MobAppiShowTime),
                            MobDelayBetweenAppi: parseInt(this.$store.state.CampaignAdaptation.MobDelayBetweenAppi),
                            PcSpeedAppi: parseInt(this.$store.state.CampaignAdaptation.PcSpeedAppi),
                            MobSpeedAppi: parseInt(this.$store.state.CampaignAdaptation.MobSpeedAppi)
                        },

                        Heureka: {
                            ShowRevFromLastDays: this.$store.state.Heureka.ShowRevFromLastDays,
                            ShowRevStarsHigherThan: parseInt(this.$store.state.Heureka.ShowRevStarsHigherThan),
                            ShowWhenExistMinRev: parseInt(this.$store.state.Heureka.ShowWhenExistMinRev),
                            CycleShowing: this.$store.state.Heureka.CycleShowing
                        },

                        Zbozi: {
                            ShowZboziShopFromLastDays: this.$store.state.Zbozi.ShowZboziShopFromLastDays,
                            ShowZboziProductFromLastDays: this.$store.state.Zbozi.ShowZboziProductFromLastDays,
                            ShowZboziStarsHigherThan: parseInt(this.$store.state.Zbozi.ShowZboziStarsHigherThan),
                            ShowWhenExistMinZboziShop: parseInt(this.$store.state.Zbozi.ShowWhenExistMinZboziShop),
                            ShowWhenExistMinZboziProduct: parseInt(this.$store.state.Zbozi.ShowWhenExistMinZboziProduct),
                            CycleShowingShop: this.$store.state.Zbozi.CycleShowingShop,
                            CycleShowingProduct: this.$store.state.Zbozi.CycleShowingProduct,
                            ZboziShopActive: this.$store.state.Zbozi.ZboziShopActive,
                            ZboziProductActive: this.$store.state.Zbozi.ZboziProductActive,
                        },

                        VisitCount: {
                            ShowDomainVisitCount: this.$store.state.VisitCount.ShowDomainVisitCount,
                            ShowCountHigherThan: parseInt(this.$store.state.VisitCount.ShowCountHigherThan),
                            CycleShowing: this.$store.state.VisitCount.CycleShowing,
                            MessageText: (that.$store.state.selectedLanguage == "en") ? this.$store.state.VisitCount.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? this.$store.state.VisitCount.MessageTextSk : this.$store.state.VisitCount.MessageTextCz
                        },

                        LastEventsOrders: {
                            MessageText: (that.$store.state.selectedLanguage == "en") ? this.$store.state.LastEventsOrders.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? this.$store.state.LastEventsOrders.MessageTextSk : this.$store.state.LastEventsOrders.MessageTextCz,
                            ShowMaxLastOrders: parseInt(this.$store.state.LastEventsOrders.ShowMaxLastOrders),
                            ShowOrdersFromLastDays: parseInt(this.$store.state.LastEventsOrders.ShowOrdersFromLastDays),
                            ShowWhenExistMinOrders: parseInt(this.$store.state.LastEventsOrders.ShowWhenExistMinOrders),
                            ShowAnonymEmails: this.$store.state.LastEventsOrders.ShowAnonymEmails,
                            ShowNewOrdersAfterReloadPage: this.$store.state.LastEventsOrders.ShowNewOrdersAfterReloadPage,
                            ShowOwnOrders: this.$store.state.LastEventsOrders.ShowOwnOrders,
                            CycleShowing: this.$store.state.LastEventsOrders.CycleShowing
                        },

                        LastEventsRegistrations: {
                            MessageText: (that.$store.state.selectedLanguage == "en") ? this.$store.state.LastEventsRegistrations.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? this.$store.state.LastEventsRegistrations.MessageTextSk : this.$store.state.LastEventsRegistrations.MessageTextCz,
                            ShowMaxLastReg: parseInt(this.$store.state.LastEventsRegistrations.ShowMaxLastReg),
                            ShowRegFromLastDays: parseInt(this.$store.state.LastEventsRegistrations.ShowRegFromLastDays),
                            ShowWhenExistMinReg: parseInt(this.$store.state.LastEventsRegistrations.ShowWhenExistMinReg),
                            ShowAnonymEmails: this.$store.state.LastEventsRegistrations.ShowAnonymEmails,
                            ShowOwnReg: this.$store.state.LastEventsRegistrations.ShowOwnReg,
                            CycleShowing: this.$store.state.LastEventsRegistrations.CycleShowing
                        },

                        Statistics: {
                            SelectedStatsVariant: this.$store.state.Statistics.SelectedStatsVariant,
                            ShowStatsFromLastDays: this.$store.state.Statistics.ShowStatsFromLastDays,
                            ShowStatsDomainVisitCount: this.$store.state.Statistics.ShowStatsDomainVisitCount,
                            ShowCountHigherThan: parseInt(this.$store.state.Statistics.ShowCountHigherThan),
                            CycleShowing: this.$store.state.Statistics.CycleShowing,
                            MessageText: (that.$store.state.selectedLanguage == "en") ? this.$store.state.Statistics.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? this.$store.state.Statistics.MessageTextSk : this.$store.state.Statistics.MessageTextCz
                        },
                        OwnAppi: {
                            OwnAppi1Name: this.$store.state.OwnAppi.OwnAppi1Name,
                            OwnAppi1Icon: this.$store.state.OwnAppi.OwnAppi1Icon,
                            OwnAppi2Name: this.$store.state.OwnAppi.OwnAppi2Name,
                            OwnAppi2Icon: this.$store.state.OwnAppi.OwnAppi2Icon,
                            OwnAppi3Name: this.$store.state.OwnAppi.OwnAppi3Name,
                            OwnAppi3Icon: this.$store.state.OwnAppi.OwnAppi3Icon,
                            OwnAppi4Name: this.$store.state.OwnAppi.OwnAppi4Name,
                            OwnAppi4Icon: this.$store.state.OwnAppi.OwnAppi4Icon,
                            OwnAppi5Name: this.$store.state.OwnAppi.OwnAppi5Name,
                            OwnAppi5Icon: this.$store.state.OwnAppi.OwnAppi5Icon,
                            ShowLink: this.$store.state.OwnAppi.ShowLink,
                            ShowLinkNewWin: this.$store.state.OwnAppi.ShowLinkNewWin,
                            ShowLinkBtn: this.$store.state.OwnAppi.ShowLinkBtn,
                            CycleShowing: this.$store.state.OwnAppi.CycleShowing,
                            ownAppiActive: this.$store.state.OwnAppi.ownAppiActive,
                            editorContent: (that.$store.state.selectedLanguage == "en") ? this.$store.state.OwnAppi.editorContentEn : (that.$store.state.selectedLanguage == "sk") ? this.$store.state.OwnAppi.editorContentSk : this.$store.state.OwnAppi.editorContentCz,
                            zoomIcon: this.$store.state.OwnAppi.zoomIcon,
                            horizontalIcon: this.$store.state.OwnAppi.horizontalIcon,
                            verticalIcon: this.$store.state.OwnAppi.verticalIcon,
                            targetUrl: this.$store.state.OwnAppi.targetUrl,
                            linkDescription: (that.$store.state.selectedLanguage == "en") ? this.$store.state.OwnAppi.linkDescriptionEn : (that.$store.state.selectedLanguage == "sk") ? this.$store.state.OwnAppi.linkDescriptionSk : this.$store.state.OwnAppi.linkDescriptionCz,
                            Iconcolor1: this.$store.state.OwnAppi.Iconcolor1,
                            Iconcolor2: this.$store.state.OwnAppi.Iconcolor2,
                            Iconcolor3: this.$store.state.OwnAppi.Iconcolor3,
                            Iconcolor4: this.$store.state.OwnAppi.Iconcolor4,
                            Iconcolor5: this.$store.state.OwnAppi.Iconcolor5,
                            IconcolorBtn1: this.$store.state.OwnAppi.IconcolorBtn1,
                            IconcolorBtn2: this.$store.state.OwnAppi.IconcolorBtn2,
                            IconcolorBtn3: this.$store.state.OwnAppi.IconcolorBtn3,
                            IconcolorBtn4: this.$store.state.OwnAppi.IconcolorBtn4,
                            IconcolorBtn5: this.$store.state.OwnAppi.IconcolorBtn5,
                            IconcolorBckBtn1: this.$store.state.OwnAppi.IconcolorBckBtn1,
                            IconcolorBckBtn2: this.$store.state.OwnAppi.IconcolorBckBtn2,
                            IconcolorBckBtn3: this.$store.state.OwnAppi.IconcolorBckBtn3,
                            IconcolorBckBtn4: this.$store.state.OwnAppi.IconcolorBckBtn4,
                            IconcolorBckBtn5: this.$store.state.OwnAppi.IconcolorBckBtn5,
                            showLastTopVariables: this.$store.state.OwnAppi.showLastTopVariables
                        }
                    }
                    if (that.userUid != "none") { campaignData.uuid = that.userUid; }
                        $.ajax({
                            type: 'POST',
                            url: "https://appi.app.cz:444/update_campaigns",
                            dataType: 'json',
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(campaignData)
                    }).done(function (data) {
                        if (data.result == 1) {
                            // that.CampaignName = "";
                            that.showAlert("Uloženo. Spuštění kampaně potvrďte v přehledu kampaní.");
                        } else {
                            const options = { title: 'Info', size: 'sm' }
                            that.$dialogs.alert("Chyba Databáze", options)
                                .then(res => {

                                });
                        }
                    });

                    
				}else{// update exist campaign
                    var that = this;
                    var campaignData = {
                        session: Vue.cookie.get('session'),
                        campaignID: that.$store.state.CampaignData.campaignID,
                        CampaignName: that.CampaignName,
                        selectedDomain: that.$store.state.selectedDomain,
                        ignoreDomain: that.$store.state.ignoreDomain,
                        selectedLanguage: that.$store.state.selectedLanguage,
                        ActiveCampaign: that.ActiveCampaign,
                        SelectedMessages: that.$store.state.SelectedMessages,
                        CaptureRuleObj: (that.$store.state.CaptureRuleObj[0] == 'none') ? [] : that.$store.state.CaptureRuleObj,
                        CapturedUrlsObjIn: that.$store.state.CapturedUrlsObjIn,
                        CapturedUrlsObjOut: that.$store.state.CapturedUrlsObjOut,
                        CaptureRuleReg: (that.$store.state.CaptureRuleReg[0] == 'none') ? [] : that.$store.state.CaptureRuleReg,
                        CapturedUrlsRegIn: that.$store.state.CapturedUrlsRegIn,
                        CapturedUrlsRegOut: that.$store.state.CapturedUrlsRegOut,
                        CaptureRuleStat: (that.$store.state.CaptureRuleStat[0] == 'none') ? [] : that.$store.state.CaptureRuleStat,
                        CapturedUrlsStatIn: that.$store.state.CapturedUrlsStatIn,
                        CapturedUrlsStatOut: that.$store.state.CapturedUrlsStatOut,
                        ShownRule: (that.$store.state.ShownRule[0] == 'none') ? [] : that.$store.state.ShownRule,
                        ShownUrlsIn: that.$store.state.ShownUrlsIn,
                        ShownUrlsOut: that.$store.state.ShownUrlsOut,
                        heurekaAPIkey: (that.$store.state.heurekaAPIkey == 'none') ? null : that.$store.state.heurekaAPIkey,
                        zboziAPIkey: (that.$store.state.zboziAPIkey == 'none') ? null : that.$store.state.zboziAPIkey,
                        OwnAppiIcons: that.$store.state.OwnAppiIcons,

                        CampaignAdaptation: {
                            HiddenAppiOnMobile: that.$store.state.CampaignAdaptation.HiddenAppiOnMobile,
                            ShowUpOnMobile: that.$store.state.CampaignAdaptation.ShowUpOnMobile,
                            HiddenAppiOnComputer: that.$store.state.CampaignAdaptation.HiddenAppiOnComputer,
                            ShowUpOnComputer: that.$store.state.CampaignAdaptation.ShowUpOnComputer,
                            AppiPosition: that.$store.state.CampaignAdaptation.AppiPosition,
                            AppiPositionOnMobile: that.$store.state.CampaignAdaptation.AppiPositionOnMobile,
                            AppiPositionCenter: that.$store.state.CampaignAdaptation.AppiPositionCenter,
                            AppiPositionOnMobileCenter: that.$store.state.CampaignAdaptation.AppiPositionOnMobileCenter,
                            PcDelayBeforeFirstAppi: parseInt(that.$store.state.CampaignAdaptation.PcDelayBeforeFirstAppi),
                            PcAppiShowTime: parseInt(that.$store.state.CampaignAdaptation.PcAppiShowTime),
                            PcDelayBetweenAppi: parseInt(that.$store.state.CampaignAdaptation.PcDelayBetweenAppi),
                            MobDelayBeforeFirstAppi: parseInt(that.$store.state.CampaignAdaptation.MobDelayBeforeFirstAppi),
                            MobAppiShowTime: parseInt(that.$store.state.CampaignAdaptation.MobAppiShowTime),
                            MobDelayBetweenAppi: parseInt(that.$store.state.CampaignAdaptation.MobDelayBetweenAppi),
                            PcSpeedAppi: parseInt(that.$store.state.CampaignAdaptation.PcSpeedAppi),
                            MobSpeedAppi: parseInt(that.$store.state.CampaignAdaptation.MobSpeedAppi)
                        },

                        Heureka: {
                            ShowRevFromLastDays: that.$store.state.Heureka.ShowRevFromLastDays,
                            ShowRevStarsHigherThan: parseInt(that.$store.state.Heureka.ShowRevStarsHigherThan),
                            ShowWhenExistMinRev: parseInt(that.$store.state.Heureka.ShowWhenExistMinRev),
                            CycleShowing: that.$store.state.Heureka.CycleShowing
                        },

                        Zbozi: {
                            ShowZboziShopFromLastDays: that.$store.state.Zbozi.ShowZboziShopFromLastDays,
                            ShowZboziProductFromLastDays: that.$store.state.Zbozi.ShowZboziProductFromLastDays,
                            ShowZboziStarsHigherThan: parseInt(that.$store.state.Zbozi.ShowZboziStarsHigherThan),
                            ShowWhenExistMinZboziShop: parseInt(that.$store.state.Zbozi.ShowWhenExistMinZboziShop),
                            ShowWhenExistMinZboziProduct: parseInt(that.$store.state.Zbozi.ShowWhenExistMinZboziProduct),
                            CycleShowingShop: that.$store.state.Zbozi.CycleShowingShop,
                            CycleShowingProduct: that.$store.state.Zbozi.CycleShowingProduct,
                            ZboziShopActive: that.$store.state.Zbozi.ZboziShopActive,
                            ZboziProductActive: that.$store.state.Zbozi.ZboziProductActive
                        },

                        VisitCount: {
                            ShowDomainVisitCount: that.$store.state.VisitCount.ShowDomainVisitCount,
                            ShowCountHigherThan: parseInt(that.$store.state.VisitCount.ShowCountHigherThan),
                            CycleShowing: that.$store.state.VisitCount.CycleShowing,
                            MessageText: (that.$store.state.selectedLanguage == "en") ? that.$store.state.VisitCount.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? that.$store.state.VisitCount.MessageTextSk : that.$store.state.VisitCount.MessageTextCz 
                        },

                        LastEventsOrders: {
                            MessageText: (that.$store.state.selectedLanguage == "en") ? that.$store.state.LastEventsOrders.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? that.$store.state.LastEventsOrders.MessageTextSk : that.$store.state.LastEventsOrders.MessageTextCz,
                            ShowMaxLastOrders: parseInt(that.$store.state.LastEventsOrders.ShowMaxLastOrders),
                            ShowOrdersFromLastDays: parseInt(that.$store.state.LastEventsOrders.ShowOrdersFromLastDays),
                            ShowWhenExistMinOrders: parseInt(that.$store.state.LastEventsOrders.ShowWhenExistMinOrders),
                            ShowAnonymEmails: that.$store.state.LastEventsOrders.ShowAnonymEmails,
                            ShowNewOrdersAfterReloadPage: that.$store.state.LastEventsOrders.ShowNewOrdersAfterReloadPage,
                            ShowOwnOrders: that.$store.state.LastEventsOrders.ShowOwnOrders,
                            CycleShowing: that.$store.state.LastEventsOrders.CycleShowing
                        },

                        LastEventsRegistrations: {
                            MessageText: (that.$store.state.selectedLanguage == "en") ? that.$store.state.LastEventsRegistrations.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? that.$store.state.LastEventsRegistrations.MessageTextSk : that.$store.state.LastEventsRegistrations.MessageTextCz,
                            ShowMaxLastReg: parseInt(that.$store.state.LastEventsRegistrations.ShowMaxLastReg),
                            ShowRegFromLastDays: parseInt(that.$store.state.LastEventsRegistrations.ShowRegFromLastDays),
                            ShowWhenExistMinReg: parseInt(that.$store.state.LastEventsRegistrations.ShowWhenExistMinReg),
                            ShowAnonymEmails: that.$store.state.LastEventsRegistrations.ShowAnonymEmails,
                            ShowOwnReg: that.$store.state.LastEventsRegistrations.ShowOwnReg,
                            CycleShowing: that.$store.state.LastEventsRegistrations.CycleShowing
                        },

                        Statistics: {
                            SelectedStatsVariant: that.$store.state.Statistics.SelectedStatsVariant,
                            ShowStatsFromLastDays: that.$store.state.Statistics.ShowStatsFromLastDays,
                            ShowStatsDomainVisitCount: that.$store.state.Statistics.ShowStatsDomainVisitCount,
                            ShowCountHigherThan: parseInt(that.$store.state.Statistics.ShowCountHigherThan),
                            CycleShowing: that.$store.state.Statistics.CycleShowing,
                            MessageText: (that.$store.state.selectedLanguage == "en") ? that.$store.state.Statistics.MessageTextEn : (that.$store.state.selectedLanguage == "sk") ? that.$store.state.Statistics.MessageTextSk : that.$store.state.Statistics.MessageTextCz
                        },
                        OwnAppi: {
                            OwnAppi1Name: that.$store.state.OwnAppi.OwnAppi1Name,
                            OwnAppi1Icon: that.$store.state.OwnAppi.OwnAppi1Icon,
                            OwnAppi2Name: that.$store.state.OwnAppi.OwnAppi2Name,
                            OwnAppi2Icon: that.$store.state.OwnAppi.OwnAppi2Icon,
                            OwnAppi3Name: that.$store.state.OwnAppi.OwnAppi3Name,
                            OwnAppi3Icon: that.$store.state.OwnAppi.OwnAppi3Icon,
                            OwnAppi4Name: that.$store.state.OwnAppi.OwnAppi4Name,
                            OwnAppi4Icon: that.$store.state.OwnAppi.OwnAppi4Icon,
                            OwnAppi5Name: that.$store.state.OwnAppi.OwnAppi5Name,
                            OwnAppi5Icon: that.$store.state.OwnAppi.OwnAppi5Icon,
                            ShowLink: that.$store.state.OwnAppi.ShowLink,
                            ShowLinkNewWin: that.$store.state.OwnAppi.ShowLinkNewWin,
                            ShowLinkBtn: that.$store.state.OwnAppi.ShowLinkBtn,
                            CycleShowing: that.$store.state.OwnAppi.CycleShowing,
                            ownAppiActive: that.$store.state.OwnAppi.ownAppiActive,
                            editorContent: (that.$store.state.selectedLanguage == "en") ? that.$store.state.OwnAppi.editorContentEn : (that.$store.state.selectedLanguage == "sk") ? that.$store.state.OwnAppi.editorContentSk : that.$store.state.OwnAppi.editorContentCz ,
                            zoomIcon: that.$store.state.OwnAppi.zoomIcon,
                            horizontalIcon: that.$store.state.OwnAppi.horizontalIcon,
                            verticalIcon: that.$store.state.OwnAppi.verticalIcon,
                            targetUrl: that.$store.state.OwnAppi.targetUrl,
                            linkDescription: (that.$store.state.selectedLanguage == "en") ? that.$store.state.OwnAppi.linkDescriptionEn : (that.$store.state.selectedLanguage == "sk") ? that.$store.state.OwnAppi.linkDescriptionSk : that.$store.state.OwnAppi.linkDescriptionCz,
                            Iconcolor1: that.$store.state.OwnAppi.Iconcolor1,
                            Iconcolor2: that.$store.state.OwnAppi.Iconcolor2,
                            Iconcolor3: that.$store.state.OwnAppi.Iconcolor3,
                            Iconcolor4: that.$store.state.OwnAppi.Iconcolor4,
                            Iconcolor5: that.$store.state.OwnAppi.Iconcolor5,
                            IconcolorBtn1: that.$store.state.OwnAppi.IconcolorBtn1,
                            IconcolorBtn2: that.$store.state.OwnAppi.IconcolorBtn2,
                            IconcolorBtn3: that.$store.state.OwnAppi.IconcolorBtn3,
                            IconcolorBtn4: that.$store.state.OwnAppi.IconcolorBtn4,
                            IconcolorBtn5: that.$store.state.OwnAppi.IconcolorBtn5,
                            IconcolorBckBtn1: that.$store.state.OwnAppi.IconcolorBckBtn1,
                            IconcolorBckBtn2: that.$store.state.OwnAppi.IconcolorBckBtn2,
                            IconcolorBckBtn3: that.$store.state.OwnAppi.IconcolorBckBtn3,
                            IconcolorBckBtn4: that.$store.state.OwnAppi.IconcolorBckBtn4,
                            IconcolorBckBtn5: that.$store.state.OwnAppi.IconcolorBckBtn5,
                            showLastTopVariables: that.$store.state.OwnAppi.showLastTopVariables
                        }
                    }
                    if (that.userUid != "none") { campaignData.uuid = that.userUid; }
                    $.ajax({
                        type: 'POST',
                        url: "https://appi.app.cz:444/update_campaigns",
                        dataType: 'json',
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify(campaignData)
                    }).done(function (data) {
                        if (data.result == 1) {
                            that.$store.state.CampaignData = [];
                            // that.CampaignName = "";
                            that.showAlert("Uloženo. Spuštění kampaně potvrďte v přehledu kampaní.");
                        } else {
                            const options = { title: 'Info', size: 'sm' }
                            that.$dialogs.alert("Chyba Databáze", options)
                                .then(res => {
                                  
                                });
                        }
                    });
				}
            },
			showAlert(val) {
				const options = {title: 'Info', size: 'sm'}
				this.$dialogs.alert(val, options)
					.then(res => {
						if(res.ok){window.location.pathname = '/Campaigns';}
				});
            },	
            checkCampaignCorrection() {
                if (this.$store.state.CampaignName.length > 0) {
                    var that = this;
                    var errorMessage = "";
                    var campaignIsCorrected = true;
                    that.nextStepAllowedCheck = true;

                    if (that.$store.state.SelectedMessages.length == 0) {
                        errorMessage = "Kampaň nemá vybranou žádnou notifikaci.\n";
                        campaignIsCorrected = false;
                    }
                    if (that.$store.state.SelectedMessages.indexOf('LastEventsOrders') > -1 && that.$store.state.CapturedUrlsObjIn[0].length === 0) {
                        errorMessage += "Kampaň nemá zadanou žádnou adresu objednávek.\n";
                        campaignIsCorrected = false;
                    }
                    if (that.$store.state.SelectedMessages.indexOf('LastEventsRegistrations') > -1 && that.$store.state.CapturedUrlsRegIn[0].length === 0) {
                        errorMessage += "Kampaň nemá zadanou žádnou adresu registrací.\n";
                        campaignIsCorrected = false;
                    }
                    if (that.$store.state.SelectedMessages.indexOf('Statistics') > -1 && that.$store.state.CapturedUrlsStatIn[0].length === 0 && that.$store.state.Statistics.SelectedStatsVariant != 'visitor' && that.$store.state.Statistics.SelectedStatsVariant != 'pages') {
                        errorMessage += "Kampaň nemá zadanou žádnou adresu statistik.\n";
                        campaignIsCorrected = false;
                    }
                    if (that.$store.state.SelectedMessages.indexOf('Heureka') > -1 && (that.$store.state.heurekaAPIkey === 'none' || that.$store.state.heurekaAPIkey === '')) {
                        errorMessage += "Kampaň nemá zadaný žádný Api klíč Heureka.cz.\n";
                        campaignIsCorrected = false;
                    }
                    if (that.$store.state.SelectedMessages.indexOf('Zbozi') > -1 && (that.$store.state.zboziAPIkey === 'none' || that.$store.state.zboziAPIkey === '')) {
                        errorMessage += "Kampaň nemá zadaný žádný Api klíč Zboží.cz.\n";
                        campaignIsCorrected = false;
                    }
                    if (that.DomainList.length == 0) {
                        errorMessage += "v databázi neexistuje žádná zachycená doména.\n";
                        campaignIsCorrected = false;
                    }
                    if (that.DomainList.length > 0 && that.selectedDomain != 'none' && that.DomainList.indexOf(that.selectedDomain) == -1) {
                        errorMessage += "Není vybrána žádná existující doména.\n";
                        campaignIsCorrected = false;
                    }

                    if (that.$store.state.SelectedMessages.indexOf('LastEventsOrders') > -1) {
                        that.CapturedUrlsObjIn.forEach(function (ruleUrlsIn, index) {
                            if (ruleUrlsIn.length > 0) {
                                ruleUrlsIn.forEach(function (urlAddressIn) {
                                    if (urlAddressIn != '' && !that.validUrl(urlAddressIn) && that.CaptureRuleObj[index] != 'contains') {
                                        errorMessage += "URL adresa objednávek Zahrnout nemá správný formát.\n";
                                        campaignIsCorrected = false;
                                    }
                                });
                            }

                            if (that.CapturedUrlsObjOut[index].length > 0) {
                                that.CapturedUrlsObjOut[index].forEach(function (urlAddressOut) {
                                    if (urlAddressOut != '' && !that.validUrl(urlAddressOut) && that.CaptureRuleObj[index] != 'contains') {
                                        errorMessage += "URL adresa objednávek Vyloučit nemá správný formát.\n";
                                        campaignIsCorrected = false;
                                    }
                                });
                            }
                        });

                        var ruleUrlsList = [];
                        that.CapturedUrlsObjIn.forEach(function (ruleUrlsIn, index) {
                            if (ruleUrlsIn.length > 0) {
                                ruleUrlsIn.forEach(function (entry) {
                                    var urlAddressIn = parseDomain(entry);
                                    if (urlAddressIn != null) {
                                        if (ruleUrlsList.indexOf(urlAddressIn.domain + '.' + urlAddressIn.tld) == -1 && urlAddressIn.domain != '' && that.CaptureRuleObj[index] != 'contains') { ruleUrlsList.push(urlAddressIn.domain + '.' + urlAddressIn.tld); }
                                        if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                            if ((
                                                (urlAddressIn.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressIn.subdomain + '.' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                || (urlAddressIn.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                || urlAddressIn.domain + '.' + urlAddressIn.tld != ruleUrlsList[0]) && that.CaptureRuleObj[index] != 'contains') {
                                                errorMessage += "V URL adresách objednávek Zahrnout není zadána pouze vybraná doména.\n";
                                                campaignIsCorrected = false;
                                            }
                                        }
                                    }
                                });
                            }

                            if (that.CapturedUrlsObjOut[index].length > 0) {
                                that.CapturedUrlsObjOut[index].forEach(function (entry) {
                                    var urlAddressOut = parseDomain(entry);
                                    if (urlAddressOut != null) {
                                        if (ruleUrlsList.indexOf(urlAddressOut.domain + '.' + urlAddressOut.tld) == -1 && urlAddressOut.domain != '' && that.CaptureRuleObj[index] != 'contains') { ruleUrlsList.push(urlAddressOut.domain + '.' + urlAddressOut.tld); }
                                        if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                            if ((
                                                (urlAddressOut.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressOut.subdomain + '.' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                || (urlAddressOut.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                || urlAddressOut.domain + '.' + urlAddressOut.tld != ruleUrlsList[0]) && that.CaptureRuleObj[index] != 'contains') {
                                                errorMessage += "V URL adresách objednávek Vyloučit není zadána pouze vybraná doména.\n";
                                                campaignIsCorrected = false;
                                            }
                                        }
                                    }
                                });
                            }
                        });
                    }

                    if (that.$store.state.SelectedMessages.indexOf('LastEventsRegistrations') > -1) {
                        that.CapturedUrlsRegIn.forEach(function (ruleUrlsIn, index) {
                            if (ruleUrlsIn.length > 0) {
                                ruleUrlsIn.forEach(function (urlAddressIn) {
                                    if (urlAddressIn != '' && !that.validUrl(urlAddressIn) && that.CaptureRuleReg[index] != 'contains') {
                                        errorMessage += "URL adresa registrací Zahrnout nemá správný formát.\n";
                                        campaignIsCorrected = false;
                                    }
                                });
                            }

                            if (that.CapturedUrlsRegOut[index].length > 0) {
                                that.CapturedUrlsRegOut[index].forEach(function (urlAddressOut) {
                                    if (urlAddressOut != '' && !that.validUrl(urlAddressOut) && that.CaptureRuleReg[index] != 'contains') {
                                        errorMessage += "URL adresa registrací Vyloučit nemá správný formát.\n";
                                        campaignIsCorrected = false;
                                    }
                                });
                            }
                        });

                        ruleUrlsList = [];
                        that.CapturedUrlsRegIn.forEach(function (ruleUrlsIn, index) {
                            if (ruleUrlsIn.length > 0) {
                                ruleUrlsIn.forEach(function (entry) {
                                    var urlAddressIn = parseDomain(entry);
                                    if (urlAddressIn != null) {
                                        if (ruleUrlsList.indexOf(urlAddressIn.domain + '.' + urlAddressIn.tld) == -1 && urlAddressIn.domain != '' && that.CaptureRuleReg[index] != 'contains') { ruleUrlsList.push(urlAddressIn.domain + '.' + urlAddressIn.tld); }
                                        if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                            if ((
                                                (urlAddressIn.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressIn.subdomain + '.' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                || (urlAddressIn.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                || urlAddressIn.domain + '.' + urlAddressIn.tld != ruleUrlsList[0]) && that.CaptureRuleReg[index] != 'contains') {
                                                errorMessage += "V URL adresách registrací Zahrnout není zadána pouze vybraná doména.\n";
                                                campaignIsCorrected = false;
                                            }
                                        }
                                    }
                                });
                            }

                            if (that.CapturedUrlsRegOut[index].length > 0) {
                                that.CapturedUrlsRegOut[index].forEach(function (entry) {
                                    var urlAddressOut = parseDomain(entry);
                                    if (urlAddressOut != null) {
                                        if (ruleUrlsList.indexOf(urlAddressOut.domain + '.' + urlAddressOut.tld) == -1 && urlAddressOut.domain != '' && that.CaptureRuleReg[index] != 'contains') { ruleUrlsList.push(urlAddressOut.domain + '.' + urlAddressOut.tld); }
                                        if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                            if ((
                                                (urlAddressOut.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressOut.subdomain + '.' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                || (urlAddressOut.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                || urlAddressOut.domain + '.' + urlAddressOut.tld != ruleUrlsList[0]) && that.CaptureRuleReg[index] != 'contains') {
                                                errorMessage += "V URL adresách registrací Vyloučit není zadána pouze vybraná doména.\n";
                                                campaignIsCorrected = false;
                                            }
                                        }
                                    }
                                });
                            }
                        });
                    }

                    if (that.$store.state.SelectedMessages.indexOf('Statistics') > -1) {

                        if (that.$store.state.Statistics.SelectedStatsVariant != 'visitor' && that.$store.state.Statistics.SelectedStatsVariant != 'pages') {
                            that.CapturedUrlsStatIn.forEach(function (ruleUrlsIn, index) {
                                if (ruleUrlsIn.length > 0) {
                                    ruleUrlsIn.forEach(function (urlAddressIn) {
                                        if (urlAddressIn != '' && !that.validUrl(urlAddressIn) && that.CaptureRuleStat[index] != 'contains') {
                                            errorMessage += "URL adresa statistik Zahrnout nemá správný formát.\n";
                                            campaignIsCorrected = false;
                                        }
                                    });
                                }

                                if (that.CapturedUrlsStatOut[index].length > 0) {
                                    that.CapturedUrlsStatOut[index].forEach(function (urlAddressOut) {
                                        if (urlAddressOut != '' && !that.validUrl(urlAddressOut) && that.CaptureRuleStat[index] != 'contains') {
                                            errorMessage += "URL adresa statistik Vyloučit nemá správný formát.\n";
                                            campaignIsCorrected = false;
                                        }
                                    });
                                }
                            });

                            ruleUrlsList = [];
                            that.CapturedUrlsStatIn.forEach(function (ruleUrlsIn, index) {
                                if (ruleUrlsIn.length > 0) {
                                    ruleUrlsIn.forEach(function (entry) {
                                        var urlAddressIn = parseDomain(entry);
                                        if (urlAddressIn != null) {
                                            if (ruleUrlsList.indexOf(urlAddressIn.domain + '.' + urlAddressIn.tld) == -1 && urlAddressIn.domain != '' && that.CaptureRuleStat[index] != 'contains') { ruleUrlsList.push(urlAddressIn.domain + '.' + urlAddressIn.tld); }
                                            if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                                if ((
                                                    (urlAddressIn.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressIn.subdomain + '.' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                    || (urlAddressIn.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressIn.domain + '.' + urlAddressIn.tld).indexOf(that.selectedDomain) == -1)
                                                    || urlAddressIn.domain + '.' + urlAddressIn.tld != ruleUrlsList[0]) && that.CaptureRuleStat[index] != 'contains') {
                                                    errorMessage += "V URL adresách statistik Zahrnout není zadána pouze vybraná doména.\n";
                                                    campaignIsCorrected = false;
                                                }
                                            }
                                        }
                                    });
                                }

                                if (that.CapturedUrlsStatOut[index].length > 0) {
                                    that.CapturedUrlsStatOut[index].forEach(function (entry) {
                                        var urlAddressOut = parseDomain(entry);
                                        if (urlAddressOut != null) {
                                            if (ruleUrlsList.indexOf(urlAddressOut.domain + '.' + urlAddressOut.tld) == -1 && urlAddressOut.domain != '' && that.CaptureRuleStat[index] != 'contains') { ruleUrlsList.push(urlAddressOut.domain + '.' + urlAddressOut.tld); }
                                            if (ruleUrlsList.length > 0 && !that.ignoreDomain) {
                                                if ((
                                                    (urlAddressOut.subdomain != '' && (parseUrl(entry).protocol + '://' + urlAddressOut.subdomain + '.' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                    || (urlAddressOut.subdomain == '' && (parseUrl(entry).protocol + '://' + urlAddressOut.domain + '.' + urlAddressOut.tld).indexOf(that.selectedDomain) == -1)
                                                    || urlAddressOut.domain + '.' + urlAddressOut.tld != ruleUrlsList[0]) && that.CaptureRuleStat[index] != 'contains') {
                                                    errorMessage += "V URL adresách statistik Vyloučit není zadána pouze vybraná doména.\n";
                                                    campaignIsCorrected = false;
                                                }
                                            }
                                        }
                                    });
                                }
                            });
                        } else {
                            that.$store.state.CaptureRuleStat = ['none'];
                            that.$store.state.CapturedUrlsStatIn = [[]];
                            that.$store.state.CapturedUrlsStatOut = [[]];
                        }
                    }

                    that.ShownUrlsIn.forEach(function (ruleUrlsIn, index) {
                        if (ruleUrlsIn.length > 0) {
                            ruleUrlsIn.forEach(function (urlAddressIn) {
                                if (urlAddressIn != '' && !that.validUrl(urlAddressIn) && that.ShownRule[index] != 'contains') {
                                    errorMessage += "URL adresa zobrazení Zahrnout nemá správný formát.\n";
                                    campaignIsCorrected = false;
                                }
                            });
                        }

                        if (that.ShownUrlsOut[index].length > 0) {
                            that.ShownUrlsOut[index].forEach(function (urlAddressOut) {
                                if (urlAddressOut != '' && !that.validUrl(urlAddressOut) && that.ShownRule[index] != 'contains') {
                                    errorMessage += "URL adresa zobrazení Vyloučit nemá správný formát.\n";
                                    campaignIsCorrected = false;
                                }
                            });
                        }
                    });

                    ruleUrlsList = [];
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
                                            errorMessage += "V URL adresách zobrazení Zahrnout není zadána pouze vybraná doména.\n";
                                            campaignIsCorrected = false;
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
                                            errorMessage += "V URL adresách zobrazení Vyloučit není zadána pouze vybraná doména.\n";
                                            campaignIsCorrected = false;
                                        }
                                    }
                                }
                            });
                        }
                    });

                    if (!campaignIsCorrected) {
                        that.nextStepAllowedCheck = false;
                        const options = { title: 'Info', size: 'sm' }
                        this.$dialogs.alert('Kampaň není správně nastavena.\n Seznam chyb:\n\n ' + errorMessage, options)
                            .then(res => {
                            });
                    }
                }
            }
        },
        watch: {
            CampaignName() {
                this.validateForm();
            },
        },
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            if (that.$store.state.CampaignData.campaignID != undefined) {
                that.ActiveCampaign = that.$store.state.CampaignData.ActiveCampaign;
                that.HiddenAppiOnMobile = that.$store.state.CampaignData.CampaignAdaptation.HiddenAppiOnMobile;
                that.ShowUpOnMobile = that.$store.state.CampaignData.CampaignAdaptation.ShowUpOnMobile;
                that.HiddenAppiOnComputer = that.$store.state.CampaignData.CampaignAdaptation.HiddenAppiOnComputer;
                that.ShowUpOnComputer = that.$store.state.CampaignData.CampaignAdaptation.ShowUpOnComputer;

                that.AppiPosition = that.$store.state.CampaignData.CampaignAdaptation.AppiPosition;
                that.AppiPositionOnMobile = that.$store.state.CampaignData.CampaignAdaptation.AppiPositionOnMobile;
                that.AppiPositionCenter = that.$store.state.CampaignData.CampaignAdaptation.AppiPositionCenter;
                that.AppiPositionOnMobileCenter = that.$store.state.CampaignData.CampaignAdaptation.AppiPositionOnMobileCenter;

                that.PcDelayBeforeFirstAppi = that.$store.state.CampaignData.CampaignAdaptation.PcDelayBeforeFirstAppi;
                that.PcAppiShowTime = that.$store.state.CampaignData.CampaignAdaptation.PcAppiShowTime;
                that.PcDelayBetweenAppi = that.$store.state.CampaignData.CampaignAdaptation.PcDelayBetweenAppi;
                that.MobDelayBeforeFirstAppi = that.$store.state.CampaignData.CampaignAdaptation.MobDelayBeforeFirstAppi;
                that.MobAppiShowTime = that.$store.state.CampaignData.CampaignAdaptation.MobAppiShowTime;
                that.MobDelayBetweenAppi = that.$store.state.CampaignData.CampaignAdaptation.MobDelayBetweenAppi;

                that.PcSpeedAppi = that.$store.state.CampaignData.CampaignAdaptation.PcSpeedAppi;
                that.MobSpeedAppi = that.$store.state.CampaignData.CampaignAdaptation.MobSpeedAppi;

                that.$store.state.CampaignAdaptation = that.$store.state.CampaignData.CampaignAdaptation;

                that.SelectedMessages = that.$store.state.CampaignData.SelectedMessages;
                that.CampaignName = that.$store.state.CampaignData.CampaignName;
                that.selectedCampaignName = that.$store.state.CampaignData.CampaignName;

                this.validateForm();
            } else {
                this.validateForm();
            }

            //$.ajax({
            //    type: "POST",
            //    url: "https://appi.app.cz:444/get_domains",
            //    dataType: "json",
            //    contentType: 'application/json; charset=utf-8',
            //    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            //}).done(function (dataDomains) {
            //    if (dataDomains.domains != undefined && dataDomains.domains.length > 0) {
            //        dataDomains.domains.forEach(function (domain) {
            //            if (that.DomainList.indexOf(domain.domain) === -1 && domain.domain != "" && domain.domain.indexOf('file://') == -1 && domain.domain.indexOf('content://') == -1 && domain.domain.indexOf('about:blank') == -1) {
            //                that.DomainList.push(domain.domain);
            //            }
            //        });
            //    }
            //});
            
		}
    }
</script>