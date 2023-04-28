<template>
    <div class="container" v-show="authUser=='true'">
        <div class="row justify-content-center">

            <div class="col-lg-11 col-xl-9 pt-5" v-if="PixelInstallation">

                <!--<div class="d-flex flex-row justify-content-between align-items-center my-3">
                    <div>
                        <input type="text" class="form-control py-2" placeholder="Napište co chcete hledat" v-model="fn_FilteredList" />
                    </div>
                </div>-->

                <div class="list-group shadow-sm">
                    <p class="list-group-item group_item_blue bold width_100">Zachycené domény</p>
                    <div v-for="url in DomainList" v-if="url[0].toLowerCase().indexOf(fn_FilteredList.toLowerCase()) > -1" class="list-group-item d-flex justify-content-between align-items-center list-group-item-action ">
                        <span class="margin-desc">{{url[0]}}</span>
                        <span class="margin-desc" style="color:#90a4ae;width:290px">Poslední aktivita: {{url[1]}}</span>
                    </div>
                </div>

            </div>

            <div class="col-lg-11 col-xl-9">

                <br />
                <div class="list-group mt-2 ">
                    <div class="list-group-item text-center shadow-sm">
                        <!-- list-group-item -->
                        <div class=" text-center">
                            <h2 class="py-3 list_group_button" title="Klikněte pro zobrazení postupu instalace" alt="Klikněte pro zobrazení postupu instalace">
                                Instalace Pixelu
                                <!--<span class="">
                                    <span class="fas fa-angle-right" v-if="!showInstallDesc"></span>
                                    <span class="fas fa-angle-down" v-if="showInstallDesc"></span>
                                </span>-->
                            </h2>
                            <!--<p>
                                Následujte instrukce níže nebo <a class="mycolor" href="https://napoveda.app.cz/navody/1-nainstalujte-kod-pixelu/?utm_source=app.app.cz&utm_medium=menu&utm_campaign=menu-pixel" target="_blank"> navštivte centrum nápovědy </a>.
                            </p>
                            <p>
                                Pokud používáte platformy třetích stran (WordPress, ShopTet, atd.)
                                <a class="mycolor" href="https://napoveda.app.cz/knowledgebase_category/propojeni/?utm_source=app.app.cz&utm_medium=menu&utm_campaign=menu-pixel" target="_blank">jak je propojit najdete zde</a>
                            </p>-->
                        </div>
                    </div>
                <!--</div>
                <span>-->


                    <!--<div class="list-group mt-2 ">-->
                        <div class="list-group-item pl-5 pr-5">
                            <p class="bold" style="padding-top: 15px;">1. Vložte kód Pixelu na váš web</p>
                            <p>
                                Zkopírujte celý odkaz kódu Pixelu a vložte ho do hlavičky celého webu (před tag "</ head>"), na kterém chcete sbírat data a zobrazovat notifikace.
                                <br />Pokud se vám o web stará programátor, pošlete mu odkaz na <a class="mycolor" href="https://napoveda.app.cz/knowledgebase_category/propojeni/?utm_source=app.app.cz&utm_medium=menu&utm_campaign=menu-pixel" target="_blank"> nápovědu s umístěním kódu Pixelu</a>
                            </p>
                            <!--<p><strong>TIP:</strong> Doporučujeme kód Pixelu vložit do hlavičky celého webu.</p>-->
                        <!--</div>
                        <div class="list-group-item">-->
                            <p class="bold" style="padding-top: 10px;">Zkopírujte odpovídající kód Pixelu pro HTTP nebo HTTPS.</p>
                            <div style="display: flex;padding-bottom: inherit;">

                                <span class="align-middle" style="display: flex;padding: 0px 10px 0px 0px;">
                                    <button class="btn btn-outline-secondary btn_new" @click="copyToClipboard('#copyhttps')">Zkopírovat kód HTTPS</button>
                                </span>
                                <span>
                                    <div class="pixel p-3 pb-3">
                                        <code id="copyhttps" style="background-color: transparent;">&lt;script charset="UTF-8" async src='https://app.app.cz/js/app.min.js?id={{ this.userUid }}'&gt;&lt;/script&gt;</code>
                                    </div>
                                </span>
                            </div>
                            <p></p>
                            <div style="display: flex;padding-bottom: inherit;">
                                <span>
                                    <div class="pixel p-3 pb-3">
                                        <code id="copyhttp" style="background-color: transparent;">&lt;script charset="UTF-8" async src='http://app.app.cz/js/app.min.js?id={{ this.userUid }}'&gt;&lt;/script&gt;</code>
                                    </div>
                                </span>
                                <span class="align-middle" style="display: flex;padding: 0px 0px 0px 10px;">
                                    <button class="btn btn-outline-secondary btn_new" @click="copyToClipboard('#copyhttp')">Zkopírovat kód HTTP</button>
                                </span>
                            </div>
                        </div>
                        <div class="list-group-item pl-5 pr-5">
                            <div class="pixel_sending p-3 mt-3 text-center" v-if="!PixelInstallation">
                                Váš Pixel zatím neodesílá žádná data
                            </div>
                            <div class="pixel_sending pixel_sending_OK  p-3 mt-3 text-center" v-else>
                                Zachytili jsme první data na vašem webu
                            </div>
                            <p></p>
                        </div>

                    <!--</div>-->
   
                    <!--<div class="list-group mt-2 ">-->
                        <div class="list-group-item pl-5 pr-5">
                            <p class="bold" style="padding-top: 15px;">2. Aktivujte Pixel na vašem webu</p>
                            <p>Pixel se aktivuje první návštěvou jakékoliv vaší stránky, kde je kód nainstalovaný. Pokud je kód Pixelu vložený správně, objeví se zde status “Zachytili jsme první data na vašem webu” a zároveň se web zobrazí v přehledu zachycených domén (viz výše). </p>
                            <!--<p>Tak se běžte podívat na váš web :-)</p>-->
                        </div>
                        <div class="list-group-item pl-5 pr-5">
                            <p class="bold" style="padding-top: 15px;">3. Stále Pixel neodesílá žádná data?</p>
                            <p>
                                Nejste si jisti, že jste nainstalovali kód Pixelu správně? <a class="mycolor" href="https://napoveda.app.cz/knowledgebase_category/propojeni/?utm_source=app.app.cz&utm_medium=menu&utm_campaign=menu-pixel" target="_blank"> Poraďte se s naší nápovědou </a> nebo nám napište na <a class="mycolor" href="mailto:podpora@app.cz?subject=Pixel_neodesílá_data"> podpora@app.cz </a> a my vám rádi pomůžeme.
                            </p>
                        </div>
                    <!--</div>-->
                </div>
                <!--</span>-->
            </div>
        </div>
    </div>
     
