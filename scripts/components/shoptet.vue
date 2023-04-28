<template>
    <div class="shoptet-external-iframe-content">
        <h2 class="std-header">NTF app</h2>

        <ul v-show="dataLoaded" class="list-reset">
            <li v-show="pixelInstalled != null &&pixelInstalled">
                <div class="system-message-success system-message-wrap">
                    <div class="system-message-outer">
                        <div class="system-message-inner">
                            <div class="system-message-content">Pixel script je nainstalovaný správně</div>
                            <div class="system-message-buttons"><a class="system-message-close system-message-close-trigger" href="#" title="Zavřít"></a></div>
                        </div>
                    </div>
                </div>
            </li>

            <!--<li>
                <div class="system-message-alert system-message-wrap">
                    <div class="system-message-outer">
                        <div class="system-message-inner">
                            <div class="system-message-content">This is an example Tip notice.</div>

                        </div>
                    </div>
                </div>
            </li>-->

            <li v-show="pixelInstalled != null && !pixelInstalled">
                <div class="system-message-error system-message-wrap">
                    <div class="system-message-outer">
                        <div class="system-message-inner">
                            <div class="system-message-content">Pixel script není nainstalován.</div>
                            <div class="system-message-buttons"><span title="Instalace Pixel scriptu" class="btn btn-default btn-md no-disable" v-on:click="installShoptetPixel()">Nainstalovat Pixel script</span><!--<a class="system-message-close system-message-close-trigger" href="#" title="Zavřít"></a>--></div>
                        </div>
                    </div>
                </div>
            </li>
        </ul>

        <h2 class="std-header"><span>Záložky</span></h2>

        <div id="tabs-default" class="ui-tabs std-tabs">
            <ul>
                <li v-show="dataLoaded">
                    <a href="#a3">Informace</a>
                </li>
                <li v-show="dataLoaded">
                    <a href="#a2">Seznam aktivních kampaní</a>
                </li>
                <li>
                    <a href="#a1">Nastavení přístupu</a>
                </li>
            </ul>

            <div id="a1">
                <div style="max-width: 100%;width: 621px;display: block;">
                    <label for="token" class="text-right" style="padding-right: 20px;">
                        Váš "API klíč"
                        <span class="tooltip-icon" v-tooltip.top="{ content: 'Zde zadejte váš 32 místný api klíč z app.cz' }"></span>
                    </label>
                    <input type="text" placeholder="Zde zadejte váš api klíč" name="apiKey" v-model="apiKey" v-validate="{ required: true, min: 32, max: 32}" class="small-12 medium-14 large-8" :class="{ 'is-invalid': errors.has('apiKey') }" autocomplete="off">
                    <button class="btn btn-md btn-default btn-min" :disabled="apiKey.length != 32" v-on:click="setApiKey(apiKey)">Uložit</button>
                </div>
                 
            </div>

                <div id="a2">
                    <v-table even-bg-color="#f2f2f2"
                             row-hover-color="#edf6e2"
                             row-click-color="#edf7ff"
                             style="width:600px;"
                             :columns="columns"
                             :table-data="rows"
                             :column-cell-class-name="columnCellClass"
                             :cell-edit-done="cellEditDone">

                    </v-table>
                </div>


                <div id="a3">

                    <div style="max-width: 100%;width: 621px;display: block;">
                        <span style="width:618px;max-width:100%;display:flex">
                            <span v-bind:class="[thirdPartyData.checkPixel ? 'shoptet-success-mainbox' : 'shoptet-fail-mainbox']">
                                <i v-if="thirdPartyData.checkPixel" class="fas fa-check shoptet-symbol-icon" style="padding-top: 20px !important;"></i>
                                <i v-else class="fas fa-times shoptet-symbol-icon" style="padding-top: 20px !important;"></i>
                                <label v-if="thirdPartyData.checkPixel" style="position: relative !important;bottom: 3px !important;">Pixel je nainstalovaný</label>
                                <label v-else style="position: relative !important;bottom: 3px !important;">Pixel není nainstalovaný</label>
                            </span>

                            <span v-bind:class="[thirdPartyData.heurekaValid ? 'shoptet-success-box' : 'shoptet-gray-box']">
                                Heureka <br />
                                <i v-if="thirdPartyData.heurekaValid" class="fas fa-check shoptet-symbol-icon"></i>
                                <i v-else class="fas fa-minus shoptet-symbol-icon"></i>
                            </span>
                        </span>

                        <span style="width:618px;max-width:100%;display:flex">
                            <span v-bind:class="[(thirdPartyData.checkPixel && thirdPartyData.PaymentVersion != 'TRIAL') ? 'shoptet-blue-box' : 'shoptet-warning-box']">
                                Tarif
                                <span class="shoptet-text-icon">{{(thirdPartyData.PaymentVersion == "TRIAL") ? '14 DNÍ ZDARMA' : thirdPartyData.PaymentVersion}}</span>
                            </span>

                            <span v-bind:class="[thirdPartyData.CreditCounts >  0.2 * thirdPartyData.CreditVariant  ? 'shoptet-success-box' : thirdPartyData.CreditCounts <=  0.2 * thirdPartyData.CreditVariant && thirdPartyData.CreditCounts > 0 ? 'shoptet-warning-box' : 'shoptet-fail-box']">
                                Přehled Kreditů
                                <span class="shoptet-text-icon"> {{thirdPartyData.CreditCounts}} / {{thirdPartyData.CreditVariant}}</span>
                            </span>

                            <span v-bind:class="[thirdPartyData.zboziValid ? 'shoptet-success-box' : 'shoptet-gray-box']">
                                Zboží <br />
                                <i v-if="thirdPartyData.zboziValid" class="fas fa-check shoptet-symbol-icon shoptet-symbol-icon"></i>
                                <i v-else class="fas fa-minus shoptet-symbol-icon"></i>
                            </span>

                        </span>
                    </div>

                </div>
            </div>

    </div>
