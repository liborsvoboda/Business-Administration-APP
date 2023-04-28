<template>
    <div class="container" v-show="authUser=='true'">
        <div class="row justify-content-center">
            <div class="col-lg-11 col-xl-9">
                <div class="d-flex flex-row justify-content-between align-items-center my-3">
                    <div>
                        <input type="text" class="form-control py-2" placeholder="Napište co chcete hledat" v-model="fn_FilteredList" />
                    </div>
                    <div>
                        <div>
                            <a href="/NewAbTest" class="btn btn-outline-secondary btn_new" :class="{disabled: userUid != 'none'}">
                                <span class="fa fa-plus"></span> Nový A/B test
                            </a>
                        </div>
                    </div>
                </div>

                <div class="list-group shadow-sm">
                    <p class="list-group-item group_item_blue bold">A/B testy</p>

                    <div v-for="abtesting,index in filteredList" v-if="abtesting.name.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1" class="list-group-item d-flex justify-content-between align-items-center list-group-item-action">
                        <!--list_group_button-->
                        <span class="width_100">

                            <i style="color:#7dc542; opacity:1;" class="fa fa-question-circle pointer"
                               v-if="(abtesting.active &&  new Date(abtesting.startDateTime) <= Date.now() && new Date(abtesting.endDateTime) >= Date.now())"
                               v-tooltip.top="{ content: 'A/B test probíhá' }"></i>
                            <i style="color:#ed6b27; opacity:1;" class="fa fa-question-circle pointer"
                               v-else-if="(abtesting.active && new Date(abtesting.startDateTime) >= Date.now())"
                               v-tooltip.top="{ content: 'A/B test bude spuštěn v naplánovaném čase' }"></i>
                            <i style="color:#dc3545; opacity:1;" class="fa fa-question-circle pointer"
                               v-else-if="(!abtesting.active && new Date(abtesting.endDateTime) <= Date.now())"
                               v-tooltip.top="{ content: 'A/B test již není aktivní' }"></i>
                            <i style="color:#dc3545; opacity:1;" class="fa fa-question-circle pointer"
                               v-else-if="(!abtesting.active)"
                               v-tooltip.top="{ content: 'A/B test není aktivní' }"></i>

                            <!--<label class="noselect">
            <span class="toogle_desc">OFF</span>&nbsp;&nbsp;
            <button type="button" class="btn btn-toggle" :class="{active: abtesting.active}" v-on:click="ActivateAbTest(abtesting.id)" v-bind:value="abtesting.active" data-toggle="button" aria-pressed="true" autocomplete="off">
                <div class="handle"></div>
            </button>
            &nbsp;&nbsp;<span class="toogle_desc">ON</span>
        </label>-->

                            <span class="fa"></span>
                            <a class="btn btn-outline-secondary_red" v-if="abtesting.active" style="padding-right: 3px;" title="Ukončit A/B test" alt="Ukončit A/B test" v-on:click="ActivateAbTest(abtesting.id,abtesting)">
                                <span class="fas fa-stop"></span>
                            </a>
                            <span class="fa"></span>
                            <span class="margin-desc">{{abtesting.name}}</span>


                        </span>

                        <label v-tooltip.bottom.end.click="{class: 'v-tooltip_shown', html:'running_' + abtesting.id }" class="monitor_ico_label list_group_button" title="Časový interval testu" alt="Časový interval testu">
                            <i class="far fa-clock" style="margin: 3px 0px 0px 4px;width: 20px;">
                                <span v-bind:id="'running_'+abtesting.id" class="text-left" style="left:-120px;">
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 0px">Začátek: {{new Date(abtesting.startDateTime).toLocaleDateString("cs-CZ").replace(/\s+/g, '') + ' v ' + new Date(abtesting.startDateTime).toLocaleTimeString("cs-CZ") }}</div>
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 8px">Konec:   {{new Date(abtesting.endDateTime).toLocaleDateString("cs-CZ").replace(/\s+/g, '') + ' v ' + new Date(abtesting.endDateTime).toLocaleTimeString("cs-CZ") }}</div>
                                </span>
                            </i>
                        </label>

                        <label v-tooltip.bottom.end.click="{class: 'v-tooltip_shown', html:'shown_' + abtesting.id }" class="monitor_ico_label list_group_button ml-2 " title="Nastavení" alt="Nastavení">
                            <i class="fas fa-cog" style="margin: 3px 0px 0px 3px;width:20px">
                                <span v-bind:id="'shown_'+abtesting.id" class="text-left" style="left:-120px;">
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 0px">Varianty A/B testu</div>
                                    <div class="width_100 text-left">
                                        <div v-for="campaignId in abtesting.selectedCampaignIds" class="width_100 tooltip_urlIn text-left"> {{getCampaignName(campaignId)}}</div>
                                    </div>

                                    <div class="width_100 text-left tooltip_label" style="padding-top: 8px">Cíle A/B testu</div>
                                    <div class="width_100 text-left">
                                        <div v-for="url,index in abtesting.targetUrls" v-if="url !== ''" class="width_100 tooltip_urlIn text-left pb-2">
                                            <div> {{abtesting.targetUrlsNames[index]}}</div>                                       
                                            <div> {{url}}</div>
                                        </div>
                                    </div>
                                </span>
                            </i>
                        </label>

                        <label v-tooltip.bottom.end.click="{class: 'v-tooltip_shown', html:'email_' + abtesting.id }" v-if="abtesting.sendEmail" class="monitor_ico_label list_group_button ml-2" title="Zaslat upozornění na e-mail" alt="Zaslat upozornění na e-mail">
                            <i class="fas fa-envelope" style="margin: 3px 0px 0px 4px;width: 20px;">
                                <span v-bind:id="'email_'+abtesting.id" class="text-left" style="left:-120px;">
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 0px">Primární adresa: {{abtesting.emailAddress}}</div>
                                    <div class="width_100 text-left tooltip_label" v-if="(abtesting.emailAddresses.length > 0)" style="padding-top: 8px">Další příjemci:</div>
                                    <div class="width_100 text-left tooltip_label" v-for="email,index in abtesting.emailAddresses.split(';')" v-if="(abtesting.emailAddresses.length > 0)" style="padding-top: 0px">{{email}}</div>
                                </span>
                            </i>
                        </label>

                        <span class="fa"></span>
                        <span class="fa"></span>
                        <span class="fa"></span>
                        <a class="btn btn-outline-secondary_orange" :class="{disabled: (new Date(abtesting.startDateTime) >= Date.now()) }" style="padding-right: 3px;" title="Statistiky" alt="Statistiky" v-on:click="showStatistics('AbGraphs',abtesting.id)">
                            <span class="fas fa-chart-bar"></span>
                        </a>
                        <span class="fa"></span>
                        <a class="btn btn-outline-secondary_orange" style="padding-right: 3px;" title="Kopírovat" alt="Kopírovat" v-on:click="copyAbTest(abtesting.name,abtesting)">
                            <span class="fas fa-copy"></span>
                        </a>
                        <span class="fa"></span>
                        <a class="btn btn-outline-secondary" style="padding-right: 3px;" title="Editovat" alt="Editovat" v-on:click="editAbTest(abtesting.id,abtesting)">
                            <span class="fas fa-pencil-alt"></span>
                        </a>
                        <span class="fa"></span>
                        <a class="btn btn-outline-secondary_red" style="padding-right: 3px;" title="Smazat" alt="Smazat" v-on:click="deleteAbTest(abtesting.id,abtesting)">
                            <span class="fa fa-trash"></span>
                        </a>
                    </div>

                    <div class="list-group-item text-center" v-if="filteredList.length == 0">
                        <span class="my-5 rounded-circle">
                            <img src="/images/new_abtest.png" class="img-fluid" />
                        </span>
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

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

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
	    data() {
            return {
                userUid: "none",
                filteredList: [],
                CampaignList: [{ campaignID: 0, CampaignName: "bez app" }],
                showNewAbTest: true,
                firstOpen: false,
			    fn_FilteredList: "",
                authUser: Vue.cookie.get('logged') || false,

                id:null,
                name: "",
                active: false,
                selectedDomain: "",
                targetUrls: [""],
                selectedCampaignIds:[""]


		    }
	    },
        methods: {
            getCampaignName(campaignId) {
                let result = '';
                this.CampaignList.forEach((campaign, index, arr) => {
                    if (campaign.campaignID == campaignId) { return result = campaign.CampaignName; }
                });
                return result;
            },
            showStatistics(route, id) {
                Vue.cookie.set('EditAbTestId', id, 1);
                this.$router.push({ path: '/' + route });
            },
            editAbTest(id, abtest) {
                //if (abtest.active &&  new Date(abtest.startDateTime) <= Date.now() && new Date(abtest.endDateTime) >= Date.now()) {
                //    var that = this;
                //    const options = { title: 'Editace A/B Testu', size: 'sm' }
                //    this.$dialogs.alert('Spuštěný test nelze editovat. ', options)
                //        .then(res => {
                //            if (res.ok) { }
                //        });
                //} else {
                    Vue.cookie.set('EditAbTestId', id, 1);
                    if (this.userUid != null) {
                        this.$router.push({ path: '/NewAbTest' });
                    } else {
                        window.location.pathname = '/NewAbTest';
                    }
              //  }
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
            copyAbTest(name, abtest) {
                var that = this;
                const options = { title: 'Kopírování A/B testu', cancelLabel: 'Ne', size: 'sm' }
                this.$dialogs.confirm('Chcete opravdu zkopírovat A/B test: ' + name + ' ?', options)
                    .then(res => {
                        if (res.ok) {
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/updateAbTest",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({
                                    session: Vue.cookie.get('session'),
                                    id: 0,
                                    uuid: that.userUid,
                                    name: abtest.name + " " + new Date().toLocaleString().replace(/\s/g, ''),
                                    active: false,
                                    activateNow: abtest.activateNow,
                                    selectedDomain: abtest.selectedDomain,
                                    campaignRatio: abtest.campaignRatio,
                                    campaignDeactivate: abtest.campaignDeactivate,
                                    targetParamIgnore: abtest.targetParamIgnore,
                                    targetUrlsNames: abtest.targetUrlsNames,
                                    targetUrls: abtest.targetUrls,
                                    selectedCampaignIds: abtest.selectedCampaignIds,
                                    startDateTime: new Date(Date.now() + 3600000).toISOString(),
                                    endDateTime: new Date(Date.now() + Number(abtest.dayCount) * 86400000).toISOString(),
                                    dayCount: abtest.dayCount,
                                    sendEmail: abtest.sendEmail,
                                    emailAddress: abtest.emailAddress,
                                    emailAddresses: abtest.emailAddresses
                                })
                            }).done(function (data) {
                                if (data.result === 1) {
                                    that.filteredList = [];
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
                                            });
                                        }
                                    });
                                }
                            }).catch((err) => {
                            });


                        }
                    });
            },
            deleteAbTest(id, abtest) {
                var that = this;
                if (new Date(abtest.startDateTime) >= Date.now()) {
                    const options = { title: 'Smazání A/B testu', cancelLabel: 'Ne', size: 'sm' }
                    this.$dialogs.confirm('Chcete opravdu smazat A/B test: ' + abtest.name+'?', options)
                        .then(res => {
                            if (res.ok) {
                                $.ajax({
                                    type: "POST",
                                    url: "https://appi.app.cz:444/deleteAbTest",
                                    dataType: "json",
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify({ session: Vue.cookie.get('session'), id: id, uuid: that.userUid })
                                }).done(function (data) {
                                    if (data.result === 1) {
                                        that.filteredList = [];
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
                                                });
                                            }
                                        });
                                    }
                                });
                            }
                        });
                } else if (!abtest.active && new Date(abtest.startDateTime) <= Date.now()) {
                    const options = { title: 'Smazání A/B testu', cancelLabel: 'Ne', size: 'sm' }
                    this.$dialogs.confirm('Chcete opravdu smazat A/B test: ' + abtest.name + ' včetně statistik?', options)
                        .then(res => {
                            if (res.ok) {

                                //delete statistics

                                $.ajax({
                                    type: "POST",
                                    url: "https://appi.app.cz:444/deleteAbTest",
                                    dataType: "json",
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify({ session: Vue.cookie.get('session'), id: id, uuid: that.userUid })
                                }).done(function (data) {
                                    if (data.result === 1) {
                                        that.filteredList = [];
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
                                                });
                                            }
                                        });
                                    }
                                });
                            }
                       });

                }
                else if (abtest.active) {
                    const options = { title: 'Smazání A/B testu', size: 'sm' }
                    this.$dialogs.alert('Nejdříve zastavte probíhající A/B test: ' + abtest.name, options)
                        .then(res => {
                            //if (res.ok) {}
                        });
                }
	        },	
		
            ActivateAbTest(id, abtest) {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/updateAbTest",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), id: id, uuid: that.userUid, active: !abtest.active })
                }).done(function (data) {
                    if (data.result === 1) {
                        that.filteredList = [];
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
                                });
                            }
                        });
                    }
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
                url: "https://appi.app.cz:444/getAbTests",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid : that.userUid })
            }).done(function (abtestings) {
                if (abtestings.abtesting != undefined) {
                    abtestings.abtesting.forEach(function (abtesting) {
                        that.filteredList.push(abtesting);

                    });
                    if (that.filteredList.length > 0) {
                        if (!that.firstOpen) {
                            that.showNewAbTest = false;
                            that.firstOpen = true;
                        }
                    }
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


	    }
    }

</script>