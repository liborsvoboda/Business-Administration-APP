<template>
    <div v-show="authUser=='true'">
        <div class="container-fluid new_campaign_container text-center">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="new_campaign_h3" v-if="selectedAbTestName == null">Nový A/B test</h3>
                        <h3 class="new_campaign_h3" v-else-if=" dataExists > 0 ">Náhled nastavení A/B testu: {{selectedAbTestName}}</h3>
                        <h3 class="new_campaign_h3" v-else-if="selectedAbTestName != null && dataExists == 0 ">Editace A/B testu: {{selectedAbTestName}}</h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="container text-center new_campaign_container_wrap">
            <div class="row justify-content-center pt-4">
                <div class="col-md-12">
                    <h3 class="new_campaign_h3_2 py-4 pb-4" v-if=" dataExists > 0 ">Náhled nastavení A/B testu</h3>
                    <h3 class="new_campaign_h3_2 py-4 pb-4" v-else-if=" dataExists == 0 ">Vytvořte si nový A/B test</h3>

                    <div class="row justify-content-md-center">
                        <div class="col-md-8 list-group mt-2 pl-3">
                            <div class="list-group-item pt-4 pb-4">
                                <div class="row align-items-center">
                                    <div class="col-md-4 py-2 text-left">
                                        Pojmenujte A/B test
                                    </div>
                                    <div class="col-md-6 py-2">
                                        <input type="text" placeholder="Název" :disabled="( dataExists > 0)" v-model="name" name="name" v-on:input="validateForm()" class="form-control py-2" :class="{ 'is-invalid': errors.has('name') }" />
                                        <span v-if="errors.has('name')" class="text-left invalid-feedback">{{ errors.first('name') }}</span>
                                    </div>
                                </div>
                                <div class="row align-items-center">
                                    <div class="col-md-4 py-2 text-left">
                                        Vyberte doménu
                                    </div>
                                    <div class="col-md-6 py-2">
                                        <select v-model="selectedDomain" :disabled="( dataExists > 0)" style="" name="selectedDomain" v-on:change="validateForm()" class="form-control" :class="{ 'is-invalid': errors.has('selectedDomain') }">
                                            <option disabled="" value="">Vyberte doménu</option>
                                            <option v-for="domain in DomainList" v-bind:value="domain">
                                                {{domain}}
                                            </option>
                                        </select>
                                        <span v-if="errors.has('selectedDomain')" class="text-left invalid-feedback">{{ errors.first('selectedDomain') }}</span>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row justify-content-center pt-4">
                        <div class="list-group mt-2 pl-3 col-md-8">
                            <h2 class="list-group-item group_item_blue bold py-3 d-flex ">
                                Vytvořte varianty A/B testu
                            </h2>

                            <div class="list-group-item" v-for="cmp,index in selectedCampaignIds">
                                <p class="d-flex text-left" v-if="index == 0">
                                    Vyberte 2 až 4 kampaně pro testování na vybraném webu.
                                    <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                       v-tooltip.top="{ content: 'Můžete testovat variantu bez notifikací nebo různé nastavení kampaní proti sobě.' }"></i>
                                </p>
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-3 py-2 text-left">
                                        Varianta {{index+1}}
                                        <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Neaktivní kampaň bude po spuštění A/B testu automaticky aktivována a po ukončení opět zastavena.' }"></i>
                                        <span class="align-items-center ml-2" style="font-family: inherit;font-weight: 500;line-height: 1.2;color: inherit;" v-if="index > 1">
                                            <button class="fas fa-trash btn-outline-third copyPaste" style="padding: 0.2rem 0.5rem;cursor: pointer;" title="Odstranit kampaň z testu" alt="Odstranit kampaň z testu" :disabled="(selectedCampaignIds.length <=2 || dataExists > 0)" v-on:click="(selectedCampaignIds.length >2)?[selectedCampaignIds.splice(index,1),campaignRatio.splice(index,1)]:'';validateForm();"> </button>
                                        </span>
                                    </div>
                                    <div class="col-md-4 py-2">
                                        <div class="row align-items-center">
                                            <select v-model="selectedCampaignIds[index]" :disabled="(dataExists > 0)" style="max-width: 240px;" name="selectedCampaignIds" v-on:change="validateForm()" class="form-control ml-3" :class="{ 'is-invalid': errors.has('selectedCampaignIds['+index+']') }">
                                                <option disabled="" value="">Vyberte kampaň</option>
                                                <option v-for="campaign,cIndex in CampaignList" v-if="((campaign.campaignID == 0 || (selectedDomain =='' || selectedDomain == campaign.selectedDomain)) && (selectedCampaignIds.indexOf(campaign.campaignID) == -1 || selectedCampaignIds.indexOf(campaign.campaignID) == index))" v-bind:value="campaign.campaignID">
                                                    {{campaign.CampaignName}}
                                                </option>
                                            </select>
                                            <span v-if="errors.has('selectedCampaignIds['+index+']')" class="text-left ml-3 invalid-feedback">{{ errors.first('selectedCampaignIds['+index+']') }}</span>
                                        </div>
                                    </div>
                                    <div class="col-md-2 d-flex py-2">
                                        <input type="text" :disabled="( dataExists > 0)" placeholder="%" v-model="campaignRatio[index]" name="campaignRatio" v-on:input="validateForm()" class="form-control py-2 width_50" :class="{ 'is-invalid': errors.has('campaignRatio['+index+']') }" />
                                        <span class="d-inline-block align-middle pt-2">%</span>
                                        <span v-if="errors.has('campaignRatio['+index+']')" class="text-left invalid-feedback">{{ errors.first('campaignRatio['+index+']') }}</span>
                                    </div>
                                    <div class="col-md-3 py-2">
                                        <span>NE</span>
                                        <button type="button" class="btn btn-toggle" :class="{active: campaignDeactivate[index]}" :disabled="(selectedCampaignIds[index] == 0 || selectedCampaignIds[index] == '' || dataExists > 0 )" v-on:click="campaignDeactivate[index] = !campaignDeactivate[index];validateForm()" v-bind:value="campaignDeactivate[index]" data-toggle="button" aria-pressed="true" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span> ANO</span>
                                        <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Deaktivovat kampaň po skončení AB testu ' }"></i>
                                    </div>

                                </div>
                            </div>
                            <div class="list-group-item pt-4 pb-4 text-left">
                                <button class="btn btn-outline-secondary" :disabled="(selectedCampaignIds.length >=4 || dataExists > 0)" v-on:click="(selectedCampaignIds.length <4)?[selectedCampaignIds.push(''),campaignRatio.push('')]:'';validateForm();"><i class="fas fa-plus"></i>Přidat variantu</button>
                            </div>
                        </div>
                    </div>

                    <div class="row justify-content-center pt-4">
                        <div class="list-group mt-2 pl-3 col-md-8">
                            <h2 class="list-group-item group_item_blue bold py-3 d-flex ">
                                Vyberte cíle A/B testu
                            </h2>

                            <div class="list-group-item" v-for="targetUrl,index in targetUrls">
                                <p class="d-flex" v-if="index == 0">
                                    Zvolte 1 až 3 cíle, kterými ověříte úspěšnost nastaveného A/B testu
                                    <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                       v-tooltip.top="{ content: 'Cílová URL může být např. děkovací stránka, stránka po registraci nebo odeslání poptávky.' }"></i>
                                </p>
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-3 py-2 text-left pr-0">
                                        Pojmenujte cíl {{index+1}}
                                    </div>
                                    <div class="col-md-8 py-2">
                                        <input type="text" :disabled="(dataExists > 0)" placeholder="" v-model="targetUrlsNames[index]" v-on:input="validateForm()" v-bind:name="targetUrlsNames[index]" class="form-control py-2" :class="{ 'is-invalid': errors.has('targetUrlsNames['+index+']') }" />
                                        <span v-if="errors.has('targetUrlsNames['+index+']')" class="text-left invalid-feedback">{{ errors.first('targetUrlsNames['+index+']') }}</span>
                                    </div>
                                </div>
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-3 py-2 text-left pr-0">
                                        Vložte cílovou URL {{index+1}}
                                    </div>
                                    <div class="col-md-8 py-2">
                                        <input type="text" :disabled="(dataExists > 0)" placeholder="" v-model="targetUrls[index]" v-on:input="validateForm()" v-bind:name="targetUrls[index]" class="form-control py-2" :class="{ 'is-invalid': errors.has('targetUrls['+index+']') }" />
                                        <span v-if="errors.has('targetUrls['+index+']')" class="text-left invalid-feedback">{{ errors.first('targetUrls['+index+']') }}</span>
                                    </div>
                                    <span class="right d-flex align-items-center ml-2" style="font-family: inherit;font-weight: 500;line-height: 1.2;color: inherit;" v-if="index > 0">
                                        <button class="fas fa-trash btn-outline-third pointer copyPaste" title="odstranit" alt="odstranit" :disabled="(targetUrls.length <=1 || dataExists > 0)" v-on:click="(targetUrls.length >1)?[targetUrls.splice(index,1),targetUrlsNames.splice(index,1),targetParamIgnore.splice(index,1)]:''"> </button>
                                    </span>
                                </div>
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-5 py-2 text-left pr-0">
                                        Pravidlo párování cílové URL
                                        <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Přesná shoda URL znamená, že do splnění cíle bude započítána jen URL zadaná výše. \'Obsahuje\' vyberte, pokud vaše cílová URL má i proměnnou část (číslo objednávky atp). Do pole vložte pouze počáteční část URL, která neobsahuje proměnnou.' }"></i>
                                        
                                    </div>
                                    <div class="col-md-6 py-2 text-right">
                                        <span>Přesná shoda</span>
                                        <button type="button" class="btn btn-toggle" :class="{active: targetParamIgnore[index]}" :disabled="(dataExists > 0 )" v-on:click="targetParamIgnore[index] = !targetParamIgnore[index];validateForm()" v-bind:value="targetParamIgnore[index]" data-toggle="button" aria-pressed="true" autocomplete="off">
                                            <div class="handle"></div>
                                        </button>
                                        <span> Obsahuje</span>
                                    </div>
                                </div>
                            </div>
                            <div class="list-group-item pt-4 pb-4 text-left">
                                <button class="btn btn-outline-secondary" :disabled="(targetUrls.length >=3 || dataExists > 0)" v-on:click="(targetUrls.length <3)?[targetUrlsNames.push(''),targetUrls.push(''),targetParamIgnore.push(true)]:'';validateForm();"><i class="fas fa-plus"></i>Přidat cíl</button>
                            </div>
                        </div>
                    </div>

                    <div class="row justify-content-center pt-4">
                        <div class="list-group mt-2 pl-3 col-md-8">
                            <h2 class="list-group-item group_item_blue bold py-3 d-flex ">
                                Časový plán A/B testu
                            </h2>

                            <div class="list-group-item">
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-4 py-2 text-left">
                                        Spuštění A/B testu
                                    </div>
                                    <div class="col-md-8 py-2 mt-2">
                                        <span class="width_100">
                                            <label class="noselect">
                                                <span class="toogle_desc">NAPLÁNOVAT</span>&nbsp;&nbsp;
                                                <button type="button" :disabled="(dataExists > 0)" class="btn btn-toggle " :class="{active: activateNow}" v-on:click="ActiveChange(true)" v-bind:value="activateNow" data-toggle="button" aria-pressed="true" autocomplete="off">
                                                    <div class="handle"></div>
                                                </button>
                                                &nbsp;&nbsp;<span class="toogle_desc">ZAPNOUT IHNED</span>
                                            </label>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="list-group-item pb-4">

                                <div class="row align-items-center d-flex">
                                    <div class="col-md-6 py-2 text-left">
                                        <p class=" pt-3 bold">Naplánujte spuštění testu</p>
                                    </div>
                                    <div class="col-md-4 py-2 text-left">
                                        <p class=" pt-3 bold">Spusťte test hned</p>
                                    </div>

                                </div>

                                <div class="row align-items-center d-flex">
                                    <div class="col-md-2 py-2 text-left">
                                        Zahájení
                                    </div>
                                    <div class="col-md-4 py-2">
                                        <datetime type="datetime" format="dd.MM.yyyy HH:mm:ss" v-bind:placeholder="new Date(startDateTime).toLocaleDateString('cs-CZ').replace(/\s+/g, '') + ' ' + new Date(startDateTime).toLocaleTimeString('cs-CZ')" input-id="startDateTime" v-on:input="validateForm()" v-on:change="validateForm()" v-model="startDateTime" :class="{disabled: (activateNow || dataExists > 0)}" :disabled="(activateNow || dataExists > 0)"></datetime>
                                        <span v-if="errors.has('startDateTime')" class="d-flex text-left invalid-feedback">{{ errors.first('startDateTime') }}</span>
                                    </div>
                                    <div class="col-md-4 py-2 text-left">
                                        Zadejte počet dní testu
                                    </div>
                                </div>
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-2 py-2 text-left">
                                        Ukončení
                                    </div>
                                    <div class="col-md-4 py-2">
                                        <datetime type="datetime" format="dd.MM.yyyy HH:mm:ss" v-bind:placeholder="new Date(endDateTime).toLocaleDateString('cs-CZ').replace(/\s+/g, '') + ' ' + new Date(endDateTime).toLocaleTimeString('cs-CZ')" input-id="endDateTime" v-on:input="validateForm()" v-on:change="validateForm()" v-model="endDateTime" :class="{disabled: (activateNow || dataExists > 0)}" :disabled="(activateNow || dataExists > 0)"></datetime>
                                        <span v-if="errors.has('endDateTime')" class="d-flex text-left invalid-feedback">{{ errors.first('endDateTime') }}</span>
                                    </div>
                                    <div class="col-md-3 py-2">
                                        <input type="text" placeholder="14" :disabled="(!activateNow || dataExists > 0)" v-model="dayCount" name="dayCount" v-on:input="validateForm()" class="form-control py-2" :class="{ 'is-invalid': errors.has('dayCount') }" />
                                        <span v-if="errors.has('dayCount')" class="text-left invalid-feedback">{{ errors.first('dayCount') }}</span>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row justify-content-center pt-4">
                        <div class="list-group mt-2 pl-3 col-md-8">
                            <h2 class="list-group-item group_item_blue bold py-3 d-flex ">
                                Informace na e-mail&nbsp;&nbsp;&nbsp;&nbsp;
                                <span style="font-size: 14px;right: 20px;padding-top: 6px;position: absolute;">
                                    <span class="" style="color: #ced4da;">NE</span>&nbsp;&nbsp;
                                    <button type="button" :disabled="( dataExists > 0)" class="btn btn-toggle" :class="{active: sendEmail}" v-on:click="sendEmail = !sendEmail;validateForm()" v-bind:value="sendEmail" data-toggle="button" aria-pressed="true" autocomplete="off" style="margin-top: -3px;">
                                        <div class="handle"></div>
                                    </button>
                                    &nbsp;&nbsp;<span class="" style="color: #ced4da;">ANO</span>
                                </span>
                            </h2>

                            <div class="list-group-item pb-4">
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-5 py-2 text-left">
                                        Zaslat e-mail po skončení A/B testu:
                                    </div>
                                    <div class="col-md-5 py-2">
                                        <input type="text" placeholder="" :disabled="(!sendEmail || dataExists > 0)" v-model="emailAddress" name="emailAddress" v-on:input="validateForm()" class="form-control py-2" :class="{ 'is-invalid': errors.has('emailAddress') }" />
                                        <span v-if="errors.has('emailAddress')" class="text-left invalid-feedback">{{ errors.first('emailAddress') }}</span>
                                    </div>
                                </div>
                                <div class="row align-items-center d-flex">
                                    <div class="col-md-5 py-2 text-left">
                                        Další e-maily pro zaslání informací:
                                        <i style="color:royalblue;padding-left:8px;" class="fa fa-question-circle pointer"
                                           v-tooltip.top="{ content: 'Každou e-mailovou adresu oddělte středníkem.' }"></i>
                                    </div>
                                    <div class="col-md-5 py-2">
                                        <input type="text" placeholder="" :disabled="(!sendEmail || dataExists > 0)" v-model="emailAddresses" name="emailAddresses" v-on:input="validateForm()" class="form-control py-2" :class="{ 'is-invalid': errors.has('emailAddresses') }" />
                                        <span v-if="errors.has('emailAddresses')" class="text-left invalid-feedback">{{ errors.first('emailAddresses') }}</span>
                                    </div>
                                </div>
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
                            <button class="btn btn-outline-secondary btn_new_campaign" v-on:click="back()">
                                <i class="fas fa-chevron-circle-left"></i>&nbsp;&nbsp;&nbsp; Zpět
                            </button>
                        </div>
                        
                        <div class="justify-content-end">
                            <button class="btn btn-main-primary btn_new btn_new_campaign" :disabled="(!saveAllowed || dataExists > 0)" v-on:click="updateAbTest()">
                                Uložit&nbsp;&nbsp;&nbsp; 
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import SlimDialog from 'v-slim-dialog';
    import VeeValidate from 'vee-validate';
    import Vue from 'vue';
    import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';
    import { Datetime } from 'vue-datetime'

    import 'vue-datetime/dist/vue-datetime.css'

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

    Vue.use(Datetime);
    Vue.use(VueCookie);
    Vue.use(VueI18n);
    Vue.use(SlimDialog);

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
            datetime: Datetime
        },
        data() {
            return {
                userUid: "none",
                filteredList: [],
                DomainList: [],
                CampaignList: [{ campaignID: 0, CampaignName: "bez notifikací" }],
                saveAllowed: false,
                authUser: Vue.cookie.get('logged') || false,
                selectedAbTestName: null,
                loading: true,

                id: null,
                name: "",
                active: true,
                activateNow: false,
                selectedDomain: "",
                targetUrlsNames: [""],
                targetUrls: [""],
                selectedCampaignIds: [0, ""],
                campaignDeactivate: [false, false],
                targetParamIgnore:[true],
                campaignRatio: [50, 50],
                startDateTime: new Date(Date.now() + 1 * 86400000).toISOString(),
                endDateTime: new Date(Date.now() + 15 * 86400000).toISOString(),
                dayCount: 14,
                sendEmail: true,
                emailAddress: '',
                emailAddresses: '',

                dataExists:0

            }
        },
        methods: {
            ActiveChange(change) {
                if (change) { this.activateNow = !this.activateNow; }
                if (this.activateNow || this.dataExists > 0) {
                    document.querySelector("#startDateTime").style.backgroundColor = "#e9ecef"
                    document.querySelector("#endDateTime").style.backgroundColor = "#e9ecef"
                } else {
                    document.querySelector("#startDateTime").style.backgroundColor = "#ffffff"
                    document.querySelector("#endDateTime").style.backgroundColor = "#ffffff"
                }
                if (this.dataExists == 0) {
                    this.validateForm();
                }
            },
            back() {
                if (this.userUid != null) {
                    this.$router.push({ path: '/AbTesting' });
                } else {
                    window.location.pathname = '/AbTesting';
                }
            },
            validateEmails(mails) {
                let result = true;
                if (mails.length > 0) { 
                    mails.split(';').forEach((email, index, arr) => {
                        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email) == false) {
                            result = false
                        }
                    });
                }
                return result;
            },
            validateForm() {
                if (!this.loading) {
                    this.errors.clear();
                    var that = this;
                    that.$validator.validateAll({
                        name: that.name,
                        selectedDomain: that.selectedDomain,
                        targetUrlsNames: that.targetUrlsNames,
                        targetUrls: that.targetUrls,
                        selectedCampaignIds: that.selectedCampaignIds,
                        startDateTime: that.startDateTime,
                        endDateTime: that.endDateTime,
                        campaignRatio: that.campaignRatio,
                        active: that.active,
                        activateNow: that.activateNow,
                        dayCount: that.dayCount,
                        emailAddress: that.emailAddress,
                        emailAddresses: that.emailAddresses
                    }).then((valid) => {
                        //var that = this;
                        if (valid) {
                            that.saveAllowed = true;

                            if (that.name.length < 3) {
                                that.errors.add({ field: 'name', msg: 'Minimální délka názvu jsou 3 znaky' });
                                that.saveAllowed = false;
                            }
                            if (that.name.length > 38) {
                                that.errors.add({ field: 'name', msg: 'Maximální délka názvu je 38 znaků' });
                                that.saveAllowed = false;
                            }

                            that.filteredList.forEach(function (abtest, index) {
                                if (abtest.id != that.id && abtest.name == that.name) {
                                    that.errors.add({ field: 'name', msg: 'Zadaný název již existuje' });
                                    that.saveAllowed = false;
                                }
                            });

                            var total = 0;
                            that.campaignRatio.forEach(function (ratio, index, arr) {
                                total = total + Number(ratio);
                                if (isNaN(ratio) || ratio.length == 0) {
                                    that.errors.add({ field: 'campaignRatio[' + index + ']', msg: 'Zadejte číslo' });
                                    that.saveAllowed = false;
                                }
                                if (Number(ratio) <= 0) {
                                    that.errors.add({ field: 'campaignRatio[' + index + ']', msg: 'Hodnota musí být větší než 0' });
                                    that.saveAllowed = false;
                                }
                                if (arr.length - 1 == index) {
                                    if (total != 100) {
                                        that.errors.add({ field: 'campaignRatio[' + index + ']', msg: 'Součet poměrů musí být 100' });
                                        that.saveAllowed = false;
                                    }
                                }
                            });

                            that.targetUrlsNames.forEach(function (targetUrlNamesCheck, index) {
                                if (targetUrlNamesCheck.length < 3) {
                                    that.errors.add({ field: 'targetUrlsNames[' + index + ']', msg: 'Minimální délka názvu jsou 3 znaky' });
                                    that.saveAllowed = false;
                                }
                                if (targetUrlNamesCheck.length > 38) {
                                    that.errors.add({ field: 'targetUrlsNames[' + index + ']', msg: 'Maximální délka názvu je 38 znaků' });
                                    that.saveAllowed = false;
                                }
                            });

                            that.targetUrls.forEach(function (targetUrlCheck, index) {
                                if (targetUrlCheck.length == 0) {
                                    that.errors.add({ field: 'targetUrls[' + index + ']', msg: 'Url adresa nesmí být prázdná' });
                                    that.saveAllowed = false;
                                }
                                if (targetUrlCheck.length > 0) {
                                    if (!that.validUrl(targetUrlCheck)) {
                                        that.errors.add({ field: 'targetUrls[' + index + ']', msg: 'Url adresa nemá správný formát' });
                                        that.saveAllowed = false;
                                    }
                                }
                                if (targetUrlCheck.length > 0 && targetUrlCheck.indexOf(that.selectedDomain) == -1 && that.selectedDomain != 'none' && that.selectedDomain != '') {
                                    that.errors.add({ field: 'targetUrls[' + index + ']', msg: 'Cíl neobsahuje vybranou doménu' });
                                    that.saveAllowed = false;
                                }
                            });

                            if ((that.selectedDomain == 'none' || that.selectedDomain == '')) {
                                that.errors.add({ field: 'selectedDomain', msg: 'Vyberte doménu' });
                                that.saveAllowed = false;
                            }

                            that.CampaignList.forEach(function (campaign, cindex) {
                                that.filteredList.forEach(function (abtest, index) {
                                    if (abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && that.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && abtest.id != that.id && campaign.campaignID != 0 && abtest.active) {
                                        that.errors.add({ field: 'selectedCampaignIds[' + that.selectedCampaignIds.indexOf(campaign.campaignID) + ']', msg: 'Kampaň již existuje v aktivním AB Testu: ' + abtest.name });
                                        that.saveAllowed = false;
                                    }
                                });
                                if ((that.selectedDomain != 'none' && that.selectedDomain != '') && that.DomainList != []) {
                                    if (that.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && that.selectedDomain != campaign.selectedDomain && campaign.campaignID != 0) {
                                        that.errors.add({ field: 'selectedCampaignIds[' + that.selectedCampaignIds.indexOf(campaign.campaignID) + ']', msg: 'Vybraná kampaň nemá doménu kampaně' });
                                        that.saveAllowed = false;
                                    }
                                }

                            });

                            that.selectedCampaignIds.forEach(function (campaignId, index) {
                                if (campaignId.length == 0) {
                                    that.errors.add({ field: 'selectedCampaignIds[' + index + ']', msg: 'Vyberte kampaň: ' });
                                    that.saveAllowed = false;
                                }
                            });

                            //console.log("datumy", new Date(that.startDateTime) <= new Date(Date.now() + 3600000), new Date(that.startDateTime), new Date(Date.now() + 3600000));

                            if (that.startDateTime == null || that.startDateTime.length == 0) {
                                that.errors.add({ field: 'startDateTime', msg: 'Zahájení musí být nastaveno' });
                                that.saveAllowed = false;
                            }

                            if (new Date(that.startDateTime) < new Date(Date.now() + 3600000)) {
                                that.errors.add({ field: 'startDateTime', msg: 'Zahájení musí nastaveno nejdříve za 1 hodinu' });
                                that.saveAllowed = false;
                            }

                            if (!that.activateNow) {
                                if (that.endDateTime == null || that.endDateTime.length == 0) {
                                    that.errors.add({ field: 'endDateTime', msg: 'Ukončení musí být nastaveno' });
                                    that.saveAllowed = false;
                                }

                                if (new Date(that.endDateTime) < new Date(new Date(that.startDateTime).getTime() + 24 * 3600000)) {
                                    that.errors.add({ field: 'endDateTime', msg: 'Ukončení může být nejdříve za 24 hodin od spuštění.' });
                                    that.saveAllowed = false;
                                }

                            } else {
                                if (isNaN(that.dayCount)) {
                                    that.errors.add({ field: 'dayCount', msg: 'Počet dní musí být číslo' });
                                    that.saveAllowed = false;
                                }

                                if (that.dayCount < 1 || that.dayCount > 90) {
                                    that.errors.add({ field: 'dayCount', msg: 'Počet dní musí být 1 - 90' });
                                    that.saveAllowed = false;
                                }
                            }

                            if (that.sendEmail && !that.validateEmails(that.emailAddress)) {
                                that.errors.add({ field: 'emailAddress', msg: 'E-mailová adresa nemá správný formát' });
                                that.saveAllowed = false;
                            }

                            if (that.sendEmail && !that.validateEmails(that.emailAddresses)) {
                                that.errors.add({ field: 'emailAddresses', msg: 'E-mailové adresy nemají správný formát' });
                                that.saveAllowed = false;
                            }

                        } else {
                            that.saveAllowed = false;
                        }
                    });
                }
            },
            updateAbTest() {
                var that = this;
                const options = { title: 'Uložení AB Testu', cancelLabel: 'Ne', size: 'sm' }
                this.$dialogs.confirm('Chcete opravdu uložit AB Test: ' + that.name, options)
                    .then(res => {
                        if (res.ok) {
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/updateAbTest",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({
                                    session: Vue.cookie.get('session'),
                                    id: that.id,
                                    name: that.name,
                                    active: true,
                                    activateNow: that.activateNow,
                                    selectedDomain: that.selectedDomain,
                                    campaignRatio: that.campaignRatio,
                                    targetUrlsNames: that.targetUrlsNames,
                                    targetUrls: that.targetUrls,
                                    selectedCampaignIds: that.selectedCampaignIds,
                                    campaignDeactivate: that.campaignDeactivate,
                                    targetParamIgnore: that.targetParamIgnore,
                                    uuid: that.userUid,
                                    startDateTime: (that.activateNow) ? new Date(Date.now()).toISOString() : that.startDateTime,
                                    endDateTime: (that.activateNow) ? new Date(Date.now() + Number(that.dayCount) * 86400000).toISOString() : that.endDateTime,
                                    dayCount: (that.activateNow && that.dayCount == null) ? 14 : (that.activateNow && that.dayCount !== null) ? that.dayCount : null,
                                    sendEmail: that.sendEmail,
                                    emailAddress: that.emailAddress,
                                    emailAddresses: that.emailAddresses
                                })
                            }).done(function (data) {
                                if (that.activateNow) {
                                    that.$dialogs.alert('A/B test byl aktivován', options)
                                        .then(res => {
                                            that.back();
                                        });
                                } else {
                                    that.$dialogs.alert('A/B test bude spuštěn v naplánovaném čase', options)
                                        .then(res => {
                                            that.back();
                                        });
                                }
                            }).catch((err) => {
                                that.$dialogs.alert('A/B test se nepodařilo uložit', options)
                                    .then(res => {
                                        that.back();
                                    });
                            });
                        }
                    });
            },
            parseUrl(parsUrl) {
                return parseUrl(parsUrl, false).resource;
            },
            validUrl(valUrl) {
                try {

                    if (parseUrl(valUrl, false).protocol != "http" && parseUrl(valUrl, false).protocol != "https" && parseUrl(valUrl, false).protocol != "ssh") {
                        return false;
                    }

                    if (parseUrl(valUrl, false).protocol == null) {
                        return false;
                    }

                    if (parseDomain(valUrl) == null) {
                        return false;
                    }
                    return true;
                }
                catch (err) {
                    return false;
                }
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            }
        },
        watch: {
        },
        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
        },

        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
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

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_campaigns",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (dataCampaigns) {
                if (dataCampaigns.campaigns != undefined) {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        that.CampaignList.push(campaign);

                    })
                }
            });

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getAbTests",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (abtestings) {
                if (abtestings.abtesting != undefined) {
                    abtestings.abtesting.forEach(function (abtesting, index, arr) {
                        that.filteredList.push(abtesting);
                        if (Vue.cookie.get('EditAbTestId') != 'null' && abtesting.id == Vue.cookie.get('EditAbTestId')) {
                            that.selectedAbTestName = abtesting.name;
                            that.id = abtesting.id;
                            that.name = abtesting.name;
                            that.active = abtesting.active;
                            that.activateNow = abtesting.activateNow;
                            that.selectedDomain = abtesting.selectedDomain;
                            that.campaignRatio = abtesting.campaignRatio;
                            that.targetUrlsNames = abtesting.targetUrlsNames;
                            that.targetUrls = abtesting.targetUrls;
                            that.selectedCampaignIds = abtesting.selectedCampaignIds;
                            that.campaignDeactivate = abtesting.campaignDeactivate;
                            that.targetParamIgnore = abtesting.targetParamIgnore;
                            that.startDateTime = abtesting.startDateTime;
                            that.endDateTime = abtesting.endDateTime;
                            that.dayCount = abtesting.dayCount;
                            that.sendEmail = abtesting.sendEmail;
                            that.emailAddress = abtesting.emailAddress;
                            that.emailAddresses = abtesting.emailAddresses;
                            that.dataExists = abtesting.dataExists;
                            Vue.cookie.set('EditAbTestId', null, 1);

                            that.ActiveChange(false);
                        }

                        if (index == arr.length - 1) {
                            that.loading = false;
                        }
                    });
                }
                if (abtestings.abtesting.length == 0) { that.loading = false;}
            });

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_user_profile",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (dataProfile) {
                that.emailAddress = dataProfile.RegEmail;
            });

        }
    }


</script>

<style lang="css">
    /*.new_campaign_container
    {
        background-color: red !important;
    }*/
</style>