</template>

<script>
    import VeeValidate from 'vee-validate';
    import Vue from 'vue';
    import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';

    import 'vue-easytable/libs/themes-base/index.css'
    import { VTable, VPagination } from 'vue-easytable'
    Vue.component(VTable.name, VTable)
    Vue.component(VPagination.name, VPagination)

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
            cs, en
        }
    });

export default {
    data() {
        return {
            thirdPartyData: {
                uuid: null,
                apiKey: null,
                checkPixel: false,
                CreditVariant: null,
                CreditCounts: null,
                PaymentVersion: null,
                heurekaValid: false,
                zboziValid: false,
                Level: null,
                activeCampaigns: [],
                bearer: null,
                bearerValidity:null
            },
            apiKey: '',
            shopId: 0,
            pixelInstalled: null,
            dataLoaded: false,

            columns: [
                { title: 'Název kampaně', field: 'campaignName', width: 250, isEdit: false, isResize: true, titleCellClassName: 'shoptet-table-header' }
                , {
                    title: 'Vybrané notifikace', field: 'MessageTypes', isEdit: false, width: 250, isResize: true, titleCellClassName: 'shoptet-table-header',
                    formatter: function (rowData, rowIndex, pagingIndex, field) {
                        let dataContent = '<span style="display:block;padding-top: 5px;">';

                        if (rowData.MessageTypes[0].indexOf("OwnAppi") != -1) {
                            dataContent += '<img src="/images/product/offer.svg" alt="TOP nabídky" title="TOP nabídky" class="navbar-toggler-icon svg_img_ico" style="padding-right: 5px;">';
                        }

                        if (rowData.MessageTypes[0].indexOf("Zbozi") != -1) {
                            dataContent += '<img src="/images/product/zbozi.svg" alt="Recenze Zboží.cz" title="Recenze Zboží.cz" class="navbar-toggler-icon svg_img_ico" style="padding-right: 5px; width: 34px;">';
                        }

                        if (rowData.MessageTypes[0].indexOf("Heureka") != -1) {
                            dataContent += '<img src="' +
                                ((Math.trunc(((100 / 5) * rowData.MessageTypes[1])) >= 80) ? '/images/product/reviews.svg' : '/images/product/reviewsBadScore.svg')
                                + '" alt="' +
                                ((Math.trunc(((100 / 5) * rowData.MessageTypes[1])) >= 80) ? 'Recenze Heureka.cz' : 'Zobrazení notifikací zastaveno.\nPrůměrné hodnocení e-shopu kleslo pod 80 %.')
                                + '" title="' +
                                ((Math.trunc(((100 / 5) * rowData.MessageTypes[1])) >= 80) ? 'Recenze Heureka.cz' : 'Zobrazení notifikací zastaveno.\nPrůměrné hodnocení e-shopu kleslo pod 80 %.')
                                + '" class="navbar-toggler-icon svg_img_ico" style="padding-right: 5px;">';
                        }

                        if (rowData.MessageTypes[0].indexOf("Statistics") != -1) {
                            dataContent += '<img src="/images/product/statistics.svg" alt="Souhrnné statistiky" title="Souhrnné statistiky" class="navbar-toggler-icon svg_img_ico" style="padding-right: 5px;">';
                        }

                        if (rowData.MessageTypes[0].indexOf("VisitCount") != -1) {
                            dataContent += '<img src="/images/product/visits.svg" alt="Počet návštěv" title="Počet návštěv" class="navbar-toggler-icon svg_img_ico" style="padding-right: 5px;">';
                        }

                        if (rowData.MessageTypes[0].indexOf("LastEventsRegistrations") != -1) {
                            dataContent += '<img src="/images/product/registration.svg" alt="Poslední události Registrace" title="Poslední události Registrace" class="navbar-toggler-icon svg_img_ico" style="padding-right: 5px;">';
                        }

                        if (rowData.MessageTypes[0].indexOf("LastEventsOrders") != -1) {
                            dataContent += '<img src="/images/product/orders.svg" alt="Poslední události Objednávky" title="Poslední události Objednávky" class="navbar-toggler-icon svg_img_ico" style="padding-right: 5px;">';
                        }

                    
                        return dataContent + '</span>';
                    }
                }
                , { title: 'Stav', field: 'status', isEdit: false, width: 100, isResize: false, titleCellClassName: 'shoptet-table-header' }
                    ],
            rows: [],
        }
    },
    methods: {
        checkShoptetPixelInstalled() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/checkShoptetPixel",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ eshopId: that.shopId })
            }).done(function (data) {
                if (data.result == 1) {
                    that.pixelInstalled = true;
                } else {
                    that.pixelInstalled = false;
                }
            });
        },
        installShoptetPixel() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/installShoptetPixel",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ eshopId: that.shopId })
            }).done(function (data) {
                if (data.result == 1) {
                    that.pixelInstalled = true;
                } else {
                    that.pixelInstalled = false;
                }
            });
        },
        setApiKey() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/setShoptetApikey",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ apiKey: that.apiKey, eshopId: that.shopId })
            }).done(function (data) {
                if (data.result == 1) {
                    that.thirdPartyData = data.data;
                    that.apiKey = data.data.apiKey;

                    that.rows = [];
                    data.data.activeCampaigns.forEach(function (campaign, index, arr) {
                        that.rows.push({
                            campaignName: campaign.name,
                            MessageTypes: [campaign.AppiTypes, campaign.heurekaLastScore],
                            status: (campaign.active) ? 'Aktivní' : 'Neaktivní'
                        });
                    });
                    if (that.rows.length == 0) {
                        that.rows.push({
                            campaignName: '',
                            MessageTypes: [[], 0],
                            status: ''
                        });
                    }
                    document.querySelector("#ui-id-1").click();
                    that.dataLoaded = true;
                }
            });
        },
        columnCellClass(rowIndex, columnName, rowData) {
            return 'shoptet-table-column';
        }
    },
    created() {
        var that = this;
        
        if (JSON.stringify(that.$route.query) != "{}") {
            that.shopId = Number(that.$route.query.shopId);

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getThirdPartyData",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ eshopId: that.shopId })
            }).done(function (data) {
                if (data.result == 1 && data.data.apiKey != undefined) {
                    that.thirdPartyData = data.data;
                    that.apiKey = data.data.apiKey;


                    that.rows = [];
                    data.data.activeCampaigns.forEach(function (campaign, index, arr) {
                        that.rows.push({
                            campaignName: campaign.name,
                            MessageTypes: [campaign.AppiTypes, campaign.heurekaLastScore],
                            status: (campaign.active) ? 'Aktivní' : 'Neaktivní'
                        });
                    });
                    if (that.rows.length == 0) {
                        that.rows.push({
                            campaignName: '',
                            MessageTypes: [[], 0],
                            status: ''
                        });
                    }
                    that.checkShoptetPixelInstalled();
                    that.dataLoaded = true;
                } else {
                    document.querySelector("#ui-id-3").click();
                }
            
            });
        } 
    }
}

    document.cookie = 'safari_cookie_fix=fixed; secure; path=/';
    const urlParams = new URLSearchParams(window.location.search);
    const backUrl = urlParams.get('backUrl');
    if (backUrl !== null) {
        window.location.replace(decodeURIComponent(backUrl));
    }
</script>

<style scoped>

</style>