<template>
    <div v-show="authUser=='true'">
        <!--<div class="container-fluid new_campaign_container text-center">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="new_campaign_h3" v-if="selectedAbTestName != null">{{selectedAbTestName}}</h3>
                    </div>
                </div>
            </div>
        </div>-->
        <div class="container text-center new_campaign_container_wrap">
            <div class="row justify-content-center">
                <div class="col-md-12">
                    <!--<h3 class="new_campaign_h3_2 py-4 pb-4">Vyhodnocení stanovených cílů</h3>-->
                    <div class="row justify-content-md-center pt-4">
                        <div class="col-md-12">
                            <div class="list-group mt-2 shadow-sm">
                                <div class="list-group-item" style="padding: 1.25rem 1.25rem">
                                    <div class="row align-items-center">
                                        <div class="col-md-12 mycolor d-flex">
                                            <h3 class="col-md-6 text-left">{{selectedAbTestName}}</h3>
                                        </div>
                                        <span class="col-md-12 py-2 d-flex">
                                            <div class="col-md-6 py-2 d-flex">
                                                <b>Datum spuštění: </b>&nbsp;&nbsp;{{new Date(startDateTime).toLocaleDateString("cs-CZ").replace(/\s+/g, '') + ' v ' + new Date(startDateTime).toLocaleTimeString("cs-CZ") }}
                                            </div>
                                            <div class="col-md-6 py-2 text-right">
                                                <b>Datum ukončení: </b>&nbsp;&nbsp; {{new Date(endDateTime).toLocaleDateString("cs-CZ").replace(/\s+/g, '') + ' v ' + new Date(endDateTime).toLocaleTimeString("cs-CZ") }}
                                            </div>
                                        </span>
                                        <span class="col-md-12 py-2 d-flex">

                                            <div class="col-md-4 py-2 d-flex" v-if="(active && new Date(startDateTime) <= Date.now() && new Date(endDateTime) >= Date.now())">
                                                Test právě probíhá a {{endsIn}}
                                            </div>
                                            <div class="col-md-4 py-2 d-flex" v-if="(!active)">
                                                Test byl ukončen
                                            </div>
                                            <div class="col-md-8 py-2 text-right" v-if="lastUpdateType == 'end'">Poslední aktualizace dat: {{new Date(lastUpdateTime).toLocaleDateString("cs-CZ").replace(/\s+/g, '') + ' v ' + new Date(lastUpdateTime).toLocaleTimeString("cs-CZ") }}</div>
                                            <div class="col-md-8 py-2 text-right" v-if="lastUpdateType == 'start'">Právě probíhá přepočet dat</div>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row justify-content-md-center pt-4">
                        <div class="col-md-12">
                            <div class="list-group mt-2 shadow-sm">
                                <div class="list-group-item" style="padding: 1.25rem 1.25rem">
                                    <span class="d-block align-middle text-left">
                                        <button class="btn btn-outline-secondary btn_new_campaign" id="variantBtn1" v-on:click="setVariant(1,null)" style="padding: 0.375rem 1.5rem !important;">
                                            Konverzní poměr
                                        </button>
                                        <button class="btn btn-outline-secondary btn_new_campaign" id="variantBtn2" v-on:click="setVariant(2,null)" style="padding: 0.375rem 1.5rem !important;">
                                            Splnění cíle
                                        </button>
                                        <button class="btn btn-outline-secondary btn_new_campaign" id="variantBtn3" v-on:click="setVariant(3,null)" style="padding: 0.375rem 1.5rem !important;">
                                            Zobrazení stránek
                                        </button>
                                        <button class="btn btn-outline-secondary btn_new_campaign" id="variantBtn4" v-on:click="setVariant(4,null)" style="padding: 0.375rem 1.5rem !important;">
                                            Návštěvy
                                        </button>
                                        <!--<span class="noselect text-center align-middle">
                                            <span class="toogle_desc">HODINY</span>&nbsp;&nbsp;
                                            <button type="button" class="btn btn-toggle" :class="{active: measureDay}" v-on:click="measureDay = !measureDay;setVariant(null,null)" data-toggle="button" aria-pressed="false" autocomplete="off"><div class="handle"></div></button>
                                            &nbsp;&nbsp;<span class="toogle_desc">DNY</span>
                                        </span>-->
                                    </span>

                                    <span class="d-block align-middle text-left pb-1" v-if="variant == 1 || variant == 2">
                                        <button v-if="targetUrlsNames.length >= 1" class="btn btn-outline-secondary btn_new_campaign" id="targetBtn1" v-on:click="setVariant(null,1)" style="padding: 0.375rem 1.5rem !important;">
                                            {{targetUrlsNames[0]}}
                                        </button>
                                        <button v-if="targetUrlsNames.length >= 2" class="btn btn-outline-secondary btn_new_campaign" id="targetBtn2" v-on:click="setVariant(null,2)" style="padding: 0.375rem 1.5rem !important;">
                                            {{targetUrlsNames[1]}}
                                        </button>
                                        <button v-if="targetUrlsNames.length == 3" class="btn btn-outline-secondary btn_new_campaign" id="targetBtn3" v-on:click="setVariant(null,3)" style="padding: 0.375rem 1.5rem !important;">
                                            {{targetUrlsNames[2]}}
                                        </button>
                                    </span>

                                    <apexchart id="chart" ref="chart" type="line" :options="chartOptions" :series="series"></apexchart>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row justify-content-md-center pt-4">
                        <div class="col-md-12">
                            <div class="list-group mt-2 shadow-sm">
                                <p class="list-group-item group_item_blue bold text-left">Celkový přehled a zaznamenaná data A/B testu</p>
                                <div class="list-group-item" style="padding: 1.25rem 1.25rem">
                                    <vue-good-table :columns="columns" id="resultTable"
                                                    :rows="rows" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row justify-content-md-center pt-4">
                        <div class="col-md-12">
                            <div class="list-group mt-2 shadow-sm d-flex">
                                <div class="list-group-item group_item_blue bold d-flex text-left">Porovnání konverzních poměrů jednotlivých variant
                                    <div style="right: 20px;position: absolute;top: 7px;">
                                        <select v-model="selectedTarget" style="max-width: 240px;" name="selectedTarget" v-on:change="changeTarget()" class="form-control ml-3">
                                            <option v-for="target,index in targetUrlsNames">
                                                {{target}}
                                            </option>
                                        </select>
                                    </div>
                                </div>
                                <div class="list-group-item" style="padding: 1.25rem 1.25rem">
                                    <vue-good-table :columns="totalColumns" id="totalTable"
                                                    :rows="totalRows" />
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


                    </div>
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
    import SlimDialog from 'v-slim-dialog';

    import VueGoodTablePlugin from 'vue-good-table';
    import 'vue-good-table/dist/vue-good-table.css'
    Vue.use(VueGoodTablePlugin);

	import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";
    import VueApexCharts from 'vue-apexcharts'
    Vue.use(VueApexCharts)
    Vue.component('apexchart', VueApexCharts)
	
	Vue.use(VueI18n);
	Vue.use(VueCookie);
    Vue.use(SlimDialog);

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
	
    var bcrypt = require('bcrypt-nodejs');

    export default {

	data() {
        return {
            columns: [],
            rows: [],

            totalColumns: [],
            totalRows: [],

            series: [],
            chartOptions: {
                chart: {
                    height: 350,type: 'line',
                    dropShadow: {enabled: true,color: '#000',top: 18,left: 7,blur: 10, opacity: 0.2},
                    toolbar: { show: true}
                },
                colors: ['#7CC542', '#e23433', '#039bcd','#ed6b27'],
                dataLabels: {enabled: false },
                stroke: { curve: 'smooth'},
                title: { text: '<p></p>\n\n', align: 'left', margin: 10, style: { fontSize: '14px', color: '#FFFFFF' }},
                grid: {borderColor: '#e7e7e7',row: {colors: ['#f3f3f3', 'transparent'], opacity: 0.5},},
                markers: { size: 1},
                xaxis: {categories: [],title: {text: 'ČASOVÁ OSA'}},
                yaxis: { title: { text: 'Konverzní poměr'},min: 0,max: 0},
                legend: { position: 'top', horizontalAlign: 'left', floating: true, offsetY: -28, offsetX: -5, fontSize: '16px'}
            },

            endsIn: '',
            measureDay: true,
            variant: 1,
            target: 1,
            lastUpdateType: null,
            lastUpdateTime: null,
            userUid: "none",
            filteredList: [],
            authUser: Vue.cookie.get('logged') || false,
            selectedAbTestName: null,

            id: null,
            name: "",
            active: true,
            activateNow: false,
            selectedDomain: "",
            targetUrlsNames: [""],
            targetUrls: [""],
            targetParamIgnore: [true],
            selectedCampaignIds: [0, ""],
            selectedTarget: null,
            campaignDeactivate: [false, false],
            campaignRatio: ["", ""],
            startDateTime: new Date(Date.now() + 1 * 86400000).toISOString(),
            endDateTime: new Date(Date.now() + 15 * 86400000).toISOString(),
            dayCount: 14,
            sendEmail: true,
            emailAddress: '',
            emailAddresses: ''
		}
	},
    beforeCreate() {
        this.authUser = Vue.cookie.get('logged') || false;
    },
    methods: {
        showAlert(val) {
            const options = { title: 'Info', size: 'sm' }
            this.$dialogs.alert(val, options)
                .then(res => {
                });
        },
        date_diff_indays(date2, date1) {
            var dt1 = date1;
            var dt2 = date2;
            return Math.floor((Date.UTC(dt2.getFullYear(), dt2.getMonth(), dt2.getDate()) - Date.UTC(dt1.getFullYear(), dt1.getMonth(), dt1.getDate())) / (1000 * 60 * 60 * 24));
        },
        calculateEndsIn() {
            this.endsIn = this.date_diff_indays(new Date(this.endDateTime), new Date());
            switch (this.endsIn) {
                case 0: this.endsIn = "končí dnes"; break;
                case 1: this.endsIn = "končí za " + this.endsIn + " den"; break;
                case 2: case 3: case 4:
                    this.endsIn = "končí za " + this.endsIn + " dny"; break;
                default:
                    this.endsIn = "končí za " + this.endsIn + " dní";
            }
        },
        back() {
            if (this.userUid != null) {
                this.$router.push({ path: '/AbTesting' });
            } else {
                window.location.pathname = '/AbTesting';
            }
        },
        setVariant(variant, target) {
            variant = (variant == null) ? this.variant : variant;
            target = (target == null) ? this.target : target;

            for (let i = 1; i < 5; i++) {
                if (variant == i) {
                    setTimeout(() => {
                        document.querySelector("#variantBtn" + i).classList.remove("btn-outline-secondary");
                        document.querySelector("#variantBtn" + i).classList.add("btn-main-primary");
                    }, 0);
                } else {
                    setTimeout(() => {
                        document.querySelector("#variantBtn" + i).classList.remove("btn-main-primary");
                        document.querySelector("#variantBtn" + i).classList.add("btn-outline-secondary");
                    }, 0);
                }
                if (target == i) {
                    setTimeout(() => {
                        if (document.querySelector("#targetBtn" + i) != undefined) {
                            document.querySelector("#targetBtn" + i).classList.remove("btn-outline-secondary");
                            document.querySelector("#targetBtn" + i).classList.add("btn-main-primary");
                        }
                    }, 0);
                } else if (i <= 3) {
                    setTimeout(() => {
                        if (document.querySelector("#targetBtn" + i) != undefined) {
                            document.querySelector("#targetBtn" + i).classList.remove("btn-main-primary");
                            document.querySelector("#targetBtn" + i).classList.add("btn-outline-secondary");
                        }
                    }, 0);
                }
            }
            this.variant = variant;
            this.target = target;
            this.changeVariant(variant);
        },
        changeVariant(variant) {
            this.calculating = false;
            var that = this;
            that.series = [];
            that.chartOptions.xaxis.categories = [];

            switch (variant) {
                case 1: that.chartOptions.yaxis.title.text = 'Konverzní poměr v %'; break;
                case 2: that.chartOptions.yaxis.title.text = 'Splnění cíle'; break;
                case 3: that.chartOptions.yaxis.title.text = 'Zobrazení stránek'; break;
                case 4: that.chartOptions.yaxis.title.text = 'Návštěvy'; break;
            }

            let zeroCampaign = "bez app"; let cmpName = ''; let maxValue = 0; let xaxis = '';
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getABVisitors",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({
                    session: Vue.cookie.get('session'), uuid: (that.userUid != "none") ? that.userUid : null, abTestId: that.id,
                    type: (variant == 1) ? 'conversion' : (variant == 2) ? 'visits' : (variant == 3) ? 'allVisits' : (variant == 4) ? 'visitors' : 'visits',
                    measureDay: that.measureDay,
                    target: (variant == 1 || variant == 2) ? that.targetUrls[(that.target - 1)] : null,
                    targetParamIgnore: (variant == 1 || variant == 2) ? that.targetParamIgnore[(that.target - 1)] : null
                })
            }).done(function (abvisitors) {
                abvisitors.visitors.forEach(function (visitor, index, arr) {
                    maxValue = (maxValue < visitor.count) ? visitor.count : maxValue;

                    //insert campaignName and data
                    cmpName = (visitor.campaignID == 0) ? zeroCampaign : visitor.CampaignName;
                    if (that.series.find((cmp) => { return cmp.name == cmpName; }) == undefined) {
                        that.series.push({ name: cmpName, data: [visitor.count] });
                    } else {
                        that.series.filter((cmp) => { if (cmp.name.indexOf(cmpName) > -1) { cmp.data.push(visitor.count); } });
                    }

                    // insert xaxis
                    if (visitor.yeardayhour != undefined) {
                        xaxis = visitor.yeardayhour.toString().substring(6, 8) + '.' + visitor.yeardayhour.toString().substring(4, 6) + '.' + visitor.yeardayhour.toString().substring(0, 4) + ' ' + visitor.yeardayhour.toString().substring(8, 10) + 'h';
                    } else if (visitor.yearday != undefined) {
                        xaxis = visitor.yearday.toString().substring(6, 8) + '.' + visitor.yearday.toString().substring(4, 6) + '.' + visitor.yearday.toString().substring(0, 4);
                    }
                    if (that.chartOptions.xaxis.categories.indexOf(xaxis) == -1) { that.chartOptions.xaxis.categories.push(xaxis); }

                    // rerender graph
                    if (index == arr.length - 1) {
                        that.chartOptions.yaxis.max = Math.ceil(Number(maxValue) * 1.2);
                        setTimeout(function () {
                            document.querySelector("#chart").__vue__.refresh();
                            //that.$refs.chart.refresh();
                            setTimeout(function () { document.querySelector("#chart").__vue__.refresh(); }, 0);
                        }, 100);
                    }
                });
            });

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getABTable",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid, abTestId: that.id, measureDay: that.measureDay })
            }).done(function (abTable) {
                let cmp = 0; let lastCmp = null; let firstInsert = true; let counter = 0; let conversion = []; let target = [];
                that.columns = [{ label: 'Varianta', field: 'variant', tdClass: 'bold' }, { label: 'Reální návštěvníci', field: 'realvisitors', type: 'number' }, { label: 'Návštěvy', field: 'visitors', type: 'number' }, { label: 'Zobrazení stránek', field: 'visits', type: 'number' }, { label: 'Zobrazení notifikací', field: 'Messages', type: 'number' }];
                that.rows = []; let saveData = false;
                abTable.abTable.forEach((row, index, arr) => {

                    conversion.push(row.conversion * 0.01);
                    target.push(row.targetCount);

                    let nextCmp = (arr[index + 1] != undefined) ? arr[index + 1].campaignName : null;
                    if (index == arr.length - 1 || (row.campaignName != nextCmp)) { saveData = true; }

                    // insert columns
                    if (firstInsert) {
                        that.columns.push({ label: 'Konverzní poměr: ' + row.targetUrlsNames, field: 'conversion' + counter.toString(), type: 'percentage' },
                            { label: 'Splnění cíle: ' + row.targetUrlsNames, field: 'target' + counter.toString(), type: 'number' });

                    }

                    //insert to table
                    if (saveData) {
                        saveData = false; firstInsert = false;
                        if (conversion.length == 1) { that.rows.push({ variant: arr[index].campaignName, realvisitors: arr[index].realVisitorsCount, visitors: arr[index].visitorsCount, visits: arr[index].visitCount, Messages: arr[index].MessageCount, conversion0: conversion[0], target0: target[0] }); }
                        if (conversion.length == 2) { that.rows.push({ variant: arr[index].campaignName, realvisitors: arr[index].realVisitorsCount, visitors: arr[index].visitorsCount, visits: arr[index].visitCount, Messages: arr[index].MessageCount, conversion0: conversion[0], target0: target[0], conversion1: conversion[1], target1: target[1] }); }
                        if (conversion.length == 3) { that.rows.push({ variant: arr[index].campaignName, realvisitors: arr[index].realVisitorsCount, visitors: arr[index].visitorsCount, visits: arr[index].visitCount, Messages: arr[index].MessageCount, conversion0: conversion[0], target0: target[0], conversion1: conversion[1], target1: target[1], conversion2: conversion[2], target2: target[2] }); }
                        if (conversion.length == 4) { that.rows.push({ variant: arr[index].campaignName, realvisitors: arr[index].realVisitorsCount, visitors: arr[index].visitorsCount, visits: arr[index].visitCount, Messages: arr[index].MessageCount, conversion0: conversion[0], target0: target[0], conversion1: conversion[1], target1: target[1], conversion2: conversion[2], target2: target[2], conversion3: conversion[3], target3: target[3] }); }
                        counter = 0; conversion = []; target = [];
                    }
                    lastCmp = row.campaignName; counter += 1;
                });

                that.totalColumns = [{ label: 'Varianta A/B testu', field: 'variant', tdClass: 'bold' }]; that.totalRows = [];
                for (counter = 0; counter < that.rows.length; counter++) {
                    that.totalColumns.push({ label: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion0 * 100).toFixed(2) + '%)', field: 'conversion' + counter.toString(), thClass: 'text-center bold', html: true, tdClass: 'text-center', value: parseFloat(that.rows[counter].conversion0 * 100).toFixed(2) });
                }

                for (counter = 0; counter < that.rows.length; counter++) {
                    that.totalRows.push({ variant: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion0 * 100).toFixed(2) + '%)' });
                    for (var counter1 = 0; counter1 < that.rows.length; counter1++) {
                        if (counter == counter1) {
                            if (counter1 == 0) { that.totalRows[counter].conversion0 = '- - -'; }
                            if (counter1 == 1) { that.totalRows[counter].conversion1 = '- - -'; }
                            if (counter1 == 2) { that.totalRows[counter].conversion2 = '- - -'; }
                            if (counter1 == 3) { that.totalRows[counter].conversion3 = '- - -'; }
                        } else {
                            cmp = parseFloat((Number(that.rows[counter].conversion0 * 100) / Number(that.totalColumns[counter1 + 1].value)) * 100 - 100).toFixed(2);

                            if (counter1 == 0) {
                                that.totalRows[counter].conversion0 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                            }
                            if (counter1 == 1) {
                                that.totalRows[counter].conversion1 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                            }
                            if (counter1 == 2) {
                                that.totalRows[counter].conversion2 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                            }
                            if (counter1 == 3) {
                                that.totalRows[counter].conversion3 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                            }
                        }
                    }
                }


            });

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getLastUpdate",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (lastUpdate) {
                that.lastUpdateType = lastUpdate.type;
                that.lastUpdateTime = lastUpdate.timestamp;
            });

        },
        changeTarget() {
            var that = this;
            let selectedIndex = that.targetUrlsNames.indexOf(that.selectedTarget);

            that.totalColumns = [{ label: 'Varianta A/B testu', field: 'variant', tdClass: 'bold' }]; that.totalRows = [];let counter = 0,cmp =0;
            for (counter = 0; counter < that.rows.length; counter++) {
                if (selectedIndex == 0) { that.totalColumns.push({ label: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion0 * 100).toFixed(2) + '%)', field: 'conversion' + counter.toString(), thClass: 'text-center bold', html: true, tdClass: 'text-center', value: parseFloat(that.rows[counter].conversion0 * 100).toFixed(2) }); }
                if (selectedIndex == 1) { that.totalColumns.push({ label: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion1 * 100).toFixed(2) + '%)', field: 'conversion' + counter.toString(), thClass: 'text-center bold', html: true, tdClass: 'text-center', value: parseFloat(that.rows[counter].conversion1 * 100).toFixed(2) }); }
                if (selectedIndex == 2) { that.totalColumns.push({ label: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion2 * 100).toFixed(2) + '%)', field: 'conversion' + counter.toString(), thClass: 'text-center bold', html: true, tdClass: 'text-center', value: parseFloat(that.rows[counter].conversion2 * 100).toFixed(2) }); }
                if (selectedIndex == 3) { that.totalColumns.push({ label: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion3 * 100).toFixed(2) + '%)', field: 'conversion' + counter.toString(), thClass: 'text-center bold', html: true, tdClass: 'text-center', value: parseFloat(that.rows[counter].conversion3 * 100).toFixed(2) }); }
            }

            for (counter = 0; counter < that.rows.length; counter++) {
                if (selectedIndex == 0) { that.totalRows.push({ variant: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion0 * 100).toFixed(2) + '%)' }); }
                if (selectedIndex == 1) { that.totalRows.push({ variant: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion1 * 100).toFixed(2) + '%)' }); }
                if (selectedIndex == 2) { that.totalRows.push({ variant: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion2 * 100).toFixed(2) + '%)' }); }
                if (selectedIndex == 3) { that.totalRows.push({ variant: that.rows[counter].variant + ' (' + parseFloat(that.rows[counter].conversion3 * 100).toFixed(2) + '%)' }); }

                for (var counter1 = 0; counter1 < that.rows.length; counter1++) {
                    if (counter == counter1) {
                        if (counter1 == 0) { that.totalRows[counter].conversion0 = '- - -'; }
                        if (counter1 == 1) { that.totalRows[counter].conversion1 = '- - -'; }
                        if (counter1 == 2) { that.totalRows[counter].conversion2 = '- - -'; }
                        if (counter1 == 3) { that.totalRows[counter].conversion3 = '- - -'; }
                    } else {

                        if (selectedIndex == 0) { cmp = parseFloat((Number(that.rows[counter].conversion0 * 100) / Number(that.totalColumns[counter1 + 1].value)) * 100 - 100).toFixed(2); }
                        if (selectedIndex == 1) { cmp = parseFloat((Number(that.rows[counter].conversion1 * 100) / Number(that.totalColumns[counter1 + 1].value)) * 100 - 100).toFixed(2); }
                        if (selectedIndex == 2) { cmp = parseFloat((Number(that.rows[counter].conversion2 * 100) / Number(that.totalColumns[counter1 + 1].value)) * 100 - 100).toFixed(2); }
                        if (selectedIndex == 3) { cmp = parseFloat((Number(that.rows[counter].conversion3 * 100) / Number(that.totalColumns[counter1 + 1].value)) * 100 - 100).toFixed(2); }

                        if (counter1 == 0) {
                            that.totalRows[counter].conversion0 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                        }
                        if (counter1 == 1) {
                            that.totalRows[counter].conversion1 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                        }
                        if (counter1 == 2) {
                            that.totalRows[counter].conversion2 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                        }
                        if (counter1 == 3) {
                            that.totalRows[counter].conversion3 = (cmp >= 0) ? "<font class='green-class'>" + cmp + " %</font>" : "<font class='red-class'> " + cmp + " %</font>";
                        }
                    }
                }
            }


        }
	},
    created() {
        this.userUid = this.$store.state.AdminModule.adminUserKey;
        var that = this;
        let fromPath = (that.$route.query.testId != undefined) ? that.$route.query.testId : null;

        $.ajax({
            type: "POST",
            url: "https://appi.app.cz:444/getAbTests",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
        }).done(function (abtestings) {
            if (abtestings.abtesting != undefined) {
                abtestings.abtesting.forEach(function (abtesting) {
                    that.filteredList.push(abtesting);
                    if ((Vue.cookie.get('EditAbTestId') != 'null' && abtesting.id == Vue.cookie.get('EditAbTestId'))
                        || (fromPath == abtesting.id && fromPath != null)
                    ) {
                        that.selectedAbTestName = abtesting.name;
                        that.id = abtesting.id;
                        that.name = abtesting.name;
                        that.active = abtesting.active;
                        that.activateNow = abtesting.activateNow;
                        that.selectedDomain = abtesting.selectedDomain;
                        that.campaignRatio = abtesting.campaignRatio;
                        that.targetUrlsNames = abtesting.targetUrlsNames;
                        that.targetUrls = abtesting.targetUrls;
                        that.targetParamIgnore = abtesting.targetParamIgnore;
                        that.campaignDeactivate = abtesting.campaignDeactivate;
                        that.selectedCampaignIds = abtesting.selectedCampaignIds;
                        that.campaignDeactivate = abtesting.campaignDeactivate;
                        that.startDateTime = abtesting.startDateTime;
                        that.endDateTime = abtesting.endDateTime;
                        that.dayCount = abtesting.dayCount;
                        that.sendEmail = abtesting.sendEmail;
                        that.emailAddress = abtesting.emailAddress;
                        that.emailAddresses = abtesting.emailAddresses;

                        that.selectedTarget = that.targetUrlsNames[0];

                        that.calculateEndsIn();
                        setTimeout(function () {
                            that.setVariant(null,null);
                        }, 500);
                        
                        Vue.cookie.set('EditAbTestId', null, 1);
                    }
                });
            }
        });

    }

}

</script>
<style >
    table.vgt-table {
        font-size: 14px !important;
    }
</style>