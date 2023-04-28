<template>
    <div class="help_center_content panel_right">
        <div class="row pl-5 pr-5">
            <div class="col-md-12 pb-4 pt-3">
                <button ref="closeBtn" type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="col-md-12 text-center pt-2 pb-2">
                <h1 class="panel_right_h2">Centrum nápovědy app.cz</h1>
            </div>
            <div class="col-md-12 py-2 text-center">
                <p class="under_title" style="margin-bottom:0px;">Bez nápovědy není žádný web kompletní.</p>
                <p class="under_title">Tady máte malou ochutnávku té naší :-)</p>
            </div>
            <div class="col-md-12">
                <p class="bold">Nejčastější otázky jak rychle a snadno začít</p>
                <p><span class="far fa-question-circle mycolor"></span><a href="https://napoveda.app.cz/navody/1-nainstalujte-kod-pixelu/?utm_source=app.app.cz&utm_medium=zaciname-napoveda&utm_campaign=zaciname-pixel" target="_blank" class="mycolor">Jak nainstalovat pixel?</a></p>
                <p><span class="far fa-question-circle mycolor"></span><a href="https://napoveda.app.cz/navody/2-heureka-api-klic/?utm_source=app.app.cz&utm_medium=zaciname-napoveda&utm_campaign=zaciname-heureka" target="_blank" class="mycolor">Jak nastavit API Heuréka?</a></p>
                <p><span class="far fa-question-circle mycolor"></span><a href="https://napoveda.app.cz/navody/2-zbozi-api-klic/?utm_source=app.app.cz&utm_medium=zaciname-napoveda&utm_campaign=zaciname-zbozi" target="_blank" class="mycolor">Jak nastavit API Zboží.cz?</a></p>
                <p><span class="far fa-question-circle mycolor"></span><a href="https://napoveda.app.cz/navody/3-spustte-prvni-kampan/?utm_source=app.app.cz&utm_medium=zaciname-napoveda&utm_campaign=zaciname-kampan" target="_blank" class="mycolor">Jak vytvořit první kampaň?</a></p>
            </div>

            <div class="col-md-12">
                <hr />
            </div>

            <div class="col-md-12">
                <p class="bold">Nejčastější otázky k app</p>
                <p><span class="far fa-question-circle mycolor"></span><a href="https://app.cz/faq/?utm_source=app.app.cz&utm_medium=zaciname&utm_campaign=zaciname-faq" target="_blank" class="mycolor">Co se stane po 14 dnech zdarma?</a></p>
                <p><span class="far fa-question-circle mycolor"></span><a href="https://app.cz/faq/?utm_source=app.app.cz&utm_medium=zaciname&utm_campaign=zaciname-faq" target="_blank" class="mycolor">Jak vybrat vhodný tarif?</a></p>
                <p><span class="far fa-question-circle mycolor"></span><a href="https://app.cz/faq/?utm_source=app.app.cz&utm_medium=zaciname&utm_campaign=zaciname-faq" target="_blank" class="mycolor">Jaké jsou typy notifikací?</a></p>
            </div>

            <div class="col-md-12 pt-4 text-center pb-5">
                <a href="https://napoveda.app.cz/?utm_source=app.app.cz&utm_medium=zaciname-napoveda&utm_campaign=zaciname-napoveda" target="_blank" class="btn btn-main-primary btn_new mr-2" style=" margin-bottom: 10px;">Přejít do nápovědy</a>
                <button class="btn btn-outline-secondary" style=" margin-bottom: 10px;" @click="update">Dokončit krok</button>
            </div>
        </div>
    </div>
</template>


<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';
    import SlimDialog from 'v-slim-dialog';

    Vue.use(SlimDialog);
    Vue.use(VueCookie);

    export default {
        data() {
            return {
                StepHelp: {
                    Finished: false
                },
            }
        },
        methods: {
            update() {
                var that = this;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/update_help",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), Finished: true })
                }).done(function (updateHelp) {
                    if (updateHelp.result == 1) {
                        $.ajax({
                            type: "POST",
                            url: "https://appi.app.cz:444/get_help",
                            dataType: "json",
                            contentType: 'application/json; charset=utf-8',
                            data: JSON.stringify({ session: Vue.cookie.get('session') })
                        }).done(function (dataHelp) {
                            that.StepHelp.Finished = dataHelp.Finished;
                            that.$emit("changesFinished", that.StepHelp.Finished);
                            that.$refs.closeBtn.click();
                        })
                    }
                })
            },
            showAlert(val) {
                const options = { title: 'Info', size: 'sm' }
                this.$dialogs.alert(val, options)
                    .then(res => {
                    });
            },
        },
        created() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_help",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (dataHelp) {
                that.StepHelp.Finished = dataHelp.Finished;
                that.$emit("changesFinished", that.StepHelp.Finished);
            })
        }
    }
</script>