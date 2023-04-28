<template>
	<span v-show="loadingFinished">
		<span class="fas fa-exclamation-circle alert_pixel" v-if="!heurekaKeyExist"></span>
		<span class="fas fa-check-circle alert_campaign" v-else-if="heurekaKeyExist"></span>
	</span>
</template>

<script>
    import VeeValidate from 'vee-validate';
    import Vue from 'vue';
    import VueCookie from 'vue-cookie';

    Vue.use(VueCookie);

    export default {
        data() {
            return {
                userUid: "none",
                userEmail: null,
                heurekaKeyExist: false,
                loadingFinished: false,
            }
        },

        methods: {
            fn_reloadCredit() {
                this.userUid = this.$store.state.AdminModule.adminUserKey;
                var that = this;
                that.heurekaKeyExist = false;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/get_user_heureka",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (apiKeys) {
                    if (apiKeys.result === 1) {
                        that.heurekaKeyExist = apiKeys.Finished;
                    }
                })
            }
        },

		beforeCreate(){
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
            this.userUid = this.$store.state.AdminModule.adminUserKey;
            var that = this;
            that.heurekaKeyExist = false;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/get_user_heureka",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (apiKeys) {
                if (apiKeys.result === 1) {
                    that.heurekaKeyExist = apiKeys.Finished;
                }
                that.loadingFinished = true;
            })
        }
    }
</script>