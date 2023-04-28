<template>
    <span v-show="loadingFinished">
        <span class="fas fa-exclamation-circle alert_pixel" v-if="!campaignExist"></span>
        <span class="fas fa-check-circle alert_campaign" v-else-if="campaignExist"></span>
        <!--<span class="mycolor" v-else-if="campaignExist">{{active}} / {{exist}}</span>-->
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
                campaignExist: false,
				active : 0,
                exist: 0,
                loadingFinished: false,
            }
        },

        methods: {
            fn_reloadCredit() {
                this.campaignExist = false;
                this.userUid = this.$store.state.AdminModule.adminUserKey;
                var that = this;
                that.active = 0;
                that.exist = 0;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_campaigns",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (dataCampaigns) {
                    if (dataCampaigns.campaigns.length > 0) {
                        dataCampaigns.campaigns.forEach(function (campaign) {
                            if (campaign.ActiveCampaign) { that.active++; }
                            that.exist++;
                        });
                        that.campaignExist = true;
                    }
                });
            }
        },

        beforeCreate() {
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
        created() {
            var that = this;
            that.campaignExist = false;
            that.active = 0;
            that.exist = 0;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_campaigns",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (dataCampaigns) {
                if (dataCampaigns.campaigns.length > 0) {
                    dataCampaigns.campaigns.forEach(function (campaign) {
                        if (campaign.ActiveCampaign) { that.active++; }
                        that.exist++;
                    });
                    that.campaignExist = true;
                }
                that.loadingFinished = true;
            });
        }
    }
</script>