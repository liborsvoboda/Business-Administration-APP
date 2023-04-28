<template>
    <div class="heureka_content panel_right">
        <div class="row pl-5 pr-5">
            <div class="col-md-12 pb-2 pt-2">
                <button ref="closeBtn" type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="col-md-12">
                <h1 class="panel_right_h1">Recenze a hodnocení</h1>
            </div>
            <div class="col-md-12 pb-2">
                <p class="under_title">Zobrazí recenze a kladná hodnocení ze serveru Heureka CZ / SK.</p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="notifikace">
                    <img v-bind:src="imgSource" class="notifikace_img" title="Recenze a hodnocení" alt="Recenze a hodnocení" />
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3">
                <div style="font-size:30px">DETAILNÍ NASTAVENÍ</div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Pravidla zobrazování notifikací
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5">
            <div class="col-md-12 py-3 form_inline_set">
                <div>Zobrazí recenze za posledních</div>&nbsp;&nbsp;
                <div class="btn-group btn-group-toggle" data-toggle="buttons">
                    <label class="btn btn btn-outline-primary mycolor " :class="{active: ShowRevFromLastDays == 1}" v-on:click="ShowRevFromLastDays = 1">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowRevFromLastDays == 1"> 24 hod.
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowRevFromLastDays == 7}" v-on:click="ShowRevFromLastDays = 7">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowRevFromLastDays == 7"> 7 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: (ShowRevFromLastDays == 30 || ShowRevFromLastDays == '')}" v-on:click="ShowRevFromLastDays = 30">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowRevFromLastDays == 30 || ShowRevFromLastDays == ''"> 30 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowRevFromLastDays == 90}" v-on:click="ShowRevFromLastDays = 90">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowRevFromLastDays == 90"> 90 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowRevFromLastDays == 365}" v-on:click="ShowRevFromLastDays = 365">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowRevFromLastDays == 365"> od začátku
                    </label>
                </div>
            </div>
            <div class="col-md-12 py-3 form_inline_set">
                <div>Zobrazí recenze stejné a vyšší než</div>&nbsp;&nbsp;<input type="text" placeholder="4" v-model="ShowRevStarsHigherThan" v-on:input="validateFields()" v-validate="{numeric:true, min_value:1, max_value: 5}" name="showeviewWithStarsAndMore" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('showeviewWithStarsAndMore') }" />&nbsp;&nbsp;<div>hvězdičky</div>
            </div>

            <div class="col-md-12 py-3 form_inline_set">
                <div>
                    Zobrazí se pokud jsou dostupné minimálně
                </div>&nbsp;&nbsp;<input type="text" placeholder="3" v-model="ShowWhenExistMinRev" v-on:input="validateFields()" v-validate="{numeric:true, min_value:1, max_value: 100000}" name="showWhenMinimalReviewExists" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('showWhenMinimalReviewExists') }" />&nbsp;&nbsp;
                <div>
                    recenze
                    <i style="color:royalblue" class="fa fa-question-circle pointer"
                       v-tooltip.top="{ content: 'Pro zobrazování dostatečného množství recenzí, zohledněte zvolené časové rozmezí a počet hvězdiček.\n Např. za posledních 7 dní máte dvě hodnocení s 5* a zvolíte zobrazování 3 recenzí, pak se notifikace nebudou zobrazovat' }"></i>
                </div>
            </div>
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Neustálé opakování notifikací
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Vypnutím zastavíte opakované zobrazování recenzí.\nKaždá recenze se zobrazí jen jednou.' }"></i>
                    </div>
                    <div class="noselect">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: CycleShowing}" v-on:click="CycleShowing = !CycleShowing" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                </div>
            </div>
        </div>
        <div class="row pl-5 pr-5 pb-5">
            <div class="col-md-12 border-top pt-3">
                <button class="btn btn-outline-secondary btn_new" :disabled="!SaveAllowed" v-on:click="Save">Uložit</button>
            </div>
        </div>

    </div>
</template>

