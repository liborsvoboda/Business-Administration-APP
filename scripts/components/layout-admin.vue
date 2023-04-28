<template>
    <a href="/AdminClientList" class="btn btn-primary btn_nav_other" v-if="adminAccount">
        <span class="fa fa-clipboard-list"></span> Přehled Klientů
        <span class="fas fa-key" style="margin-left: 30px;opacity: 1;" v-show="adminUserKey != null" v-bind:title=adminUserEmail  v-bind:alt=adminUserEmail ></span>
    </a>
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
                adminAccount: false,
                adminUserKey: this.$store.state.AdminModule.adminUserKey,
                adminUserEmail: this.$store.state.AdminModule.adminUserEmail
			}
        },
        computed: {
            checkadminUserKey() {
                return this.$store.state.AdminModule.adminUserKey;
            },
            checkadminUserEmail() {
                return this.$store.state.AdminModule.adminUserEmail;
            }
        },
        watch: {
            checkadminUserKey(value) {
                this.adminUserKey = value;
            },
            checkadminUserEmail(value) {
                this.adminUserEmail = value;
            }
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
                    if (data.isAdmin) {
                        that.adminAccount = true;
                    } else {
                        that.adminAccount = false;
                    }
                } else {
                    that.adminAccount = false;
                }
            });
        },
        created() {
            this.authUser = Vue.cookie.get('logged') || false;
            this.adminUserKey = this.$store.state.AdminModule.adminUserKey;
            this.adminUserEmail = this.$store.state.AdminModule.adminUserEmail;
        }
	}
</script>
