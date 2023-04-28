<template>
    <div v-show="authUser=='true'">
        <div class="container-fluid new_campaign_container text-center">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="new_campaign_h3" v-if="selectedCampaignName == null">Spusťte novou kampaň</h3>
                        <h3 class="new_campaign_h3" v-else-if="selectedCampaignName != null">Editace kampaně: {{selectedCampaignName}}</h3>
                    </div>
                </div>
            </div>
        </div>
        <keep-alive>
            <component v-bind:is="selectedComponents" v-on:changeComponent="selectedComponents = $event"></component>
        </keep-alive>
        <app-settings-heureka></app-settings-heureka>
        <app-settings-zbozi></app-settings-zbozi>
        <app-settings-visits></app-settings-visits>
        <app-settings-orders></app-settings-orders>
        <app-settings-registrations></app-settings-registrations>
        <app-settings-statistics></app-settings-statistics>
        <app-settings-ownAppi></app-settings-ownAppi>
    </div>
</template>

<script>
    import newCampaignStep1 from "./newCampaign-step1.vue"
    import newCampaignStep2_obj from "./newCampaign-step2_obj.vue"
    import newCampaignStep2_reg from "./newCampaign-step2_reg.vue"
    import newCampaignStep2_visit from "./newCampaign-step2_visit.vue"
    import newCampaignStep2_stat from "./newCampaign-step2_stat.vue"
    import newCampaignStep2_rev from "./newCampaign-step2_rev.vue"
    import newCampaignStep2_zbozi from "./newCampaign-step2_zbozi.vue"
    import newCampaignStep2_ownAppi from "./newCampaign-step2_ownAppi.vue"
    import newCampaignStep3 from "./newCampaign-step3.vue"
    import newCampaignStep4 from "./newCampaign-step4.vue"

    import SettingsHeureka from "./newCampaign-settingsHeureka.vue";
    import SettingsZbozi from "./newCampaign-settingsZbozi.vue";
    import SettingsVisits from "./newCampaign-settingsVisits.vue";
    import SettingsOrders from "./newCampaign-settingsOrders.vue";
    import SettingsRegistrations from "./newCampaign-settingsRegistrations.vue";
    import SettingsStatistics from "./newCampaign-settingsStatistics.vue";
    import SettingsOwnAppi from "./newCampaign-settingsOwnAppi.vue";

	import Vue from 'vue';
    import VueCookie from 'vue-cookie';
    import VueI18n from 'vue-i18n';

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

    import VeeValidate from 'vee-validate';
    import SlimDialog from 'v-slim-dialog';

    Vue.use(SlimDialog);
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
        components: {
            "app-new-campaign-Step1": newCampaignStep1,
            "app-new-campaign-Step2_obj": newCampaignStep2_obj,
            "app-new-campaign-Step2_reg": newCampaignStep2_reg,
            "app-new-campaign-Step2_visit": newCampaignStep2_visit,
            "app-new-campaign-Step2_stat": newCampaignStep2_stat,
            "app-new-campaign-Step2_rev": newCampaignStep2_rev,
            "app-new-campaign-Step2_zbozi": newCampaignStep2_zbozi,
            "app-new-campaign-Step2_ownAppi": newCampaignStep2_ownAppi,
            "app-new-campaign-Step3": newCampaignStep3,
            "app-new-campaign-Step4": newCampaignStep4,

            "app-settings-heureka": SettingsHeureka,
            "app-settings-zbozi": SettingsZbozi,
            "app-settings-visits": SettingsVisits,
            "app-settings-orders": SettingsOrders,
            "app-settings-registrations": SettingsRegistrations,
            "app-settings-statistics": SettingsStatistics,
            "app-settings-ownAppi": SettingsOwnAppi,

        },
        mounted: function () {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            if (Vue.cookie.get('EditCampaignID') != 'null' && Vue.cookie.get('EditCampaignID') != undefined) {

                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_campaigns",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (dataCampaigns) {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        if (campaign.campaignID == Vue.cookie.get('EditCampaignID')) {
                            that.$store.state.CampaignData = campaign;
                            that.SelectedMessages = campaign.SelectedMessages;
                            that.$store.state.SelectedMessages = campaign.SelectedMessages.SelectedMessages;

                        }
                    });
                });
            
            }
        },
        data() {
            return {
                authUser: Vue.cookie.get('logged') || false,
                userUid: "none",
                userEmail: null,
                selectedCampaignName: null,
                selectedComponents: "app-new-campaign-Step1"
            }
        },
        methods: {
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                        window.location.pathname = '/PixelInstallation';
                    });
            },
        },

        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
         },

        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;

            if (Vue.cookie.get('EditCampaignID') != 'null') {
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_campaigns",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid})
                }).done(function (dataCampaigns) {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        if (campaign.campaignID == Vue.cookie.get('EditCampaignID')) {
                            that.selectedCampaignName = campaign.CampaignName;
                            that.$store.state.CampaignName = campaign.CampaignName;
                            that.$store.state.CampaignData = campaign;
                        }
                    });
                });
         
            } else {
                that.$store.state.CampaignData = [];
            }

            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/check_pixel",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid  })
            }).done(function (checkPixel) {
                if (!checkPixel.pixelExist) {
                    that.showAlert("Nejdříve si nainstalujte PIXEL");
                }
            });


            if (that.userUid != "none" || Vue.cookie.get('EditCampaignID') != 'null') {
                $(document).ready(function () {
                    $('.visits_content').simplerSidebar({
                        selectors: {
                            trigger: "#visits_button",
                            quitter: ".close",
                        },
                        sidebar: {
                            width: 700
                        },
                    });

                    $('.statistics_content').simplerSidebar({
                        selectors: {
                            trigger: "#statistics_button",
                            quitter: ".close",
                        },
                        sidebar: {
                            width: 700
                        },
                    });

                    $('.orders_content').simplerSidebar({
                        selectors: {
                            trigger: "#orders_button",
                            quitter: ".close",
                        },
                        sidebar: {
                            width: 700
                        },
                    });

                    $('.registrations_content').simplerSidebar({
                        selectors: {
                            trigger: "#registrations_button",
                            quitter: ".close",
                        },
                        sidebar: {
                            width: 700
                        },
                    });

                    $('.heureka_content').simplerSidebar({
                        selectors: {
                            trigger: "#heureka_button",
                            quitter: ".close",
                        },
                        sidebar: {
                            width: 700
                        },
                    });

                    $('.zbozi_content').simplerSidebar({
                        selectors: {
                            trigger: "#zbozi_button",
                            quitter: ".close",
                        },
                        sidebar: {
                            width: 700
                        },
                    });

                    $('.ownAppi_content').simplerSidebar({
                        selectors: {
                            trigger: "#ownAppi_button",
                            quitter: ".close",
                        },
                        sidebar: {
                            width: 700
                        },
                    });
                });
            }
		}
	}


</script>

<style lang="css">
    /*.new_campaign_container
    {
        background-color: red !important;
    }*/
</style>