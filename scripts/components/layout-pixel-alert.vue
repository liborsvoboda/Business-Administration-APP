<template>
    <span v-show="loadingFinished">
        <span class="fas fa-exclamation-circle alert_pixel" v-if="!PixelExist"></span>
        <span class="fas fa-check-circle alert_campaign" v-else-if="PixelExist"></span>
    </span>
</template>

<script>
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);

    export default {
        data() {
            return {
                userUid: "none",
                userEmail: null,
                PixelExist: false,
                loadingFinished: false,
            }
        },
        methods: {
            fn_reloadCredit() {
                this.userUid = this.$store.state.AdminModule.adminUserKey;
                var that = this;
                that.PixelExist = false;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/check_pixel",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (checkPixel) {
                    that.PixelExist = checkPixel.pixelExist;
                    that.loadingFinished = true;
                });
            }
        },
        computed: {
            checkadminUserKey() {
                return this.$store.state.AdminModule.adminUserKey;
            },
        },
        watch: {
            checkadminUserKey(value) {
                this.fn_reloadCredit();
            },
        },
        beforeCreate() {
        },
        created() {
            var that = this;
            that.PixelExist = false;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/check_pixel",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (checkPixel) {
                that.PixelExist = checkPixel.pixelExist;
                that.loadingFinished = true;
            });
        }
    }
</script>