<template>
    <div class="container" v-show="authUser=='true'">
        <div class="row justify-content-center">
            <div class="col-lg-11 col-xl-9">
                <div class="d-flex flex-row justify-content-between align-items-center my-3">
                    <div>
                        <input type="text" class="form-control py-2" placeholder="Napište co chcete hledat" v-model="fn_FilteredList" />
                    </div>
                    <div>
                        <a href="/NewCampaign" class="btn btn-outline-secondary btn_new" :class="{disabled: userUid != 'none'}">
                            <span class="fa fa-plus"></span> Nová kampaň
                        </a>
                    </div>
                </div>
                <div class="list-group shadow-sm">
                    <p class="list-group-item group_item_blue bold">Kampaně</p>

                    <div v-for="campaign,index in filteredList" v-if="campaign.CampaignName.toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1" class="list-group-item d-flex justify-content-between align-items-center list-group-item-action">
                        <!--list_group_button-->
                        <span class="width_100">
                            <label class="noselect" v-show="(abTestList.filter(function (abtest) {return abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && abtest.active}).length == 0 )">
                                <span class="toogle_desc">OFF</span>&nbsp;&nbsp;
                                <button type="button" class="btn btn-toggle" :class="{active: campaign.ActiveCampaign}" v-on:click="ActivateCampaign(campaign.campaignID)" v-bind:value="campaign.ActiveCampaign" data-toggle="button" aria-pressed="true" autocomplete="off">
                                    <div class="handle"></div>
                                </button>
                                &nbsp;&nbsp;<span class="toogle_desc">ON</span>
                            </label>

                            <label style="width:25px" v-show="(abTestList.filter(function (abtest) {return abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && abtest.active}).length > 0 )" v-tooltip.bottom.end.click="{class: 'v-tooltip_shown', html:'abTests_' + campaign.campaignID }" class="monitor_ico_label list_group_button" title="Použito v A/B testu" alt="Použito v A/B testu">
                                <i class="fas fa-lock" style="margin: 0px 0px 0px 4px;">
                                    <span v-bind:id="'abTests_'+campaign.campaignID" class="text-left" style="left:-120px;">
                                        <div class="width_100 text-left tooltip_label" v-for="abtest,index in abTestList.filter(function (abtest) {return abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1})" style="padding-top: 0px">{{abtest.name }}</div>
                                    </span>
                                </i>
                            </label>
                            <span class="margin-desc">{{campaign.CampaignName}}</span>

                            <span>

                                <img v-tooltip.bottom.end.click="{class: 'v-tooltip_ownAppi', html:'own_' + campaign.campaignID }" v-if="checkMessage(campaign.CampaignName,'OwnAppi')" src="/images/product/offer.svg" class="navbar-toggler-icon svg_img_ico" style="padding-right:5px;" alt="TOP nabídky" Title="TOP nabídky" />
                                <span v-bind:id="'own_'+campaign.campaignID" class="text-left" style="left:-120px;" v-if="checkMessage(campaign.CampaignName,'OwnAppi')">
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Aktivní TOP nabídky</div>
                                    <div v-if="campaign.OwnAppi.ownAppiActive[0]" class="width_100 tooltip_urlIn text-left">{{campaign.OwnAppi.OwnAppi1Name}}</div>
                                    <div v-if="campaign.OwnAppi.ownAppiActive[1]" class="width_100 tooltip_urlIn text-left">{{campaign.OwnAppi.OwnAppi2Name}}</div>
                                    <div v-if="campaign.OwnAppi.ownAppiActive[2]" class="width_100 tooltip_urlIn text-left">{{campaign.OwnAppi.OwnAppi3Name}}</div>
                                    <div v-if="campaign.OwnAppi.ownAppiActive[3]" class="width_100 tooltip_urlIn text-left">{{campaign.OwnAppi.OwnAppi4Name}}</div>
                                    <div v-if="campaign.OwnAppi.ownAppiActive[4]" class="width_100 tooltip_urlIn text-left">{{campaign.OwnAppi.OwnAppi5Name}}</div>
                                </span>

                                <img v-tooltip.bottom.end.click="{class: 'v-tooltip_zbozi', html:'zbo_' + campaign.campaignID }" v-if="checkMessage(campaign.CampaignName,'Zbozi')" src="/images/product/zbozi.svg" class="navbar-toggler-icon svg_img_ico" style="padding-right:5px;width:34px;" alt="Recenze Zboží.cz" Title="Recenze Zboží.cz" />
                                <span v-bind:id="'zbo_'+campaign.campaignID" class="text-left" style="left:-120px;" v-if="checkMessage(campaign.CampaignName,'Zbozi')">
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Přiřazený API klíč</div>
                                    <div v-if="campaign.zboziAPIkey !== ''" class="width_100 tooltip_urlIn text-left">{{campaign.zboziAPIkeyName}}</div>

                                    <div class="width_100 text-left pt-3">
                                        <div class="width_100 text-left tooltip_label">Aktivní notifikace</div>
                                        <div class="width_100 tooltip_urlIn text-left" v-if="campaign.Zbozi.ZboziShopActive">Zobrazuje hodnocení e-shopu</div>
                                        <div class="width_100 tooltip_urlIn text-left" v-if="campaign.Zbozi.ZboziProductActive">Zobrazuje recenze produktů</div>
                                    </div>
                                </span>

                                <img v-tooltip.bottom.end.click="{class: 'v-tooltip_review', html:'rev_' + campaign.campaignID }" v-if="checkMessage(campaign.CampaignName,'Heureka')" v-bind:src="(Math.trunc(((100/5) * campaign.heurekaLastScore)) >= 80)?'/images/product/reviews.svg':'/images/product/reviewsBadScore.svg'" class="navbar-toggler-icon svg_img_ico" style="padding-right:5px;" v-bind:alt="(Math.trunc(((100/5) * campaign.heurekaLastScore)) >= 80)?'Recenze Heureka.cz':'Zobrazení notifikací zastaveno.\nPrůměrné hodnocení e-shopu kleslo pod 80 %.'" v-bind:Title="(Math.trunc(((100/5) * campaign.heurekaLastScore)) >= 80)?'Recenze Heureka.cz':'Zobrazení notifikací zastaveno.\nPrůměrné hodnocení e-shopu kleslo pod 80 %.'" />
                                <span v-bind:id="'rev_'+campaign.campaignID" class="text-left" style="left:-120px;" v-if="checkMessage(campaign.CampaignName,'Heureka')">
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Přiřazený API klíč / Aktuální Skóre</div>
                                    <div v-if="campaign.heurekaAPIkey !== ''" class="width_100 tooltip_urlIn text-left">{{campaign.heurekaAPIkeyName +' / ' + Math.trunc(((100/5) * campaign.heurekaLastScore))+'%' }}</div>
                                </span>

                                <img v-tooltip.bottom.end.click="{class: 'v-tooltip_statistics', html:'stat_' + campaign.campaignID }" v-if="checkMessage(campaign.CampaignName,'Statistics')" src="/images/product/statistics.svg" class="navbar-toggler-icon svg_img_ico" style="padding-right:5px;" alt="Souhrnné statistiky" Title="Souhrnné statistiky" />
                                <span v-bind:id="'stat_'+campaign.campaignID" class="text-left" style="left:-120px;" v-if="checkMessage(campaign.CampaignName,'Statistics')">
                                    <div class="width_100 text-left" v-if="campaign.Statistics.SelectedStatsVariant == 'pages'">
                                        <div class="width_100 text-left tooltip_label">Vybraná varianta: Souhrn stránek</div>
                                        <div class="width_100 tooltip_urlIn text-left" v-if="campaign.Statistics.ShowStatsDomainVisitCount">Počet zobrazení stránky celá domény</div>
                                        <div class="width_100 tooltip_urlIn text-left" v-if="!campaign.Statistics.ShowStatsDomainVisitCount">Počet zobrazení stránky</div>
                                    </div>
                                    <div class="width_100 text-left" v-if="campaign.Statistics.SelectedStatsVariant == 'visitor'">
                                        <div class="width_100 text-left tooltip_label">Vybraná varianta: Souhrn návštěvníků</div>
                                        <div class="width_100 tooltip_urlIn text-left" v-if="campaign.Statistics.ShowStatsDomainVisitCount">Celá doména</div>
                                        <div class="width_100 tooltip_urlIn text-left" v-if="!campaign.Statistics.ShowStatsDomainVisitCount">Návštěvníci stránky</div>
                                    </div>
                                    <div class="width_100 text-left" v-if="campaign.Statistics.SelectedStatsVariant == 'order'">
                                        <div class="width_100 text-left tooltip_label">Vybraná varianta: Souhrn objednávek</div>
                                    </div>
                                    <div class="width_100 text-left" v-if="campaign.Statistics.SelectedStatsVariant == 'registration'">
                                        <div class="width_100 text-left tooltip_label">Vybraná varianta: Souhrn registrací</div>
                                    </div>
                                    <div class="width_100 text-left" v-for="rule, rindex in campaign.CaptureRuleStat" v-if="campaign.Statistics.SelectedStatsVariant != 'visitor' && campaign.Statistics.SelectedStatsVariant != 'pages'">
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'startWith'">Začíná na</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'exactmatch'">Shoduje se</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'contains'">Obsahuje</div>
                                        <div v-for="CapturedUrlsIn in campaign.CapturedUrlsStatIn[rindex].split(',')" v-if="CapturedUrlsIn !== ''" class="width_100 tooltip_urlIn text-left">+ {{CapturedUrlsIn}}</div>
                                        <div v-for="CapturedUrlsOut in campaign.CapturedUrlsStatOut[rindex].split(',')" v-if="CapturedUrlsOut !== ''" class="width_100 tooltip_urlOut text-left">- {{CapturedUrlsOut}}</div>
                                    </div>
                                </span>

                                <img v-tooltip.bottom.end.click="{class: 'v-tooltip_visit', html:'vis_' + campaign.campaignID }" v-if="checkMessage(campaign.CampaignName,'VisitCount')" src="/images/product/visits.svg" class="navbar-toggler-icon svg_img_ico" style="padding-right:5px;" alt="Počet návštěv" Title="Počet návštěv" />
                                <span v-bind:id="'vis_'+campaign.campaignID" class="text-left" style="left:-120px;" v-if="checkMessage(campaign.CampaignName,'VisitCount')">
                                    <div class="width_100 text-left tooltip_label" style="padding-top: 0px;">Zobrazení návštěvníků</div>
                                    <div v-if="campaign.VisitCount.ShowDomainVisitCount" class="width_100 tooltip_urlIn text-left">Celá doména</div>
                                    <div v-if="!campaign.VisitCount.ShowDomainVisitCount" class="width_100 tooltip_urlIn text-left">Návštěvníci stránky</div>
                                </span>

                                <img v-tooltip.bottom.end.click="{class: 'v-tooltip_registration', html:'reg_' + campaign.campaignID }" v-if="checkMessage(campaign.CampaignName,'LastEventsRegistrations')" src="/images/product/registration.svg" class="navbar-toggler-icon svg_img_ico" style="padding-right:5px;" alt="Poslední události Registrace" Title="Poslední události Registrace" />
                                <span v-bind:id="'reg_'+campaign.campaignID" class="text-left" style="left:-120px;" v-if="checkMessage(campaign.CampaignName,'LastEventsRegistrations')">
                                    <div class="width_100 text-left" v-for="rule, rindex in campaign.CaptureRuleReg">
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'startWith'">Začíná na</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'exactmatch'">Shoduje se</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'contains'">Obsahuje</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'domain'">Název domény</div>
                                        <div v-for="CapturedUrlsIn in campaign.CapturedUrlsRegIn[rindex].split(',')" v-if="CapturedUrlsIn !== ''" class="width_100 tooltip_urlIn text-left">+ {{CapturedUrlsIn}}</div>
                                        <div v-for="CapturedUrlsOut in campaign.CapturedUrlsRegOut[rindex].split(',')" v-if="CapturedUrlsOut !== ''" class="width_100 tooltip_urlOut text-left">- {{CapturedUrlsOut}}</div>
                                    </div>
                                </span>

                                <img v-tooltip.bottom.end.click="{class: 'v-tooltip_order', html:'obj_' + campaign.campaignID}" v-if="checkMessage(campaign.CampaignName,'LastEventsOrders')" src="/images/product/orders.svg" class="navbar-toggler-icon svg_img_ico" style="padding-right:5px;" alt="Poslední události Objednávky" Title="Poslední události Objednávky" />
                                <span v-bind:id="'obj_'+campaign.campaignID" class="text-left" style="left:-120px;" v-if="checkMessage(campaign.CampaignName,'LastEventsOrders')">
                                    <div class="width_100 text-left" v-for="rule, rindex in campaign.CaptureRuleObj" v-if="rule !== ''">
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'startWith'">Začíná na</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'exactmatch'">Shoduje se</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'contains'">Obsahuje</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'domain'">Název domény</div>
                                        <div v-for="CapturedUrlsIn in campaign.CapturedUrlsObjIn[rindex].split(',')" v-if="CapturedUrlsIn !== ''" class="width_100 tooltip_urlIn text-left">+ {{CapturedUrlsIn}}</div>
                                        <div v-for="CapturedUrlsOut in campaign.CapturedUrlsObjOut[rindex].split(',')" v-if="CapturedUrlsOut !== ''" class="width_100 tooltip_urlOut text-left">- {{CapturedUrlsOut}}</div>
                                    </div>
                                </span>

                            </span>
                        </span>


                        <label v-tooltip.bottom.end.click="{class: 'v-tooltip_shown', html:'shown_' + campaign.campaignID }" class="monitor_ico_label list_group_button" title="URL zobrazení kampaně" alt="URL zobrazení kampaně">
                            <i class="fa fa-desktop monitor_ico">
                                <span v-bind:id="'shown_'+campaign.campaignID" class="text-left" style="left:-120px;">
                                    <div class="width_100 text-left" v-for="rule, rindex in campaign.ShownRule">
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'startWith'">Začíná na</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'exactmatch'">Shoduje se</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'contains'">Obsahuje</div>
                                        <div class="width_100 text-left tooltip_label" v-bind:style="[(rindex == 0 ) ? {'padding-top': '0px'} :{'padding-top': '8px'}]" v-if="rule == 'domain'">Název domény</div>
                                        <div v-for="CapturedUrlsIn in campaign.ShownUrlsIn[rindex].split(',')" v-if="CapturedUrlsIn !== ''" class="width_100 tooltip_urlIn text-left">+ {{CapturedUrlsIn}}</div>
                                        <div v-for="CapturedUrlsOut in campaign.ShownUrlsOut[rindex].split(',')" v-if="CapturedUrlsOut !== ''" class="width_100 tooltip_urlOut text-left"> - {{CapturedUrlsOut}}</div>
                                    </div>
                                </span>
                            </i>
                        </label>
                        
                        <i class="fas fa-globe is-invalid" v-if="!campaign.ignoreDomain && (userUid != 'none' || adminAccount)" style="padding-left: 5px;margin: 0px;font-size: 25px;" title="Doména není ignorována" alt="Doména není ignorována"></i>
                        <i class="fas fa-globe mycolor" v-if="campaign.ignoreDomain && (userUid != 'none' || adminAccount)" style="padding-left: 5px;margin: 0px;font-size: 25px;"  title="Doména je ignorována"  alt="Doména je ignorována"></i>

                        <span class="" v-if="campaign.selectedLanguage == 'cs' "><img src="/images/flags/cz.png" title="česky" alt="česky" class="png_img_flag" /></span>
                        <span class="" v-if="campaign.selectedLanguage == 'sk' "><img src="/images/flags/sk.png" title="slovensky" alt="slovensky" class="png_img_flag" /></span>
                        <span class="" v-if="campaign.selectedLanguage == 'en' "><img src="/images/flags/en.png" title="anglicky" alt="anglicky" class="png_img_flag" /></span>

                        <span class="fa"></span>
                        <span class="fa"></span>
                        <span class="fa"></span>
                        <a class="btn btn-outline-secondary" :class="{disabled: (abTestList.filter(function (abtest) {return abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && abtest.active}).length > 0 )}" style="padding-right: 3px;" title="Editovat" alt="Editovat" v-on:click="(abTestList.filter(function (abtest) {return abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && abtest.active}).length == 0 ) ? editCampaign(campaign.campaignID,campaign): ''">
                            <span class="fas fa-pencil-alt"></span>
                        </a>
                        <span class="fa"></span>
                        <a class="btn btn-outline-secondary_orange" style="padding-right: 3px;" title="Kopírovat" alt="Kopírovat" v-on:click="copyCampaign(campaign.CampaignName,campaign)">
                            <span class="fas fa-copy"></span>
                        </a>
                        <span class="fa"></span>
                        <a class="btn btn-outline-secondary_red" :class="{disabled: (abTestList.filter(function (abtest) {return abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && abtest.active}).length > 0 )}" style="padding-right: 3px;" title="Smazat" alt="Smazat" v-on:click="(abTestList.filter(function (abtest) {return abtest.selectedCampaignIds.indexOf(campaign.campaignID) > -1 && abtest.active}).length == 0 ) ?deleteCampaign(campaign.CampaignName,campaign.campaignID,index) : ''">
                            <span class="fa fa-trash"></span>
                        </a>
                    </div>

                    <div class="list-group-item text-center" v-if="filteredList.length == 0">
                        <span class="my-5 rounded-circle">
                            <img src="/images/new_campaign1.png" class="img-fluid" />
                        </span>
                        <!--<h5>Ahoj začni svoji novou kampaň právě teď</h5>-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import SlimDialog from 'v-slim-dialog';
    import Vue from 'vue';
	import VueCookie from 'vue-cookie';

	Vue.use(VueCookie);
	Vue.use(SlimDialog);
	
    export default {
	data() {
        return {
            adminAccount: false,
            userUid: "none",
            userEmail: null,
          //  CustomerUrlList: [],
            filteredList: [],
            abTestList: [],
            ActiveCampaigns: [],
			fn_FilteredList: "",
            authUser: Vue.cookie.get('logged') || false,
		}
	},
	methods: {
        deleteCampaign(CampaignName,campaignID,index) {
        var that = this;
		const options = {title: 'Smazání kampaně', cancelLabel: 'Ne', size: 'sm'}
		this.$dialogs.confirm('Chcete opravdu smazat kampaň: '+CampaignName, options)
			.then(res => {
                if (res.ok) {
                    $.ajax({
                        type: "POST",
                        url: "https://appi.app.cz:444/delete_campaigns",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: JSON.stringify({ session: Vue.cookie.get('session'), campaignID: campaignID, uuid: that.userUid })
                    }).done(function (data) {
                        if (data.result === 1) {
                            that.filteredList = [];
                            $.ajax({
                                type: "POST",
                                url: "https://appi.app.cz:444/get_campaigns",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                            }).done(function (dataCampaigns) {
                                if (dataCampaigns.campaigns != undefined) {
                                    dataCampaigns.campaigns.forEach(function (campaign) {
                                        that.filteredList.push(campaign);
                                    })
                                }
                            });
                        }
                    });
                }
			});
	    },	
        checkMessage(CampaignName,searched){
		    var result = false;
            var res = this.filteredList.filter(function (object) {
                if (object['CampaignName']===CampaignName){
                result = ((object['SelectedMessages'].indexOf(searched) >-1) ? true : false);
                return ((object['SelectedMessages'].indexOf(searched) >-1) ? true : false);
				}
			});
			return result;
		},
		
        ActivateCampaign(CampaignId) {
            var that = this;
            var selectedCampaign = "";
            var checkFail = false;
            that.filteredList.forEach(function (getSelectedCampaign) {
                if (getSelectedCampaign.campaignID == CampaignId) {
                    getSelectedCampaign.ActiveCampaign = !getSelectedCampaign.ActiveCampaign;
                    selectedCampaign = getSelectedCampaign;
                }
            });

            if (!checkFail) {
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/update_campaigns",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), campaignID: CampaignId, uuid: that.userUid, ActiveCampaign: selectedCampaign.ActiveCampaign })
                }).done(function (data) {
                    if (data.result === 1) {
                    }
                });
            }
        },

        editCampaign(CampaignID, campaignData) {
            this.$store.state.VisitCount.MessageText = campaignData.VisitCount.MessageText;
            Vue.cookie.set('EditCampaignID', CampaignID, 1);
            if (this.userUid != null) {
                this.$router.push({ path: '/NewCampaign' });
            } else {
                window.location.pathname = '/NewCampaign';
            }
        },
        formatUrlArray(array) {
            var tmpArray = [];
            array.forEach(function (rule, index) {
                tmpArray.push(rule.split(','));
            });
            return tmpArray;
        },
        copyCampaign(CampaignName,campaign) {
            var that = this;
            var newCampaign = JSON.parse(JSON.stringify(campaign));
            const options = { title: 'Kopírování kampaně', cancelLabel: 'Ne', size: 'sm' }
            this.$dialogs.confirm('Chcete opravdu zkopírovat kampaň: ' + CampaignName + ' ?', options)
                .then(res => {
                    if (res.ok) {
                        newCampaign.CampaignName = CampaignName + " " + new Date().toLocaleString().replace(/\s/g, '');
                        newCampaign.CapturedUrlsObjIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsObjIn)).replace(/""/g, ''));
                        newCampaign.CapturedUrlsObjOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsObjOut)).replace(/""/g, ''));
                        newCampaign.CapturedUrlsStatIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsStatIn)).replace(/""/g, ''));
                        newCampaign.CapturedUrlsStatOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsStatOut)).replace(/""/g, ''));
                        newCampaign.CapturedUrlsRegIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsRegIn)).replace(/""/g, ''));
                        newCampaign.CapturedUrlsRegOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.CapturedUrlsRegOut)).replace(/""/g, ''));
                        newCampaign.ShownUrlsIn = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.ShownUrlsIn)).replace(/""/g, ''))
                        newCampaign.ShownUrlsOut = JSON.parse(JSON.stringify(that.formatUrlArray(campaign.ShownUrlsOut)).replace(/""/g, ''))
                        newCampaign.ActiveCampaign= false;
                        delete newCampaign.campaignID;
                        newCampaign.session = Vue.cookie.get('session');
                        newCampaign.uuid = that.userUid;
                        $.ajax({
                            type: "POST",
                            url: "https://appi.app.cz:444/update_campaigns",
                            dataType: "json",
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify(newCampaign)
                        }).done(function (data) {
                            if (data.result === 1) {
                                that.filteredList = [];
                                $.ajax({
                                    type: "POST",
                                    url: "https://appi.app.cz:444/get_campaigns",
                                    dataType: "json",
                                    contentType: 'application/json; charset=utf-8',
                                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                                }).done(function (dataCampaigns) {
                                    if (dataCampaigns.campaigns != undefined) {
                                        dataCampaigns.campaigns.forEach(function (campaign) {
                                            that.filteredList.push(campaign);
                                        })
                                    }
                                });
                            }
                        });
                    }
                });
        },
	},
	watch: {
	},
    beforeCreate() {
        this.authUser = Vue.cookie.get('logged') || false;
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
        Vue.cookie.set('EditCampaignID', null, 1);
        this.$store.state.CampaignData = [];
        this.$store.state.AllCampaignData = [];
        this.userUid = this.$store.state.AdminModule.adminUserKey;
        var that = this;
        $.ajax({
            type: "POST",
            url: "https://appi.app.cz:444/get_campaigns",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ session: Vue.cookie.get('session'), uuid : that.userUid })
        }).done(function (dataCampaigns) {
            if (dataCampaigns.campaigns != undefined) {
                dataCampaigns.campaigns.forEach(function (campaign) {
                    that.filteredList.push(campaign);
                       
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
                abtestings.abtesting.forEach(function (abtesting) {
                    that.abTestList.push(abtesting);
                });
            }
        });
           
	}
	
}

</script>