<script>
    //import { mapGetters } from "vuex";
    import { mapState } from 'vuex';
 	import Vue from 'vue';
	import VueCookie from 'vue-cookie';
	import SlimDialog from 'v-slim-dialog';
    import VeeValidate from 'vee-validate';
    import VueI18n from 'vue-i18n';
    import axios from 'axios';

    import cs from "vee-validate/dist/locale/cs";
    import en from "vee-validate/dist/locale/en";

    import Tooltip from 'vue-directive-tooltip';
    Vue.use(Tooltip); 
  
    Vue.use(SlimDialog);
    Vue.use(VueCookie);
    Vue.use(VueI18n);

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
                selectedLanguage: this.$store.state.selectedLanguage,

                adminAccess: false,
                userUid: "none",
                userEmail: null,
                ShowRevFromLastDays: "",
                ShowRevStarsHigherThan: "",
                ShowWhenExistMinRev: "",
                CycleShowing: true,
                SaveAllowed: true,
                imgSource:"/images/notifikace/review.png"
           }
        },
        computed: mapState({
            state: state => state.Heureka
        }),
        methods: {
            validateFields: function () {
                this.$validator.validateAll().then((valid) => {
                    if (valid) {
                        this.SaveAllowed = true;
                    } else { this.SaveAllowed = false; }
                })
            },
           Save() {
               if (this.ShowRevFromLastDays) {
                   this.state.ShowRevFromLastDays = this.ShowRevFromLastDays;
                }
                else {
                   this.state.ShowRevFromLastDays = this.$store.getters.HEUREKA_ShowRevFromLastDays;
                }

               if (this.ShowRevStarsHigherThan) {
                   this.state.ShowRevStarsHigherThan = this.ShowRevStarsHigherThan;
                }
                else {
                   this.state.ShowRevStarsHigherThan = this.$store.getters.HEUREKA_ShowRevStarsHigherThan;
                }

               if (this.ShowWhenExistMinRev) {
                   this.state.ShowWhenExistMinRev = this.ShowWhenExistMinRev;
                }
                else {
                   this.state.ShowWhenExistMinRev = this.$store.getters.HEUREKA_ShowWhenExistMinRev;
                }

               if (this.CycleShowing) {
                   this.state.CycleShowing = this.CycleShowing;
                }
                else {
                   this.state.CycleShowing = this.$store.getters.HEUREKA_CycleShowing;
                }
				this.$refs.closeBtn.click();//this.showAlert("Saved");
            },
			showAlert(val) {
				const options = {title: 'Info', size: 'sm'}
				this.$dialogs.alert(val, options)
					.then(res => {
				});
            },
            GetCampaignData() {
                return new Promise((resolve, reject) => {
                    return axios.post('https://appi.app.cz:444/get_campaigns', {
                        session: Vue.cookie.get('session'),
                        uuid: this.userUid
                    }).then((dataCampaigns) => {
                        resolve(dataCampaigns.data);
                    }).catch((error) => {
                        //console.log(error);
                        reject(error)
                    })
                });
            }
        },
        watch: {
            '$store.state.selectedLanguage': function () {
                this.selectedLanguage = this.$store.state.selectedLanguage;
                switch (this.selectedLanguage) {
                    case "cs":
                        this.imgSource = "/images/notifikace/review.png";
                        break;
                    case "sk":
                        this.imgSource = "/images/notifikace/reviewsk.png";
                        break;
                    case "en":
                        this.imgSource = "/images/notifikace/reviewen.png";
                        break;
                    default:
                        this.imgSource = "/images/notifikace/review.png";
                }
            }
        },
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            if (Vue.cookie.get('EditCampaignID') != 'null' && Vue.cookie.get('EditCampaignID') != undefined) {
                var selectedCampaignID = Vue.cookie.get('EditCampaignID');
                this.GetCampaignData().then(dataCampaigns => {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        if (campaign.campaignID == selectedCampaignID) {
                            that.ShowRevFromLastDays = campaign.Heureka.ShowRevFromLastDays;
                            that.ShowRevStarsHigherThan = campaign.Heureka.ShowRevStarsHigherThan;
                            that.ShowWhenExistMinRev = campaign.Heureka.ShowWhenExistMinRev;
                            that.CycleShowing = campaign.Heureka.CycleShowing;

                            that.$store.state.Heureka = campaign.Heureka;
                        }
                    })
                })
            }
		}

    }

</script>