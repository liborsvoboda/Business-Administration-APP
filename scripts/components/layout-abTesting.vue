<template>
    <span v-if="abTestingAllowed">
        <a href="/AbTesting" class="btn btn-primary btn_nav_other" v-if="abTestingAllowed">
            <span class="fas fa-chart-pie"></span> A/B testy
            <span v-show="loadingFinished">
                <!--<span class="fas pl-3 fa-exclamation-circle alert_pixel" v-if="!abTestExist"></span>-->
                <span class="fas pl-3 fa-check-circle alert_campaign" v-if="abTestExist"></span>
            </span>
        </a>
        <hr v-show="abTestingAllowed" />
    </span>
</template>

<script>
    import Vue from 'vue';
    import VueI18n from 'vue-i18n';
    import VueCookie from 'vue-cookie';

    Vue.use(VueI18n);
    Vue.use(VueCookie);

	export default {
		data () {
            return {
                userUid: "none",
                abTestingAllowed: false,
                abTestExist: false,
                loadingFinished: false,
			}
        },
        methods: {
            fn_reloadCredit() {
                this.userUid = this.$store.state.AdminModule.adminUserKey;
                var that = this;
                that.abTestExist = false;
                $.ajax({
                    type: "POST",
                    url: "https://appi.app.cz:444/getAbTests",
                    dataType: "json",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
                }).done(function (abtestings) {
                    if (abtestings.abtesting != undefined) {
                        that.abTestExist = (abtestings.abtesting.length > 0) ? true : false;
                    }
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
            var that = this;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/auth_status",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session') })
            }).done(function (data) {
                if (data.result === 1) {
                    if (data.abTestingAllowed) {
                        that.abTestingAllowed = true;
                    } else {
                        that.abTestingAllowed = false;
                    }
                } else {
                    that.abTestingAllowed = false;
                }
            });
            that.abTestExist = false;
            $.ajax({
                type: "POST",
                url: "https://appi.app.cz:444/getAbTests",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ session: Vue.cookie.get('session'), uuid: that.userUid })
            }).done(function (abtestings) {
                if (abtestings.abtesting != undefined) {
                    that.abTestExist = (abtestings.abtesting.length > 0) ? true : false;
                }
                that.loadingFinished = true;
            })
        },
        created() {
            this.authUser = Vue.cookie.get('logged') || false;
        }
	}
</script>
