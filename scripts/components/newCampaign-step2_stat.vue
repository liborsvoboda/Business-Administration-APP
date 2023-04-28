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

                            <li v-if="SelectedMessages.indexOf('Statistics') > -1" class="align-items-center pl-3 pr-3" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/statistics.svg" class="svg_img_60" style="margin-right:10px;cursor:default;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title statistic_color">Souhrnné statistiky</span>
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

                            <li v-if="SelectedMessages.indexOf('Zbozi') > -1" v-on:click="(nextStepAllowed2) ? goToSelected('Zbozi'): setCorrectForm()" v-bind:class="{ 'cursor_default': (zboziAPIkey === 'none' || CampaignName.length === 0) }" class="align-items-center pl-3 pr-3 list_group_button" style="display: inline-flex;background-color: transparent">
                                <span>
                                    <img src="/images/product/zbozi_grey.svg" v-on:click="(nextStepAllowed2) ? goToSelected('Zbozi'): setCorrectForm()" v-bind:class="{ 'cursor_default': (zboziAPIkey === 'none' || CampaignName.length === 0) }" class="svg_img_60 list_group_button" style="margin-right:10px;width: 70px;" />
                                </span>
                                <span class="with_100_points" style="vertical-align: top;">
                                    <div class="" style="vertical-align: top;font-weight: bold;">
                                        <span class="sub_title wizard_step_desc">Recenze Zboží.cz</span>
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
                                    <div class="list-group-item group_item_yellow">
                                        <div class="new_campaign_tile_group_item statistic_color d-flex align-items-center">
                                            <span v-if="SelectedStatsVariant !='visitor' && SelectedStatsVariant !='pages'" class="width_100">Zadejte URL pro Souhrnné statistiky</span>
                                            <span v-if="SelectedStatsVariant =='visitor' || SelectedStatsVariant =='pages'" class="width_100">URL pro Souhrnné statistiky</span>
                                            <span class="right d-flex align-items-center" v-if="SelectedStatsVariant !='visitor' && SelectedStatsVariant !='pages'">
                                                <button class="btn btn-outline-secondary_stat fas fa-copy copyPaste" style="padding: 0.2rem 0.5rem;" v-on:click="copyToClipboard" title="Zkopírovat pravidla z této stránky" alt="Zkopírovat pravidla z této stránky"> </button>
                                                <button class="btn btn-outline-secondary_stat fas fa-paste copyPaste" style="padding: 0.2rem 0.5rem;" v-on:click="pasteFromClipboard" title="Vložit zkopírovaná pravidla" alt="Vložit zkopírovaná pravidla" :disabled="!pasteEnable"> </button>
                                            </span>
                                        </div>
                                    </div>

                                    <div class="list-group-item" v-for="rule,index in CaptureRuleStat" v-if="SelectedStatsVariant !='visitor' && SelectedStatsVariant !='pages'">
                                        <p v-if="index == 0">
                                        <p v-if="SelectedStatsVariant =='registration'">
                                            Do pole „Zahrnout“ vložte celou nebo částečnou URL adresu s registračním formulářem.
                                            <br />Každou URL potvrďte tlačítkem *Enter*.
                                        </p>
                                        <p v-if="SelectedStatsVariant =='order'">
                                            Do pole „Zahrnout“ vložte celou nebo částečnou URL adresu s objednávkovým formulářem.
                                            <br />Každou URL potvrďte tlačítkem *Enter*.
                                        </p>
                                        </p>

                                        <div class="align-items-center pb-4 pt-3" style="display: flex;">
                                            <span class="d-flex width_100 align-items-center">
                                                <span class="width_70px">URL </span>
                                                <select v-model="CaptureRuleStat[index]" style="max-width: 240px;" v-on:change="validateForm()" v-bind:name="CaptureRuleStat[index]" v-validate="{required: true}" class="form-control" v-bind:class="{ 'is-invalid': errors.has('CaptureRuleStat['+index+']') }">
                                                    <option disabled="" value="none">Vyberte</option>
                                                    <option value="startWith" :hidden="CaptureRuleStat.indexOf('startWith') > -1 && CaptureRuleStat.indexOf('startWith') != index">Začíná na</option>
                                                    <option value="exactmatch" :hidden="CaptureRuleStat.indexOf('exactmatch') > -1 && CaptureRuleStat.indexOf('exactmatch') != index">Shoduje se</option>
                                                    <option value="contains" :hidden="CaptureRuleStat.indexOf('contains') > -1 && CaptureRuleStat.indexOf('contains') != index">Obsahuje</option>
                                                </select>
                                                <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                                   v-tooltip.top="{ content: 'Začíná na = zadejte jen začátek URL a začleňte tím všechny další znaky nebo parametry vypsané v URL (např. strom podstránek).\n\nShoduje se = vložte přesnou URL stránky nebo podstránky (ideálně zkopírováním z URL řádku v prohlížeči).\n\nObsahuje = vložte slovo nebo řetězec obsažený v URL (např. kosik, lcd-televizory).' }"></i>
                                            </span>
                                            <span class="right d-flex align-items-center" style="font-family: inherit;font-weight: 500;line-height: 1.2;color: inherit;" v-if="index > 0">
                                                <span class="fas fa-trash btn btn-outline-secondary_remove copyPaste" style="cursor:pointer" title="odstranit" alt="odstranit" v-on:click="removeRule(index)"> </span>
                                            </span>
                                        </div>

                                        <div class="d-flex">
                                            <span class="width_70px">Zahrnout </span>
                                            <tags-input :selectedRule="CaptureRuleStat[index]" v-bind:element-id="'tagsCapturedUrlsStatIn'+index" v-on:input="validateForm()" v-bind:ref="'tagsCapturedUrlsStatIn'+index" v-model="CapturedUrlsStatIn[index]" :allow-duplicates="false" placeholder="" v-bind:name="CapturedUrlsStatIn[index]" v-validate="{ required: false,url:require_protocol}" class="form-control" v-bind:class="{ 'is-invalid': errors.has('CapturedUrlsStatIn['+index+']') }" style="display: inline-table;table-layout: fixed;width: calc(100% - 70px);"></tags-input>
                                        </div>

                                        <div class="d-flex">
                                            <span class="width_70px">Vyloučit </span>
                                            <tags-input :selectedRule="CaptureRuleStat[index]" v-bind:element-id="'tagsCapturedUrlsStatOut'+index" v-on:input="validateForm()" v-bind:ref="'tagsCapturedUrlsStatOut'+index" v-model="CapturedUrlsStatOut[index]" :allow-duplicates="false" placeholder="" v-bind:name="CapturedUrlsStatOut[index]" v-validate="{ required: false,url:require_protocol}" class="form-control" v-bind:class="{ 'is-invalid': errors.has('CapturedUrlsStatOut['+index+']') }" style="display: inline-table;table-layout: fixed;width: calc(100% - 70px);"></tags-input>
                                        </div>
                                        <span v-if="errors.has('CapturedUrlsStatIn['+index+']') || errors.has('CapturedUrlsStatOut['+index+']') " class="d-flex invalid-feedback pl_70px">{{ errors.first('CapturedUrlsStatIn['+index+']') }} {{ errors.first('CapturedUrlsStatOut['+index+']') }}</span>
                                        <!--<span style="padding-top: 10px;display: block;padding-bottom: 10px;overflow-wrap: break-word;">{{CapturedUrlsStatIn[rule]}}</span>-->

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

                                    <div class="list-group-item pt-4 pb-4" v-if="SelectedStatsVariant !='visitor' && SelectedStatsVariant !='pages'">
                                        <button class="btn btn-outline-secondary" v-on:click="addRule" :disabled="(!nextStepAllowed2 || CaptureRuleStat.length ==3)"><i class="fas fa-plus"></i>Přidat pravidlo</button>
                                    </div>

                                    <div class="list-group-item" v-if="SelectedStatsVariant =='visitor' || SelectedStatsVariant =='pages'">
                                        <div class="align-items-center pb-4 pt-3 d-flex" v-if="(selectedStatVisitorsDomain && SelectedStatsVariant =='visitor')">
                                            <span class="bold " style="width:150px;color:inherit">Pravidlo párování: </span>
                                            <input type="text" value="Souhrny návštěvníků celé domény" disabled="disabled" name="CampaignName" class="form-control" style="width: 300px;max-width: 300px;" />
                                        </div>
                                        <div class="align-items-center pb-4 pt-3 d-flex" v-if="(!selectedStatVisitorsDomain && SelectedStatsVariant =='visitor')">
                                            <span class="bold" style="width:150px;color:inherit">Pravidlo párování: </span>
                                            <input type="text" value="Souhrny návštěvníků jednotlivých stránek" disabled="disabled" name="CampaignName" class="form-control" style="width: 300px;max-width: 300px;" />
                                        </div>
                                        <div class="align-items-center pb-4 pt-3 d-flex" v-if="(selectedStatVisitorsDomain && SelectedStatsVariant =='pages')">
                                            <span class="bold " style="width:150px;color:inherit">Pravidlo párování: </span>
                                            <input type="text" value="Souhrny zobrazení stránek celé domény" disabled="disabled" name="CampaignName" class="form-control" style="width: 300px;max-width: 300px;" />
                                        </div>
                                        <div class="align-items-center pb-4 pt-3 d-flex" v-if="(!selectedStatVisitorsDomain && SelectedStatsVariant =='pages')">
                                            <span class="bold" style="width:150px;color:inherit">Pravidlo párování: </span>
                                            <input type="text" value="Souhrny zobrazení jednotlivých stránek" disabled="disabled" name="CampaignName" class="form-control" style="width: 300px;max-width: 300px;" />
                                        </div>

                                        <div class="align-items-center d-flex">
                                            <span class="bold " style="width:150px;color:inherit">Vybraná doména: </span>
                                            <tags-input v-bind:element-id="selectedDomain" v-bind:ref="selectedDomain" v-model="selectedDomain" :hiddenRemove="true" :disabled="true" :allow-duplicates="false" placeholder="" v-bind:name="selectedDomain" class="form-control" style="display: inline-table;table-layout: fixed;width: calc(100% - 150px);"></tags-input>
                                        </div>

                                        <p class="mb-0 pt-5" v-if="(selectedStatVisitorsDomain && SelectedStatsVariant =='visitor')">Kampaň bude zachytávat souhrny návštěvníků z celého webu.</p>
                                        <p class="mb-0 pt-5" v-if="(!selectedStatVisitorsDomain && SelectedStatsVariant =='visitor')">Kampaň bude zachytávat souhrny návštěvníků každé stránky samostatně.</p>
                                        <p class="mb-0 pt-5" v-if="(selectedStatVisitorsDomain && SelectedStatsVariant =='pages')">Kampaň bude zachytávat souhrny zobrazení stránek z celého webu.</p>
                                        <p class="mb-0 pt-5" v-if="(!selectedStatVisitorsDomain && SelectedStatsVariant =='pages')">Kampaň bude zachytávat souhrny zobrazení každé stránky samostatně.</p>
                                        <p>Pro změnu pravidla se vraťte do kroku 1 - Detailní nastavení.</p>
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
                            <button class="btn btn-main-primary btn_new btn_new_campaign" :disabled="!nextStepAllowed2 && SelectedStatsVariant !='visitor' && SelectedStatsVariant !='pages'" v-on:click="NextStep">
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

    import TagsInput from "../plugin/VoerroTagsInput.vue";
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';
    import VeeValidate from 'vee-validate';
    import VueI18n from 'vue-i18n';
    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

    Vue.use(VueI18n);
    Vue.use(VueCookie);

    const parseDomain = require("parse-domain");
    const parseUrl = require("parse-url");
    //    console.log(parseUrl("http://domain.com/path/name?foo=bar&bar=42#some-hash"))
    // { protocols: [ 'http' ],
    //   protocol: 'http',
    //   port: null,
    //   resource: 'domain.com',
    //   user: '',
    //   pathname: '/path/name',
    //   hash: 'some-hash',
    //   search: 'foo=bar&bar=42',
    //   href: 'http://domain.com/path/name?foo=bar&bar=42#some-hash' }


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
                nextStepAllowed2: false,
                Component: '',
                CaptureRuleStat: this.$store.state.CaptureRuleStat,
                CapturedUrlsStatIn: this.$store.state.CapturedUrlsStatIn,
                CapturedUrlsStatOut: this.$store.state.CapturedUrlsStatOut,
                CampaignName: this.$store.state.CampaignName,
                selectedDomain: this.$store.state.selectedDomain,
                selectedLanguage: this.$store.state.selectedLanguage,
                DomainList: [],
                SelectedStatsVariant: this.$store.state.Statistics.SelectedStatsVariant,
                selectedStatVisitorsDomain: this.$store.state.Statistics.ShowStatsDomainVisitCount,

                SelectedMessages: [],
                validatingEnabled: true,
                pasteEnable: (this.$store.state.clipBoardRules.length > 0) ? true : false,
                ignoreDomain: this.$store.state.ignoreDomain,

                CaptureRuleObj: this.$store.state.CaptureRuleObj,
                CapturedUrlsObjIn: this.$store.state.CapturedUrlsObjIn,
                CapturedUrlsObjOut: this.$store.state.CapturedUrlsObjOut,
                CaptureRuleReg: this.$store.state.CaptureRuleReg,
                CapturedUrlsRegIn: this.$store.state.CapturedUrlsRegIn,
                CapturedUrlsRegOut: this.$store.state.CapturedUrlsRegOut,
                ShownRule: this.$store.state.ShownRule,
                ShownUrlsIn: this.$store.state.ShownUrlsIn,
                ShownUrlsOut: this.$store.state.ShownUrlsOut,
                heurekaAPIkey: this.$store.state.heurekaAPIkey,
                zboziAPIkey: this.$store.state.zboziAPIkey,
                ownAppi: this.$store.state.OwnAppi,

            }
        },
        activated() {
            var that = this;
            if (that.$store.state.CampaignData.campaignID != undefined) {
                that.SelectedStatsVariant = that.$store.state.Statistics.SelectedStatsVariant;
                that.selectedStatVisitorsDomain = (that.$store.state.Statistics.SelectedStatsVariant == 'visitor' || that.$store.state.Statistics.SelectedStatsVariant == 'pages') ? that.$store.state.Statistics.ShowStatsDomainVisitCount : (that.$store.state.CampaignData.Statistics.SelectedStatsVariant == 'visitor' || that.$store.state.CampaignData.Statistics.SelectedStatsVariant == 'pages') ? that.$store.state.CampaignData.Statistics.ShowStatsDomainVisitCount : false;
                if (that.SelectedMessages == '') { that.SelectedMessages = (that.$store.state.SelectedMessages != '') ? that.$store.state.SelectedMessages : that.$store.state.CampaignData.SelectedMessages; }
                that.CaptureRuleStat = (that.$store.state.CaptureRuleStat[0] != 'none' || that.$store.state.CampaignData.CaptureRuleStat[0] == undefined) ? JSON.parse(JSON.stringify(that.$store.state.CaptureRuleStat)) : JSON.parse(JSON.stringify(that.$store.state.CampaignData.CaptureRuleStat)); 
                that.CapturedUrlsStatIn = (that.$store.state.CaptureRuleStat[0] != 'none' || that.$store.state.CampaignData.CaptureRuleStat[0] == undefined) ? JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatIn)) : JSON.parse(JSON.stringify(that.$store.state.CampaignData.CapturedUrlsStatIn).replace(/""/g, '[]')); 
                that.CapturedUrlsStatOut = (that.$store.state.CaptureRuleStat[0] != 'none' || that.$store.state.CampaignData.CaptureRuleStat[0] == undefined) ? JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatOut)) : JSON.parse(JSON.stringify(that.$store.state.CampaignData.CapturedUrlsStatOut).replace(/""/g, '[]')); 
            } else {
                that.SelectedStatsVariant = that.$store.state.Statistics.SelectedStatsVariant;
                that.selectedStatVisitorsDomain = (that.$store.state.Statistics.SelectedStatsVariant == 'visitor' || that.$store.state.Statistics.SelectedStatsVariant == 'pages') ? that.$store.state.Statistics.ShowStatsDomainVisitCount : false;
                if (that.SelectedMessages == '') { that.SelectedMessages = that.$store.state.SelectedMessages; }
                that.CaptureRuleStat = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleStat));
                that.CapturedUrlsStatIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatIn));
                that.CapturedUrlsStatOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsStatOut));
            }

            that.CaptureRuleObj = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleObj));
            that.CapturedUrlsObjIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsObjIn));
            that.CapturedUrlsObjOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsObjOut)); 
            that.CaptureRuleReg = JSON.parse(JSON.stringify(that.$store.state.CaptureRuleReg));
            that.CapturedUrlsRegIn = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsRegIn));
            that.CapturedUrlsRegOut = JSON.parse(JSON.stringify(that.$store.state.CapturedUrlsRegOut));
            that.ShownRule = JSON.parse(JSON.stringify(that.$store.state.ShownRule));
            that.ShownUrlsIn = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsIn));
            that.ShownUrlsOut = JSON.parse(JSON.stringify(that.$store.state.ShownUrlsOut));
            that.heurekaAPIkey = that.$store.state.heurekaAPIkey;
            that.zboziAPIkey = that.$store.state.zboziAPIkey;
            that.ownAppi = that.$store.state.OwnAppi;

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
            goToStep(value) {
                this.$store.state.CaptureRuleStat = JSON.parse(JSON.stringify(this.CaptureRuleStat));
                this.$store.state.CapturedUrlsStatIn = JSON.parse(JSON.stringify(this.CapturedUrlsStatIn));
                this.$store.state.CapturedUrlsStatOut = JSON.parse(JSON.stringify(this.CapturedUrlsStatOut));

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
                this.$store.state.clipBoardRules = JSON.parse(JSON.stringify(this.CaptureRuleStat));
                this.$store.state.clipBoardUrlsIn = JSON.parse(JSON.stringify(this.CapturedUrlsStatIn));
                this.$store.state.clipBoardUrlsOut = JSON.parse(JSON.stringify(this.CapturedUrlsStatOut));
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
                            this.CaptureRuleStat = JSON.parse(JSON.stringify(this.$store.state.clipBoardRules));
                            this.CapturedUrlsStatIn = JSON.parse(JSON.stringify(this.$store.state.clipBoardUrlsIn));
                            this.CapturedUrlsStatOut = JSON.parse(JSON.stringify(this.$store.state.clipBoardUrlsOut));
                            this.validatingEnabled = true;
                            this.validateForm();
                        }
                    });
            },
            setCorrectForm() {
                if (this.CampaignName.length > 0) {
                    const options = { title: 'Info', size: 'sm' }
                    this.$dialogs.alert('Nejdříve vyplňte správně formulář.', options)
                        .then(res => {
                        });
                }
            },
            addRule() {
                this.validatingEnabled = false;
                this.CaptureRuleStat.push('none');
                this.CapturedUrlsStatIn.push([]);
                this.CapturedUrlsStatOut.push([]);
                this.validatingEnabled = true;
                this.validateForm();
            },
            removeRule(value) {
                this.validatingEnabled = false;
                this.CaptureRuleStat.splice(value, 1);
                this.CapturedUrlsStatIn.splice(value, 1);
                this.CapturedUrlsStatOut.splice(value, 1);
                this.validatingEnabled = true;
                this.validateForm();
            },
            goToSelected(value) {
                this.$store.state.CaptureRuleStat = JSON.parse(JSON.stringify(this.CaptureRuleStat));
                this.$store.state.CapturedUrlsStatIn = JSON.parse(JSON.stringify(this.CapturedUrlsStatIn));
                this.$store.state.CapturedUrlsStatOut = JSON.parse(JSON.stringify(this.CapturedUrlsStatOut));

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
                this.$store.state.CaptureRuleStat = JSON.parse(JSON.stringify(this.CaptureRuleStat));
                this.$store.state.CapturedUrlsStatIn = JSON.parse(JSON.stringify(this.CapturedUrlsStatIn));
                this.$store.state.CapturedUrlsStatOut = JSON.parse(JSON.stringify(this.CapturedUrlsStatOut));

                //změna dynamické komponenty
                if (this.SelectedMessages.indexOf('Heureka') > -1) {
                    this.Component = "app-new-campaign-Step2_rev";
                } else if (this.SelectedMessages.indexOf('Zbozi') > -1) {
                    this.Component = "app-new-campaign-Step2_zbozi";
                } else if (this.SelectedMessages.indexOf('OwnAppi') > -1) {
                    this.Component = "app-new-campaign-Step2_ownAppi";
                } else {
                    this.Component = "app-new-campaign-Step3";
                }
                this.$emit("changeComponent", this.Component);
            },

            PreviousStep() {
                //uloží vybrané URL do globální state
                this.$store.state.CaptureRuleStat = JSON.parse(JSON.stringify(this.CaptureRuleStat));
                this.$store.state.CapturedUrlsStatIn = JSON.parse(JSON.stringify(this.CapturedUrlsStatIn));
                this.$store.state.CapturedUrlsStatOut = JSON.parse(JSON.stringify(this.CapturedUrlsStatOut));

                //změna dynamické komponenty
                if (this.SelectedMessages.indexOf('VisitCount') > -1) {
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
                this.nextStepAllowed2 = true;
                this.errors.clear();
                var that = this;

                this.$validator.validateAll({
                    CapturedUrlsStatIn: this.CapturedUrlsStatIn,
                    CaptureRuleStat: this.CaptureRuleStat
                }).then((valid) => {
                    if (this.validatingEnabled) {
                        if (valid) {

                            that.CaptureRuleStat.forEach(function (rule, index) {
                                if (rule == 'none') {
                                    that.errors.add({ field: 'CaptureRuleStat[' + index + ']', msg: 'Vyberte variantu' });
                                    that.nextStepAllowed2 = false;
                                }
                            });

                            //check minimum 1 url in next rules
                            that.CapturedUrlsStatIn.forEach(function (ruleUrlsIn, index) {
                                var checkInsertedMinimumUrl = [];
                                if (index > 0) {
                                    if (ruleUrlsIn.length > 0) {
                                        ruleUrlsIn.forEach(function (urlAddressIn) {
                                            if (checkInsertedMinimumUrl.indexOf(urlAddressIn) == -1 && urlAddressIn != '') { checkInsertedMinimumUrl.push(urlAddressIn); }
                                        });
                                    }

                                    if (that.CapturedUrlsStatOut[index].length > 0) {
                                        that.CapturedUrlsStatOut[index].forEach(function (urlAddressOut) {
                                            if (checkInsertedMinimumUrl.indexOf(urlAddressOut) == -1 && urlAddressOut != '') { checkInsertedMinimumUrl.push(urlAddressOut); }
                                        });
                                    }

                                    if (checkInsertedMinimumUrl.length == 0) {
                                        that.errors.add({ field: 'CapturedUrlsStatIn[' + index + ']', msg: 'Musí být zadána minimálně 1 URL.' });
                                        that.errors.add({ field: 'CapturedUrlsStatOut[' + index + ']', msg: ' ' });
                                        that.nextStepAllowed2 = false;
                                    }
                                }
                            });

                            //check minimum 1 url in first rule
                            if (that.CapturedUrlsStatIn[0].length == 0) {
                                that.errors.add({ field: 'CapturedUrlsStatIn[0]', msg: 'Není zadaná žádná zahrnutá URL.' });
                                that.nextStepAllowed2 = false;
                            }

                            //check if domain inserted only in fulldomain mode in stat bubble
                            if (that.CapturedUrlsStatIn.length > 0) {
                                if (that.selectedStatVisitorsDomain && that.SelectedMessages.indexOf("Statistics") > -1) {
                                    if (that.CapturedUrlsStatIn[0] != '') { 
                                        that.CapturedUrlsStatIn[0].forEach(function (entry) {
                                            var urlArray = parseUrl(entry, true);
                                            if (urlArray.pathname != "" || urlArray.search != "") {
                                                that.errors.add({ field: 'CapturedUrlsStatIn[0]', msg: 'Zadaná URL není pouze název domény.' });
                                                that.nextStepAllowed2 = false;
                                            }
                                        });
                                    }
                                }
                            }

                            //check valid url format !validUrl(urlAddressOut)
                            that.CapturedUrlsStatIn.forEach(function (ruleUrlsIn, index) {
                                if (ruleUrlsIn.length > 0) {
                                    ruleUrlsIn.forEach(function (urlAddressIn) {
                                        if (urlAddressIn != '' && !that.validUrl(urlAddressIn) && that.CaptureRuleStat[index] != 'contains') {
                                            that.errors.add({ field: 'CapturedUrlsStatIn[' + index + ']', msg: 'URL adresa nemá správný formát.' });
                                            that.nextStepAllowed2 = false;
                                        }
                                    });
                                }

                                if (that.CapturedUrlsStatOut[index].length > 0) {
                                    that.CapturedUrlsStatOut[index].forEach(function (urlAddressOut) {
                                        if (urlAddressOut != '' && !that.validUrl(urlAddressOut) && that.CaptureRuleStat[index] != 'contains') {
                                            that.errors.add({ field: 'CapturedUrlsStatOut[' + index + ']', msg: 'URL adresa nemá správný formát.' });
                                            that.nextStepAllowed2 = false;
                                        }
                                    });
                                }
                            });

                            //check if only 1 domain inserted
                            //Stat
                            var ruleUrlsList = [];
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
                                                    that.errors.add({ field: 'CapturedUrlsStatIn[' + index + ']', msg: 'V Kampani může být nastavena jen jedna doména: ' + that.selectedDomain });
                                                    that.nextStepAllowed2 = false;
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
                                                    that.errors.add({ field: 'CapturedUrlsStatOut[' + index + ']', msg: 'V Kampani může být nastavena jen jedna doména: ' + that.selectedDomain });
                                                    that.nextStepAllowed2 = false;
                                                }
                                            }
                                        }
                                    });
                                }
                            });

                        } else {
                            //console.log("not valid");
                            that.nextStepAllowed2 = false;
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