</template>
<script>

    const parseUrl = require("parse-url");
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);
  
    export default {
        data() {
            return {
                CustomerUrlList: [],
                DomainList:[],
                Campaigns: [],
                filteredList: [],
                ActiveCampaigns: [],
                fn_FilteredList: "",
                PixelInstallation: false,
                //showInstallDesc: true,
                //firstOpen: false,
                userUid: "none",
                userEmail: null,
                authUser: Vue.cookie.get('logged') || false,
            }
        },
        methods: {
 
            copyToClipboard(element) {
                var $temp = $("<input>");
                $("body").append($temp);
                $temp.val($(element).text()).select();
                document.execCommand("copy");
                $temp.remove();
            }

        },
        beforeCreate() {
            this.authUser = Vue.cookie.get('logged') || false;
        },


        watch: {
        },

        created() {
            Vue.cookie.set('EditCampaignID', null, 1);
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_domains",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid})
            }).done(function (dataDomains) {
                if (dataDomains.domains != undefined && dataDomains.domains.length > 0) {
                    dataDomains.domains.forEach(function (domain) {
                        if (that.DomainList.indexOf(domain.domain) === -1 && domain.domain != "" && domain.domain.indexOf('file://') == -1 && domain.domain.indexOf('content://') == -1 && domain.domain.indexOf('about:blank') == -1 ) {
                            var record = [domain.domain, new Date(domain.timestamp * 1000).toLocaleDateString("cs-CZ").replace(/\s+/g, '') + ' v ' + new Date(domain.timestamp *1000).toLocaleTimeString("cs-CZ")];
                            that.DomainList.push(record);
                        }
                    });
                    if (that.DomainList.length > 0) {
                        that.PixelInstallation = true;

                        //if (!that.firstOpen) {
                        //    that.showInstallDesc = false;
                        //    that.firstOpen = true;
                        //}
                        that.$emit("changesFinished", true);
                    }
                }
            });
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_user_profile",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (dataProfile) {
                if (dataProfile.result === 1) {
                    that.userUid = dataProfile.uuid;
                }
            })
          
        }
    }

</script>
