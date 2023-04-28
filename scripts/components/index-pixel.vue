<template>
    <div class="install_pixel_content panel_right">
        <div class="row pl-5 pr-5">
            <div class="col-md-12 pb-4 pt-3">
                <button type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="col-md-12 text-center pt-2 pb-2">
                <h1 class="panel_right_h2">Nainstalujte si Pixel</h1>
            </div>
            <div class="col-md-12 py-2 text-center">
                <p class="under_title">Toto je klíčový krok, aby vše běželo hladce. Nainstalováním pixelu (<strong>umístěním krátkého kódu do hlavičky vašeho webu</strong>) povolíte odesílat a sbírat data a zobrazovat je návštěvníkům vašeho webu.</p>
            </div>

            <div class="col-md-12 py-3 pixel_sending text-center" v-if="!PixelInstallation">
                Váš Pixel zatím neodesílá žádná data
            </div>
            <div class="pixel_sending pixel_sending_OK  col-md-12 py-3 text-center" v-else>
                Zachytili jsme první data na vašem webu
             </div>

            <div class="col-md-12 pt-4 text-center pb-5">
                <a href="/PixelInstallation" class="btn btn-main-primary btn_new mr-2" style=" margin-bottom: 10px;">Instalace Pixelu</a>
                <a href="https://napoveda.app.cz/navody/1-nainstalujte-kod-pixelu/?utm_source=app.app.cz&utm_medium=zaciname-pixel&utm_campaign=zaciname-pixel" target="_blank" class="btn btn-outline-secondary" style=" margin-bottom: 10px;">Přečíst nápovědu</a>
            </div>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);

    export default {
        data() {
            return {
                PixelInstallation: false
            }
        },
        methods: {
        },
        created() {
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/check_pixel",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (checkPixel) {
                that.PixelInstallation = checkPixel.pixelExist;
                that.$emit("changesFinished", checkPixel.pixelExist);
            });
        }
    }
    
</script>