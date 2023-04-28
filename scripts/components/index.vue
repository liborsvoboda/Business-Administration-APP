<template>
    <div class="container" v-show="authUser=='true'">
        <div class="row justify-content-center">
            <div class="col-lg-6 col-xl-6">
                <div class="mb-3 py-4 py-lg-5 text-center">
                    <h1 style="font-size: 50px;">
                        <!--{{ $t('welcome') }}-->
                        <span class="h1_bold">Vítejte v app.cz</span>
                        <div class="panel_subTitle_h1">
                            Projděte si průvodce, který vám pomůže s orientací v aplikaci a nastavením první kampaně.
                        </div>
                    </h1>
                </div>
                <div class="list-group shadow-sm">
                    <div class="list-group-item group_item_blue bold" style="padding-left:1.5rem;">Rychlý začátek</div>
                    <!--<button class="list-group-item d-flex justify-content-between align-items-center list-group-item-action list_group_button" style="padding-left:1.5rem;" id="finish_profil_but">
                        <span class="fas fa-check-circle check_home_screen" v-bind:class="{ 'check-green': ProfileFinished }"></span>
                        <div class="mr-auto">Dokončete váš profil</div>
                        <span class="">
                            <span class="fas fa-angle-right"></span>
                        </span>
                    </button>
                    <button class="list-group-item d-flex justify-content-between align-items-center list-group-item-action list_group_button" style="padding-left:1.5rem;" id="meet_team_but">
                        <span class="fas fa-check-circle check_home_screen" v-bind:class="{ 'check-green': TeamFinished }"></span>
                        <div class="mr-auto">
                            Poznejte náš tým
                        </div>
                        <span class="">
                            <span class="fas fa-angle-right"></span>
                        </span>
                    </button>-->
                    <button class="list-group-item d-flex justify-content-between align-items-center list-group-item-action list_group_button" style="padding-left:1.5rem;" id="install_pixel_but">
                        <span class="fas fa-check-circle check_home_screen" v-bind:class="{ 'check-green': PixelInstallationFinished }"></span>
                        <div class="mr-auto">
                            Nainstalujte si Pixel
                        </div>
                        <span class="">
                            <span class="fas fa-angle-right"></span>
                        </span>
                    </button>
                    <button class="list-group-item d-flex justify-content-between align-items-center list-group-item-action list_group_button" style="padding-left:1.5rem;" id="heureka_key_but">
                        <span class="fas fa-check-circle check_home_screen" v-bind:class="{ 'check-green': HeurekaFinished }"></span>
                        <div class="mr-auto">
                            Vložte API klíč Heuréka CZ/SK anebo Zboží.cz
                        </div>
                        <span class="">
                            <span class="fas fa-angle-right"></span>
                        </span>
                    </button>
                    <button class="list-group-item d-flex justify-content-between align-items-center list-group-item-action list_group_button" style="padding-left:1.5rem;" id="launch_campaign_but">
                        <span class="fas fa-check-circle check_home_screen" v-bind:class="{ 'check-green': CampaignExist }"></span>
                        <div class="mr-auto">
                            Vytvořte první kampaň
                        </div>
                        <span class="">
                            <span class="fas fa-angle-right"></span>
                        </span>
                    </button>
                    <button class="list-group-item d-flex justify-content-between align-items-center list-group-item-action list_group_button" style="padding-left:1.5rem;" id="help_center_but">
                        <span class="fas fa-check-circle check_home_screen" v-bind:class="{ 'check-green': HelpFinished }"></span>
                        <div class="mr-auto">
                            Navštivte naše centrum nápovědy
                        </div>
                        <span class="">
                            <span class="fas fa-angle-right"></span>
                        </span>
                    </button>
                </div>
                <!--panely-->
                <app-index-profile v-on:changesFinished="ProfileFinished = $event"></app-index-profile>
                <app-index-team v-on:changesFinished="TeamFinished = $event"></app-index-team>
                <app-index-pixel v-on:changesFinished="PixelInstallationFinished = $event"></app-index-pixel>
                <app-index-heureka v-on:changesFinished="HeurekaFinished = $event"></app-index-heureka>
                <app-index-campaign v-on:campaingExist="CampaignExist = $event"></app-index-campaign>
                <app-index-help v-on:changesFinished="HelpFinished = $event"></app-index-help>

            </div>
        </div>
    </div>
</template>

<script>

    import IndexProfile from "./index-profile.vue";
    import IndexTeam from "./index-team.vue";
    import IndexHelp from "./index-help.vue";
    import IndexPixel from "./index-pixel.vue";
    import IndexHeureka from "./index-heureka.vue";
    import IndexCampaign from "./index-campaign.vue";
    import Vue from 'vue';
    import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';
 
    Vue.use(VueI18n);
    Vue.use(VueCookie);

 	export default {
	components: {
	"app-index-profile": IndexProfile,
	"app-index-team": IndexTeam,
	"app-index-help": IndexHelp,
	"app-index-pixel": IndexPixel,
	"app-index-heureka": IndexHeureka,
	"app-index-campaign": IndexCampaign
	},
	data() {
	return {
        ProfileFinished: false,
        TeamFinished: false,
        PixelInstallationFinished: false,
        HelpFinished: false,
        HeurekaFinished: false,
        CampaignExist: false,
        authUser: Vue.cookie.get('logged') || false,
    	};
	},
        methods: {
        },
        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
        },

	    created() {
            Vue.cookie.set('EditCampaignID', null, 1);
	    }
    }
</script>

<style lang="scss" scoped>
</style>