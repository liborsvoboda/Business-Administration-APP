<template>
    <div class="zbozi_content panel_right">
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
                <p class="under_title">Zobrazí recenze produktů a/nebo hodnocení obchodu ze Zboží.cz.</p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="title_sidebar_set_new_campaign pl-5 pr-5 pb-3 pt-3">
                    Aktivujte jednu nebo více druhů notifikací
                </div>
            </div>
        </div>
        <div class="col-md-12 pl-5 py-3 form_inline_set">
            <div>Vyberte variantu</div>&nbsp;&nbsp;
            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                <label class="btn btn btn-outline-primary mycolor" :class="{active: (SelectedZboziVariant == 'shop' || SelectedZboziVariant == '')}" v-on:click="SelectedZboziVariant = 'shop'">
                    <input type="radio" name="options" autocomplete="off" :checked="SelectedZboziVariant == 'shop' || SelectedZboziVariant == '' "> Hodnocení obchodu
                </label>
                <label class="btn btn btn-outline-primary mycolor" :class="{active: SelectedZboziVariant == 'product'}" v-on:click="SelectedZboziVariant = 'product'">
                    <input type="radio" name="options" autocomplete="off" :checked="SelectedZboziVariant == 'product'"> Recenze produktů
                </label>
            </div>
           
        </div>
        <div class="col-md-12 pl-5 py-3 form_inline_set">
            <div class="pr-3">
                Notifikace je aktivní
            </div>
            <div class="noselect" v-if="SelectedZboziVariant=='shop'">
                <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                <button type="button" class="btn btn-toggle" :class="{active: ZboziShopActive}" v-on:click="ZboziShopActive = !ZboziShopActive" data-toggle="button" aria-pressed="false" autocomplete="off">
                    <div class="handle"></div>
                </button>
                &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
            </div>
            <div class="noselect" v-if="SelectedZboziVariant=='product'">
                <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                <button type="button" class="btn btn-toggle" :class="{active: ZboziProductActive}" v-on:click="ZboziProductActive = !ZboziProductActive" data-toggle="button" aria-pressed="false" autocomplete="off">
                    <div class="handle"></div>
                </button>
                &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="notifikace">
                    <img v-if="SelectedZboziVariant=='shop'" src="/images/notifikace/zbozi.png" class="notifikace_img" title="Recenze a hodnocení" alt="Recenze a hodnocení" />
                    <img v-if="SelectedZboziVariant=='product'" src="/images/notifikace/zbozi_produkt.png" class="notifikace_img" title="Recenze a hodnocení" alt="Recenze a hodnocení" />
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
                <div class="btn-group btn-group-toggle" data-toggle="buttons" v-if="SelectedZboziVariant=='shop'">
                    <label class="btn btn btn-outline-primary mycolor " :class="{active: ShowZboziShopFromLastDays == 1}" v-on:click="ShowZboziShopFromLastDays = 1">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziShopFromLastDays == 1"> 24 hod.
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowZboziShopFromLastDays == 7}" v-on:click="ShowZboziShopFromLastDays = 7">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziShopFromLastDays == 7"> 7 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowZboziShopFromLastDays == 30}" v-on:click="ShowZboziShopFromLastDays = 30">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziShopFromLastDays == 30"> 30 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowZboziShopFromLastDays == 90}" v-on:click="ShowZboziShopFromLastDays = 90">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziShopFromLastDays == 90"> 90 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: (ShowZboziShopFromLastDays == 365 || ShowZboziShopFromLastDays == '')}" v-on:click="ShowZboziShopFromLastDays = 365">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziShopFromLastDays == 365 || ShowZboziShopFromLastDays == ''"> 1 rok
                    </label>
                </div>
                <div class="btn-group btn-group-toggle" data-toggle="buttons" v-if="SelectedZboziVariant=='product'">
                    <label class="btn btn btn-outline-primary mycolor " :class="{active: ShowZboziProductFromLastDays == 1}" v-on:click="ShowZboziProductFromLastDays = 1">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziProductFromLastDays == 1"> 24 hod.
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowZboziProductFromLastDays == 7}" v-on:click="ShowZboziProductFromLastDays = 7">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziProductFromLastDays == 7"> 7 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowZboziProductFromLastDays == 30}" v-on:click="ShowZboziProductFromLastDays = 30">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziProductFromLastDays == 30"> 30 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: ShowZboziProductFromLastDays == 90}" v-on:click="ShowZboziProductFromLastDays = 90">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziProductFromLastDays == 90"> 90 dní
                    </label>
                    <label class="btn btn btn-outline-primary mycolor" :class="{active: (ShowZboziProductFromLastDays == 365 || ShowZboziProductFromLastDays == '')}" v-on:click="ShowZboziProductFromLastDays = 365">
                        <input type="radio" name="options" autocomplete="off" :checked="ShowZboziProductFromLastDays == 365 || ShowZboziProductFromLastDays == ''"> 1 rok
                    </label>
                </div>
            </div>

            <div class="col-md-12 py-3 form_inline_set" v-if="SelectedZboziVariant=='product'">
                <div>Zobrazí recenze stejné a vyšší než</div>&nbsp;&nbsp;<input type="text" placeholder="4" v-model="ShowZboziStarsHigherThan" v-on:input="validateFields()" v-validate="{numeric:true, min_value:1, max_value: 5}" name="ShowZboziStarsHigherThan" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowZboziStarsHigherThan') }" />&nbsp;&nbsp;<div>hvězdičky</div>
            </div>

            <div class="col-md-12 py-3 form_inline_set" v-if="SelectedZboziVariant=='shop'">
                <div>
                    Zobrazí se pokud jsou dostupné minimálně
                </div>&nbsp;&nbsp;<input type="text" placeholder="3" v-model="ShowWhenExistMinZboziShop" v-on:input="validateFields()" v-validate="{numeric:true, min_value:1, max_value: 100000}" name="ShowWhenExistMinZboziShop" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowWhenExistMinZboziShop') }" />&nbsp;&nbsp;
                <div>
                    hodnocení
                    <i style="color:royalblue" class="fa fa-question-circle pointer"
                       v-tooltip.top="{ content: 'Pro zobrazování dostatečného množství hodnocení zohledněte zvolené časové rozmezí.\nNapř. za posledních 30 dní máte tři hodnocení obchodu a zvolíte zobrazování od 5 hodnocení, pak se tato notifikace nebude zobrazovat.' }"></i>
                </div>
            </div>

            <div class="col-md-12 py-3 form_inline_set" v-if="SelectedZboziVariant=='product'">
                <div>
                    Zobrazí se pokud jsou dostupné minimálně
                </div>&nbsp;&nbsp;<input type="text" placeholder="3" v-model="ShowWhenExistMinZboziProduct" v-on:input="validateFields()" v-validate="{numeric:true, min_value:1, max_value: 100000}" name="ShowWhenExistMinZboziProduct" class="form-control form_control_set_width" :class="{ 'is-invalid': errors.has('ShowWhenExistMinZboziProduct') }" />&nbsp;&nbsp;
                <div>
                    recenze produktů
                    <i style="color:royalblue" class="fa fa-question-circle pointer"
                       v-tooltip.top="{ content: 'Pro zobrazování dostatečného množství hodnocení zohledněte zvolené časové rozmezí a počet hvězdiček.\nNapř. za posledních 7 dní máte dvě recenze produktu s 5* a zvolíte zobrazování od 3 recenzí, pak se notifikace nebudou zobrazovat.' }"></i>
                </div>
            </div>
            
            <div class="col-md-12 py-3">
                <div class="d-flex flex-row justify-content-between align-items-center">
                    <div>
                        Neustálé opakování notifikací
                        <i style="color:royalblue" class="fa fa-question-circle pointer"
                           v-tooltip.top="{ content: 'Vypnutím zastavíte opakované zobrazování recenzí.\nKaždá recenze se zobrazí jen jednou.' }"></i>
                    </div>
                    <div class="noselect" v-if="SelectedZboziVariant=='shop'">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: CycleShowingShop}" v-on:click="CycleShowingShop = !CycleShowingShop" data-toggle="button" aria-pressed="false" autocomplete="off">
                            <div class="handle"></div>
                        </button>
                        &nbsp;&nbsp;<span class="toogle_desc">ANO</span>
                    </div>
                    <div class="noselect" v-if="SelectedZboziVariant=='product'">
                        <span class="toogle_desc">NE</span>&nbsp;&nbsp;
                        <button type="button" class="btn btn-toggle" :class="{active: CycleShowingProduct}" v-on:click="CycleShowingProduct = !CycleShowingProduct" data-toggle="button" aria-pressed="false" autocomplete="off">
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
                adminAccess: false,
                userUid: "none",
                userEmail: null,
                ShowZboziShopFromLastDays: 365,
                ShowZboziProductFromLastDays: 365,
                ShowZboziStarsHigherThan: "",
                ShowWhenExistMinZboziShop: "",
                ShowWhenExistMinZboziProduct:"",
                SelectedZboziVariant: "shop",
                ZboziShopActive: true,
                ZboziProductActive: false,
                CycleShowingShop: true,
                CycleShowingProduct: true,
                SaveAllowed: true,
           }
        },
        computed: mapState({
            state: state => state.Zbozi
        }),
        methods: {
            validateFields: function () {
                this.errors.clear();
                var that = this;

                this.$validator.validateAll({
                    ShowZboziStarsHigherThan: this.ShowZboziStarsHigherThan,
                    ShowWhenExistMinZboziShop: this.ShowWhenExistMinZboziShop,
                    ShowWhenExistMinZboziProduct: this.ShowWhenExistMinZboziProduct
                }).then((valid) => {
                    if (valid) {
                        this.SaveAllowed = true;

                        if (isNaN(this.ShowZboziStarsHigherThan)) {
                            that.errors.add({ field: 'ShowZboziStarsHigherThan', msg: 'Zadejte hodnotu v rozmezí 1-5' });
                            that.SaveAllowed = false;
                        } else {
                            if ((this.ShowZboziStarsHigherThan < 1 || this.ShowZboziStarsHigherThan > 5) && this.ShowZboziStarsHigherThan.length > 0) {
                                that.errors.add({ field: 'ShowZboziStarsHigherThan', msg: 'Zadejte hodnotu v rozmezí 1-5' });
                                that.SaveAllowed = false;
                            }
                        }
                    } else { this.SaveAllowed = false; }
                })
            },
           Save() {
             

               if (this.ShowZboziStarsHigherThan) {
                   this.state.ShowZboziStarsHigherThan = this.ShowZboziStarsHigherThan;
                }
                else {
                   this.state.ShowZboziStarsHigherThan = this.$store.getters.ZBOZI_ShowZboziStarsHigherThan;
               }
               
               this.state.ZboziShopActive = this.ZboziShopActive;
               this.state.ZboziProductActive = this.ZboziProductActive;
               this.state.ShowZboziShopFromLastDays = this.ShowZboziShopFromLastDays;
               this.state.ShowZboziProductFromLastDays = this.ShowZboziProductFromLastDays;
               this.state.CycleShowingShop = this.CycleShowingShop;
               this.state.CycleShowingProduct = this.CycleShowingProduct;
               this.state.ShowWhenExistMinZboziShop = this.ShowWhenExistMinZboziShop;
               this.state.ShowWhenExistMinZboziProduct = this.ShowWhenExistMinZboziProduct;
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
        created() {
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            if (Vue.cookie.get('EditCampaignID') != 'null' && Vue.cookie.get('EditCampaignID') != undefined) {
                var selectedCampaignID = Vue.cookie.get('EditCampaignID');
                this.GetCampaignData().then(dataCampaigns => {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        if (campaign.campaignID == selectedCampaignID) {
                            that.ShowZboziShopFromLastDays = campaign.Zbozi.ShowZboziShopFromLastDays;
                            that.ShowZboziProductFromLastDays = campaign.Zbozi.ShowZboziProductFromLastDays;
                            that.ShowZboziStarsHigherThan = campaign.Zbozi.ShowZboziStarsHigherThan;
                            that.ShowWhenExistMinZboziShop = campaign.Zbozi.ShowWhenExistMinZboziShop;
                            that.ShowWhenExistMinZboziProduct = campaign.Zbozi.ShowWhenExistMinZboziProduct;
                            that.CycleShowingShop = campaign.Zbozi.CycleShowingShop;
                            that.CycleShowingProduct = campaign.Zbozi.CycleShowingProduct;
                            that.ZboziShopActive = campaign.Zbozi.ZboziShopActive;
                            that.ZboziProductActive = campaign.Zbozi.ZboziProductActive;

                            that.$store.state.Zbozi = campaign.Zbozi;
                        }
                    })
                })
            }
		}

    }

</script>